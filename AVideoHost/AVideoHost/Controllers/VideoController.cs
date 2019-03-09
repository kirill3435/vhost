using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AVideoHost.Data;
using AVideoHost.Models;

namespace AVideoHost.Controllers
{
    [Route("Video")]
    public class VideoController : Controller
    {
        public VideoContext _db;

        public VideoController(VideoContext db)
        {
            _db = db;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var video = await _db.Video.ToListAsync();
            return View(video);
        }

        [HttpGet]
        [Route("Add")]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Video(int? id)
        {
            var video = await _db.Video.FirstOrDefaultAsync(x => x.Id == id);
            return View(video);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save(Video video)
        {
            if (video.Id == default(int))
            {
                _db.Video.Add(video);
            }
            else
            {
                _db.Video.Attach(video);
                _db.Entry(video).State = EntityState.Modified;
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}