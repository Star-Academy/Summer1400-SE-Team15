using System;
using System.Collections.Generic;
using System.Text.Json;


namespace readingJson
{
    internal class StudentSerializer : IStudentSerializer
    {
        public List<Student> Deserialize(String jsonString)
        {
            return JsonSerializer.Deserialize<List<Student>>(jsonString);
        }
    }
}
