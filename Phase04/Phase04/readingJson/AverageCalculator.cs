using System.Collections.Generic;
using System.Linq;

namespace readingJson
{
    internal class AverageCalculator : IAverageCalculator
    {
        private List<Score> _scores;
        private List<Student> _students;
        private List<StudentAverage> _studentAverages;
        public AverageCalculator(List<Score> Scores, List<Student> Students)
        {
            this._scores = Scores;
            this._students = Students;
            _studentAverages = Calculate();
        }

        private List<StudentAverage> Calculate()
        {
            var query = from score in _scores
                         group score.LessonScore by score.StudentNumber into average
                         join student in _students on average.Key equals student.StudentNumber
                         select new StudentAverage { 
                             StudentNumber = student.StudentNumber, 
                             FirstName = student.FirstName, 
                             LastName = student.LastName, 
                             Average = average.Average() 
                         };

            return query.ToList();
        }

        public List<StudentAverage> GetTopNStudents(int n)
        {
            return _studentAverages.OrderByDescending(student => student.Average).Take(n).ToList();
        }
    }
}
