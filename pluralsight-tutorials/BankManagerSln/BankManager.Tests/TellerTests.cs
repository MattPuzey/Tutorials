using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BankManager.Tests
{
    [TestFixture]
    public class TellerTests 
    {

        private Teller _teller;
        private AccountRepository _accountRepository;

        [SetUp]
        public void Setup()
        {
            _accountRepository = Mock.Of<AccountRepository>();
            _teller = new Teller(_accountRepository);
        }

        [Test]
        public void CheckBalance_RequestsTheAccountBalanceFromRepository()
        {
            // Test should only care about behavioural action of making a request 
            const int nonZeroBalance = 1;
            Mock.Get(_accountRepository).Setup(x => x.GetBalance())
                .Returns(nonZeroBalance);
            
            //Act
            var balance = _teller.CheckBalance();
            //Assert
            Assert.That(balance, Is.EqualTo(nonZeroBalance),
                "Checking the balance should return the one recieved from the repository.");
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
                 "The Teller should forward the process transaction request to the repository.");
        }

    
    }
}
    
