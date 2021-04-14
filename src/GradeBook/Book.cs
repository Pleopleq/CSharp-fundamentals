using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        private List<double> grades;
        public string Name;

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStats()
        {
            var results = new Statistics();
            results.Average = 0.0;
            results.High = double.MinValue;
            results.Low = double.MaxValue;

            foreach(double grade in grades) 
            {
                results.Low = Math.Min(grade, results.Low);
                results.High = Math.Max(grade, results.High);
                results.Average += grade;   
            }
            results.Average = results.Average / grades.Count;

            return results;
        }
        
        public void ShowStats()
        {
            var stats = new Statistics();
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1} and the highest grade is {stats.High:N1}");
        }
    }
}