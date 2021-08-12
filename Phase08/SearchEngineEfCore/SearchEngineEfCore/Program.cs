namespace SearchEngineEfCore
{
    class Program
    {
        private static readonly string _folderPath = "../../../EnglishData";
        private static readonly string _stopWordsPath = "../../../utilities/stopWords.txt";
        static void Main(string[] args)
        {
            IFileReader fileReader = new FileReader(_folderPath, _stopWordsPath);
            IDatabase database = new DatabaseClass();
            IInvertedIndex invertedIndex = new InvertedIndex(fileReader, database);
            IInputScanner inputScanner = new InputScanner();
            ISearchEngine searchEngine = new SearchEngine(invertedIndex);
            IEngineStarter engineStarter = new EngineStarter(inputScanner, searchEngine);
            engineStarter.Start();
            
        }
    }
}