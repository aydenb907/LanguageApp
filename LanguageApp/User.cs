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
        private List<int> totalScores;
        private List<int> attempts = new List<int>() {0,0,0 };


        // Object methods

        // Constructor
        public User()
        {
            
        }

        //Adds new user to the database
        public void NewUser(string n, string p, List<int> s, List<int> a)
        {
            userName = n;
            password = p;
            totalScores = s;
            attempts = a;
          
            
        }

        // Checks new user name isn't the same as others
        public void CheckUserName()
        {
            
        }

        // finds user in database, by matching username to userID
        // gets userID and then scores
        public void FindUser()
        {
            

        }

        // Adds score to scores list for user that has been found in database
        public void UpdateScores(int score, int lesson)
        {
           
            totalScores[lesson] += score;
            attempts[lesson]++;
            
        }

        //Calculate average score for test in specific lesson
        public float CalculateAvgScore(int lesson)
        {
            float avgScore = totalScores[lesson] / attempts[lesson];
            return avgScore;
          
        }

        public int NumberOfAttempts(int lesson)
        {
            return attempts[lesson];
        }


    }
}
