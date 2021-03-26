using System;
using System.Collections.Generic;

namespace Test.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T item);

        T Update(T item);

        T Delete(int id, DateTime created);

        List<T> List();
    }
}

