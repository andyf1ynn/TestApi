using Test.Services;
using Test.Interfaces;
using Test.Models;
using Moq;
using NUnit.Framework;

namespace Test.UnitTests.ServiceTests
{
    [TestFixture]
    public class TransactionServiceTests
    {
        private TransactionService _testClass;
        private Mock<IRepository<Transaction>> _repositoryMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepository<Transaction>>();
            _testClass = new TransactionService(_repositoryMock.Object);
        }

        [TestCase(0)]
        [TestCase(null)]
        [TestCase(284)]
        [TestCase(1227852158)]
        [TestCase(12278521582555284122)]
        [TestCase(-71)]
        [TestCase("NOTANINT")]
        public void Test_Transaction_Should_Return_Input(object input)
        {
            //Act
            var transaction = _testClass.GetLetters(input);

            //Assert
            Assert.AreEqual(input, transaction.Result);
        }

        [TestCase(7)]
        [TestCase(14)]
        [TestCase(21)]
        [TestCase(28)]
        [TestCase(-70)]
        public void Test_Transaction_Should_Return_E(object input)
        {
            //Act
            var transaction = _testClass.GetLetters(input);

            //Assert
            Assert.AreEqual("E", transaction.Result);
        }

        [TestCase(9)]
        [TestCase(18)]
        [TestCase(27)]
        [TestCase(36)]
        [TestCase(-18)]
        public void Test_Transaction_Should_Return_G(object input)
        {
            //Act
            var transaction = _testClass.GetLetters(input);

            //Assert
            Assert.AreEqual("G", transaction.Result);
        }

        [TestCase(63)]
        public void Test_Transaction_Should_Return_EG(object input)
        {
            //Act
            var transaction = _testClass.GetLetters(input);

            //Assert
            Assert.AreEqual("EG", transaction.Result);
        }
    }
}
