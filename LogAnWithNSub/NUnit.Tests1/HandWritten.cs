using NUnit.Framework;
using LogAnWithNSub;
using System;

namespace NUnit.Tests1
{
    class FakeLogger : ILogger
    {
        public string LastError;
        public void LogError(string message)
        {
            LastError = message;
        }
    }

    class FakeWebService : IWebService
    {
        public string MessageToWebService;
        public void Write(string message)
        {
            MessageToWebService = message;
        }
    }

    class FakeLogger2 : ILogger
    {
        public Exception WillThrow = null;
        public string LoggerGotMessage = null;
        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if (WillThrow != null)
            {
                throw WillThrow;
            }
        }
    }

    [TestFixture]
    public class HandWritten
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            FakeLogger logger = new FakeLogger();
            LogAnalyzer analyzer = new LogAnalyzer(logger);

            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

            StringAssert.Contains("too short", logger.LastError);
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            FakeWebService mockWebService = new FakeWebService();
            FakeLogger2 stubLogger = new FakeLogger2();
            stubLogger.WillThrow = new Exception("fake exception");
            var analyzer2 = new LogAnalyzer2(stubLogger, mockWebService);

            analyzer2.MinNameLength = 8;
            string tooShortFileName = "abc.ext";
            analyzer2.Analyze(tooShortFileName);

            Assert.That(mockWebService.MessageToWebService, Does.Contain("fake exception"));
        }
    }
}
