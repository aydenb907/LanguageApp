using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    
    public class UserManager
    {
        private List<User> users = new List<User>();

        public UserManager()
        {

        }

        public List<string> GetUsernames()
        {
            List<string> names = new List<string>();
            foreach (User user in users)
            {
                names.Add(user.GetName());


            }

            return names;

        }

        public List<string> GetPasswords()
        {
            List<string> passwords = new List<string>();
            foreach (User user in users)
            {
                passwords.Add(user.GetPassword());


            }

            return passwords;

        }

        public string AddUser(string n, string p, List<int> s, List<int> a)
        {
            users.Add(new User(n,p,s,a));
            return "User has been added.";
        }


    }
}
