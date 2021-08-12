using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SearchEngineEfCore
{
    public class DatabaseClass : IDatabase
    {
        private int QueryWord(string word)
        {
            using (var context = new SearchEngineContext())
            {
                var result = context.Words
                    .SingleOrDefault(w => w.Word == word);
                return result?.WordId ?? -1;
            }
        }

        private int QueryPosting(string docName)
        {
            using (var context = new SearchEngineContext())
            {
                var result = context.Postings
                    .SingleOrDefault(p => p.DocName == docName);
                return result?.Id ?? -1;
            }
        }

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

        public void InsertToWords(string word)
        {
            if (QueryWord(word) != -1) return;
            using (var context = new SearchEngineContext())
            {
                var wrd = new WordModel()
                {
                    Word = word
                };
                context.Words.Add(wrd);
                context.SaveChanges();
            }
        }

        public void InsertToPostings(string docName, string word)
        {
            using (var context = new SearchEngineContext())
            {
                var wrd = context.Words
                    .SingleOrDefault(w => w.Word == word);
                if (wrd == null) return;
                var pos = context.Postings
                    .Include(p => p.Words)
                    .SingleOrDefault(p => p.DocName == docName);
                if (pos == null)
                {
                    pos = new Posting()
                    {
                        DocName = docName,
                        Words = new List<WordModel>() {wrd}
                    };
                    context.Postings.Add(pos);
                }
                else
                {
                    if (!pos.Words.Contains(wrd))
                    {
                        pos.Words.Add(wrd);
                    }
   
                }
                context.SaveChanges();
            }
        }
    }
}