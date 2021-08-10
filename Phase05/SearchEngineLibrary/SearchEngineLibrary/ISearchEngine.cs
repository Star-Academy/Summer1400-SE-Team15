using System.Collections.Generic;

namespace SearchEngineLibrary
{
    public interface ISearchEngine
    {
        HashSet<string> GetResult(string query);
        
    }
}