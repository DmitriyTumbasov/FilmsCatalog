using FilmsCatalog.Data.Models;
using FilmsCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Extensions
{
    public static class FilmModelsExtension
    {
        public static Film ToDataModel(this CreateOrUpdateFilmViewModel viewModel)
        {
            var film = new Film
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                FilmDirector = viewModel.FilmDirector,
                Year = viewModel.Year,
            };

            if (viewModel.ImageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    viewModel.ImageFile.CopyTo(memoryStream);
                    film.ImageFile = memoryStream.ToArray();
                }
            }
            else if(viewModel.OldImageFile != null)
            {
                film.ImageFile = viewModel.OldImageFile;
            }

            return film;
        }

        public static CreateOrUpdateFilmViewModel ToCreateOrUpdateFilmViewModel(this Film film)
        {
            return new CreateOrUpdateFilmViewModel
            {
                Id = film.Id,
                Description = film.Description,
                FilmDirector = film.FilmDirector,
                Name = film.Name,
                OldImageFile = film.ImageFile,
                Year = film.Year
            };
        }
    }
}
