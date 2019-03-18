using System;

namespace LogAnExt
{
    public interface IExtensionManager
    {
        bool IsValid(string fileName);
    }

    /// <summary>
    /// Assume that this class is externally depends on filesystem, threading, etc
    /// </summary>
    public class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
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
