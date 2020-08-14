using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallogApp.Areas.User.Controllers.API
{
    [Route("api/upload")]
    [ApiController]
    public class UploadAPIController : Controller
    {
        private IWebHostEnvironment _hostingEnv;
        public UploadAPIController(IWebHostEnvironment env)
        {
            _hostingEnv = env;
        }
        public async Task<IActionResult> Upload(IFormFile upload)
        {
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + upload.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), _hostingEnv.WebRootPath, "uploads", fileName);
            var stream = new FileStream(path, FileMode.Create);
            await upload.CopyToAsync(stream);
            return new JsonResult(new { path = "/uploads/" + fileName });
        }
    }
}