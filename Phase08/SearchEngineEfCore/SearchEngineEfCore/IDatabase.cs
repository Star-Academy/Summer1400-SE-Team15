using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface IDatabase
    {
        bool InsertWordsOfDoc(string docName, List<string> words);
        List<Posting> QueryListOfPostings(string word);
    }
}