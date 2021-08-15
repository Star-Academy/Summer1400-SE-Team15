using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface IInvertedIndex
    {
        HashSet<string> GetResultListByWord(string word);
    }
}