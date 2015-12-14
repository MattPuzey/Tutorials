using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public class SimpleTransactionTests : TransactionTests
    {
        public override Transaction GetTransactionWith(int baseAmount)
        {
            return new SimpleTransaction(baseAmount);
        }

        [Test]
        public void CalculateTotalTransaction_AmountProvided_ReturnsSameAmount()
        {
            const int baseAmount = 100;
            var simpleTransaction = new SimpleTransaction(baseAmount);

            var totalTransaction = simpleTransaction.CalculateTotalTransaction();

            Assert.That(totalTransaction, Is.EqualTo(baseAmount), 
                "Calculated transaction should be equal to the base amount.");
        }
    }
}
