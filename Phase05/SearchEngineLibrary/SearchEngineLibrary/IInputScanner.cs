using System.Collections.Generic;

namespace SearchEngineLibrary
{
    public interface IInputScanner
    {
        string Scan();

        void Print(HashSet<string> output);
    }
}