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
        
            //Adds new user's details: name and password
            string name = "fjfjr";
            string password = "34";
            List<int> scores = new List<int>();

        
            User u = new User();
            u.NewUser(name, password, scores);

            //Gives what lesson it is
            //int lesson = 1;

            int score = 0;
            //Generates practice questions in random order based on what lesson it is
            Random rand = new Random();
            List<int> randomIndexes = new List<int>();
            for(int i=0; i<5; i++)
            {
                randomIndexes.Add(rand.Next(0,3));
            }

            List<string> practiceQues = Lesson.GenPracQuestions(randomIndexes);
            List<string> practiceAns = Lesson.GenPracQuestions(randomIndexes);

           for(int j=0; j<5; j++)
            {
                Console.WriteLine(practiceQues[j]);

                string userAnswer = "answer 2";

                if (Lesson.MarkPracQuestions(j, userAnswer))
                {
                
                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.Write("Incorrect");
                }
            }

            randomIndexes = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                randomIndexes.Add(rand.Next(0, 3));
            }

            List<string> germanWords = Lesson.GenPracQuestions(randomIndexes);

            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(practiceQues[j]);

                string userAnswer = "answer 2";

                if (Lesson.MarkPracQuestions(j, userAnswer))
                {
                    score++;
                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.Write("Incorrect");
                }
            }





            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());*/
        }



    }
}
