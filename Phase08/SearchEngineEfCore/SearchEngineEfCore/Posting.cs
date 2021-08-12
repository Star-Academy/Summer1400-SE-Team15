using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchEngineEfCore
{
    public class Posting
    {
        [Key]
        public int Id { get; set; }
        public string DocName { get; set; }
        public List<WordModel> Words { get; set; }
    }
}