using System;
using Models;

namespace Services
{
    public class TransactionService
    {
        public Transaction GetLetters(int? input)
        {
            object res = null;

            if (input == null || input == 0)
            {
                res = input;
            }

            if (input % 7 == 0)
            {
                if (input % 9 == 0)
                    res = "EG";
                else
                    res = "E";
            }
            else if (input % 9 == 0)
            {
                res = "G";
            }
            else
                res = input;

            return new Transaction { Result = res };
        }
    }
}
