using System;
using LogAnExt;

namespace LogAn5
{
    public class LogAnalyzer
    {
        private IWebService service;
        public LogAnalyzer(IWebService service)
        {
            this.service = service;
        }
        public void Analyze(string fileName)
        {
            // service won't be called every time,
            // we need a way to test if it was called
            if (fileName.Length < 8)
            {
                service.LogError(string.Format("Filename too short:{0}", fileName));
            }
        }
    }
}
