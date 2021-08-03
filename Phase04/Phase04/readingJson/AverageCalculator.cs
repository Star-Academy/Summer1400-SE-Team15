using System.Collections.Generic;
using System.Linq;

namespace readingJson
{
    class AverageCalculator
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
            List<StudentAverage> list = new List<StudentAverage>();

            var query = from score in _scores
                         group score.LessonScore by score.StudentNumber into average
                         join student in _students on average.Key equals student.StudentNumber
                         select new { 
                             StudentNumber = student.StudentNumber, 
                             FirstName = student.FirstName, 
                             LastName = student.LastName, 
                             Average = average.Average() 
                         };


            foreach (var v in query)
            {
                list.Add(new StudentAverage
                    {
                        StudentNumber = v.StudentNumber,
                        FirstName = v.FirstName,
                        LastName = v.LastName,
                        Average = v.Average
                    }
                );
            }

            return list;
        }

        public List<StudentAverage> GetTopThreeStudents()
        {
            return _studentAverages.OrderByDescending(n => n.Average).Take(3).ToList();
        }
    }
}
