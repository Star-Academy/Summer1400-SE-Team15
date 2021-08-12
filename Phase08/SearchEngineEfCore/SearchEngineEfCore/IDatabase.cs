using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface IDatabase
    {
        List<Posting> QueryListOfPostings(string word);
        void InsertToWords(string word);
        void InsertToPostings(string docName, string word);
    }
}