using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchEngineLibrary
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly Dictionary<string, HashSet<string>> _dataDictionary;

        public InvertedIndex(IFileReader fileReader)
        {
            _dataDictionary = Tokenize(fileReader.GetFilesContents(), fileReader.GetStopWords());
        }

        private static Dictionary<string, HashSet<string>> Tokenize(List<Tuple<string, string>> docs, List<string> stopWords)
        {
            Dictionary<string, HashSet<string>> output = new Dictionary<string, HashSet<string>>();
            foreach (var doc in docs)
            {
                AddWordsToDictionary(output,doc.Item1,RemoveStopWords(doc.Item2,stopWords));
            }

            return output;
        }

        private static string RemoveStopWords(string input, List<string> stopWords)
        {
            var content = new StringBuilder(input);
            foreach (var word in stopWords)
            {
                content.Replace(word, "");
            }

            return content.ToString();
        }

        private static void AddWordsToDictionary(Dictionary<string, HashSet<string>> outputDictionary, string docName,
            string words)
        {
            var wordsList = GetNormalizedString(words);
            foreach (var word in wordsList)
            {
                outputDictionary.TryAdd(word, new HashSet<string>());
                outputDictionary[word].Add(docName);
            }
            
        }


        private static List<string> GetNormalizedString(string input)
        {
            return input.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        public HashSet<string> GetResultListByWord(string word)
        {
            _dataDictionary.TryGetValue(word, out var output);
            return output;
        }
    }
}