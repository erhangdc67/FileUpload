using Assignment_Team.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Team.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetListInfo()
        {
            var Info = new List<FileInfomations>();

            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = Path.Combine(contentRootPath, "UploadedFiles");

            var filePath = path;

            foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                FileInfo _fileInfo = new FileInfo(file);

                Info.Add(new FileInfomations { Path = _fileInfo.FullName.ToString(),  Name = _fileInfo.Name, Lenght = _fileInfo.Length.ToString(), CreateDate = _fileInfo.CreationTime.ToString() });
            }
            return Json(Info);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
