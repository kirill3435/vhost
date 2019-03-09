using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AVideoHost.Data;
using AVideoHost.Models;
using AVideoHost.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AVideoHost.Controllers
{
    [Route("Titles")]
    public class TitlesController : Controller
    {
        public VideoContext _db;

        public TitlesController(VideoContext db)
        {
            _db = db;
        }

        [Route("{id:int}")]
        public async Task<IActionResult> Index(int? id)
        {

            var titles = await _db.Titles
    .Include(x => x.Items)
    .ThenInclude(x => x.Video)
    .ToListAsync();

            var titlesViewModel = titles
                //.Where(x => x.Id == id)
                .Select(title => new TitleViewModel
                {
                    Id = title.Id,
                    Name = title.Name,
                    TitleDescription = title.TitleDescription,
                    PictureUrl = title.PictureUrl,
                    Items = title.Items
                        .Select(item => new TitleItemViewModel
                        {
                            VideoName = item.Video.Name,
                            VideoUrl = item.Video.VideoUrl,
                        }).ToList()
                });

            return View(titlesViewModel);
        }

        [HttpGet]
        [Route("Add")]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Title(int? id)
        {
            var titles = await _db.Titles.FirstOrDefaultAsync(x => x.Id == id);
            return View(titles);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save(Title title)
        {
            if (title.Id == default(int))
            {
                _db.Titles.Add(title);
            }
            else
            {
                _db.Titles.Attach(title);
                _db.Entry(title).State = EntityState.Modified;
            }

            await _db.SaveChangesAsync();

            return Redirect("~/Home/Index");
        }
    }
}