using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OldetMemberFamaly
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name,int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get; set; }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }
                this.age = value;
            }
        }
    }
}
