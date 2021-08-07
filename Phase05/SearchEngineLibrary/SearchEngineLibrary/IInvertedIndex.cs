using System;
using System.Collections.Generic;

namespace SearchEngineLibrary
{
    public interface IInvertedIndex
    {
        public HashSet<string> GetResultListByWord(string word);
    }
}