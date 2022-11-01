using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LanguageApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            //Starts on Login form

            UserManager u = new UserManager(); //New UserManager here so that the list of users will be saved 
            
            u.AddAllUsers(); //Adds all the users stored in the database to the users list in UserManager, otherwise their points won't count and they won't be on the leaderboard until they login again 
            //Users list isn't stored after the program is closed so they need to be added again.

            //Starts with Login form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(u)); 
        }



    }
}
