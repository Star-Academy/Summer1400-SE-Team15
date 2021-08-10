using System;
using System.Collections.Generic;

namespace readingJson
{
    internal interface IScoreSerializer
    {
        List<Score> Deserialize(String jsonString);
    }
}