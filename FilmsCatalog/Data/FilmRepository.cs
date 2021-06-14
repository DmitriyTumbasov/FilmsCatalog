using FilmsCatalog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Data
{
    public class FilmRepository : IRepository<Film, long>
    {
        public void Create(Film item)
        {
            context.Films.Add(item);
        }

        public void Delete(long id)
        {
            var item = Get(id);
            if (item != null)
            {
                context.Films.Remove(item);
            }
        }

        public Film Get(long id)
        {
            return context.Films.Find(id);
        }

        public IEnumerable<Film> GetAll()
        {
            return context.Films;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Film item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        private readonly ApplicationDbContext context;

        public FilmRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Count()
        {
            return context.Films.Count();
        }

        public IEnumerable<Film> Page(int pageNo, int pageSize)
        {
            pageNo--;
            if (pageNo < 0)
            {
                pageNo = 0;
            }

            return context.Films.Skip(pageNo * pageSize).Take(pageSize);
        }
    }
}
