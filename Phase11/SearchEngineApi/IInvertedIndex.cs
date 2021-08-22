using System.Collections.Generic;

namespace SearchEngineApi
{
    public interface IInvertedIndex
    {
        bool AddWordsToDatabase(string docName, string words);
        HashSet<string> GetResultListByWord(string word);
    }
}