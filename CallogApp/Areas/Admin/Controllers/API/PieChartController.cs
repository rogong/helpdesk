using AutoMapper;
using CallogApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.Admin.Controllers.API
{
    [Route("api/piechart")]
    [ApiController]
    public class PieChartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PieChartController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Network")]
        public async Task<IActionResult> Network()
        {
            var networkIssueCount = await _context.Requests
                .Where(r => r.Issue.Name == "Network Issue")
                .CountAsync();

    
            return Ok(networkIssueCount);
        }

        [HttpGet("Printer")]
        public async Task<IActionResult> Printer()
        {
           

            var printerIssueCount = await _context.Requests
                     .Where(r => r.Issue.Name == "PRINTER ISSUE")
                     .CountAsync();

            return Ok(printerIssueCount);
        }

        [HttpGet("Mail")]
        public async Task<IActionResult> Mail()
        {
           

            var mailCount = await _context.Requests
                     .Where(r => r.Issue.Name == "Mail (OUTLOOK) ISSUE")
                     .CountAsync();


            return Ok(mailCount);
        }


        [HttpGet("DataProcessing")]
        public async Task<IActionResult> DataProcessing()
        {


            var dataProcessingCount = await _context.Requests
                   .Where(r => r.Issue.Name == "Data Processing Issue")
                   .CountAsync();

         

            return Ok(dataProcessingCount);
        }

        [HttpGet("DataSystem")]
        public async Task<IActionResult> DataSystem()
        {

            var DataSystemCount = await _context.Requests
                  .Where(r => r.Issue.Name == "SYSTEM Issue")
                  .CountAsync();

            return Ok(DataSystemCount);
        }
    }
}