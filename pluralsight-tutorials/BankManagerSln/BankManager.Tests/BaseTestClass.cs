using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{

    public abstract class BaseTestClass
    {
        [SetUp]
        public virtual void Setup()
        {
            Logging.Logger = Mock.Of<ILogger>();
        }
    }

}
