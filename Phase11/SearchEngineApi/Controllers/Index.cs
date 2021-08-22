using System;
using Microsoft.AspNetCore.Mvc;

namespace SearchEngineApi.Controllers
{
    [ApiController]
    [Route("api/v1/index")]
    public class Index : ControllerBase
    {
        private static IInvertedIndex _invertedIndex;

        public Index(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }
        
        [HttpPost]
        public IActionResult Post(Doc doc)
        {
            try
            {
                if (_invertedIndex.AddWordsToDatabase(doc.DocName, doc.DocContent))
                {
                    return Ok();
                }
                return BadRequest("Coulden't index the document");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}