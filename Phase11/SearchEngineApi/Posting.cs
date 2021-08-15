using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Asp.net_Core_Test;

namespace SearchEngineApi
{
    public class Posting
    {
        [Key]
        public int Id { get; set; }
        public string DocName { get; set; }
        public List<WordModel> Words { get; set; }
    }
}