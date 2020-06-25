using CallogApp.Data;
using CallogApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminUser + "," + SD.AdminUser)]
    public class KPIsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KPIsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["ITStaffId"] = new SelectList(_context.ITStaffs, "Id", "Name");
           
            return View();

            
        }
    }
}