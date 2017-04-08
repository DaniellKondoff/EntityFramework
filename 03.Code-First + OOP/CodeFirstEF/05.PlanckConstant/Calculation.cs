using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Calculation
{
    const double PLANCK = 6.6262e-27;
    const double PI = 3.14159;

    public static double GetPlanckConstant()
    {
        return PLANCK / (2 * PI);
    }
}

