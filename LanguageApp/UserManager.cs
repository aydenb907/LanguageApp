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
        public string GetUsername()
        {
            return users[users.Count - 1].GetName();
        }

        public string CalcTotalScore()
        {
            float totalScore = 0;
            foreach(int lessonTotalScore in users[users.Count-1].GetTotalScores())
            {
                totalScore += lessonTotalScore;
            }
            return $"{totalScore} points";
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

        public string FindUser(string name, string password)
        {
            string message = "Invalid username/password.";
            List<int> totalScores = new List<int>();
            List<int> attempts = new List<int>();
            int number = 0;
            
            foreach (User user in users)
            {
                if(name.Equals(user.GetName()) & password.Equals(user.GetPassword())) 
                {
                    message = "logged in";
                    totalScores = user.GetTotalScores();
                    attempts = user.GetAttempts();
                }
                number++;

            }

            if(message.Equals("logged in"))
            {
                
                users.Remove(users[number-1]);
                users.Add(new User(name, password, totalScores, attempts));

            }
           

            return message;
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
