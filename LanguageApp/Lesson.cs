using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    class Lesson
    {

        private static SqlConnection connection;
        private static string connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString;

        public static List<string> GenQuestions(List<int> randomIndex, int lesson, string lessonType)
        {
            List<string> questions = new List<string>();

            string query = $"SELECT question FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", lesson);
                command.Parameters.AddWithValue("@type", lessonType);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    questions.Add((string)reader[0]); 
                }
                reader.Close();
               

            }
            connection.Close();

            List<string> selectedQues = new List<string>();

            foreach (int index in randomIndex)
            {
                selectedQues.Add(questions[index]);

            }


            return selectedQues;
        }

        public static List<string> GetGermanWords(int lesson)
        {
            List<string> germanWords = new List<string>();

            string query = $"SELECT answer FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";
            
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", lesson);
                command.Parameters.AddWithValue("@type", "words");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    germanWords.Add((string)reader[0]);
                }
                reader.Close();


            }
            connection.Close();


            return germanWords;
        }

        public static List<string> GetEnglishWords(int lesson)
        {
            List<string> englishWords = new List<string>();

            string query = $"SELECT question FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", lesson);
                command.Parameters.AddWithValue("@type", "words");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    englishWords.Add((string)reader[0]);
                }
                reader.Close();


            }
            connection.Close();


            return englishWords;
        }

        public static List<string> GenAnswers(List<int> randomIndex, int lesson, string type)
        {
            List<string> answers = new List<string>();

            string query = $"SELECT answer FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", lesson);
                command.Parameters.AddWithValue("@type", type);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    answers.Add((string)reader[0]);
                }
                reader.Close();


            }
            connection.Close();

            List<string> selectedAns = new List<string>();

            foreach (int index in randomIndex)
            {
                selectedAns.Add(answers[index]);

            }


            return selectedAns;
        }


        public static bool MarkQuestions(int index, string userAnswer, List<string> chosenAnswers)
        {
            if (userAnswer.Equals(chosenAnswers[index]))
            {
                return true;
            }

            return false;
        }

 
        public static string GetLessonText(int lesson)
        {
            string lessonText = "";
            string query = "SELECT LessonText FROM LessonTable WHERE LessonID = @LessonID";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@LessonID", lesson);


                lessonText = (string)command.ExecuteScalar();

            }

            return lessonText;
        }

    }
}
