using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        private AccountRepository _accountRepository;
        [SetUp]
        public void SetUp()
        {
            _accountRepository = new AccountRepository();
        }

        [Test]
        public void GetBalance_WithNoTransactions_Returns0Balance()
        {
            var accountBalance = _accountRepository.GetBalance();

            const int expectedBalance = 0;
            Assert.That(accountBalance, Is.EqualTo(expectedBalance),
                 "Empty account should return a 0 balance.");
        }

        [Test]
        public void ProcessTransaction_FirstTransaction_StoredTransactionsContainOnlyThatOneTransaction()
        {
            var transaction = new SimpleTransaction(10);

            _accountRepository.ProcessTransaction(transaction);

            var transactions = _accountRepository.GetTransactions();
            Assert.That(transactions.Count(), Is.EqualTo(1),
                "First transaction should be stored in the transaction list.");
            Assert.That(transactions.Single(), Is.EqualTo(transaction),
                "First transaction should be the only item stored.");
        }

        public static IEnumerable Transactions
        {
            get
            {
                yield return new TestCaseData(new SimpleTransaction(10));
                yield return new TestCaseData(new SimpleTransaction(0));
                yield return new TestCaseData(new SimpleTransaction(-1));
                yield return new TestCaseData(new FeeTransaction(10,2));
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

        [Test]
        public void GetTransactions_ZeroTransactionIsNotPartOfTransactionList()
        {
            var numberOfTransactions = new Random().Next(10);
            Enumerable.Range(0, numberOfTransactions).ToList().ForEach(_=>_accountRepository.ProcessTransaction(new SimpleTransaction(new Random().Next(50))));

            var transactions = _accountRepository.GetTransactions();

            foreach (var transaction in transactions)
            {
                var transactionAmount = transaction.CalculateTotalTransaction();
                if (transactionAmount == 0)
                {
                    Assert.That(transactionAmount, Is.Not.EqualTo(0), "0 transaction should not show in the transaction list.");
                    break;
                }
            }
        }

        public void GetBalance_WithTwoEqualTransactions_ReturnsDoubleOfTransactionValue()
        {
            _accountRepository.ProcessTransaction(new SimpleTransaction(100));
            _accountRepository.ProcessTransaction(new SimpleTransaction(100));

            Assert.That(_accountRepository.GetBalance(), Is.EqualTo(200));
        }
    }
}