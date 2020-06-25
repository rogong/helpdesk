using AutoMapper;
using CallogApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.Admin.Controllers.API
{
    [Route("api/piechartreport")]
    [ApiController]
    public class APIPieChartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public APIPieChartController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Network")]
        public async Task<IActionResult> Network(DateTime startDate, DateTime endDate)
        {
            var networkIssueCount = await _context.Requests
                .Where(r => r.Issue.Name == "Network Issue")
                .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                .CountAsync();


            return Ok(networkIssueCount);
        }

        [HttpGet("Printer")]
        public async Task<IActionResult> Printer(DateTime startDate, DateTime endDate)
        {
            var printerIssueCount = await _context.Requests
                     .Where(r => r.Issue.Name == "PRINTER ISSUE")
                     .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                     .CountAsync();

            return Ok(printerIssueCount);
        }

        [HttpGet("Mail")]
        public async Task<IActionResult> Mail(DateTime startDate, DateTime endDate)
        {


            var mailCount = await _context.Requests
                     .Where(r => r.Issue.Name == "Mail (OUTLOOK) ISSUE")
                     .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                     .CountAsync();


            return Ok(mailCount);
        }


        [HttpGet("DataProcessing")]
        public async Task<IActionResult> DataProcessing(DateTime startDate, DateTime endDate)
        {


            var dataProcessingCount = await _context.Requests
                   .Where(r => r.Issue.Name == "Data Processing Issue")
                   .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                   .CountAsync();



            return Ok(dataProcessingCount);
        }

        [HttpGet("DataSystem")]
        public async Task<IActionResult> DataSystem(DateTime startDate, DateTime endDate)
        {

            var DataSystemCount = await _context.Requests
                  .Where(r => r.Issue.Name == "SYSTEM Issue")
                  .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                  .CountAsync();

            return Ok(DataSystemCount);
        }

        [HttpGet("Other")]
        public async Task<IActionResult> Other(DateTime startDate, DateTime endDate)
        {

            var DataSystemCount = await _context.Requests
                  .Where(r => r.Issue.Name == "OTHER")
                  .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                  .CountAsync();

            return Ok(DataSystemCount);
        }

        [HttpGet("Procurement")]
        public async Task<IActionResult> Procurement(DateTime startDate, DateTime endDate)
        {

            var procurement = await _context.Requests
                  .Where(r => r.Issue.Name == "Procurement")
                  .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                  .CountAsync();

            return Ok(procurement);
        }

        [HttpGet("Software")]
        public async Task<IActionResult> Software(DateTime startDate, DateTime endDate)
        {

            var software = await _context.Requests
                  .Where(r => r.Issue.Name == "SOFTWARE ISSUE")
                  .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                  .CountAsync();

            return Ok(software);
        }


        [HttpGet("KrMachine")]
        public async Task<IActionResult> KrMachine(DateTime startDate, DateTime endDate)
        {

            var krCount = await _context.Requests
                  .Where(r => r.Issue.Name == "KRs Template Issue")
                  .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                  .CountAsync();

            return Ok(krCount);
        }


        [HttpGet("Logs")]
        public async Task<IActionResult> Logs(DateTime startDate, DateTime endDate)
        {

            var logsCount = await _context.Requests
                  .Where(r => r.Issue.Name == "Personalisation Logs Issue")
                  .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                  .CountAsync();

            return Ok(logsCount);
        }
    }
}