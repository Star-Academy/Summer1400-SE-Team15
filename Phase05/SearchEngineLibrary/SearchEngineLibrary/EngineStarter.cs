using System.Collections.Generic;

namespace SearchEngineLibrary
{
    public class EngineStarter : IEngineStarter
    {
        private readonly IInputScanner _inputScanner;
        private readonly ISearchEngine _searchEngine;
        private const string _exitQuery = "--exit";
        

        public EngineStarter(IInputScanner inputScanner , ISearchEngine searchEngine)
        {
            this._inputScanner = inputScanner;
            this._searchEngine = searchEngine;
        }
        
        public void Start()
        {
            while (true)
            {
                string query = _inputScanner.Scan();
                if (query.Equals(_exitQuery)) break;
                HashSet<string> results = _searchEngine.GetResult(query);
                _inputScanner.Print(results);
            }
        }
    }
}