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
        

            string name = "fjfjr";
            string password = "34";
            List<int> scores = new List<int>();


            User u = new User(name, password, scores);

            int score = 3;
            u.UpdateScores(score);
            int score2 = 8;
            u.UpdateScores(score2);
            Console.WriteLine(u.ToString());

            int lesson = 1;

            Lesson L = new Lesson();

            Random rand = new Random();
        
            List<string> practiceQues = L.GeneratePracticeQuestions(lesson);
            
            int questionNumber = rand.Next(0,2);
            Console.WriteLine(practiceQues[questionNumber]);
            practiceQues.Remove(practiceQues[questionNumber]);
            string userAnswer = "answer 2";
            Console.WriteLine(L.MarkPracticeQuestions(userAnswer, questionNumber));

            questionNumber = rand.Next(0, 1);
            Console.WriteLine(practiceQues[questionNumber]);
            practiceQues.Remove(practiceQues[questionNumber]);
            userAnswer = "answer 1";
            Console.WriteLine(L.MarkPracticeQuestions(userAnswer, questionNumber));

            questionNumber = rand.Next(0);
            Console.WriteLine(practiceQues[questionNumber]);
            practiceQues.Remove(practiceQues[questionNumber]);
            userAnswer = "answer 3";
            Console.WriteLine(L.MarkPracticeQuestions(userAnswer, questionNumber));




            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());*/
        }

        
     
        
    }
}
