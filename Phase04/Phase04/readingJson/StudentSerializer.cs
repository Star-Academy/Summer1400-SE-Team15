using System;
using System.Collections.Generic;
using System.Text.Json;


namespace readingJson
{
    class StudentSerializer
    {
        public List<Student> Deserialize(String jsonString)
        {
            return JsonSerializer.Deserialize<List<Student>>(jsonString);
        }
    }
}
