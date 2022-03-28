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
       
        private string userName;
        private string password;
        private List<int> scores;
  
       

        // Object methods

        // Constructor
        public User(string n, string p, List<int> s)
        {
            userName = n;
            password = p;
            scores = s;
        }

        // Checks new user name isn't the same as others
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
        public void UpdateScores(int score)
        {
            scores.Add(score);
        }

        //Calculate average score for test in specific lesson
        public float CalculateAvgScore()
        {
            int totalScore = 0;
            int attempts = 0;
           
            // Adds all scores in list together and divides by number of scores that are in the list
            foreach (int score in scores)
            {

                totalScore += score;
                attempts++;
                
            }
            float avgScore = totalScore / attempts;
            return avgScore;
        }

        // Returns message: Score, average score, number of attempts
        public string Result()
        {
            return "";
        }

        public override string ToString()
        {
            return userName + " " + password + " " + CalculateAvgScore();
  
        }


    }
}
