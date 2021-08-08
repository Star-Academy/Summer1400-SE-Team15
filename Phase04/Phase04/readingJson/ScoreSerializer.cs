using System;
using System.Collections.Generic;
using System.Text.Json;


namespace readingJson
{
    internal class ScoreSerializer : IScoreSerializer
    {
        public List<Score> Deserialize(String jsonString)
        {
            return JsonSerializer.Deserialize<List<Score>>(jsonString);
        }
    }
}
