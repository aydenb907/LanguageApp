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
      

        // Object methods

        // Constructor
        public User(string n)
        {
           
            username = n;
           
        }

        // Get Methods
        public string GetName()
        {
            return username;
        }
        public List<int> GetAttempts()
        {
            return attempts;
        }

        public void CompletedLessons()
        {

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
