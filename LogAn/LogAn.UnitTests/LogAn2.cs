using NUnit.Framework;
using LogAnExt;
using LogAn2;

namespace Tests2
{
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public bool IsValid(string fileName)
        {
            return WillBeValid;
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
            // passed fake implementation of external dependency, test is isolated.
            LogAnalyzer analyzer = new LogAnalyzer();
            analyzer.Manager = myFakeManager;

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }
    }
}
