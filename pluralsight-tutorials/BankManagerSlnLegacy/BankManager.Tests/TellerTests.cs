using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{

    public class TellerOverride : Teller
        // only the dependecy should be overriden in this non-production implementation
    {
        public TellerOverride(AccountRepository accountRepository) : base(accountRepository) {}

        public LoanAdvisorWrapper LoanAdvisor { get; set; }

        //We can override the GetLoanAdvisor factory method and return a property value if it exists which can be controlled by the setter. 
        protected override LoanAdvisorWrapper GetLoanAdvisor()
        {
            return LoanAdvisor ?? base.GetLoanAdvisor();
        }
    }

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
            _teller = new TellerOverride(_accountRepository);

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
        public void RequestLoan_ForwardsTheLoanrRequestParametersToTheLoanAdvisor()
        {
            var loanAdvisorWrapper = Mock.Of<LoanAdvisorWrapper>();
            (_teller as TellerOverride).LoanAdvisor = loanAdvisorWrapper;

            _teller.RequestLoan(1, 1, 1);

            Mock.Get(loanAdvisorWrapper).Verify(x => x.RequestLoan(1, 1, 1), Times.Once,
                "Teller is expected to call the advisor with the same parameters    ");

        }
            
        //Exists for refactoring purposes 
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