using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface IDatabase
    {
        int QueryWord(string word);
        int QueryPosting(string docName);
        List<WordModel> QueryListOfWords(string docName);
        List<Posting> QueryListOfPostings(string word);
        void InsertToWords(string word);
        void InsertToPostings(string docName, string word);
    }
}