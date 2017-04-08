using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Students
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input!="End")
            {
                Student student = new Student(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(Student.counter);
        }
    }
}
