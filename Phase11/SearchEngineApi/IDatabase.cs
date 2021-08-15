using System.Collections.Generic;
using Asp.net_Core_Test;

namespace SearchEngineApi
{
    public interface IDatabase
    {
        bool InsertWordsOfDoc(string docName, List<string> words);
        List<Posting> QueryListOfPostings(string word);
    }
}