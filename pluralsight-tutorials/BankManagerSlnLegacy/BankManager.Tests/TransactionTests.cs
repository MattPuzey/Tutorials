using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public abstract class TransactionTests
    {
        public abstract Transaction GetTransactionWith(int baseAmount);

        [Test]
        public void BaseAmount_AmountPassedToConstructor_ReturnsSameAmount()
        {
            const int nonZeroAmount = 5;
            var transaction = GetTransactionWith(nonZeroAmount);

            Assert.That(transaction.BaseAmount, Is.EqualTo(nonZeroAmount),
                "The base amount of a transaction should be the same as the amount passed into the constructor.");
        }
    }
}