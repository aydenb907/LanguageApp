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


        public UserManager()
        {

        }

    

        public void NewUser(int i, string n)
        {
            string message = "";
            int index = 0;
            int removeIndex = 0;
            foreach(User user in users)
            {
                

                if (n.Equals(user.GetName()))
                {
                    message = "Already added";
                    removeIndex = index;
                }

                index++;

            }

            if(message.Equals("Already added"))
            {
                users.Remove(users[removeIndex]);
            }
            
            users.Add(new User(i, n));
        }

        public string GetUsername()
        {
            return users[users.Count - 1].GetName();
        }

        public int GetId()
        {
            return users[users.Count - 1].GetId();
        }

        public float GetAvgScore(int lesson)
        {
            return users[users.Count-1].AvgScore(lesson);
        }

        public void DeleteUser()
        {
            users.Remove(users[users.Count-1]);
        }


        public string DisplayTotalPoints()
        {
            if(users[users.Count - 1].TotalPoints() == 1)
            {
                return $"{users[users.Count - 1].TotalPoints()} point";
            }
            else
            {
                return $"{users[users.Count - 1].TotalPoints()} points";
            }
            

        }

        public string CompareTotalScores(string name)
        {

            List<int> totalPoints = new List<int>();

            foreach(User user in users)
            {
                totalPoints.Add(user.TotalPoints());
            }

            totalPoints.Sort();
            totalPoints.Reverse();

            int placing = 0;

            foreach(User user in users)
            {
                if(user.GetName() == name)
                {
                    for (int n = 0; n < totalPoints.Count; n++)
                    {
                        if(totalPoints[n] == user.TotalPoints())
                        {
                            placing = n + 1;
                        }
                    }
                }
            }

            string text = "";
            if (placing == 1)
            {
                text = $"1st place";
            }
            else if (placing == 2)
            {
                text = $"2nd place";
            }
            else if (placing == 3)
            {
                text = $"3rd place";
            }
            else
            {
                text = $"{placing}th place";
            }


            return text;


        }
       

    }
}
