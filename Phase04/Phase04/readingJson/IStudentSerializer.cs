using System;
using System.Collections.Generic;

namespace readingJson
{
    internal interface IStudentSerializer
    {
        List<Student> Deserialize(String jsonString);
    }
}