using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CallogApp.Data;
using CallogApp.Models;

namespace CallogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Tests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requests.Include(r => r.Department).Include(r => r.Device).Include(r => r.ITStaff).Include(r => r.Issue).Include(r => r.Level).Include(r => r.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Tests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.ITStaff)
                .Include(r => r.Issue)
                .Include(r => r.Level)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Admin/Tests/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name");
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Email");
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name");
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: Admin/Tests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusId,UserId,DateCreated,ResponseDate,RespondedDate,ResolvedDate,UpdatedAt,DepartmentId,IssueId,DeviceId,Subject,Message,ITStaffId,ResolvedBy,Resolution,DepartmentOwner,LevelId,isCancel,ReasonForHigh")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Email", request.ITStaffId);
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
            return View(request);
        }

        // GET: Admin/Tests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", request.DepartmentId);
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", request.DeviceId);
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Email", request.ITStaffId);
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
            return View(request);
        }

        // POST: Admin/Tests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusId,UserId,DateCreated,ResponseDate,RespondedDate,ResolvedDate,UpdatedAt,DepartmentId,IssueId,DeviceId,Subject,Message,ITStaffId,ResolvedBy,Resolution,DepartmentOwner,LevelId,isCancel,ReasonForHigh")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Email", request.ITStaffId);
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name", request.IssueId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Name", request.LevelId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", request.StatusId);
            return View(request);
        }

        // GET: Admin/Tests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.ITStaff)
                .Include(r => r.Issue)
                .Include(r => r.Level)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Admin/Tests/Delete/5
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
    }
}
