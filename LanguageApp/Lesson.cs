using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    class Lesson //generates questions for each lesson, marks user's answers, gets lesson's text
    {

        private static SqlConnection connection;
        private static string connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString;

        //Gets the number of practice questions (5) needed for the practice form, or 10 questions for the test form, in random order, with none repeating
        public static List<string> GenQuestions(List<int> randomIndexes, string lessonType)
        {
            List<string> questions = new List<string>();

            string query = $"SELECT question FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";

            //Gets the questions from the database based on if it's a vocabulary or grammar lesson, or a test, and what lesson number it is
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", MainForm.lesson);
                command.Parameters.AddWithValue("@type", lessonType);

              
                SqlDataReader reader = command.ExecuteReader();

                //Adds each question to a list, only for the first index of the reader because otherwise the list of questions will repeat
                while (reader.Read())
                {
                    questions.Add((string)reader[0]); 
                }
                reader.Close();
               

            }
            connection.Close();

            //new list for the practice questions, so that it can add them in random order
            List<string> selectedQues = new List<string>();   
            foreach (int index in randomIndexes)
            {
                selectedQues.Add(questions[index]);
            }

            return selectedQues;
        }

        //gets total number of vocabulary or grammar questions for a lesson
        public static int QuestionsNumber(string lessonType)
        {
            int count = 0;
            string query = $"SELECT Count(*) FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", MainForm.lesson);
                command.Parameters.AddWithValue("@type", lessonType);

                 count = (int)command.ExecuteScalar();

            }
            connection.Close();
            return count;
        }
        
        //Gets a list of all the German words from the database
        public static List<string> GetGermanWords()
        {
            List<string> germanWords = new List<string>();

            string query = $"SELECT answer FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";
            
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", MainForm.lesson);
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

        //Once all the German words are pulled from the database, they are sorted into a string so that a vocabulary list can be displayed on the forms.
        public static string GermanWordsList()
        {
            //Adds each German word one by one to string.
            string list = "";
            foreach (string germanWord in GetGermanWords())
            {
                list += germanWord + "\n";
            }

            return list;
        }

        //gets a specific German word for a lesson. Method used to get a German word for a single button the Vocab form
        public static string GermanWord(int index)
        {
            return GetGermanWords()[index];
        }

        //Following three methods is the same as the three above, but for English. 
        public static List<string> GetEnglishWords()
        {
            List<string> englishWords = new List<string>();

            string query = $"SELECT question FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", MainForm.lesson);
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
        public static string EnglishWordsList()
        {
            string list = "";
            foreach (string englishWord in GetEnglishWords())
            {
                list += englishWord + "\n";
            }

            return list;
        }

        public static string EnglishWord(int index)
        {
            return GetEnglishWords()[index];
        }

        //Gets answers for the questions from the same lesson
        public static List<string> GenAnswers(List<int> randomIndex, string type)
        {
            List<string> answers = new List<string>();

            string query = $"SELECT answer FROM QuestionsTable WHERE LessonID = @LessonID AND type = @type";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {

                connection.Open();
                command.Parameters.AddWithValue("@LessonID", MainForm.lesson);
                command.Parameters.AddWithValue("@type", type);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    answers.Add((string)reader[0]);
                }
                reader.Close();


            }
            connection.Close();

            //Because randomindexes list received is the same as the list used in GenQuestions(), the answers and questions lists are linked - they'll be marked in the right order
            List<string> selectedAns = new List<string>();

            foreach (int index in randomIndex)
            {
                selectedAns.Add(answers[index]);

            }


            return selectedAns;
        }

        //marks the questions for any type
        public static bool MarkQuestions(int index, string userAnswer, List<string> chosenAnswers)
        {
            if (userAnswer.Equals(chosenAnswers[index])) //If the user answer matches the correct answer then  
            {
                return true; //it will be true 
            }

            //don't need else statement
            return false;
        }

        //Gets the text for a specific lesson, which explains a new grammar concept
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
