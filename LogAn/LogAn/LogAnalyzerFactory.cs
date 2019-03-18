using System;
using LogAnExt;

namespace LogAn3
{
    // note internal here, fabric is protected from faking
    // in the production code
    internal static class ExtensionManagerFactory
    {
        private static IExtensionManager customManager = null;
        internal static IExtensionManager Create()
        {
            var mgr = customManager ?? (customManager = new FileExtensionManager());
            return mgr;
        }
        internal static void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
    }

    public class LogAnalyzer
    {
        private IExtensionManager manager;

        public LogAnalyzer()
        {
            // a step towards DI container
            manager = ExtensionManagerFactory.Create();
        }

        public bool IsValidLogFileName(string fileName)
        {
            return manager.IsValid(fileName);
        }
    }
}
