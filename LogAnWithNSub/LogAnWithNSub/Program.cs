using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnWithNSub
{
    public interface ILogger
    {
        void LogError(string message);
    }

    public interface IWebService
    {
        void Write(string message);
    }

    public class LogAnalyzer
    {
        private ILogger logger;

        public LogAnalyzer(ILogger logger)
        {
            this.logger = logger;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string filename)
        {
            if (filename.Length < MinNameLength)
            {
                logger.LogError(string.Format("Filename too short: {0}", filename));
            }
        }
    }

    public class LogAnalyzer2
    {
        private ILogger logger;
        private IWebService webService;


        public LogAnalyzer2(ILogger logger, IWebService webService)
        {
            this.logger = logger;
            this.webService = webService;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string filename)
        {
            if (filename.Length < MinNameLength)
            {
                try
                {
                    logger.LogError(string.Format("Filename too short: {0}", filename));
                }
                catch (Exception e)
                {
                    webService.Write("Error From Logger: " + e);

                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
