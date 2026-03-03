using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlimStesiMvc.Models;
using FlimStesiMvc.Data;

namespace FlimStesiMvc.Controllers
{
    public class TheaterController : Controller
    {
        public static List<Theater> theaters= new List<Theater>();
        private readonly AppDbContext _appDbContext;
        public TheaterController(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }


        public IActionResult Index()
        {
            var tarifler=_appDbContext.Theaters.ToList();
            return View(tarifler);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Theater theater)
        {
            var id=theaters.Count()+1;
            theater.Id=id;
            theater.Photo="/imgTheater/tiyatro1.jpg";
            theaters.Add(theater);
            return RedirectToAction("Index","Theater");
        }
        public IActionResult Delete(int id)
        {
            var theater = theaters.FirstOrDefault(x=>x.Id==id);
            if (theater != null)
            {
                theaters.Remove(theater);
                TempData["mesaj"]="Film Silindi";
            }
            else
            {
                TempData["mesaj"]="Filim Silinemedi";
            }

            return RedirectToAction("Index","Theater");
        }
    }
}