﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace LanguageApp
{
    class User
    {
        // Object properties

        private string username;
        private string password;
        private List<int> totalScores;
        private List<int> attempts = new List<int>();


        // Object methods

        // Constructor
        public User(string n, string p, List<int> s, List<int> a)
        {
            username = n;
            password = p;
            totalScores = s;
            attempts = a;
        }

        public string GetName()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public List<int> GetTotalScores()
        {
            return totalScores;
        }
        public List<int> GetAttempts()
        {
            return attempts;
        }


        // Adds score to scores list for user that has been found in database
        public void UpdateScores(int score, int lesson)
        {
            totalScores[lesson] += score;
            attempts[lesson]++;
            
        }

        //Calculate average score for test in specific lesson
        public float CalculateAvgScore(int lesson)
        {
            float avgScore = totalScores[lesson] / attempts[lesson];
            avgScore = (float)Math.Round(avgScore, 2);
            return avgScore;
          
        }

        public int NumberOfAttempts(int lesson)
        {
            return attempts[lesson];
        }


    }
}
