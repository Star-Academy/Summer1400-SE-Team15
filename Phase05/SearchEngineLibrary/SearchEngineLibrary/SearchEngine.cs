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
            HashSet<string> result = new HashSet<string>();
            string modifiedQuery = GetModifiedQuery(query);

            List<string> andList = new List<string>();
            List<string> orList = new List<string>();
            List<string> excludeList = new List<string>();
            
            FillListsByQuery(modifiedQuery,andList,orList,excludeList);
            
            AddAndWordsToResult(result,andList);
            AddOrWordsToResult(result,orList);
            RemoveExcludeWordsFromResult(result,excludeList);

            return result;
        }
        
        private string GetModifiedQuery(string query)
        {
            return query.ToLower();
        }
        
        private void AddAndWordsToResult(HashSet<string> result, List<string> andList) 
        {
            foreach (string and in andList){
                if (!result.Any()){
                    result.UnionWith(_invertedIndex.GetResultListByWord(and));
                }else {
                    result.IntersectWith(_invertedIndex.GetResultListByWord(and));
                }
            }
        }
        
        private void AddOrWordsToResult(HashSet<string> result, List<string> orList) 
        {
            foreach (string or in orList){
                result.UnionWith(_invertedIndex.GetResultListByWord(or));
            }
        }
        
        private void RemoveExcludeWordsFromResult(HashSet<string> result, List<string> excludeList) {
            foreach (string exclude in excludeList){
                result.ExceptWith(_invertedIndex.GetResultListByWord(exclude));
            }
        }

        private void FillListsByQuery(string query, List<string> andList, List<string> orList, List<string> excludeList)
        {
            foreach (string word in GetNormalizedString(query)){
                if(word[0]=='+'){
                    orList.Add(word.Substring(1));
                }else if (word[0]=='-'){
                    excludeList.Add(word.Substring(1));
                }else {
                    andList.Add(word);
                }
            }
        }
        
        private string[] GetNormalizedString(string query)
        {
            return query.Split(" ");
        }
        
    }
    
}

