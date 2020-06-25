using CallogApp.Data;
using CallogApp.Models;
using CallogApp.Utility;
using CallogApp.Utility.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminUser + "," + SD.AdminUser)]
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestsController(ApplicationDbContext context)
        {
            _context = context;
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
           
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name");
            ViewBag.DateCreated = DateTime.Now;
            ViewBag.UpdatedAt = DateTime.Now;
            ViewBag.ResponseDate = null;
            ViewBag.LevelId = 3;
            ViewBag.UserId = User.Identity.Name;
            ViewBag.DepartmentId = user.DepartmentId;
            TempData["Message"] = "Request sent successfully";
            return View();
        }

        // POST: Admin/Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusId,LevelId,UserId,DateCreated,UpdatedAt,ResponseDate,DepartmentId,IssueId,DeviceId,Subject,Message,ResolvedBy,Resolution,ITStaffId")] Request request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(request);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
            
         
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
            
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusId,LevelId,UserId,DateCreated,DepartmentId,RespondedDate,ResponseDate,ResolvedDate,IssueId,DeviceId,Subject,Message,ITStaffId,ResolvedBy,Resolution,ReasonForHigh")] Request request)
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
               
                var staffId = request.ITStaffId;

                if (request.LevelId == 1 && request.StatusId == 1  && request.ReasonForHigh == null)
                {
                    ViewBag.reasonMessage = "Your must give the reason";
                    // ModelState.AddModelError("progressMessage", "You must change the status");
                   
                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);


                }

               

                else if (request.LevelId == 1 && request.StatusId == 1 && request.ReasonForHigh != null )
                {
                    ViewBag.progressMessage = "You must change the status and assign";
                    // ModelState.AddModelError("progressMessage", "You must change the status");
                 
                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                    return View(request);


                }
                //else if (request.LevelId == 1 && request.StatusId != 1 && request.ReasonForHigh != null)
                //{
                //    ViewBag.progressMessage = "You must change the status";
                //    // ModelState.AddModelError("progressMessage", "You must change the status");

                //    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
                //    ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
                //    ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name", request.ITStaffId);
                //    ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
                //    ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
                //    ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
                //    return View(request);


                //}



                try
                {
                    if (request.LevelId == 1 && request.ReasonForHigh != "")
                    {

                        SendMail.send(request.ReasonForHigh, userEmail, subject);


                    }
                    if(request.LevelId == 1 && request.ReasonForHigh == "")
                    {
                        ModelState.AddModelError("progressMessage", "Resason must not be empty.");

                        return RedirectToAction(nameof(Edit));

                    }
                }
                catch (Exception ex)
                {

                }


                if (request.RespondedDate == null && request.StatusId == 2)
                 {
                                     
                        request.RespondedDate = DateTime.Now.ToString();

                        TimeSpan responseTime = Convert.ToDateTime(request.RespondedDate) - request.DateCreated;

                    TimeSpan sestT = new TimeSpan(responseTime.Hours, responseTime.Minutes, responseTime.Milliseconds);


                        request.ResponseDate = sestT;
                    try
                    {                     
                            SendMail.send(message, userEmail, subject);
                                   
                    }
                    catch (Exception ex)
                    {
                       
                    }

                 }

                    if (request.StatusId == 3 && (request.ResolvedDate == null || request.ResolvedDate == TimeSpan.Parse("00:00:00") ))
                    {

                        TimeSpan resolvedTime = Convert.ToDateTime(DateTime.Now.ToString()) - request.DateCreated;

                            TimeSpan sestT = new TimeSpan(resolvedTime.Hours, resolvedTime.Minutes, resolvedTime.Milliseconds);
                    request.ResolvedDate = sestT;
                    try
                    {
                        //User                     
                        SendMail.send(resolveMessage, ITEmail, subject);

                    }
                    catch (Exception ex)
                    {

                    }
                    

                }


                    _context.Update(request);

                    await _context.SaveChangesAsync();

               
                

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

        public IActionResult PendingRequest()
        {
            return View();
        }
    }
}
