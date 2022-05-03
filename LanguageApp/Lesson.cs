using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    class Lesson
    {
        private static List<string> practiceQues;
        private static List<string> practiceAns;
        private static List<string> englishWords;
        private static List<string> germanWords;
        private static List<string> testQues;
        private static List<string> testAns;
        private static string lessonText;
       
        
        public static void SetPracticeQuestions(int lesson)
        {
            if(lesson == 1)
            {
                practiceQues = new List<string>() { "question 1", "question 2", "question 3", "question 4", "question 5", "question 6", "question 7", "question 8", "question 9", "question 10" };
                practiceAns = new List<string>() { "answer 1", "answer 2", "answer 3", "answer 4", "answer 5", "answer 6", "answer 7", "answer 8", "answer 9", "answer 10" };
            }
            if(lesson == 2)
            {
                practiceQues = new List<string>() {"q1", "q2", "q3", "q4", "q5" };
                practiceAns = new List<string>() {"a1", "a2", "a3", "a4", "a5" };
            }
            
        }

        public static List<string> GenPracQuestions(List<int> randomIndex, int lesson, int lessonType)
        {

            SetPracticeQuestions(lesson);
            List<string> chosenQuest = new List<string>();

            if(lessonType == 1)
            {
                foreach (int index in randomIndex)
                {
                    chosenQuest.Add(practiceQues[index]);

                }
            }
            else
            {
                foreach (int index in randomIndex)
                {
                    chosenQuest.Add(englishWords[index]);

                }
            }
           

            return chosenQuest;
        }


        public static List<string> GenPracAns(List<int> randomIndex, int lessonType)
        {
            List<string> chosenAns = new List<string>();

            if(lessonType == 1)
            {
                foreach (int index in randomIndex)
                {
                    chosenAns.Add(practiceAns[index]);

                }
            }

            else
            {
                foreach (int index in randomIndex)
                {
                    chosenAns.Add(germanWords[index]);

                }
            }
            

            return chosenAns;
        }


        public static bool MarkPracQuestions(int index, string userAnswer, List<string> chosenAnswers)
        {
            if(userAnswer.Equals(chosenAnswers[index]))
            {
                return true;
            }

            return false;
        }

        public static void SetWords(int lesson)
        {
            if (lesson == 1)
            {
                englishWords = new List<string>() { "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8", "e9", "e10" };
                germanWords = new List<string>() { "g1", "g2", "g3", "g4", "g5", "g6", "g7", "g8", "g9", "g10" };
                lessonText = "lesson 1";
            }
            if (lesson == 2)
            {
                
            }

        }

        public static string GetEnglishWords(int lesson)
        {
            SetWords(lesson);
            string list = "";

            foreach(string word in englishWords)
            {
                list += word + "\n";
            }

            return list;
        }

        public static string GetGermanWords()
        {
            string list = "";

            foreach (string word in germanWords)
            {
                list += word + "\n";
            }

            return list;

        }
        public static string GetLessonText()
        {
            return lessonText;
        }
        public static string GetGermanWord(int i)
        {
            return germanWords[i];
        }

        public static string GetEnglishWord(int i)
        {
            return englishWords[i];
        }

    
        public static void SetTestQuestions(int lesson)
        {
            if (lesson == 1)
            {
                testQues = new List<string>() { "question 1", "question 2", "question 3", "question 4", "question 5" };
                testAns = new List<string>() { "answer 1", "answer 2", "answer 3", "answer 4", "answer 5" };
            }
            if (lesson == 2)
            {

            }

        }
        public static List<string> GenTestQuestions(List<int> randomIndex, int lesson)
        {

            SetTestQuestions(lesson);
            List<string> chosenQuest = new List<string>();

            foreach (int index in randomIndex)
            {
                chosenQuest.Add(testQues[index]);
            }

            return chosenQuest;
        }
        public static List<string> GenTestAnswers(List<int> randomIndex)
        {
            List<string> chosenAns = new List<string>();

            foreach (int index in randomIndex)
            {
                chosenAns.Add(testAns[index]);
            }

            return chosenAns;
        }
        public static bool MarkTestQues(int index, string userAnswer, List<string> chosenAnswers)
        {
            if (userAnswer.Equals(chosenAnswers[index]))
            {
                return true;
            }

            return false;
        }
    }
}
