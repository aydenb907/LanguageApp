using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    class Lesson
    {
        private static List<string> practiceQues = new List<string>() { "question 1", "question 2", "question 3" };
        private static List<string> practiceAns = new List<string>() { "answer 1", "answer 2", "answer 3" };
        private List<string> englishWords;
        private List<string> germanWords;
        private List<string> testQues;
        private List<string> testAns;


        public static List<string> GenPracQuestions(List<int> randomIndex)
        {
            List<string> chosenQuest = new List<string>();

            foreach(int index in randomIndex)
            {
                chosenQuest.Add(practiceQues[index]);
            }

            return chosenQuest;
        }
        public static List<string> GenPracAnswers(List<int> randomIndex)
        {
            List<string> chosenAns = new List<string>();

            foreach(int index in randomIndex)
            {
                chosenAns.Add(practiceAns[index]);
            }

            return chosenAns;
        }

        public static bool MarkPracQuestions(int index, string userAnswer)
        {
            if(userAnswer.Equals(practiceAns[index]))
            {
                return true;
            }

            return false;
        }

    }
}
