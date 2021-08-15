using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SearchEngineEfCore
{
    public class DatabaseFunctions : IDatabase
    {
        
        public List<Posting> QueryListOfPostings(string word)
        {
            using (var context = new SearchEngineContext())
            {
                var result = context.Words
                    .Include(w => w.Postings)
                    .SingleOrDefault(w => w.Word == word);
                return result?.Postings ?? new List<Posting>();
            }
        }
        private List<WordModel> CreateWordModels(List<string> words)
        {
            var result = new List<WordModel>();
            
            using (var context = new SearchEngineContext())
            {
                foreach (var queryWord in from word in words let queryWord = context.Words
                    .SingleOrDefault(w => w.Word == word) where queryWord == null select new WordModel()
                {
                    Word = word
                })
                {
                    context.Words.Add(queryWord);
                }

                try
                {
                    context.SaveChanges();
                    result.AddRange(words
                        .Select(word => context.Words
                            .SingleOrDefault(w => w.Word == word)));
    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
            return result;
        }

        public bool InsertWordsOfDoc(string docName, List<string> words)
        {
            var temp = CreateWordModels(words);
            using (var context = new SearchEngineContext())
            {
                var posting = context.Postings
                    .SingleOrDefault(p => p.DocName == docName);
                if (posting != null) return false;
                posting = new Posting()
                {
                    DocName = docName
                };
                context.Postings.Add(posting);
                try
                {
                    context.SaveChanges();
                    posting = context.Postings
                        .Include(p => p.Words)
                        .SingleOrDefault(p => p.DocName == docName);
                    if (posting != null) posting.Words = CreateWordModels(words);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }
    }
}