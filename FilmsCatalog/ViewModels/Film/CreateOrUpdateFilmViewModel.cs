using FilmsCatalog.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.ViewModels
{
    public class CreateOrUpdateFilmViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Год")]
        public string Year { get; set; }
        [Display(Name = "Режиссер")]
        public string FilmDirector { get; set; }
        [Display(Name = "Постер")]
        public IFormFile ImageFile { get; set; }
        public byte[] OldImageFile { get; set; }
    }
}
