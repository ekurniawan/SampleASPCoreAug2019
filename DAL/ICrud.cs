using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(string id);
    }
}
