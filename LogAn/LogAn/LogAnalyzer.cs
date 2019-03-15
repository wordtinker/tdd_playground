using System;
// can be added to any file in the project
// or can be added to assemblyInfo.cs
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("LogAn.UnitTests")]

namespace LogAn
{
    public class LogAnalyzer
    {
        internal bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("filename has to be provided");
            }

            if (!fileName.EndsWith(
                ".SLF",
                StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}
