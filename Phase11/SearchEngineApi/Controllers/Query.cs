using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SearchEngineApi;

namespace Asp.net_Core_Test.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class Query : ControllerBase
    {

        [HttpPost("index")]
        public IActionResult Post(Doc doc,[FromServices] IInvertedIndex invertedIndex)
        {
            try
            {
                if (invertedIndex.AddWordsToDatabase(doc.DocName, doc.DocContent))
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

        public IActionResult Get([FromServices] ISearchEngine searchEngine)
        {
            if (!HttpContext.Request.Query.TryGetValue("q", out var query)) return BadRequest();
            Console.WriteLine(HttpContext.Request.Query["q"]);
            var result = searchEngine.GetResult(query);
            if (result.Count != 0)
            {
                return Ok(result);
            }
            return NoContent();
        }
        
        
        
    }
}