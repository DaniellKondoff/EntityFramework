using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MathUtilities
{
    class MathUtil
    {
        public static double GetSum(double num1,double num2)
        {
            return num1 + num2;
        }
        public static double GetSubtract(double num1, double num2)
        {
            return num1 - num2;
        }
        public static double GetMultiply(double num1, double num2)
        {
            return num1 * num2;
        }
        public static double GetDevide(double devident, double devidor)
        {
            return devident/devidor;
        }
        public static double GetPercentag(double totalNum, double percent)
        {
            return totalNum * (percent / 100);
        }
    }
}
