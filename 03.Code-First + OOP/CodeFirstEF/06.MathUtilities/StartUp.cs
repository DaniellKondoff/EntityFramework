using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MathUtilities
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            while (input[0] != "End")
            {
                double firstNum = double.Parse(input[1]);
                double secondNum = double.Parse(input[2]);
                switch (input[0])
                {
                    case "Sum":
                        Console.WriteLine($"{MathUtil.GetSum(firstNum,secondNum):f2}");
                        break;
                    case "Multiply":
                        Console.WriteLine($"{MathUtil.GetMultiply(firstNum, secondNum):f2}");
                        break;
                    case "Percentage":
                        Console.WriteLine($"{MathUtil.GetPercentag(firstNum, secondNum):f2}");
                        break;
                    case "Divide":
                        Console.WriteLine($"{MathUtil.GetDevide(firstNum, secondNum):f2}");
                        break;
                    case "Subtract":
                        Console.WriteLine($"{MathUtil.GetSubtract(firstNum, secondNum):f2}");
                        break;
                }

                input= Console.ReadLine().Split(' ');
            }
        }
    }
}
