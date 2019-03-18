using NUnit.Framework;
using LogAnExt;
using LogAn4;

namespace Tests4
{
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public bool IsValid(string fileName)
        {
            return WillBeValid;
        }
    }

    internal class TestableLogAnalyzer : LogAnalyzer
    {
        private readonly IExtensionManager manager;
        public TestableLogAnalyzer(IExtensionManager manager)
        {
            this.manager = manager;
        }
        protected internal override IExtensionManager GetManager()
        {
            // implementation is faked here
            return manager;
        }
    }

    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager
            {
                WillBeValid = false
            };
            TestableLogAnalyzer logan = new TestableLogAnalyzer(myFakeManager);

            bool result = logan.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }
    }
}
