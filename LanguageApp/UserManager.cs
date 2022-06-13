using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    
    public class UserManager
    {
        private List<User> users = new List<User>();

       
        List<User> users = new List<User>();
    

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

        public void NewUser(string n)
        {
            users.Add(new User(n));
        }

        public string GetUsername()
        {
            return users[users.Count - 1].GetName();
        }


            /*
        public string CalcTotalPoints()
        {
            int totalPoints = 0;
            foreach(int lessonTotalScore in users[users.Count-1].GetTotalScores())
            {
                totalPoints += lessonTotalScore;
            }

            if(totalPoints == 1)
            {
                return $"{totalPoints} point";
                
            }
            else
            {
                return $"{totalPoints} points";
            }
            
                    }*/

            /* public int CompareTotalScores(string name)
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


        //when they click the login button, checks if their username and password match any of the users' stored
        public string FindUser(string name, string password)
        {

            string message = "Invalid username/password."; //default message, will change if the user's account is found

            List<int> totalScores = new List<int>();
            List<int> attempts = new List<int>();
            List<int> completedLessons = new List<int>();
            
            int number = 0;

            //goes through all the usernames and passwords stored for each user and compares them to the name and password the user have typed in. 
            //if one of the user's stored has their name and password match exactly to what the user has typed in, the message will change to logged in
            //their total score and number of test attempts stored for each lesson will also be received
            foreach (User user in users)
            {
                if(name.Equals(user.GetName()) & password.Equals(user.GetPassword())) 
                {
                    message = "logged in";
                    totalScores = user.GetTotalScores();
                    attempts = user.GetAttempts();
                }
                number++; //index increases by 1 for the next user in the list that needs to be compared

            }

            //if the message has changed, then the user that has the name and password matching will be removed from the list based on
            //what number index they had, and they will be added to the list again with all their data. This is because in the other methods
            //the last user in the list is used, and so when they log in they must be the last user on the list, otherwise they will see the wrong average score that's calculated, the wrong 
            //username and total points will be displayed, etc
            if(message.Equals("logged in"))
            {
                
                users.Remove(users[number-1]);
                users.Add(new User(name, password, totalScores, attempts, completedLessons));

            }
           
            //message will be checked when they login to see if the username and password they have typed in are valid or not
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
