using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Sim
{
    public class Lookback:option
    {
        //constructor for Lookback option class that is inherited from constructor of option class.
        public Lookback(double So, double k, double r, double T, int steps, double sigma, int trials, bool y, bool x, bool multithread,double barrier,double rebate) : base( So, k,  T, r, sigma, y, trials, steps, x,multithread,barrier,rebate)
        {     //initialized parameters of the constructor. 
            _So = So;
            _k = k;
            _r = r;
            _T = T;
            _steps = steps;
            _sigma = sigma;
            _trials = trials;
            _y = y;
            _x = x;
            _multithread = multithread;
            _barrier = barrier;
            _rebate = rebate;
        }

        public double Get_price(double So, double k, double T, double r, double sigma, int trials, int steps, bool call, bool x, bool y, bool multithread, double[,] randn, out double SE)
        {
            double Price;//option price
            SE = 0.0;
            double sm = 0.0;
            double sumoption = 0.0;//sum of payoff
            simulator sim = new simulator();

            double[,] St = sim.simulate(So, k, T, r, sigma, trials, x, multithread, steps, randn);
            double[,] av = new double[trials, 1];
            double[,] pay_off = new double[St.GetLength(0), 1];
            double[,] cv = new double[St.GetLength(0), 1];
            double[,] max = new double[St.GetLength(0), 1];
            double[,] min = new double[St.GetLength(0), 1];
            double beta = -1.0;
            double dt = T / Convert.ToDouble(steps - 1);

            Cumulative_density_function d1 = new Cumulative_density_function();

            for (int i = 0; i < St.GetLength(0); i++)
            {
                min[i, 0] = double.MaxValue;
                max[i, 0] = double.MinValue;

                for (int j = 1; j < St.GetLength(1); j++)
                {

                    if (St[i, j] > max[i, 0])
                    {
                        max[i, 0] = St[i, j];
                    }

                    if (St[i, j] < min[i, 0])
                    {
                        min[i, 0] = St[i, j];
                    }
                }
            }


            if (y)
            {
                for (int i = 0; i < St.GetLength(0); i++)
                {
                    for (int j = 1; j < steps; j++)
                    {
                        double t = (j - 1) * dt;
                        double call_delta = d1.Blackscholes_delta(St[i, j - 1], k, T - t, r, sigma);
                        double put_delta = d1.Blackscholes_delta(St[i, j - 1], k, T - t, r, sigma) - 1;
                        double cv1 = 0.0;

                        if (call)
                        {

                            cv1 += call_delta * (St[i, j] - St[i, j - 1] * Math.Exp(r * dt));
                        }

                        else if (!call)
                        {
                            cv1 += put_delta * (St[i, j] - St[i, j - 1] * Math.Exp(r * dt));
                        }
                    }
                }

                for (int i = 0; i < St.GetLength(0); i++)

                {
                
                    if (call)

                    {
                        pay_off[i, 0] = Math.Max(max[i, 0] - k, 0) + (beta * cv[i,0]);
                    }

                    if (!call)
                    {
                        pay_off[i, 0] = Math.Max(k - min[i,0], 0) + (beta * cv[i,0]);
                    }
                }
            }

            else
            {
                for (int i = 0; i < St.GetLength(0); i++)
                {

                    if (call)

                    {
                        pay_off[i, 0] = Math.Max(max[i, 0] - k, 0);
                    }

                    if (!call)
                    {
                        pay_off[i, 0] = Math.Max(k - min[i,0], 0);
                    }
                }

            }

            for (int i = 0; i < St.GetLength(0); i++)
            {
                sumoption += pay_off[i, 0];
            }
            Price = (sumoption / Convert.ToDouble(St.GetLength(0))) * Math.Exp(-r * T);//option price


            if (x)//sum of differences between the pay_off at each trial and the price of the option (with antithetic)
            {

                for (int i = 0; i < trials; i++)
                {
                    av[i, 0] = (pay_off[i, 0] + pay_off[i + trials, 0]) * 0.5;
                }
                for (int i = 0; i < trials; i++)
                {
                    sm += Math.Pow((av[i, 0] * Math.Exp(-r * T)) - Price, 2);
                }

            }
            else // sum of differences between the pay_off at each trial and the price of the option (without antithetic)

            {
                for (int i = 0; i < trials; i++)
                {
                    sm += Math.Pow((pay_off[i, 0] * Math.Exp(-r * T)) - Price, 2);

                }
            }
            double SD;                                             //Standard deviation
            SD = Math.Sqrt((1 / Convert.ToDouble((trials - 1))) * sm);
            SE = SD / Math.Sqrt(trials);//compute standard error
            //Program.increaseprogress(trials * steps);
            return Price;
        }


    }

}

