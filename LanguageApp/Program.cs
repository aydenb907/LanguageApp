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


            //Generates practice questions in random order based on what lesson it is
            Random rand = new Random();
            List<int> randomIndexes = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                randomIndexes.Add(rand.Next(0, 4));
            }

            List<string> practiceQues = Lesson.GenPracQuestions(randomIndexes);
            List<string> practiceAns = Lesson.GenPracAns(randomIndexes);

            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(practiceQues[j]);

                string userAnswer = "answer 2";

                //Marks practice questions
                if (Lesson.MarkPracQuestions(j, userAnswer, practiceAns))
                {

                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.Write("Incorrect\n");
                }
            }

            //Generates English words to translate into German
            randomIndexes = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                randomIndexes.Add(rand.Next(0, 3));
            }

            List<string> englishWords = Lesson.GenEnglishWords(randomIndexes);
            List<string> germanWords = Lesson.GenGermanWords(randomIndexes);

            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(englishWords[j]);

                string userAnswer = "g2";

                //Marks German translations
                if (Lesson.MarkTranslations(j, userAnswer, germanWords))
                {
                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.Write("Incorrect\n");
                }
            }

            //Generates test questions
            randomIndexes = new List<int>();
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                randomIndexes.Add(rand.Next(0, 3));

            }

            List<string> testQues = Lesson.GenTestQuestions(randomIndexes);
            List<string> testAns = Lesson.GenTestAnswers(randomIndexes);

            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(testQues[j]);

            }

            List<string> userAnswers = new List<string>() { "answer 2", "answer 2", "answer 2", "answer 2", "answer 2" };

            for (int j = 0; j < 5; j++)
            {
                //Marks test questions and adds score
                if (Lesson.MarkTestQues(j, userAnswers[j], testAns))
                {
                    Console.WriteLine("Correct");
                    score++;
                }
                else
                {
                    Console.Write("Incorrect\n");
                }
            }

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());*/
        }



    }
}
