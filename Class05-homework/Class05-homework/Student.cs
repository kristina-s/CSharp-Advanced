using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class05_homework
{
    class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }


        public void Print(string name, int grade)
        {
            if ((grade > 5) && (grade <= 10))
            {
                Console.WriteLine($"Student {name} passed the exam!");
            }
            else if (grade == 5)
            {
                Console.WriteLine($"Student {name} failed the exam!");
            }
            else
            {
                Console.WriteLine("No such grade!");
            }
        }
    }
}
