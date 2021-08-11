using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchEngineEfCore
{
    public class InvertedIndex : IInvertedIndex
    {
        private static IDatabase _database;
        public InvertedIndex(IFileReader fileReader,IDatabase databaseClass)
        {
            _database = databaseClass;
            Tokenize(fileReader.GetFilesContents(), fileReader.GetStopWords());
        }

        private static void Tokenize(List<Tuple<string, string>> docs, HashSet<string> stopWords)
        {
            foreach (var doc in docs)
            {
                AddWordsToDatabase(doc.Item1,doc.Item2,stopWords);
            }
        }

        private static List<string> RemoveStopWords(string input, HashSet<string> stopWords)
        {
            var words = GetNormalizedString(input);
            return words
                .Where(word => !stopWords.Contains(word))
                .ToList();
        }

        private static void AddWordsToDatabase(string docName, string words, HashSet<string> stopWords)
        {
            var wordsList = RemoveStopWords(words,stopWords);
            var db = new DatabaseClass();
            foreach (var word in wordsList)
            {
                _database.InsertToWords(word);
                _database.InsertToPostings(docName,word);
            }
            
        }


        private static List<string> GetNormalizedString(string input)
        {
            return input.Split(' ')
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();
        }

        public HashSet<string> GetResultListByWord(string word)
        {
            return _database.QueryListOfPostings(word)
                                        .Select(w => w.DocName)
                                        .ToHashSet();
        }
    }
}