using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallogApp.Data;
using CallogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssignRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignRequestController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Create()
        {
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name");
            ViewBag.CreatedAt = DateTime.Now;
            ViewBag.UpdatedAt = DateTime.Now;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ITStaffId,RequestId,CreatedAt,UpdatedAt")] AssignRequest assignrequest)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    

                    _context.Add(assignrequest);
                   await _context.SaveChangesAsync();
                    ViewBag.Message = "Task assigned successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name");
            return View();
        }

        public IActionResult MyAssignedRequest()
        {
            return View();
        }



    }
}