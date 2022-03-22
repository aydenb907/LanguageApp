using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    class User
    {
        // Object properties
        private int userID;
        private string userName;
        private string password;
        private List<int> scores;

        // Object methods

        // Constructor
        public User()
        {

        }

        // Adds a new user
        public void NewUser(string n, string p)
        {
            userName = n;
            password = p;

            // Add new user to database
        }

        public void CheckUserName()
        {
          
        }

        // finds user in database, by matching username to userID
        // gets userID and then scores
        public void FindUser(string n)
        {
            userName = n;

        }

        // Adds score to scores list for user that has been found in database
        public void UpdateScores()
        {

        }

        //Calculate average score for test in specific lesson
        public float CalculateAvgScore()
        {
            // Adds all scores in list together and divides by number of scores that are in the list
            return 0;
        }

        // Returns message: Score, average score, number of attempts
        public string Result()
        {
            return "";
        }




    }
}
