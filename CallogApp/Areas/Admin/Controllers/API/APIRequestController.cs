using AutoMapper;
using CallogApp.Data;
using CallogApp.Dtos;
using CallogApp.Models;
using CallogApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Areas.Admin.Controllers
{
    [Route("api/adminrequest")]
    [ApiController]
    [Authorize(Roles = SD.SuperAdminUser + "," + SD.AdminUser)]
    public class APIRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public APIRequestController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        // GET requestS API
        public async Task<ActionResult<IReadOnlyList<RequestToReturnDto>>> GetAllRequest()
        {

          
            var requests = await _db.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.Issue)      
                .Include(r => r.Status)
                .Include(r => r.ITStaff)
                .OrderByDescending(r => r.DateCreated)
                .ToListAsync();

            var dataDto = _mapper.Map<IReadOnlyList<Request>, IReadOnlyList<RequestToReturnDto>>(requests);

            return Ok(new { data = dataDto });
        }

        [HttpGet("AssignPending")]
        public async Task<ActionResult<IReadOnlyList<RequestToReturnDto>>> GetAllRequestByPending()
        {


            var requests = await _db.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.Issue)
                .Include(r => r.Status)
                .Include(r => r.ITStaff)
                .OrderByDescending(r => r.DateCreated)
                .Where(r => r.Status.Name != "Resolved" && r.isCancel == false)
                .ToListAsync();

            var dataDto = _mapper.Map<IReadOnlyList<Request>, IReadOnlyList<RequestToReturnDto>>(requests);

            return Ok(new { data = dataDto });
        }


        [HttpGet("MyAssignedTask")]
        public async Task<ActionResult<IReadOnlyList<RequestToReturnDto>>> GetAllMyAssignedTask()
        {

            var user = User.Identity.Name;

            var requests = await _db.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.Issue)
                .Include(r => r.Status)
                .Include(r => r.ITStaff)
                .OrderByDescending(r => r.DateCreated)
                .Where(r => r.ITStaff.Email == user)
                .ToListAsync();

            var dataDto = _mapper.Map<IReadOnlyList<Request>, IReadOnlyList<RequestToReturnDto>>(requests);

            return Ok(new { data = dataDto });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _db.Requests.FirstOrDefaultAsync(U => U.Id == id);
            if (request == null)
            {
                return Ok(new { success = true, message = "Error while Deleting" });
            }
            _db.Requests.Remove(request);
            await _db.SaveChangesAsync();
            return Ok(new { success = true, message = "Delete successful" });
        }
    }
}
