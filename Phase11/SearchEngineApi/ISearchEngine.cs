using System.Collections.Generic;

namespace SearchEngineApi
{
    public interface ISearchEngine
    {
        HashSet<string> GetResult(string query);
        
    }
}