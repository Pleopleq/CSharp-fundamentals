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
            if(grade <= 100 && grade >= 0) 
            {
                grades.Add(grade);
            }
            else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)} ");
            }
        }

        public Statistics GetStats()
        {
            var results = new Statistics();
            results.Average = 0.0;
            results.High = double.MinValue;
            results.Low = double.MaxValue;

            for(var index = 0; index < grades.Count; index++)
            {
                results.Low = Math.Min(grades[index], results.Low);
                results.High = Math.Max(grades[index], results.High);
                results.Average += grades[index];   
            }
            
            results.Average /= grades.Count;
            
            switch (results.Average)
            {
                case var d when d >= 90.0:
                results.Letter = 'A';
                break;
                case var d when d >= 80.0:
                results.Letter = 'B';
                break;
                case var d when d >= 70.0:
                results.Letter = 'C';
                break;
                case var d when d >= 60.0:
                results.Letter = 'D';
                break;

                default:
                    results.Letter = 'F';
                    break;
            }

            return results;
        }
        
        public void ShowStats()
        {
            var stats = new Statistics();
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1} and the highest grade is {stats.High:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}