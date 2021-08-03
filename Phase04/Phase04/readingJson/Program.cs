using System;
using System.Collections.Generic;


namespace readingJson
{
    class Program
    {
        private const string _studentFilePath = "..\\..\\..\\resources\\Students.json";
        private const string _scoreFilePath = "..\\..\\..\\resources\\Scores.json";

        static void Main(string[] args)
        {
            FileReader studentReader = new FileReader(_studentFilePath);
            StudentSerializer studentSerializer = new StudentSerializer();

            FileReader scoreReader = new FileReader(_scoreFilePath);
            ScoreSerializer scoreSerializer = new ScoreSerializer();

            List<Student> students = studentSerializer.Deserialize(studentReader.GetFileContent());
            List<Score> scores = scoreSerializer.Deserialize(scoreReader.GetFileContent());

            AverageCalculator averageCalculator = new AverageCalculator(scores, students);
            averageCalculator.GetTopThreeStudents().ForEach((n) => Console.WriteLine(n.StudentNumber + " " + n.FirstName + " " + n.LastName + " " + n.Average));


            Console.ReadKey();
            


        }
    }
}
