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

        //Adds users to users list when they successfully sign up. If the user has already signed up and is logging in, user is removed from users list and added again, to make sure they're in the last index for the other methods.
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

        public string SortUsers()
        {
            List<int> totalPoints = TotalPointsEachUser();
            List<string> names = new List<string>();

            for (int n = 0; n < totalPoints.Count; n++)
            {
                foreach(User user in users)
                {
                    if (totalPoints[n] == user.TotalPoints())
                    {
                        names.Add(user.GetName());

                        if(names.Count>users.Count)
                        {
                            names.Remove(user.GetName());
                        }
                    }
                   
                }
              
            }

            string list = "";
            int placing = 0;

            foreach (string name in names)
            {
                placing++;

                if (totalPoints[placing - 1] == 1)
                {
                    list += $"{placing}. {name} | {totalPoints[placing - 1]} point\n";
                }
                else
                {
                    list += $"{placing}. {name} | {totalPoints[placing - 1]} points\n";
                }

            }

            return list;

        }

        public List<int> TotalPointsEachUser()
        {
            List<int> totalPoints = new List<int>();

            foreach (User user in users)
            {
                totalPoints.Add(user.TotalPoints());
            }

            totalPoints.Sort();
            totalPoints.Reverse();
            return totalPoints;
        }

        public string CalculatePlacingForUser(string name)
        {

            List<int> totalPoints = TotalPointsEachUser();

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
