using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Class05_homework
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Trainer t = new Trainer();

            Student student01 = new Student()
            {
                Name = "Kristina",
                Grade = 9,
            };
            t.EventHandler += student01.Print;

            Student student02 = new Student()
            {
                Name = "Tose",
                Grade = 10,
            };
            //t.EventHandler += student02.Print;

            Student student03 = new Student()
            {
                Name = "Andrej",
                Grade = 5,
            };
            //t.EventHandler += student03.Print;

            t.ListenGrades(student01.Name, student01.Grade);
            Thread.Sleep(3000);
            t.ListenGrades(student02.Name, student02.Grade);
            Thread.Sleep(3000);
            t.ListenGrades(student03.Name, student03.Grade);

            Console.ReadLine();
        }
        
    }
}
