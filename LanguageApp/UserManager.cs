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

       
        List<User> users = new List<User>();
    

        public UserManager()
        {
            
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

                 return displayPlacing;*/
            /*
                    }*/


        
      
    }
}
