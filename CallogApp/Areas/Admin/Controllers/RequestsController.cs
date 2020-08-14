using CallogApp.Data;
using CallogApp.Models;
using CallogApp.Utility;
using CallogApp.Utility.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminUser + "," + SD.AdminUser)]
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _hostingEnv;


        public RequestsController(IWebHostEnvironment env, ApplicationDbContext context)
        {
            _context = context;
            _hostingEnv = env;
        }

        // GET: Admin/Requests
        public  IActionResult Index()
        {
            
            return View();
        }


        public IActionResult MyAssignedTask()
        {
            return View();
        }

        // GET: Admin/Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = $"Request with Id = {id} cannot be found";
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
                ViewBag.ErrorMessage = $"Request with Id = {id} cannot be found";
                return NotFound();
            }

            return View(request);
        }

        // GET: Admin/Requests/Create
        public async Task<IActionResult> Create()
        {
            var userEmail = User.Identity.Name;
            var user = await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound();
            }

            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name");
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name");

            ViewBag.DateCreated = DateTime.Now;
            ViewBag.UpdatedAt = DateTime.Now;
            ViewBag.ResponseDate = "";
            ViewBag.RespondedDate = null;
            ViewBag.ResolvedDate = "";
            ViewBag.DateResolved = null;
            ViewBag.ReasonForHigh = "";
            ViewBag.LevelId = 3;
            ViewBag.UserId = User.Identity.Name;
            ViewBag.ITStaffId = 7;
            ViewBag.StatusId = 1;
            ViewBag.isCancel = false;
            ViewBag.step = 0;
            //ViewBag.OtherDevice = null;
            //ViewBag.OtherIssue = null;
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
            "OtherIssue,OtherDevice,ResolvedDate,DepartmentId,IssueId,DeviceId,Subject,Message,ITStaffId,DepartmentOwner,ReasonForHigh,DateResolved,step,PhotoUrl")] 
          Request request, IFormFile file, string returnUrl = null)
        {

            // Admin
            var ITEmail = "it@superfluxnigeria.com";
            var departmemt = await _context.Departments.FindAsync(request.DepartmentId);
            var status = await _context.Departments.FindAsync(request.StatusId);

            //User S
            var userEmail = User.Identity.Name;
            var subject = "Request Received";
            var message = $"Your request " + $" ''" + $"{request.Subject}" + $"''" + " was received, we will get back to you shortly";

            returnUrl = returnUrl ?? Url.Content("~/");

            if (request.DeviceId == 1)
            {
                ViewBag.reasonMessage = "Select a valid device";
                // ModelState.AddModelError("progressMessage", "You must change the status");

                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                return View(request);


            }
            if (request.IssueId == 1)
            {
                ViewBag.reasonMessage = "Select a valid category";
                // ModelState.AddModelError("progressMessage", "You must change the status");

                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                return View(request);


            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (request.IssueId == 15)
                    {
                        request.LevelId = 1;
                    }

                    //Upload data
                    if (file != null)
                    {
                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), _hostingEnv.WebRootPath, "uploads", fileName);
                        //var stream = new FileStream(path, FileMode.Create);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var WebUrl = $"{this.Request.Scheme}://{this.Request.Host}/uploads/";

                        request.PhotoUrl = WebUrl + fileName;
                    }

                    _context.Add(request);
                    await _context.SaveChangesAsync();
                    //user
                 SendMail.send(message, userEmail, subject);
                    //IT
                  
                    //  Decalre variable
                    var adminMessage =
                $"<img src='http://superfluxnigeria.com/images/logo.png' />" +
                $"<h4 style='background:pink'>Support Ticket with Id number {request.Id}{request.Status}{Environment.NewLine} was created</h4>" +
               
                $"Subject: {request.Subject} {Environment.NewLine}<br />" +
                $"User: {request.UserId} {Environment.NewLine}<br />" +
                $"Department: {departmemt.Name} {Environment.NewLine}<br />" +
                $"Description: {request.Message} {Environment.NewLine}";
               SendMail.send(adminMessage + " " + $"{this.Request.Scheme}://{this.Request.Host}/Admin/Requests/Details/{request.Id}", ITEmail, subject);
                    return RedirectToAction(nameof(Success));
                }
                catch (Exception ex)
                {
                    ViewBag.progressMessage2 = $"Mail could not be sent,Check your network connection." +
                          "Check your dashboard before sending another request because your request might have been sent.";
                    return View(request);
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
                ViewBag.ErrorMessage = $"Request with Id = {id} cannot be found";
                return NotFound();
            }

            var request = await _context.Requests
                             .Include(r => r.Department)
                             .Include(r => r.Device)
                             .Include(r => r.Issue)
                             .FirstOrDefaultAsync(m => m.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            ViewBag.Department = request.Department.Name;
            ViewBag.Device = request.Device.Name;
            ViewBag.Issue = request.Issue.Name;
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);

            return View(request);
        }

        // POST: Admin/Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusId,LevelId,UserId,DateCreated,DepartmentId,RespondedDate,ResponseDate,ResolvedDate,ResponseInterval,ResolutionInterval,IssueId,DeviceId,Subject,Message,ITStaffId,ResolvedBy,Resolution,ReasonForHigh,step,OtherIssue,OtherDevice,PhotoUrl")] Request request)
        {

            var ITEmail = "it@superfluxnigeria.com";
            //User
            var userEmail = request.UserId;
            var subject = "Request Update From IT HelpDesk";

            var message = $"Your request has been assigned to an ITStaff to resolve. " +
                $"Subject: {request.Subject} {Environment.NewLine}" +
                $"Description: {request.Message} {Environment.NewLine}";

            var resolveMessage = $"The request with subject" + $" ''" + $"{request.Subject}" + $"''" + "has been resolved.";

            var adminMessage =
               $"The message from HelpDesk, new request was received.{Environment.NewLine}" +
               $"Subject: {request.Subject} {Environment.NewLine}" +
               $"Description: {request.Message} {Environment.NewLine}";

            if (id != request.Id)
            {
                ViewBag.ErrorMessage = $"Request with Id = {id} cannot be found";
                return View("NotFound");
            }

            

            if (ModelState.IsValid)
            {

                //request.step = Convert.ToInt32(request.step);

                var staffId = request.ITStaffId;

                if (request.ITStaffId != 7 && request.step == 0)
                {
                    request.step = 1;
                    _context.Update(request);

                    await _context.SaveChangesAsync();


                    if (User.IsInRole(SD.SuperAdminUser))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("MyAssignedTask", "Requests", new { Area = "Admin" });
                    }

                }
                else if (request.ITStaffId == 7 && request.step == 0)
                {

                    ViewBag.reasonMessage = "You must assign task to a person!";

                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);
                }           

                else if (request.LevelId == 1 && request.ReasonForHigh == null && request.ITStaffId != 7 && request.step == 1)
                {
                    ViewBag.reasonMessage = "You must give the reason";
                    
                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);


                }



                else if (request.LevelId != 1 && request.ReasonForHigh == null && request.StatusId == 1 && request.step == 1)
                {
                    ViewBag.reasonMessage = "Choose a the right status";
                   
                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);


                }

                else if (request.LevelId == 1 && request.StatusId == 1 && request.ReasonForHigh != null && request.ITStaffId != 7 && request.step == 1)
                {
                    ViewBag.progressMessage = "You must change the status";
                   
                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);


                }

                else if (request.step == 2 && request.StatusId != 1 && request.ResolvedBy == null)
                {
                    ViewBag.reasonMessage = "Resolved by is required!";

                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);


                }
                else if (request.step == 2 && request.StatusId != 1 && request.Resolution == null)
                {
                    ViewBag.reasonMessage = "Resolution is required!";

                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);


                }

                else if (request.step == 2 && request.StatusId != 3)
                {
                    ViewBag.reasonMessage = "Choose the right status(Resolved)";

                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);


                }

                else
                {
                    request.step = 2;
                }

                try
                {


                    if (request.LevelId == 1 && request.ReasonForHigh == null && request.ITStaffId != 7 && request.step == 1)
                    {
                        ViewBag.reasonMessage = "Your must give the reason";

                        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                        ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                        ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                        ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                        ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                        ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                        return View(request);


                    }
                    else
                    {
                        if (request.LevelId == 1 && request.ReasonForHigh != null)
                        {

                            SendMail.send(request.ReasonForHigh, userEmail, subject);

                            request.step = 2;
                            _context.Update(request);

                            await _context.SaveChangesAsync();

                        }
                       
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.progressMessage = $"Mail could not be sent,Check your network connection." +
                        "Check your dashboard before sending another request because your request might have been sent.";
                    return View();
                }


                //if (request.RespondedDate == null && request.StatusId == 2)
                if (request.ResponseInterval == null && request.StatusId == 2)
                    {
                                     
                        request.RespondedDate = DateTime.Now.ToString();

                        TimeSpan responseTime = Convert.ToDateTime(request.RespondedDate) - request.DateCreated;

                       
                       TimeSpan sestT = new TimeSpan(responseTime.Hours, responseTime.Minutes, responseTime.Milliseconds);
                       TimeSpan sestTInterval = new TimeSpan(responseTime.Days, responseTime.Hours, responseTime.Minutes, responseTime.Milliseconds);

                    request.ResponseDate = sestT;
                    var interval = sestTInterval.ToString();
                    request.ResponseInterval = interval;

                    try
                    {                     
                            SendMail.send(message, userEmail, subject);
                                   
                    }
                    catch (Exception ex)
                    {
                       
                    }

                 }
                //Check resolution, status id
                    if (request.StatusId == 3 && (request.ResolutionInterval == null || request.ResolutionInterval == null ))
                    {

                        TimeSpan resolvedTime = Convert.ToDateTime(DateTime.Now.ToString()) - request.DateCreated;

                        TimeSpan sestT = new TimeSpan(resolvedTime.Hours, resolvedTime.Minutes, resolvedTime.Milliseconds);
                        TimeSpan sestInterval = new TimeSpan(resolvedTime.Days, resolvedTime.Hours, resolvedTime.Minutes, resolvedTime.Milliseconds);

                         request.ResolvedDate = sestT;

                      /// Interval 
                        var interval = sestInterval.ToString();

                    request.ResolutionInterval = interval;
                        request.DateResolved = Convert.ToString(DateTime.Now);
                    try
                    {
                        //Send mail to User                     
                        SendMail.send(resolveMessage, ITEmail, subject);

                    }
                    catch (Exception ex)
                    {
                        ViewBag.progressMessage2 = $"Mail could not be sent,Check your network connection." +
                          "Check your dashboard before sending another request because your request might have been sent.";
                        return View();
                    }
                    

                }


                    _context.Update(request);

                    await _context.SaveChangesAsync();

               
                
                // check the role
                if(User.IsInRole(SD.SuperAdminUser))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("MyAssignedTask", "Requests", new { Area = "Admin" });
                }
            }
        
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
            return View(request);
        }

        // GET: Admin/Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = $"Request with Id = {id} cannot be found";
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

        // Pending view
        public IActionResult PendingRequest()
        {
            return View();
        }

        //Success View
        public IActionResult Success()
        {
            return View();
        }

     
    }
}
