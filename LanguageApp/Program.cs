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
            u.AddAllUsers();


            //when opening and closing each form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(u));
        }



    }
}
