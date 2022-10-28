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

        
        //Adds all the users stored in the database to the users list
        //Method used for when program starts
        public void AddAllUsers()
        {
            SqlConnection connection;
            string connectionString = ConfigurationManager.ConnectionStrings["LanguageApp.Properties.Settings.Database1ConnectionString"].ConnectionString;

            List<string> usernames = new List<string>();

            //gets all the usernames in the database and puts them into one list
            string query = $"SELECT username FROM UsersTable";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usernames.Add((string)reader[0]);
                }
                reader.Close();

                
            }
            connection.Close();

            //for each username, the corresponding UserID for it is selected and added along with its username into the users list
            foreach (string u in usernames)
            {
                string query2 = $"SELECT UserID FROM UsersTable WHERE username = @username";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command2 = new SqlCommand(query2, connection))
                {
                    connection.Open();
                    command2.Parameters.AddWithValue("@username", u);

                    int id = (int)command2.ExecuteScalar();
                    users.Add(new User(id, u));

                }


            }       
        }

        //Makes sure user isn't already added in users list when they click login
        public void Login(string username)
        {
            int index = 0;
            int userIndex = 0;
            int id = 0;

            //Compares the username they've typed into to every username stored
            foreach (User user in users)
            {
                //if there is a match, that means they have signed up and their login will be successful
                if (user.GetName().Equals(username))
                {
                    userIndex = index; //userIndex will remain the same index that the user is in, while the loop is being completed
                    id = user.GetId();
                }

                index++;
            }
            
            //index is used to remove the same user from the list so that they can be added again
            //this is to make sure they are in the last index of the users list, since the other methods use the last index
            users.Remove(users[userIndex]);

            NewUser(id, username);


        }
        
        //Adds users to users list once they've successfully signed up or logged in
        public void NewUser(int i, string n)
        {
            users.Add(new User(i, n));
        }


        //changes username for the account that is logged in
        public void ChangeUsername(string u)
        {
            int id = GetId();
            users.Remove(users[users.Count-1]); //account is removed and then added again with the new username 

            NewUser(id, u);
        }

        //Following methods gets the information for an account needed from User class
        //Always gets it from the last index in the user list
        public string GetUsername()
        {
            return users[users.Count - 1].GetName();
        }

        public int GetId()
        {
            return users[users.Count - 1].GetId();
        }

        public decimal GetAvgScore(int lesson)
        {
            return users[users.Count-1].AvgScore(lesson);
        }

        //gets the user's total points
        public string DisplayTotalPoints()
        {
            if (users[users.Count - 1].TotalPoints() == 1)
            {
                return $"{users[users.Count - 1].TotalPoints()} point"; //if they only have 1 point then it will read "1 point" on the form instead of "1 points", to be gramatically correct
            }
            else
            {
                return $"{users[users.Count - 1].TotalPoints()} points";
            }


        }

        //removes user from the users list once they've been deleted from the database
        public void DeleteUser() 
        {
            users.Remove(users[users.Count-1]);
            
        }

       
        //sorts users by their total points - most points to least, and gives all of their placings
        public string SortUsers()
        {
            List<int> totalPoints = TotalPointsEachUser(); //total points are already sorted from highest to lowest
            List<string> names = new List<string>();

            //sorts the usernames so that each username can linked to the correct total of points for their account
            for (int n = 0; n < totalPoints.Count; n++)
            {
                foreach(User user in users) 
                {
                    if (totalPoints[n] == user.TotalPoints()) 
                    {
                        names.Add(user.GetName()); //if there is a match username will be added

                        if(names.Count>users.Count) //prevents the username being added multiple times, since some users will share the same number of points. 
                            //Makes sure the next username with the same number of points is added instead. The user who signed up first will go before other users with the same total of points
                        {
                            names.Remove(user.GetName());
                        }

                    }
                   
                }
              
            }

            
            string list = "";
            int placing = 0;

            //for each username, it is added to the summary list with its number of total points
            //placing increases by 1 for each user
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

            return list; //returns the list of users to be used for the leaderboard

        }

        //adds the total number of points for each individual user into one list
        public List<int> TotalPointsEachUser()
        {
            List<int> totalPoints = new List<int>();

            foreach (User user in users)
            {
                totalPoints.Add(user.TotalPoints());
            }

            //sorts the list from lowest number of points to highest
            totalPoints.Sort();

            //reverses order of points, so it changes from highest to lowest 
            totalPoints.Reverse(); //Sort method is used first because just using Reverse would cause the order of points to be last user added's total points to first user. Reverse does not mean it sorts numbers from highest to lowest.


            return totalPoints; 
        }

        //determines the placing for the user that is logged in
        public string CalculatePlacingForUser(string name)
        {
            //total points from highest to lowest
            List<int> totalPoints = TotalPointsEachUser();

            int placing = 0;

            //for each user, placing increases by 1
            //only the user with the username that matches will have their placing 
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
           
            //gives the correct ending to the place number
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
