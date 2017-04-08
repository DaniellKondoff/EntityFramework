using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonConstr
{
    public class Person
    {
        private string name;
        private int age;
        public Person():this("No Name",1)
        {
        }

        public Person(int age) :this("No Name",age)
        {

        }
        public Person(string name) :this(name,1)
        {

        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }
                this.age = value;
            }
        }
    }
}
