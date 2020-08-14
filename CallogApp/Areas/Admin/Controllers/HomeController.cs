using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallogApp.Data;
using CallogApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext  db)
        {
            _db = db;
        }

        [Authorize(Roles = SD.SuperAdminUser)]
        public async Task<IActionResult> Index()
        {
            var users = await _db.ApplicationUsers.CountAsync();
            var requests = await _db.Requests.CountAsync();
            var calls = await _db.Calls.CountAsync();
            var pendingRequests = await _db.Requests
                                   .Where(r => r.Status.Name != "Resolved" && r.isCancel == false)

                                   .CountAsync();
            var todayRequests = await _db.Requests
             .Where(r => r.DateCreated.Date == DateTime.Today.Date)
             .CountAsync();



            var networkIssueCount = await _db.Requests
                .Where(r => r.Issue.Name == "Network Issue" && r.DateCreated.Date == DateTime.Today.Date)
                .CountAsync();

            var printerIssueCount = await _db.Requests
                    .Where(r => r.Issue.Name == "PRINTER ISSUE" && r.DateCreated.Date == DateTime.Today.Date)
                    .CountAsync();

            var mailCount = await _db.Requests
                    .Where(r => r.Issue.Name == "Mail (OUTLOOK) ISSUE" && r.DateCreated.Date == DateTime.Today.Date)
                    .CountAsync();

            var dataProcessingCount = await _db.Requests
                   .Where(r => r.Issue.Name == "Data Processing Issue" && r.DateCreated.Date == DateTime.Today.Date)
                   .CountAsync();

            var dataSystemCount = await _db.Requests
                  .Where(r => r.Issue.Name == "SYSTEM Issue" && r.DateCreated.Date == DateTime.Today.Date)
                  .CountAsync();

            var dataProcurementCount = await _db.Requests
                 .Where(r => r.Issue.Name == "Procurement" && r.DateCreated.Date == DateTime.Today.Date)
                 .CountAsync();

            var dataOtherCount = await _db.Requests
                 .Where(r => r.Issue.Name == "Other" && r.DateCreated.Date == DateTime.Today.Date)
                 .CountAsync();

            var dataKRCount = await _db.Requests
                .Where(r => r.Issue.Name == "KR Machine  Issue" && r.DateCreated.Date == DateTime.Today.Date)
                .CountAsync();

            var logsCount = await _db.Requests
               .Where(r => r.Issue.Name == "Personalisation Logs Issue" && r.DateCreated.Date == DateTime.Today.Date)
               .CountAsync();

            var softwareCount = await _db.Requests
              .Where(r => r.Issue.Name == "SOFTWARE ISSUE" && r.DateCreated.Date == DateTime.Today.Date)
              .CountAsync();


            ViewBag.usersCount = users;
            ViewBag.requestsCount = requests;
            ViewBag.pendingRequestsCount = pendingRequests;
            ViewBag.todayRequests = todayRequests;
            ViewBag.networkIssueCount = networkIssueCount;
            ViewBag.printerIssueCount = printerIssueCount;
            ViewBag.mailCount = mailCount;
            ViewBag.dataProcessingCount = dataProcessingCount;
            ViewBag.dataSystemCount = dataSystemCount;
            ViewBag.dataProcurementCount = dataProcurementCount;
            ViewBag.dataOtherCount = dataOtherCount;
            ViewBag.dataKRCount = dataKRCount;
            ViewBag.logsCount = logsCount;
            ViewBag.softwareCount = softwareCount;


            return View();
        }

        [Authorize(Roles = SD.AdminUser)]
        public async Task<IActionResult> ITDashboard()
        {
            var user = User.Identity.Name;

            var users = await _db.ApplicationUsers.CountAsync();
            var pendingRequests = await _db.Requests
                                    .Where(r => r.Status.Name != "Resolved" && r.isCancel == false )                             
                                    .CountAsync();
            var myPendingRequest = await _db.Requests
                                    .Where(r => r.Status.Name != "Resolved" && r.isCancel == false && r.ITStaff.Email == user)
                                    .CountAsync();

            var todayRequests = await _db.Requests
             .Where(r => r.DateCreated.Date == DateTime.Today.Date)
             .CountAsync();

            ViewBag.usersCount = users;
            ViewBag.pendingRequestsCount = pendingRequests;
            ViewBag.myPendingRequest = myPendingRequest;
            ViewBag.todayRequests = todayRequests;



            var networkIssueCount = await _db.Requests
         .Where(r => r.Issue.Name == "Network Issue" && r.DateCreated.Date == DateTime.Today.Date)
         .CountAsync();

            var printerIssueCount = await _db.Requests
                    .Where(r => r.Issue.Name == "PRINTER ISSUE" && r.DateCreated.Date == DateTime.Today.Date)
                    .CountAsync();

            var mailCount = await _db.Requests
                    .Where(r => r.Issue.Name == "Mail (OUTLOOK) ISSUE" && r.DateCreated.Date == DateTime.Today.Date)
                    .CountAsync();

            var dataProcessingCount = await _db.Requests
                   .Where(r => r.Issue.Name == "Data Processing Issue" && r.DateCreated.Date == DateTime.Today.Date)
                   .CountAsync();

            var dataSystemCount = await _db.Requests
                  .Where(r => r.Issue.Name == "SYSTEM Issue" && r.DateCreated.Date == DateTime.Today.Date)
                  .CountAsync();

            var dataProcurementCount = await _db.Requests
                 .Where(r => r.Issue.Name == "Procurement" && r.DateCreated.Date == DateTime.Today.Date)
                 .CountAsync();

            var dataOtherCount = await _db.Requests
                 .Where(r => r.Issue.Name == "Other" && r.DateCreated.Date == DateTime.Today.Date)
                 .CountAsync();

            var dataKRCount = await _db.Requests
                .Where(r => r.Issue.Name == "KR Machine  Issue" && r.DateCreated.Date == DateTime.Today.Date)
                .CountAsync();

            var logsCount = await _db.Requests
               .Where(r => r.Issue.Name == "Personalisation Logs Issue" && r.DateCreated.Date == DateTime.Today.Date)
               .CountAsync();

            var softwareCount = await _db.Requests
              .Where(r => r.Issue.Name == "SOFTWARE ISSUE" && r.DateCreated.Date == DateTime.Today.Date)
              .CountAsync();


            ViewBag.networkIssueCount = networkIssueCount;
            ViewBag.printerIssueCount = printerIssueCount;
            ViewBag.mailCount = mailCount;
            ViewBag.dataProcessingCount = dataProcessingCount;
            ViewBag.dataSystemCount = dataSystemCount;
            ViewBag.dataProcurementCount = dataProcurementCount;
            ViewBag.dataOtherCount = dataOtherCount;
            ViewBag.dataKRCount = dataKRCount;
            ViewBag.logsCount = logsCount;
            ViewBag.softwareCount = softwareCount;

            return View();
        }

        [Authorize(Roles = SD.SuperAdminUser + "," + SD.AdminUser)]
        public IActionResult PieChart()
        {
            return View();
        }
    }
}