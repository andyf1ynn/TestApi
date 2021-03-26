using System;

namespace Test.DataAccess
{
    public class DataStore<T> where T : class, new()
    {
        private DataStore() { }

        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance { get { return instance.Value; } }
    }
}
