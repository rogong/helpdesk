using CallogApp.Data;
using CallogApp.Models;
using CallogApp.Utility.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize] 
    public class UserRequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRequestController(ApplicationDbContext context, IEmailService emailService, 
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _emailService = emailService;
            _userManager = userManager;
        }

        // GET: Admin/Requests
        public IActionResult Index()
        {
          
            return View();
        }

        // GET: Admin/Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.Issue)
            
                .Include(r => r.Status)
                .Include(r => r.ITStaff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Admin/Requests/Create
        public async Task<IActionResult> Create()
        {
            var userEmail = User.Identity.Name;
            var user = await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Email == userEmail);

            if(user == null)
            {
                return NotFound();
            }

            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name");
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name");

            ViewBag.DateCreated = DateTime.Now;
            ViewBag.UpdatedAt = DateTime.Now;
            ViewBag.ResponseDate = null;
            ViewBag.RespondedDate = null;
            ViewBag.ResolvedDate = null;
            ViewBag.ReasonForHigh = null;
            ViewBag.LevelId = 3;
            ViewBag.UserId = User.Identity.Name;
            ViewBag.ITStaffId = 7;
            ViewBag.StatusId = 1;
            ViewBag.isCancel = false;
            ViewBag.DepartmentId = user.DepartmentId;
            TempData["Message"] = "Request sent successfully";
            return View();
        }

        // POST: Admin/Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusId,LevelId,isCancel,UserId,DateCreated,ResponseDate,RespondedDate," +
            "ResolvedDate,DepartmentId,IssueId,DeviceId,Subject,Message,ITStaffId,DepartmentOwner,ReasonForHigh")] Request request, string returnUrl = null)
        {

            // Admin
            var ITEmail = "it@superfluxnigeria.com";
            var adminMessage = 
                $"The message from HelpDesk, new request was received.{Environment.NewLine}" +
                $"Subject: {request.Subject} {Environment.NewLine}" +
                $"Description: {request.Message} {Environment.NewLine}";

            //User S
            var userEmail = User.Identity.Name;
            var subject = "Request Received";
            var message = $"Your request " + $" ''" + $"{request.Subject}" + $"''" + " was received, we will get back to you shortly";

            returnUrl = returnUrl ?? Url.Content("~/");


            if (ModelState.IsValid)
            {
                try
                {
                    if(request.IssueId == 15)
                    {
                        request.LevelId = 1;
                    }


                    _context.Add(request);
                    await _context.SaveChangesAsync();
                    //user
                    //SendMail.send(message, userEmail, subject);
                    //IT
                    SendMail.send(adminMessage + " " + $"{this.Request.Scheme}://{this.Request.Host}/Admin/Requests/Details/{request.Id}", ITEmail, subject);


                    return RedirectToAction(nameof(Success));
            }
            catch (Exception ex)
            {

            }
        }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
           
          
          
            return View(request);
        }

        // GET: Admin/Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userEmail = User.Identity.Name;
            var user = await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name");
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name");
            ViewBag.DateCreated = DateTime.Now;
            ViewBag.UpdatedAt = DateTime.Now;
            ViewBag.ResponseDate = null;
            ViewBag.RespondedDate = null;
            ViewBag.ResolvedDate = null;
            ViewBag.UserId = User.Identity.Name;
            ViewBag.ITStaffId = 7;
            ViewBag.LevelId = 1;
           
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
            ViewBag.DepartmentId = user.DepartmentId;
            TempData["Message"] = "Request sent successfully";
            return View(request);
        }

        // POST: Admin/Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusId,Status,UserId,isCancel,LevelId,DateCreated,DepartmentId,IssueId,DeviceId,RequestTypeId,Subject,Message,ITStaffId")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    request.StatusId = 1;
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
            ViewData["LevelId"] = new SelectList(_context.Issues, "Id", "Name", request.LevelId);
 
            return View(request);
        }

        // GET: Admin/Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.Issue)
           
                .Include(r => r.Status)
                .Include(r => r.ITStaff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Admin/Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }

        public IActionResult Success()
        {
            return View();
        }


        public IActionResult PendingRequest()
        {
            return View();
        }
    }
}
