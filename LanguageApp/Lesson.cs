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
                germanWords = new List<string>() { "g1", "g2", "g3"};
                englishWords = new List<string>() { "e1", "e2", "e3" };
                testQues = new List<string>() {"q1", "q2", "q3" };
                testAns = new List<string>() {"a1", "a2", "a3" };
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
        public List<string> GetEnglishWords()
        {
            return englishWords;
        }

        public string MarkTranslations(string u, int q)
        {
            string feedback = "";

            if (u.Equals(germanWords[q]))
            {
                feedback = "Correct!";
            }
            else
            {
                feedback = $"Incorrect. The correct answer is {germanWords[q]}.";
            }

            germanWords.Remove(germanWords[q]);

            return feedback;
        }

        public List<string> GetTestQuestions()
        {
            return testQues;
        }

        public List<string> GetTestAnswers()
        {
            return testAns;
        }

        public string MarkTestQuestions(List<string> userAnswers, List<string> correctAnswers)
        {
            string feedback = "";
            
            for(int n = 0; n < correctAnswers.Count(); n++)
            {
                if(userAnswers[n].Equals(correctAnswers[n]))
                {
                    feedback += $"{n+1}. Correct\n";
                }
                else
                {
                    feedback += $"{n+1}. Incorrect. Correct answer is {correctAnswers[n]}.\n";
                }
            }
           

            return feedback;
        }
    }
}
