using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 12.7, 16.4, 17.1, 11.5 };
            grades.Add(56.1);

            var result = 0.0;
            
            foreach(double number in grades) 
            {
                result += number;   
            }
            result = result / grades.Count;
            Console.WriteLine($"The average grade is {result:N1}");

            if(args.Length > 0) 
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else {
                Console.WriteLine("Hello!");
            }
        }
    }
}
