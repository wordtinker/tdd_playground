using System;
using LogAnExt;

namespace LogAn1
{
    public class LogAnalyzer
    {
        private IExtensionManager manager;

        // Use ctor dependency injection not just for tests.
        public LogAnalyzer(IExtensionManager manager)
        {
            // external dependency is moved out of function under testing
            this.manager = manager;
        }

        public bool IsValidLogFileName(string fileName)
        {
            return manager.IsValid(fileName);
        }
    }
}
