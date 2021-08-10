using System;
using System.Collections.Generic;

namespace SearchEngineLibrary
{
    public interface IFileReader
    {
        List<Tuple<string, string>> GetFilesContents();
        List<string> GetStopWords();
    }
}