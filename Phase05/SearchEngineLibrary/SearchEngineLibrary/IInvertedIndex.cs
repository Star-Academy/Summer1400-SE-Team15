using System.Collections.Generic;

namespace SearchEngineLibrary
{
    public interface IInvertedIndex
    {
        HashSet<string> GetResultListByWord(string word);
    }
}