using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Team.Controllers
{
    public class FileUploadController : Controller
    {
        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var filePaths = new List<string>();
          
                if (file.Length > 0)
                {
                    string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles"),Path.GetFileName(file.FileName));
                    var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            return Ok(new { filePath });
        }
    }
}
