using System.Text.Json.Serialization;

namespace readingJson
{
    class Score
    {
        public int StudentNumber { set; get; }
        public string Lesson { set; get; }

        [JsonPropertyName("Score")]
        public double LessonScore { set; get; }
    }
}
