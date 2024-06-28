using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Inventory_Management_System.Models.Class;

public class RequestsController : Controller
{
    private readonly Context _context;

    public RequestsController(Context context)
    {
        _context = context;
    }

    public RequestsController()
    {
        _context = new Context();
    }

    // GET: Requests/Create
    public ActionResult Create()
    {
        Random rnd = new Random();
        string[] character = { "A", "B", "C", "D", "E", "F", "G", "H" };
        int k1, k2, k3;
        k1 = rnd.Next(0, character.Length);
        k2 = rnd.Next(0, character.Length);
        k3 = rnd.Next(0, character.Length);
        int s1, s2, s3;
        s1 = rnd.Next(100, 100);
        s2 = rnd.Next(10, 99);
        s3 = rnd.Next(10, 99);
        string kod = s1.ToString() + character[k1] + s2 + character[k2] + s3 + character[k3];
        ViewBag.serialnumber = kod;

        return View();
    }

    // POST: Requests/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Request request, string[] approvers)
    {
        if (ModelState.IsValid && approvers != null)
        {
            request.RequestDate = DateTime.Now;
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            // Save approvers to database
            foreach (var approver in approvers)
            {
                _context.Approvals.Add(new Approval
                {
                    RequestId = request.Id,
                    ApproverEmail = approver,
                    IsApproved = false,
                });
            }
            await _context.SaveChangesAsync();

            // Send approval email to the first approver
            await SendApprovalEmailAsync(approvers[0], request.Id);

            return RedirectToAction("PendingDemands");
        }
        return View(request);
    }

    // GET: Requests/Approve/{requestId}
    public ActionResult Approve(int requestId)
    {
        var request = _context.Requests.Find(requestId);
        if (request == null)
        {
            return HttpNotFound();
        }

        ViewBag.Message = TempData["Message"] as string;

        return View(request);
    }

    // GET: Requests/ApproveRequest
    [HttpGet]
    public async Task<ActionResult> ApproveRequest(int requestId, bool isApproved)
    {
        var request = await _context.Requests.FindAsync(requestId);
        if (request == null)
        {
            return HttpNotFound();
        }

        // Check if the approval has already been processed
        var approval = await _context.Approvals.FirstOrDefaultAsync(a => a.RequestId == requestId && !a.IsApproved);
        if (approval != null && approval.ApprovalDate == null)
        {
            approval.IsApproved = isApproved;
            approval.ApprovalDate = DateTime.Now;
            await _context.SaveChangesAsync();

            // If the request is rejected, notify the requester immediately
            if (!isApproved)
            {
                await SendApprovalStatusEmailAsync("kadir.demirkaya@bbnairlines.com.tr", request, false);
                TempData["Message"] = "FORMUNUZ REDDEDİLMİŞTİR.";
                return RedirectToAction("PendingDemands", new { requestId = request.Id });
            }

            // Find the next approver
            var nextApprover = await _context.Approvals
                .Where(a => a.RequestId == requestId && !a.IsApproved)
                .OrderBy(a => a.Id)
                .FirstOrDefaultAsync();

            if (nextApprover != null)
            {
                await SendApprovalEmailAsync(nextApprover.ApproverEmail, requestId);
                // Only send "Süreç Devam Ediyor" email if there's a next approver
                await SendApprovalStatusEmailAsync("kadir.demirkaya@bbnairlines.com.tr", request, null);
            }
            else
            {
                // If all approvals are done, update request's IsApproved status
                request.IsApproved = true;
                await _context.SaveChangesAsync();

                // Notify requestor that the request has been approved
                await SendApprovalStatusEmailAsync("kadir.demirkaya@bbnairlines.com.tr", request, true);
                TempData["Message"] = "FORMUNUZ ONAYLANMIŞTIR.";
            }
        }

        return RedirectToAction("PendingDemands", new { requestId = request.Id });
    }

    // Mail sending methods
    private async Task SendApprovalEmailAsync(string userEmail, int requestId)
    {
        var subject = "Talebinizi Onaylayın";
        var approveUrl = Url.Action("ApproveRequest", "Requests", new { requestId = requestId, isApproved = true }, Request.Url.Scheme);
        var rejectUrl = Url.Action("ApproveRequest", "Requests", new { requestId = requestId, isApproved = false }, Request.Url.Scheme);
        var requestUrl = Url.Action("ApproveDetail", "Requests", new { id = requestId }, Request.Url.Scheme);
        //var approveUrl = $"http://10.51.151.12/BBN/Requests/ApproveRequest?requestId={requestId}&isApproved=true";
        //var rejectUrl = $"http://10.51.151.12/BBN/Requests/ApproveRequest?requestId={requestId}&isApproved=false";
        //var requestUrl = $"http://10.51.151.12/BBN/Requests/ApproveDetail?id={requestId}";

        var body = $@"
    <div style='font-family: Arial, sans-serif;'>
        Personel Talep formu oluşturulmuştur . Formu onaylamak için link üzerinden giriş yapıp talebi onaylayabilirsiniz.<br/><br /><br />
        Talebinizi onaylamak için lütfen aşağıdaki butonları kullanın:<br /><br />
        <div style='display: flex; justify-content: space-between;'>
            <a href='{approveUrl}' style='padding: 10px 15px; background-color: white; color: black; text-decoration: none; border: 2px solid green; border-radius: 5px; display: inline-block;'>
                <span style='margin-right: 5px; color: green;'>&#10003;</span>Kabul Et
            </a>
            <a href='{rejectUrl}' style='padding: 10px 15px; background-color: white; color: black; text-decoration: none; border: 2px solid red; border-radius: 5px; display: inline-block;'>
                <span style='margin-right: 5px; color: red;'>&#10007;</span>Reddet
            </a>
        </div>
        <br /><br />
        Talep detayları için <a href='{requestUrl}' style='color: blue; text-decoration: underline;'>buraya</a> tıklayın.
    </div>
";
        await SendEmailAsync(userEmail, subject, body);
    }

    private async Task SendApprovalStatusEmailAsync(string to, Request request, bool? isApproved)
    {
        string subject;
        string body;

        if (isApproved == null)
        {
            subject = "Süreç Devam Ediyor";
            body = $"Talebiniz şu anda onay sürecinde.\n\nTalep ID: {request.Id}";
        }
        else if (isApproved == true)
        {
            subject = "Talebiniz Onaylandı";
            body = $"Talebiniz başarı ile onaylanmıştır.\n\nTalep ID: {request.Id}";
        }
        else
        {
            subject = "Talebiniz Reddedildi";
            body = $"Talebiniz reddedilmiştir.\n\nTalep ID: {request.Id}";
        }

        await SendEmailAsync(to, subject, body);
    }

    private async Task SendEmailAsync(string to, string subject, string body)
    {
        if (string.IsNullOrEmpty(to))
        {
            throw new Exception("Recipient email is missing");
        }
        var mailSender = new SendMail();
        await mailSender.SendEmailAsync(to, subject, body);
    }

    public ActionResult PendingDemands()
    {
        var values = _context.Requests.ToList();
        return View(values);
    }

    public ActionResult ApproveDetail(int id)
    {
        var dpt = _context.Requests.Find(id);
        if (dpt == null)
        {
            return HttpNotFound();
        }
        return View("ApproveDetail", dpt);
    }
}
