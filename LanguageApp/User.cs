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

        public void CompletedLessons()
        {

        }

       
        
    }
}
