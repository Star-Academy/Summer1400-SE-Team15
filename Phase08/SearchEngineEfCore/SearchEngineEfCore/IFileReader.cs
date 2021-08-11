using System;
using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface IFileReader
    {
        List<Tuple<string, string>> GetFilesContents();
        HashSet<string> GetStopWords();
    }
}