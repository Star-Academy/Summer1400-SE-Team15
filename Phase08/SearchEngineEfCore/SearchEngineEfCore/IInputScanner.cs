using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface IInputScanner
    {
        string Scan();

        void Print(HashSet<string> output);
    }
}