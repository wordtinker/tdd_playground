using NUnit.Framework;
using NSubstitute;
using LogAnWithNSub;
using System;

namespace NUnit.Tests1
{
    [TestFixture]
    class NSub
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>(); // Creates a mock object
            LogAnalyzer analyzer = new LogAnalyzer(logger);

            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

            logger.Received().LogError("Filename too short: a.txt");
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger
                .When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });
            var analyzer = new LogAnalyzer2(stubLogger, mockService);

            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            mockService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }
    }
}
