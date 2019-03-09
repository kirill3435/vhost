using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AVideoHost.Models;
using AVideoHost.Data;

namespace AVideoHost.Controllers
{
    public class HomeController : Controller
    {
        public VideoContext _db;

        public HomeController(VideoContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var titles = await _db.Titles.ToListAsync();
            return View(titles);
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
