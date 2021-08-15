using System;
using System.Collections.Generic;
using System.Linq;
using Asp.net_Core_Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SearchEngineApi
{
    public class DatabaseFunctions : IDatabase
    {
        private static IConfiguration _configuration;

        public DatabaseFunctions(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public List<Posting> QueryListOfPostings(string word)
        {
            using (var context = new SearchEngineContext(_configuration))
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
            
            using (var context = new SearchEngineContext(_configuration))
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
            using (var context = new SearchEngineContext(_configuration))
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