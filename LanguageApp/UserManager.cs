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
            return users[users.Count - 1].AvgScore(lesson);
        }



        public string DisplayTotalPoints()
        {
            return $"{users[users.Count - 1].TotalPoints()} points";

        }

        public string CompareTotalScores(string name)
        {
            string text = "";
            if (users.Count == 0)
            {
                return text;
            }
            else
            {
                for (int i = 0; i < users.Count - 1; i++)
                {


                    if (users[i + 1].TotalPoints() > users[i].TotalPoints())
                    {
                        User tempUser = users[i];
                        users[i] = users[i + 1];
                        users[i + 1] = tempUser;
                    }
                }



                int placing = 0;
                int displayPlacing = 0;

                foreach (User user in users)
                {
                    placing++;
                    if (name.Equals(user.GetName()))
                    {
                        displayPlacing = placing;
                    }
                }


                if (displayPlacing == 1)
                {
                    text = $"1st place";
                }
                else if (displayPlacing == 2)
                {
                    text = $"2nd place";
                }
                else if (displayPlacing == 3)
                {
                    text = $"3rd place";
                }
                else
                {
                    text = $"{displayPlacing}th place";
                }

                return text;
            }



        }


    }
}
