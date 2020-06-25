using AutoMapper;
using CallogApp.Data;
using CallogApp.Dtos;
using CallogApp.Models;
using CallogApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.Admin.Controllers.API
{
    [Route("api/kpi")]
    [ApiController]
    [Authorize(Roles = SD.SuperAdminUser + "," + SD.AdminUser)]
    public class KPIByUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public KPIByUserController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("GetAllRequestByUser")]
        public async Task<ActionResult<IReadOnlyList<RequestToReturnDto>>> GetAllRequestByUser(DateTime startDate, DateTime endDate, int ITStaffId)
        {


            var requests = await _context.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.Issue)
                .Include(r => r.Status)
                .Include(r => r.ITStaff)
                .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date && r.ITStaffId == ITStaffId)
                .OrderByDescending(r => r.DateCreated)
                .ToListAsync();

            var dataDto = _mapper.Map<IReadOnlyList<Request>, IReadOnlyList<RequestToReturnDto>>(requests);

            return Ok(dataDto );
        }

        [HttpGet("TotalRequestsByUser")]
        public async Task<ActionResult> TotalRequestsByUser(DateTime startDate, DateTime endDate, int ITStaffId)
        {


            var totalNoOfRequests = await _context.Requests
                         .Where(r => r.ITStaffId == ITStaffId)
                         .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                         .CountAsync();

            return Ok(totalNoOfRequests);
            //return Ok(new { data = totalNoOfRequests });
        }

        [HttpGet("TotalRequestsResolvedByUser")]
        public async Task<ActionResult> TotalRequestsResolvedByUser(DateTime startDate, DateTime endDate, int ITStaffId)
        {



            var totalNoOfRequestsResolved = await _context.Requests
                                            .Where(r => r.ITStaffId == ITStaffId)
                                            .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                                            .Where(r => r.Status.Name == "Resolved")
                                            .CountAsync();

            //return Ok(new { data = totalNoOfRequestsResolved });
            return Ok( totalNoOfRequestsResolved );
        }


        [HttpGet("TotalRequestsPendingByUser")]
        public async Task<ActionResult> TotalRequestsPendingByUser(DateTime startDate, DateTime endDate, int ITStaffId)
        {

            

            var totalNoOfRequestsResolved = await _context.Requests
                                            
                                            .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                                            .Where(r => r.ITStaffId == ITStaffId &&  r.Status.Name == "Pending")
                                            .CountAsync();

            //return Ok(new { data = totalNoOfRequestsResolved });
            return Ok(totalNoOfRequestsResolved);
        }

        [HttpGet("AverageResponseTimeByUser")]
        public async Task<ActionResult> AverageResponseTimeByUser(DateTime startDate, DateTime endDate, int ITStaffId)
        {
            
            var noOfResponseTimes =  from r in  _context.Requests
                                           .Where(r => r.ITStaffId == ITStaffId)
                                           .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)
                                          
                                            select r.ResponseDate;


          
                var totalnoOfResponseTimes = (noOfResponseTimes).TotalTime();

                var totalnoOfResponseTimesPerMinute = totalnoOfResponseTimes.TotalMinutes;

                var ct = Convert.ToDouble(await noOfResponseTimes.CountAsync());

                var AverageResponseTime = Convert.ToInt64(totalnoOfResponseTimesPerMinute / ct);



          

            return Ok(AverageResponseTime);
            //return Ok(new { data = AverageResponseTime });
        }

        [HttpGet("AverageResponseTimeHour")]
        public async Task<ActionResult> AverageResponseTimeHour(DateTime startDate, DateTime endDate, int ITStaffId)
        {

            var noOfResponseTimes = from r in _context.Requests
                                          .Where(r => r.ITStaffId == ITStaffId)
                                          .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date)

                                    select r.ResponseDate;



            var totalnoOfResponseTimes = (noOfResponseTimes).TotalTime();

            var totalnoOfResponseTimesPerMinute = totalnoOfResponseTimes.TotalHours;

            var ct = Convert.ToDouble(await noOfResponseTimes.CountAsync());

            var AverageResponseTimeHour = Convert.ToInt64(totalnoOfResponseTimesPerMinute / ct);





            return Ok(AverageResponseTimeHour);
            //return Ok(new { data = AverageResponseTime });
        }


        [HttpGet("AverageResolutionTimeByUser")]
        public async Task<ActionResult> AverageResolutionTimeByUser(DateTime startDate, DateTime endDate, int ITStaffId)
        {

            var noOfResolvedTimes = from r in _context.Requests
                                          .Where(r => r.Status.Name == "Resolved")
                                          .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date && r.ITStaffId == ITStaffId)

                                    select r.ResolvedDate;

            var totalnoOfResolvedTimes = (noOfResolvedTimes).TotalTime();

            var totalnoOfResolvedTimesPerHour = totalnoOfResolvedTimes.TotalMinutes;

            var ct = Convert.ToDouble(await noOfResolvedTimes.CountAsync());

            var AverageResolutionTime = Convert.ToInt64(totalnoOfResolvedTimesPerHour / ct);


            return Ok(AverageResolutionTime);
            //return Ok(new { data = AverageResolutionTime });
        }

        [HttpGet("AverageResolutionTimeHour")]
        public async Task<ActionResult> AverageResolutionTimeHour(DateTime startDate, DateTime endDate, int ITStaffId)
        {

            var noOfResolvedTimes = from r in _context.Requests
                                          .Where(r => r.Status.Name == "Resolved")
                                          .Where(r => r.DateCreated.Date >= startDate.Date && r.DateCreated.Date <= endDate.Date && r.ITStaffId == ITStaffId)

                                    select r.ResolvedDate;

            var totalnoOfResolvedTimes = (noOfResolvedTimes).TotalTime();

            var totalnoOfResolvedTimesPerHour = totalnoOfResolvedTimes.TotalHours;

            var ct = Convert.ToDouble(await noOfResolvedTimes.CountAsync());

            var AverageResolutionTimeHour = Convert.ToInt64(totalnoOfResolvedTimesPerHour / ct);


            return Ok(AverageResolutionTimeHour);
            //return Ok(new { data = AverageResolutionTime });
        }

    }
}