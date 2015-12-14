using System.Linq;
using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        private AccountRepository _accountRepository;

        [SetUp]
        public  void Setup()
        {
            _accountRepository = new AccountRepository();
        }
        [Test]
        public void GetBalance_WithNoTransactions_Returns0Balance()
        {
            //Act
            var accountBalance = _accountRepository.GetBalance();
            //Assert
            const int expectedBalance = 0;
            Assert.That(accountBalance, Is.EqualTo(expectedBalance), 
                "Empty account should return a 0 balance,");
        }

        [Test]
        public void ProcessTransaction_FirstTransaction_StoredTransactionsContainOnlyThatOne()
        {
            var transaction = new SimpleTransaction(10);

            _accountRepository.ProcessTransaction(transaction);

            var transactions = _accountRepository.GetTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1),
                "First transaction should be stored in the transaction list.");
            Assert.That(transactions.Single(), Is.EqualTo(transaction),
            "First transaction should return the same balance.");
        }
    }
}