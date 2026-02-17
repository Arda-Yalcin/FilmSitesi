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
    public class MovieController : Controller
    {
        public static List<Movie> movies= new List<Movie>();

        public MovieController()
        {
            if(!movies.Any())
            {
                movies.Add(new Movie{Id=1,Name="Yüzüklerin Efendisi",Year="1999",Photo="/img/yuzuk.jpg"});
                movies.Add(new Movie{Id=2,Name="Hızlı ve Öfkeli",Year="2001",Photo="/img/hizli.jpg"});
                movies.Add(new Movie{Id=3,Name="Olağan Şüpeliler",Year="2000",Photo="/img/olagan.jpg"});
            }
        }

        public IActionResult Index()
        {

            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            var id=movies.Count()+1;
            movie.Id=id;
            movie.Photo="/img/ornek.jpg";
            movies.Add(movie);
            return RedirectToAction("Index","Movie");
        }

        public IActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(x=>x.Id==id);
            if (movie != null)
            {
                movies.Remove(movie);
                TempData["mesaj"]="Film Silindi";
            }
            else
            {
                TempData["mesaj"]="Filim Silinemedi";
            }

            return RedirectToAction("Index","Movie");
        }
    }
}