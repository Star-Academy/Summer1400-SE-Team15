using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace SearchEngineApi
{
    public class InvertedIndex : IInvertedIndex
    {
        private static IDatabase _database;
        private static IConfiguration _configuration;
        private static readonly Regex NonCharRegex = new Regex("[^a-zA-Z0-9 -]");
        
        public InvertedIndex(IDatabase databaseClass,IConfiguration configuration)
        {
            _database = databaseClass;
            _configuration = configuration;
        }
        
        private static List<string> GetNormalizedString(string input)
        {
            var replace = NonCharRegex.Replace(input, " ");
            return replace.ToLower()
                .Split(' ')
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();
        }

        private static HashSet<string> GetStopWords()
        {
            return new HashSet<string>(File.ReadAllLines(_configuration["stopwords_path"])); 
        }

        private static List<string> RemoveStopWords(string input)
        {
            var stopWords = GetStopWords();
            var words = GetNormalizedString(input);
            return words
                .Where(word => !stopWords.Contains(word))
                .ToList();
        }
        
        public bool AddWordsToDatabase(string docName, string words)
        {
            var wordsList = RemoveStopWords(words);
            return _database.InsertWordsOfDoc(docName,wordsList);
        }
        
        public HashSet<string> GetResultListByWord(string word)
        {
            return _database.QueryListOfPostings(word)
                                        .Select(w => w.DocName)
                                        .ToHashSet();
        }
    }
}