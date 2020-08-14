using CallogApp.Data;
using CallogApp.Models;
using CallogApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.User.Controllers
{

    [Area("User")]
    [Authorize(Roles = SD.AdminUser)]

    public class UserRequestEditCommentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserRequestEditCommentController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

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
            ViewBag.Level = request.Level.Name;
            ViewBag.Status = request.Status.Name;
            ViewBag.ITStaff = request.ITStaff.Name;
            ViewBag.Resolution = request.Resolution;
            ViewBag.ReasonForHigh = request.ReasonForHigh;
            ViewBag.DateCreated = request.DateCreated;
          

            return View(request);
        }

        // POST: Admin/Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusId,LevelId,UserId,DateCreated,DepartmentId,RespondedDate,ResponseDate,ResolvedDate,IssueId,DeviceId,Subject,Message,ITStaffId,ResolvedBy,Resolution,ReasonForHigh,step,OtherIssue,OtherDevice")] Request request)
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
        

            return View(request);


        }


        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }

    }
}