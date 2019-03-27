using System.Collections.Generic;

namespace EarthquakesApp.Services.Abstract
{
    public interface IRepository<T>
    {
        void Add(T item);
        List<T> GetAll();
    }
}
