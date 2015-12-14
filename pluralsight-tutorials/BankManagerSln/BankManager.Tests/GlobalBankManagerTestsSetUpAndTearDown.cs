using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{
    [SetUpFixture]
    public class GlobalBankManagerTestsSetUpAndTearDown
    {
        public static Mock<ILogger> LoggerFake { get; private set; }   
        //[SetUp]
        public void BankManagerTestsSetup()
        {
            var logger = Mock.Of<ILogger>();
            LoggerFake = Mock.Get(logger);
            Logging.Logger = Mock.Of<ILogger>();
        }
    }
}
