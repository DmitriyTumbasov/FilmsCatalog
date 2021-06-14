using FilmsCatalog.Data;
using FilmsCatalog.Data.Models;
using FilmsCatalog.Extensions;
using FilmsCatalog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index(int pageNo = 1, int pageSize = 10)
        {
            if (pageNo < 1)
            {
                pageNo = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            var totalCount = _filmRepository.Count();

            var model = new FilmIndexViewModel
            {
                Films = _filmRepository.Page(pageNo, pageSize),
                PageNo = pageNo,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)(Math.Ceiling((double)totalCount / (double)pageSize))
            };

            return View(model);
        }

        [Authorize]
        public IActionResult Edit(long id)
        {
            var film = _filmRepository.Get(id);

            if (film == null)
            {
                return NotFound("Фильм не найден");
            }

            var viewModel = film.ToCreateOrUpdateFilmViewModel();

            return View("Film/CreateOrEdit", viewModel);
        }

        public IActionResult Details(long id)
        {
            var film = _filmRepository.Get(id);

            if (film == null)
            {
                return NotFound("Фильм не найден");
            }

            return View(film);
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new CreateOrUpdateFilmViewModel();
            return View("Film/CreateOrEdit", model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateOrUpdate(CreateOrUpdateFilmViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Film/CreateOrEdit", model);
            }

            if (model.ImageFile != null && model.ImageFile.Length >= 2097152)
            {
                ModelState.AddModelError("File", "The file is too large.");
            }

            var film = model.ToDataModel();
            var loggedInUser = _userManager.GetUserAsync(User).Result;

            if (model.Id > 0)
            {
                _filmRepository.Update(film);
            }
            else
            {
                film.Author = loggedInUser;
                _filmRepository.Create(film);
            }


            _filmRepository.Save();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public FilmController(UserManager<User> userManager, SignInManager<User> signInManager, IRepository<Film, long> filmRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _filmRepository = filmRepository;
        }

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRepository<Film, long> _filmRepository;
    }
}
