using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SearchEngineApi
{
    public class DatabaseFunctions : IDatabase
    {
        private readonly SearchEngineContext _context;

        public DatabaseFunctions(SearchEngineContext searchEngineContext)
        {
            _context = searchEngineContext;
        }
        
        public List<Posting> QueryListOfPostings(string word)
        {
            
            var result = _context.Words
                .Include(w => w.Postings)
                .SingleOrDefault(w => w.Word == word);
            return result?.Postings ?? new List<Posting>();
            
        }
        private List<WordModel> CreateWordModels(List<string> words)
        {
            var result = new List<WordModel>();
            
            foreach (var queryWord in from word in words let queryWord = _context.Words
                .SingleOrDefault(w => w.Word == word) where queryWord == null select new WordModel()
            {
                Word = word
            })
            {
                _context.Words.Add(queryWord);
            }
            try
            {
                _context.SaveChanges();
                result.AddRange(words
                    .Select(word => _context.Words
                        .SingleOrDefault(w => w.Word == word)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public bool InsertWordsOfDoc(string docName, List<string> words)
        {
            var posting = _context.Postings
                    .SingleOrDefault(p => p.DocName == docName);
            if (posting != null) return false;
            posting = new Posting()
            {
                DocName = docName
            };
            _context.Postings.Add(posting);
            try
            {
                _context.SaveChanges();
                posting = _context.Postings
                    .Include(p => p.Words)
                    .SingleOrDefault(p => p.DocName == docName);
                if (posting != null) posting.Words = CreateWordModels(words);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}