using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace LanguageApp
{
    class User
    {
        // Object properties
        private string username;
        private int id;
      

        SqlConnection connection;
        string connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString;

        // Object methods

        // Constructor
        public User(int i, string n)
        {

            username = n;
            id = i;
        

        }

        // Get Methods
        public string GetName()
        {
            return username;
        }

        public int GetId()
        {
            return id;
        }
      
        //Calculates average score for a single lesson
        public float AvgScore(int lesson)
        {
            float avgScore = 0;
            int totalScore = 0;
            int attempts = 0;

            string query = "SELECT Count(*) FROM TestTable WHERE UserID = @UserID AND LessonID = @LessonID"; //Gets number of tests attempted for one lesson


            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@UserID", id);
                command.Parameters.AddWithValue("@LessonID", lesson);
                attempts = (int)command.ExecuteScalar();

                if (attempts == 0) //if there have been no test attempts then average score is automatically 0
                {
                    return avgScore;
                }
                else  //if the test has been attempted, then each attempt's score is collected to get the total score, which is then divided by number of attempts to calculate the average score
                {
                    string queryTwo = "SELECT SUM (score) FROM TestTable WHERE UserID = @UserID AND LessonID = @LessonID";

                    using (SqlCommand commandTwo = new SqlCommand(queryTwo, connection))
                    {
                        commandTwo.Parameters.AddWithValue("@UserID", id);
                        commandTwo.Parameters.AddWithValue("@LessonID", lesson);

                        totalScore = (int)commandTwo.ExecuteScalar();
                        return avgScore = (totalScore / attempts) * 10;
                    }
                }


            }


        }

        //gets total points of user by adding up the total score for every lesson
        public int TotalPoints()
        {


            string queryy = "SELECT Count (*) FROM TestTable WHERE UserID = @UserID"; //checks to see if the user has attempted any tests first, because if it attempts to calculate the sum without there being any scores for the user,
            //there will be an exception unhandled message
            int count = 0;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand commandd = new SqlCommand(queryy, connection))
            {
                connection.Open();

                commandd.Parameters.AddWithValue("@UserID", id);
                count = (int)commandd.ExecuteScalar();


            }
            connection.Close();

            int totalPoints = 0;

            if (count == 0)
            {
                return totalPoints;
            }
            else //if there are test attempts stored for that user, then the sum of the scores will be received, which equals the total points
            {
                string query = "SELECT SUM (score) FROM TestTable WHERE UserID = @UserID";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@UserID", id);

                    totalPoints = (int)command.ExecuteScalar();
                }


                return totalPoints;
            }
        }
    }
}
