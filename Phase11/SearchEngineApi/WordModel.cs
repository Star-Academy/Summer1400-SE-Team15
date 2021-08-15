using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchEngineApi
{
    public class WordModel
    {
        [Key]
        public int WordId { get; set; }
        public string Word { get; set; }
        public List<Posting> Postings { get; set; }
    }
}