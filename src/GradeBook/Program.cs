using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Felix GradeBook");
            book.GradeAdded += OnGradeAdded;          

            while (true)
            {
                Console.WriteLine("Enter a grade or 'Q' to exit");
                var input = Console.ReadLine();
                
                if(input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("*****");
                }
                
            }

            var stats = book.GetStats();
            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low} and the highest grade is {stats.High}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added"); 
        }
    }
}
