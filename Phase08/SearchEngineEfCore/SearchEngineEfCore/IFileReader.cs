using System;
using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface IFileReader
    {
        List<FileTuple> GetFilesContents();
        HashSet<string> GetStopWords();
    }
}