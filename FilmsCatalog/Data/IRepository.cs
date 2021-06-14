using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Data
{
    /// <summary>
    /// Дженерик интерфейс для репозитория
    /// </summary>
    /// <typeparam name="T">Тип сущности репозитория</typeparam>
    /// <typeparam name="Tid">Тип первичного ключа сущности репозитория</typeparam>
    public interface IRepository<T, Tid> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Tid id);
        void Create(T item);
        void Update(T item);
        void Delete(Tid id);
        void Save();
        int Count();
        IEnumerable<T> Page(int pageNo, int pageSize);
    }
}
