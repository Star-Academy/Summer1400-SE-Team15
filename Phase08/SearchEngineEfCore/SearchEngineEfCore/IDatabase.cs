using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface IDatabase
    {
        public void InsertWordsOfDoc(string docName, List<string> words);
        public List<Posting> QueryListOfPostings(string word);
    }
}