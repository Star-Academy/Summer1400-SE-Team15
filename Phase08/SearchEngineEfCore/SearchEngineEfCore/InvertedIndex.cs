using System;
using System.Collections.Generic;
using System.Linq;

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

        private static void Tokenize(List<FileTuple> docs, HashSet<string> stopWords)
        {
            foreach (var doc in docs)
            {
                AddWordsToDatabase(doc.DocName,doc.DocContent,stopWords);
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
            _database.InsertWordsOfDoc(docName,wordsList);
        }


        private static List<string> GetNormalizedString(string input)
        {
            return input.Split(' ')
                .Distinct()
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