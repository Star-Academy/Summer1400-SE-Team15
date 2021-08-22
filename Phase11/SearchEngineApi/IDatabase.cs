using System;
using System.Collections.Generic;

namespace SearchEngineApi
{
    public interface IDatabase : IDisposable
    {
        bool InsertWordsOfDoc(string docName, List<string> words);
        List<Posting> QueryListOfPostings(string word);
    }
}