using FilmsCatalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.ViewModels.Film
{
    public class FilmDetailsViewModel
    {
        public long Id { get; set; }
        public User Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string FilmDirector { get; set; }
    }
}
