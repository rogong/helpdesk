using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallogApp.Data;
using CallogApp.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallogApp.Areas.User.Controllers
{
    [Route("api/userrequest")]
    [ApiController]
    [Authorize]
    public class UserRequestAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UserRequestAPIController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET requestS API
        public async Task<ActionResult<List<RequestToReturnDto>>> GetRequests()
        {

            var userId = User.Identity.Name;
            var requests = await _db.Requests
                .Where(r => r.UserId == userId)
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.Issue)
                .Include(r => r.Status)
                .Include(r => r.ITStaff)
                .OrderByDescending(r => r.DateCreated)
                .ToListAsync();
            var requestDto = requests.Select(request => new RequestToReturnDto
            {
                Id = request.Id,
                UserId = request.UserId,
                Status = request.Status.Name,
                DateCreated = request.DateCreated.ToString(),
                Department = request.Department.Name,
                Issue = request.Issue.Name,
                Device = request.Device.Name,
                DepartmentOwner = request.DepartmentOwner,
                ITStaff = request.ITStaff.Name,
                Subject = request.Subject,
                Message = request.Message,
                isCancel = Convert.ToString(request.isCancel)




            }).ToList();
            return Ok(new { data = requestDto });
        }

        [HttpPut]
        public async Task<IActionResult> Cancel(int id)
        {
            var request = await _db.Requests.FirstOrDefaultAsync(U => U.Id == id);
            if (request == null)
            {
                return Ok(new { success = true, message = "Error while Cancelling" });
            }

            request.isCancel = true;
            await _db.SaveChangesAsync();
            return Ok(new { success = true, message = "Request canceled" });
        }

        [HttpGet("PendingRequest")]
        public async Task<ActionResult<List<RequestToReturnDto>>> PendingRequest()
        {
            var userId = User.Identity.Name;
            var requests = await _db.Requests
                .Include(r => r.Department)
                .Include(r => r.Device)
                .Include(r => r.Issue)
                .Include(r => r.Status)
                .Include(r => r.ITStaff)
                .Where(r => r.UserId == userId &&  r.Status.Name == "Pending")
                .OrderByDescending(r => r.DateCreated)
                .ToListAsync();
            var requestDto = requests.Select(request => new RequestToReturnDto
            {
                Id = request.Id,
                UserId = request.UserId,
                Status = request.Status.Name,
                DateCreated = request.DateCreated.ToString(),
                Department = request.Department.Name,
                Issue = request.Issue.Name,
                Device = request.Device.Name,
                DepartmentOwner = request.DepartmentOwner,
                ITStaff = request.ITStaff.Name,
                Subject = request.Subject,
                Message = request.Message,
                isCancel = Convert.ToString(request.isCancel)




            }).ToList();
            return Ok(new { data = requestDto });
        }
    }
}