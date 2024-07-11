using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using SavePro.Models;
using SavePro.Data;

namespace SavePro.Controllers
{
    public class VideoController : Controller
    {
        private readonly AppDbContext _context;

        public VideoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(VideoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var video = new Video
                {
                    Title = model.Title,
                    FilePath = "/uploads/" + model.VideoFile.FileName // Example path
                };

                // Save file to server
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", model.VideoFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.VideoFile.CopyToAsync(stream);
                }

                _context.Videos.Add(video);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); // Redirect to video list page or homepage
            }

            return View(model); // If ModelState is not valid, return to the upload view with errors
        }
    }
}
