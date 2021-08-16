using System;
using Microsoft.AspNetCore.Mvc;

namespace SearchEngineApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class Query : ControllerBase
    {
        private static ISearchEngine _searchEngine;

        public Query(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }
        [HttpGet]
        public IActionResult Get([FromQuery(Name = "q")] string query)
        {
            if (query == null) return BadRequest();
            var result = _searchEngine.GetResult(query);
            if (result.Count != 0)
            {
                return Ok(result);
            }
            return NoContent();
        }
        
        
        
    }
}