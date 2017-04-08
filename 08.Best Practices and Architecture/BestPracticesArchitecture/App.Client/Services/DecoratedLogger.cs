using System;


namespace App.Client.Services
{
   public class DecoratedLogger : Logger
    {
        public override void Log(string line)
        {
            Console.WriteLine($"Action received: {line}");
        }
    }
}
