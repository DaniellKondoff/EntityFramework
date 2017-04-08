using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonConstr
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //string name = Console.ReadLine();
            //int age = int.Parse(Console.ReadLine());
            Person person = new Person(43);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);

        }
    }
}
