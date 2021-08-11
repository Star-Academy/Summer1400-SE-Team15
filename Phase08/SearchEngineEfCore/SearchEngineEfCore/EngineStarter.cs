
namespace SearchEngineEfCore
{
    public class EngineStarter : IEngineStarter
    {
        private readonly IInputScanner _inputScanner;
        private readonly ISearchEngine _searchEngine;
        private const string ExitQuery = "--exit";
        

        public EngineStarter(IInputScanner inputScanner , ISearchEngine searchEngine)
        {
            this._inputScanner = inputScanner;
            this._searchEngine = searchEngine;
        }
        
        public void Start()
        {
            while (true)
            {
                var query = _inputScanner.Scan();
                if (query.Equals(ExitQuery)) break;
                var results = _searchEngine.GetResult(query);
                _inputScanner.Print(results);
            }
        }
    }
}