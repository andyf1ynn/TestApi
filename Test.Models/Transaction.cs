using System;

namespace Test.Models
{
    public class Transaction
    {
        public DateTime DateCreated { get; set; }
        public int Id { get; set; }
        public object Result { get; set; }
    }
}
