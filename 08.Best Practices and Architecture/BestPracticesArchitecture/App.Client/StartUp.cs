using App.Client.Commands;
using App.Client.Services;
using App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //using (var context = new SoftUniContext())
            //{
            //    //Usage Optimization
            //    Console.WriteLine(context.Employees.Where(e => e.Salary > 15000).Select(e => e.Salary));

            //    var project = context.Projects.Find(5);
            //    Console.WriteLine(project.Name);

            //}

            //SingleTon
            //Authenticator.Instance.LogIn("Pesho");
            //Console.WriteLine(Authenticator.Instance.Current);

            //Service Locator
            //RegisterServices();
            //string myString = "Hello,Service Locator!";
            //var logger = ServiceLocator.Instance.GetService("console");
            //logger.Log(myString);

            //CommandPattern
            //var parser = new CommandParser();
            //MyData data = new MyData
            //{
            //    Number = 5,
            //    MyString = "Some Data"
            //};
            //while (true)
            //{
            //    var cmd = parser.Parse(Console.ReadLine(),data);
            //    Console.WriteLine("Pres any key to exevute command:");
            //    Console.ReadKey(true);             
            //    cmd.Execute();
            //}

            //Singleton
            //Authenticator.Instance.LogIn("Pesho");
            //Console.WriteLine(Authenticator.Instance.Current);
            //Utility.SomeMethod();


        }

        static void RegisterServices()
        {
            ServiceLocator.Instance.AddService("console", new ConsoleLoger());
            ServiceLocator.Instance.AddService("Decorated", new DecoratedLogger());
        }
    }

   public class MyData
    {
        public string MyString { get; set; }

        public int Number { get; set; }
    }
}
