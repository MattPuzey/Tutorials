using System.Linq;
using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{
    public class AccountRepositoryTests : BaseTestClass
    {

        private Teller _teller;
        private AccountRepository _accountRepository;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _accountRepository = new AccountRepository();
            _teller = new Teller(_accountRepository);
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
            const int depositAmount = 10;

            _accountRepository.ProcessTransaction(depositAmount);

            var transactions = _accountRepository.GetTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1),
                "First transaction should be stored in the transaction list.");
            Assert.That(transactions.Single(), Is.EqualTo(depositAmount),
            "First transaction should return the same balance.");
        }
    }
}