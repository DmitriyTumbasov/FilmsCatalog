using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.ViewModels
{
    public class PagingViewModel
    {
        public int TotalCount { get; set; }
        public int CurrentPageNo { get; set; }
        public int PageSize { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int TotalPages { get; set; }
    }
}
