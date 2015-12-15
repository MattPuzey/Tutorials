using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
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

        public static IEnumerable Transactions
        {
            get
            {
                yield return new TestCaseData(new SimpleTransaction(10));
                yield return new TestCaseData(new SimpleTransaction(0));
                yield return new TestCaseData(new SimpleTransaction(-1));
                yield return new TestCaseData(new FeeTransaction(10, 2));
            } 
        }

        [TestCaseSource("Transactions")]
        public void GetBalance_WithOneTransaction_ReturnsTotalOfTransaction(Transaction transaction)
        {
            _accountRepository.ProcessTransaction(transaction);
            var totalOfTransaction = transaction.CalculateTotalTransaction();

            var currentBalance = _accountRepository.GetBalance();

            Assert.That(currentBalance, Is.EqualTo(totalOfTransaction),
                "Balance of one transaction should equal the total of that one transaction.");
        }
    }
}