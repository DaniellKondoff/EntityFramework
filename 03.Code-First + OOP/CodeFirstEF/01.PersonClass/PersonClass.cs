using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PersonClass
{
    class PersonClass
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Person person = new Person();
            person.Age = age;
            person.Name = name;

            Console.WriteLine($"{person.Name} {person.Age}");
            
        }
    }
}
