using Test.DataAccess;
using Test.Interfaces;
using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Repos
{
    public class TransactionRepository<T> : IRepository<T> where T : Transaction
    {
        List<T> _store = DataStore<List<T>>.Instance;

        public T Create(T item)
        {
            var id = _store.Any() ? _store.OrderBy(x => x.Id).Last().Id + 1 : 1;
            item.Id = id;
            _store.Add(item);

            return item;
        }

        public T Update(T item)
        {
            var itemToUpdate = _store.Where(
                x => x.Id == item.Id)?.FirstOrDefault();
            var itemIndex = _store.IndexOf(itemToUpdate);
            _store[itemIndex] = item;

            return item;
        }

        public T Delete(int id, DateTime created)
        {
            var transaction = _store.Where(x => x.Id == id && x.DateCreated == created).FirstOrDefault();
            _store.Remove(transaction);

            return transaction;
        }

        public List<T> List()
        {
            return DataStore<List<T>>.Instance.ToList();
        }
    }
}
