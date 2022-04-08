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
            List<int> scores = new List<int>() {0,0,0 };
            List<int> attempts = new List<int>() {0,0,0 };

            User u = new User();
            u.NewUser(name, password, scores, attempts);

            int lesson = 1;
            //Generates practice questions in random order based on what lesson it is
            Random rand = new Random();
            List<int> randomIndexes = new List<int>();
            List<int> indexes = new List<int>() {0,1,2,3,4,5,6,7,8,9 };
            
            for(int i = 0; i < indexes.Count; i++)
            {
                int random = rand.Next(0, indexes.Count-1);
                randomIndexes.Add(indexes[random]);
                indexes.Remove(indexes[random]);
            }

            List<string> practiceQues = Lesson.GenPracQuestions(randomIndexes, lesson);
            List<string> practiceAns = Lesson.GenPracAns(randomIndexes);


            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine("\n"+ practiceQues[j]);

                string userAnswer = "answer 2";

                //Marks practice questions
                if (Lesson.MarkPracQuestions(j, userAnswer, practiceAns))
                {

                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.Write($"Incorrect. The correct answer is {practiceAns[j]}.\n");
                }
                
            }

            //Generates English words to translate into German
            randomIndexes = new List<int>();

            indexes = new List<int>() { 0, 1, 2, 3, 4 };

            for (int i = 0; i < 5; i++)
            {
                int random = rand.Next(0, indexes.Count - 1);
                randomIndexes.Add(indexes[random]);
                indexes.Remove(indexes[random]);
            }

            List<string> englishWords = Lesson.GenEnglishWords(randomIndexes);
            List<string> germanWords = Lesson.GenGermanWords(randomIndexes);

            Console.WriteLine("\n\n");

            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine("\n"+ englishWords[j]);

                string userAnswer = "g2";

                //Marks German translations
                if (Lesson.MarkTranslations(j, userAnswer, germanWords))
                {
                    Console.WriteLine("Correct.");
                }
                else
                {
                    Console.Write($"Incorrect. The correct answer is {germanWords[j]}.\n");
                }
            }

            //Generates test questions
            randomIndexes = new List<int>();
            int score = 0;

            indexes = new List<int>() { 0, 1, 2, 3, 4 };

            for (int i = 0; i < 5; i++)
            {
                int random = rand.Next(0, indexes.Count - 1);
                randomIndexes.Add(indexes[random]);
                indexes.Remove(indexes[random]);
            }

            List<string> testQues = Lesson.GenTestQuestions(randomIndexes);
            List<string> testAns = Lesson.GenTestAnswers(randomIndexes);

            Console.WriteLine("\n\n");

            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine("\n"+ testQues[j]);

            }

            List<string> userAnswers = new List<string>() { "answer 2", "answer 2", "answer 2", "answer 2", "answer 2" };

            Console.WriteLine("\n\n");

            for (int j = 0; j < 5; j++)
            {
                //Marks test questions and adds score
                if (Lesson.MarkTestQues(j, userAnswers[j], testAns))
                {
                    Console.WriteLine($"{j+1}. Correct");
                    score++;
                }
                else
                {
                    Console.Write($"{j+1}. Incorrect. The correct answer is {testAns[j]}.\n");
                }
            }

            u.UpdateScores(score, lesson);
           

            Console.WriteLine($"Score: {score}/5\n" +
                $"Average Score: {u.CalculateAvgScore(lesson)}\n" +
                $"Number of attempts: {u.NumberOfAttempts(lesson)}");

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());*/
        }



    }
}
