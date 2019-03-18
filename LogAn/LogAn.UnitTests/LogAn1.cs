using NUnit.Framework;
using LogAnExt;
using LogAn1;

namespace Tests1
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
            LogAnalyzer analyzer = new LogAnalyzer(myFakeManager);

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }
    }
}
