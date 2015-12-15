using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{
    public abstract class BaseTestClass
    {
        [SetUp]
        public virtual void SetUp()
        {
            Logging.Logger = Mock.Of<ILogger>();
        }
    }
}