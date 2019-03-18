using System;
using LogAnExt;

namespace LogAn4
{

    public class LogAnalyzer
    {
        // NB virtual
        protected internal virtual IExtensionManager GetManager()
        {
            // we use concrete class here
            return new FileExtensionManager();
        }

        public bool IsValidLogFileName(string fileName)
        {
            return GetManager().IsValid(fileName);
        }
    }
}
