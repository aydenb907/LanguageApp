using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp
{
    class Lesson
    {
        private List<string> practiceQues;
        private List<string> practiceAns;
        private List<string> englishWords;
        private List<string> germanWords;
        private List<string> testQues;
        private List<string> testAns;


        public Lesson()
        {
           
        }

        public List<string> GeneratePracticeQuestions(int l)
        {
            if(l == 1)
            {
                practiceQues = new List<string>() {"question 1", "question 2", "question 3" };
                practiceAns = new List<string>() { "answer 1", "answer 2", "answer 3" };
            }
            if(l == 2)
            {

            }
            else
            {

            }

            

            return practiceQues;
        }

      
        public string MarkPracticeQuestions(string u, int q)
        {

            string feedback = "";

            if(u.Equals(practiceAns[q]))
            {
                feedback = "Correct!";
            }
            else
            {
                feedback = $"Incorrect. The correct answer is {practiceAns[q]}.";
            }

            practiceAns.Remove(practiceAns[q]);

            return feedback;
        }
        public List<string> GenerateGermanWords()
        {
            return germanWords;
        }

        public List<string> GenerateEnglishWords()
        {
            return englishWords;
        }

        public List<string> GenerateTestQuestions()
        {
            return testQues;
        }

        public List<string> GenerateTestAnswers()
        {
            return testAns;
        }
    }
}
