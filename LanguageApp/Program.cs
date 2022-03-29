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
        
            //Adds new user: name and password
            string name = "fjfjr";
            string password = "34";
            List<int> scores = new List<int>();


            User u = new User(name, password, scores);

            //Adds scores
            int score = 3;
            u.UpdateScores(score);
            int score2 = 8;
            u.UpdateScores(score2);
            Console.WriteLine(u.ToString());

            //Gives what lesson it is
            int lesson = 1;
            Lesson L = new Lesson();

            //Generates practice questions in random order based on what lesson it is
            Random rand = new Random();

            List<string> practiceQues = L.GeneratePracticeQuestions(lesson);

            int questionNumber = rand.Next(0, 2);
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

            //Generates English words in random order based on the lesson, answers are the German words
            List<string> englishWords = L.GetEnglishWords();

            questionNumber = rand.Next(0, 2);
            Console.WriteLine(englishWords[questionNumber]);
            englishWords.Remove(englishWords[questionNumber]);
            userAnswer = "g2";
            Console.WriteLine(L.MarkTranslations(userAnswer, questionNumber));

            questionNumber = rand.Next(0, 1);
            Console.WriteLine(englishWords[questionNumber]);
            englishWords.Remove(englishWords[questionNumber]);
            userAnswer = "g2";
            Console.WriteLine(L.MarkTranslations(userAnswer, questionNumber));
            
            questionNumber = 0;
            Console.WriteLine(englishWords[questionNumber]);
            englishWords.Remove(englishWords[questionNumber]);
            userAnswer = "g2";
            Console.WriteLine(L.MarkTranslations(userAnswer, questionNumber));

            //Generates test questions in random order based on lesson
            List<string> testQuestions = L.GetTestQuestions();
            List<string> testAnswers = L.GetTestAnswers();
            List<string> newAnswers = new List<string>();
            List<string> uAnswers = new List<string>() {"a1", "a2", "a3" };

            questionNumber = rand.Next(0, 2);
            Console.WriteLine(testQuestions[questionNumber]);
            testQuestions.Remove(testQuestions[questionNumber]);
            newAnswers.Add(testAnswers[questionNumber]);
            testAnswers.Remove(testAnswers[questionNumber]);

            questionNumber = rand.Next(0, 1);
            Console.WriteLine(testQuestions[questionNumber]);
            testQuestions.Remove(testQuestions[questionNumber]);
            newAnswers.Add(testAnswers[questionNumber]);
            testAnswers.Remove(testAnswers[questionNumber]);


            questionNumber = rand.Next(0);
            Console.WriteLine(testQuestions[questionNumber]);
            testQuestions.Remove(testQuestions[questionNumber]);
            newAnswers.Add(testAnswers[questionNumber]);
            testAnswers.Remove(testAnswers[questionNumber]);

            Console.WriteLine(L.MarkTestQuestions(uAnswers, newAnswers));
        


            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());*/
        }



    }
}
