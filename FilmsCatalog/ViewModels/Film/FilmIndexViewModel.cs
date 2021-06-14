using FilmsCatalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.ViewModels
{
    public class FilmIndexViewModel
    {
        public IEnumerable<Data.Models.Film> Films { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
