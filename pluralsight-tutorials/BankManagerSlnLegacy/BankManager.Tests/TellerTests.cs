using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public class TellerTests
    {
        private Teller _teller;
        private AccountRepository _accountRepository;
        const int NonZeroBalance = 1;

        [SetUp]
        public void SetUp()
        {
            _accountRepository = Mock.Of<AccountRepository>();
            _teller = new Teller(_accountRepository);

            Mock.Get(_accountRepository).Setup(x => x.GetBalance()).Returns(NonZeroBalance);
        }

        [Test]
        public void CheckBalance_RequestsTheAccountBalanceFromTheRepository()
        {
            var balance = _teller.CheckBalance();

            Assert.That(balance, Is.EqualTo(NonZeroBalance),
                "Checking the balance should return the balance retrieved from the repository.");
        }

        [Test]
        public void ProcessTransaction_TransactionValueGiven_TellerSubmitsGivenTransactionToTheRepository()
        {
            var transaction = new SimpleTransaction(10);
            var processTransactionTrigger = new ManualResetEvent(false);
            Mock.Get(_accountRepository).Setup(x => x.ProcessTransaction(transaction))
                .Callback(() => processTransactionTrigger.Set());

            _teller.ProcessTransaction(transaction);

            processTransactionTrigger.WaitOne(TimeSpan.FromSeconds(1));
            Mock.Get(_accountRepository).Verify(x => x.ProcessTransaction(transaction), Times.Once(),
                "The teller should forward the process transaction request to the repository.");
        }

        [Test]
        public void Constructor_NullAccountRepository_ThrowsException()
        {
            try
            {
                new Teller(null);
            }
            catch
            {
                Assert.Pass();
                return;
            }
            Assert.Fail("Null account repository did not throw an exception");
        }

        [Test]
        public void RequestLoan_GoldenMaster()
        {
            var loanDetails = _teller.RequestLoan(100, 201, 100);
            Assert.That(loanDetails.IsApproved);

            loanDetails = _teller.RequestLoan(100, 200, 100);
            Assert.That(loanDetails.IsApproved, Is.False);

        }
    }
}