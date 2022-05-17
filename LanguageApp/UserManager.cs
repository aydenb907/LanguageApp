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
            int totalScore = 0;
            foreach(int lessonTotalScore in users[users.Count-1].GetTotalScores())
            {
                totalScore += lessonTotalScore;
            }

            if(totalScore == 1)
            {
                return $"{totalScore} point";
                
            }
            else
            {
                return $"{totalScore} points";
            }
            
        }

        public int CompareTotalScores(string name)
        {
            for(int i = 0; i< users.Count-1; i++)
            {
                int a = i;

                int totalScore1 = 0;
                foreach (int lessonTotalScore in users[a].GetTotalScores())
                {
                    totalScore1 += lessonTotalScore;
                }

                int b = i + 1;
                int totalScore2 = 0;
                foreach (int lessonTotalScore in users[b].GetTotalScores())
                {
                    totalScore2 += lessonTotalScore;
                }


                if (totalScore2>totalScore1)
                {
                    User temp = users[a];
                    users[a] = users[b];
                    users[b] = temp;

                }
            }

            int placing = 0;
            int displayPlacing = 0;

            foreach(User user in users)
            {
                placing++;
                if(name.Equals(user.GetName()))
                {
                    displayPlacing = placing;
                }
            }

            return displayPlacing;

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

        public string AddUser(string n, string p, List<int> s, List<int> a, List<int> c)
        {
            users.Add(new User(n,p,s,a,c));
            return "User has been added.";
        }

        public string FindUser(string name, string password)
        {
            string message = "Invalid username/password.";
            List<int> totalScores = new List<int>();
            List<int> attempts = new List<int>();
            List<int> completedLessons = new List<int>();
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
                users.Add(new User(name, password, totalScores, attempts, completedLessons));

            }
           

            return message;
        }

        public void AddScoreToUser(int score, int lesson)
        {
            users[users.Count - 1].UpdateScores(score, lesson);

        }

        public void AddLessonsToUser(int lesson)
        {
            users[users.Count - 1].UpdateCompletedLessons(lesson);
        }

        public float GetAvgScore(int lesson)
        {
            return users[users.Count - 1].CalculateAvgScore(lesson);
        }

        public int GetAttemptsNumber(int lesson)
        {
            return users[users.Count - 1].NumberOfAttempts(lesson);
        }

        public List<int> GetLessons()
        {
            return users[users.Count - 1].GetCompletedLessons();
        }
    }
}
