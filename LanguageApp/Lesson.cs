using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    class Lesson
    {
        private static List<string> practiceQues = new List<string>() { "question 1", "question 2", "question 3", "question 4", "question 5" };
        private static List<string> practiceAns = new List<string>() { "answer 1", "answer 2", "answer 3", "answer 4", "answer 5" };
        private static List<string> englishWords = new List<string>() { "e1", "e2", "e3", "e4", "e5" };
        private static List<string> germanWords = new List<string>() { "g1", "g2", "g3", "g4", "g5" };
        private static List<string> testQues = new List<string>() { "question 1", "question 2", "question 3", "question 4", "question 5" };
        private static List<string> testAns = new List<string>() { "answer 1", "answer 2", "answer 3", "answer 4", "answer 5" };


        public static List<string> GenPracQuestions(List<int> randomIndex)
        {
            List<string> chosenQuest = new List<string>();

            foreach(int index in randomIndex)
            {
                chosenQuest.Add(practiceQues[index]);
              
            }

            return chosenQuest;
        }

        public static List<string> GenPracAns(List<int> randomIndex)
        {
            List<string> chosenAns = new List<string>();

            foreach (int index in randomIndex)
            {
                chosenAns.Add(practiceAns[index]);

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
        public static List<string> GenEnglishWords(List<int> randomIndex)
        {
            List<string> chosenWords = new List<string>();

            foreach (int index in randomIndex)
            {
                chosenWords.Add(englishWords[index]);
            }

            return chosenWords;
        }
        public static List<string> GenGermanWords(List<int> randomIndex)
        {
            List<string> chosenWords = new List<string>();

            foreach (int index in randomIndex)
            {
                chosenWords.Add(germanWords[index]);
            }

            return chosenWords;
        }

        public static bool MarkTranslations(int index, string userAnswer, List<string> chosenGermanWords)
        {
            if (userAnswer.Equals(chosenGermanWords[index]))
            {
                return true;
            }

            return false;
        }

        public static List<string> GenTestQuestions(List<int> randomIndex)
        {
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
