using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlimStesiMvc.Models;

namespace FlimStesiMvc.Controllers
{
    public class TheaterController : Controller
    {
        public static List<Theater> theaters= new List<Theater>();
        public TheaterController()
        {
            if(!theaters.Any())
            {
                theaters.Add(new Theater{Id=1,Name="Tiyatrolar",Year="1999",Photo="/imgTheater/tiyatro1.jpg"});
                theaters.Add(new Theater{Id=2,Name="Sanat Tiyatrosu",Year="2001",Photo="/imgTheater/tiyatro2.jpg"});
                theaters.Add(new Theater{Id=3,Name="Eski Dönem Tiyatrosu",Year="2000",Photo="/imgTheater/theater.jpg"});
            }
        }
        public IActionResult Index()
        {
            return View(theaters);
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