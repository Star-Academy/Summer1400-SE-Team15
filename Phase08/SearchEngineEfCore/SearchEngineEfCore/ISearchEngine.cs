using System.Collections.Generic;

namespace SearchEngineEfCore
{
    public interface ISearchEngine
    {
        HashSet<string> GetResult(string query);
        
    }
}