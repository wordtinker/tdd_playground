using LogAnExt;

namespace LogAn2
{
    public class LogAnalyzer
    {
        // More relaxed than ctor approach, dependency is optional
        // dependency is passed into prop
        public IExtensionManager Manager { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            return Manager.IsValid(fileName);
        }
    }
}
