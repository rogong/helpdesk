using CallogApp.Data;
using CallogApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminUser + "," + SD.AdminUser)]
    public class RequestReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

       


        public RequestReportsController(ApplicationDbContext context)
        {
            _context = context;
          
        }
        public IActionResult Index()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");       

            return View();
        }


        public IActionResult Category()
        {
            ViewData["IssueId"] = new SelectList(_context.Issues, "Id", "Name");

            return View();
        }

        public IActionResult ReportWithoutDepartment()
        {
            return View();
        }

        public IActionResult PieChartReport()
        {
            return View();
        }

    }
}