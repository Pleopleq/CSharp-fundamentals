using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStats();
        string Name { get; }
        event InMemoryBook.GradeAddedDelegate GradeAdded;
    }   
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name) { }

        public abstract event InMemoryBook.GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStats();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name){}

        public override event InMemoryBook.GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
           using(var writer = File.AppendText($"{Name}.txt"))
           {
               writer.WriteLine(grade);
               if(GradeAdded != null){
                   GradeAdded(this, new EventArgs());
               }
           }
        }

        public override Statistics GetStats()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
               var line = reader.ReadLine();
               while(line != null)
               {
                   var number = double.Parse(line);
                   result.Add(number);
                   line = reader.ReadLine();
               }
            }
            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        private List<double> grades;
        public string name;
        public const string CATEGORY = "Science";
        
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0) 
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)} ");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStats()
        {
            var results = new Statistics();

            for(var index = 0; index < grades.Count; index++)
            {
                results.Add(grades[index]);
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