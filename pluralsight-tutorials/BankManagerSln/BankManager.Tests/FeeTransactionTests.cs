using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public class FeeTransactionTests : TransactionTests
    {

        public override Transaction GetTransactionWith(int baseAmount)
        {
            return GetTransactionWith(baseAmount, 0);
        }

        public Transaction GetTransactionWith(int baseAmount, int fee)
        {
            return new FeeTransaction(baseAmount, fee);
        }

        [Test]
        public void CalcualteTotalTransaction_AmountAndFeeProvided_ReturnsAmountMinusFee()
        {
            const int baseAmount = 100;
            const int fee = 5;
            var feeTransaction = new FeeTransaction(baseAmount, fee);

            var totalTransaction = feeTransaction.CalculateTotalTransaction();

            const int expectedTotalTransaction = baseAmount - fee;
            Assert.That(totalTransaction, Is.EqualTo(expectedTotalTransaction),
                "Calculated transaction should equal the base amount minus the fee.");
        }
    }
}
