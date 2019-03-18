using NUnit.Framework;
using LogAnExt;
using LogAn5;

namespace Tests5
{
    public class FakeWebService : IWebService
    {
        // mock has state that will be checked after unit test
        public string LastError;
        public void LogError(string message)
        {
            LastError = message;
        }
    }

    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer log = new LogAnalyzer(mockService);
            string tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);
            // call the mock property and test mock
            // test is here, not in the mock object
            // there should be only one mock, several stubs are allowed
            StringAssert.Contains("Filename too short:abc.ext", mockService.LastError);
        }
    }
}
