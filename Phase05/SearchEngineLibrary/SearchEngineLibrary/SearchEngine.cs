using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SearchEngineLibrary
{
    public class SearchEngine : ISearchEngine
    {
        private static IInvertedIndex _invertedIndex;
        
        public SearchEngine(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }

        public HashSet<string> GetResult(string query)
        {
            var result = new HashSet<string>();
            var modifiedQuery = GetModifiedQuery(query);

            var andList = new List<string>();
            var orList = new List<string>();
            var excludeList = new List<string>();
            
            FillListsByQuery(modifiedQuery,andList,orList,excludeList);
            
            AddAndWordsToResult(result,andList);
            AddOrWordsToResult(result,orList);
            RemoveExcludeWordsFromResult(result,excludeList);

            return result;
        }
        
        private static string GetModifiedQuery(string query)
        {
            return query.ToLower();
        }
        
        private static void AddAndWordsToResult(HashSet<string> result, List<string> andList) 
        {
            foreach (string and in andList){
                if (!result.Any()){
                    result.UnionWith(_invertedIndex.GetResultListByWord(and));
                }else {
                    result.IntersectWith(_invertedIndex.GetResultListByWord(and));
                }
            }
        }
        
        private static void AddOrWordsToResult(HashSet<string> result, List<string> orList) 
        {
            foreach (string or in orList){
                result.UnionWith(_invertedIndex.GetResultListByWord(or));
            }
        }
        
        private static void RemoveExcludeWordsFromResult(HashSet<string> result, List<string> excludeList) {
            foreach (string exclude in excludeList){
                result.ExceptWith(_invertedIndex.GetResultListByWord(exclude));
            }
        }

        private void FillListsByQuery(string query, List<string> andList, List<string> orList, List<string> excludeList)
        {
            foreach (string word in GetNormalizedString(query))
            {
                switch (word[0])
                {
                    case '+':
                        orList.Add(word.Substring(1));
                        break;
                    case '-':
                        excludeList.Add(word.Substring(1));
                        break;
                    default:
                        andList.Add(word);
                        break;
                }
            }
        }
        
        private static string[] GetNormalizedString(string query)
        {
            return query.Split(" ");
        }
        
    }
    
}

