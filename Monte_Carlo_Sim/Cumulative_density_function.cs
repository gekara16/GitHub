using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Sim
{
    class Cumulative_density_function
    {
        public double Blackscholes_delta(double So, double k, double T, double r, double sigma)//this  method  approximates the normal-cumulative density function of d1;wich is an input of the blackscholes equation.
        {
            double d1 = (Math.Log(So / k) + (r + (Math.Pow(sigma, 2) / 2) * T)) / (sigma * Math.Sqrt(T));//attribution: James McCaffrey https://jamesmccaffrey.wordpress.com/2014/07/16/the-normal-cumulative-density-function-using-c/

            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            int sign;
            if (d1 < 0.0)
                sign = -1;
            else
                sign = 1;

            double x = Math.Abs(d1) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3)
              * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        }


    }
}
