using System;
using Test.Interfaces;
using Test.Models;

namespace Test.Services
{
    public class TransactionService : ITransactionService
    {
        public TransactionService(IRepository<Transaction> repository)
        {
            _repository = repository;
        }

        private readonly IRepository<Transaction> _repository;

        public Transaction GetLetters(object input)
        {
            object res = null;

            if (input == null || !Int32.TryParse(input.ToString(), out int val))
            {
                res = input;
            }
            else if (val == 0)
            {
                res = input;
            }
            else if (val % 7 == 0)
            {
                if (val % 9 == 0)
                    res = "EG";
                else
                    res = "E";
            }
            else if (val % 9 == 0)
            {
                res = "G";
            }
            else
                res = input;

            var transaction = new Transaction { Result = res, DateCreated = DateTime.Now };

            _repository.Create(transaction);

            return transaction;
        }
    }
}
