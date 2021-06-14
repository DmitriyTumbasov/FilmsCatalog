using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;

namespace FilmsCatalog.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}