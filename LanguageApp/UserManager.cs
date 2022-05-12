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

        public void AddScoreToUser(int score, int lesson)
        {
            users[users.Count - 1].UpdateScores(score, lesson);

        }

        public float GetAvgScore(int lesson)
        {
            return users[users.Count - 1].CalculateAvgScore(lesson);
        }

        public int GetAttemptsNumber(int lesson)
        {
            return users[users.Count - 1].NumberOfAttempts(lesson);
        }

    }
}
