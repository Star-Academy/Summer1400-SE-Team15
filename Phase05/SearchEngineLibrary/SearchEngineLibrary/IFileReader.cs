using System;
using System.Collections.Generic;

namespace SearchEngineLibrary
{
    public interface IFileReader
    {
        public List<Tuple<string, string>> GetFilesContents();
        public List<string> GetStopWords();
    }
}