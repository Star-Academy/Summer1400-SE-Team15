using System;
using System.Collections.Generic;
using System.Text.Json;


namespace readingJson
{
    class ScoreSerializer
    {
        public List<Score> Deserialize(String jsonString)
        {
            return JsonSerializer.Deserialize<List<Score>>(jsonString);
        }
    }
}
