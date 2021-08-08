using System;
using System.Collections.Generic;


namespace readingJson
{
    class Program
    {
        private const string _studentFilePath = "../../../resources/Students.json";
        private const string _scoreFilePath = "../../../resources/Scores.json";

        static void Main(string[] args)
        {
            var fileReader = new FileReader();
            
            var studentSerializer = new StudentSerializer();
            var scoreSerializer = new ScoreSerializer();

            var students = studentSerializer.Deserialize(fileReader.GetFileContent(_studentFilePath));
            var scores = scoreSerializer.Deserialize(fileReader.GetFileContent(_scoreFilePath));

            var averageCalculator = new AverageCalculator(scores, students);
            PrintAverages(averageCalculator,3);

        }

        private static void PrintAverages(AverageCalculator averageCalculator, int numberOfStudents)
        {
            averageCalculator.GetTopNStudents(numberOfStudents).ForEach((student) => 
                Console.WriteLine(student.StudentNumber + " " + student.FirstName + " " + student.LastName + " " +
                                  student.Average));
        }
    }
}
