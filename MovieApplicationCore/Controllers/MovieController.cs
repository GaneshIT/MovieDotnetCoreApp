using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplicationCore.Controllers
{
    public class MovieController : Controller
    {
        MovieDbContext _movieDbContext = null;
        public MovieController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            LanguageRepository languageRepository = new LanguageRepository(_movieDbContext);
            ViewBag.MyLanguageList = languageRepository.GetLanguages();
            return View();
        }
        [HttpPost]
        public IActionResult Create(MovieModel movieModel)
        {
            LanguageRepository languageRepository = new LanguageRepository(_movieDbContext);
            if (ModelState.IsValid)
            {
                
                SelectListItem selectLanguage = languageRepository.GetLanguageById(movieModel.MovieLangauge);
                movieModel.MovieLangauge = selectLanguage.Text;
                MovieRepository movieRepository = new MovieRepository(_movieDbContext);
               bool result= movieRepository.AddMovie(movieModel);
                if (result)
                    ViewBag.Message = "Inserted";
                else
                    ViewBag.Message = "Failed";
               
            }
            ViewBag.MyLanguageList = languageRepository.GetLanguages();
            return View();
        }
    }
}
