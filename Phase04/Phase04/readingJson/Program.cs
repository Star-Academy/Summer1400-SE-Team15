using System;
using System.Collections.Generic;

namespace readingJson
{
    class Program
    {
        private const string _studentFilePath = "E:\\codeStar\\4\\Summer1400-SE-Team15\\Phase04\\Phase04\\readingJson\\resources\\Students.json";
        private const string _scoreFilePath = "E:\\codeStar\\4\\Summer1400-SE-Team15\\Phase04\\Phase04\\readingJson\\resources\\Scores.json";

        static void Main(string[] args)
        {
            FileReader studentReader = new FileReader(_studentFilePath);
            StudentSerializer studentSerializer = new StudentSerializer();

            FileReader scoreReader = new FileReader(_scoreFilePath);
            ScoreSerializer scoreSerializer = new ScoreSerializer();

            List<Student> students = studentSerializer.Deserialize(studentReader.GetFileContent());
            List<Score> scores = scoreSerializer.Deserialize(scoreReader.GetFileContent());

            foreach(Student st in students)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " " + st.StudentNumber);
            }

            foreach (Score sc in scores)
            {
                Console.WriteLine(sc.Lesson + " " + sc.LessonScore + " " + sc.StudentNumber);
            }

            Console.ReadKey();
            


        }
    }
}
