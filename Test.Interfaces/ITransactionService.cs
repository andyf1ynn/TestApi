using Test.Models;

namespace Test.Interfaces
{
    public interface ITransactionService
    {
        Transaction GetLetters(object input);
    }
}
