using AutoMapper;
using CallogApp.Data;
using CallogApp.Dtos;
using CallogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.Admin.Controllers
{
    [Route("api/requestreports")]
    [ApiController]
    public class APIRequestReportsControllerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public APIRequestReportsControllerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IReadOnlyList<RequestToReturnDto>>> Index(DateTime startDate, DateTime endDate, int department)
        {
          

            var requests = await _context.Requests
                         .Include(r => r.Device)
                         .Include(r => r.Issue)
                         .Include(r => r.Department)
                         .Include(r => r.Status)
                         .Include(r => r.ITStaff)
                         .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                         .Where(r => r.Department.Id == department)
                         .OrderByDescending(r => r.DateCreated)
                         .ToListAsync();

           
             var dataDto = _mapper.Map<IReadOnlyList<Request>, IReadOnlyList<RequestToReturnDto>>(requests);
            //return Ok(new { data = dataDto });
            return Ok(dataDto);
        }

        [HttpGet("category")]
        public async Task<ActionResult<IReadOnlyList<RequestToReturnDto>>> Category(DateTime startDate, DateTime endDate, int category)
        {


            var requests = await _context.Requests
                         .Include(r => r.Device)
                         .Include(r => r.Issue)
                         .Include(r => r.Department)
                         .Include(r => r.Status)
                         .Include(r => r.ITStaff)
                         .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                         .Where(r => r.Issue.Id == category)
                         .OrderByDescending(r => r.DateCreated)
                         .ToListAsync();


            var dataDto = _mapper.Map<IReadOnlyList<Request>, IReadOnlyList<RequestToReturnDto>>(requests);
            //return Ok(new { data = dataDto });
            return Ok(dataDto);
        }


        [HttpGet("daterange")]
        public async Task<ActionResult<IReadOnlyList<RequestToReturnDto>>> ReportWithoutDepartment(DateTime startDate, DateTime endDate)
        {


            var requests = await _context.Requests
                         .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                         .Include(r => r.Department)
                         .Include(r => r.Device)
                         .Include(r => r.Issue)                    
                         .Include(r => r.Status)
                         .Include(r => r.ITStaff)
                         .OrderByDescending(r => r.DateCreated)
                         .ToListAsync();

            var dataDto = _mapper.Map<IReadOnlyList<Request>, IReadOnlyList<RequestToReturnDto>>(requests);
            return Ok( dataDto );
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(U => U.Id == id);
            if (request == null)
            {
                return Ok(new { success = true, message = "Error while Deleting" });
            }
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Delete successful" });
        }
    }
}