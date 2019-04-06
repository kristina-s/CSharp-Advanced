using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class05_homework
{
    public delegate void EventHandlerDelegate(string name, int grade);

    public class Trainer
    {

        public event EventHandlerDelegate EventHandler;

        public Trainer()
        {
        }

        public void ListenGrades(string name, int grade)
        {
            EventHandler?.Invoke(name, grade);

        }

     
        
    }
}
