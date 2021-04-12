using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Felix GradeBook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(81.5);
            book.AddGrade(70.0);
            book.AddGrade(86.2);

            book.ShowStats();
        }
    }
}
