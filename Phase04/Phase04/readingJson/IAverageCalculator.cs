using System.Collections.Generic;

namespace readingJson
{
    internal interface IAverageCalculator
    {
        List<StudentAverage> GetTopNStudents(int n);
    }
}