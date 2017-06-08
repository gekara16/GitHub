using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Monte_Carlo_Sim
{
   public class simulator
    { 
        public double[,] simulate(double So, double k, double T, double r, double sigma, int trials, bool x, bool multithread, int steps, double[,] randn)
        {
            //implement multithreading
            int numcores = System.Environment.ProcessorCount;
            if (!multithread)
                numcores = 1;
            int count = 0;
            int averagetrial;

            if (trials % numcores == 0)
                averagetrial = trials / numcores;
            else averagetrial = trials / numcores + 1;


            double dt = T / Convert.ToDouble(steps - 1);
            
            //initialize stock matrix
            double[,] St;

            if (x)
            {
                St = new double[2 * trials, steps];// matrix size without antithetic method
            }
            else
            {
                St = new double[trials, steps];
            }
            for (int i = 0; i < St.GetLength(0); i++)
            {
                St[i, 0] = So;
            }

            List<Thread> threadpool = new List<Thread>();
            Action<object> Randomarray = (o) =>
            {
                int start = Convert.ToInt32(o);
                int end = start + averagetrial;
                if (end > trials) end = trials;


                for (int i = start; i < end; i++)//generating paths for the stock price
                {
                    for (int j = 1; j < steps; j++)
                    {
                        St[i, j] = St[i, j - 1] * (Math.Exp(((r - (sigma * sigma) * 0.5) * dt) + (sigma * Math.Sqrt(dt) * randn[i, j])));//simulating paths in steps and trials

                        if (x)
                        {
                            St[i+trials, j] = St[i+trials, j - 1] * (Math.Exp(((r - (sigma * sigma) * 0.5) * dt) - (sigma * Math.Sqrt(dt) * randn[i, j])));

                        }
                    }
                }
              
            };
            for (int i = 0; i < numcores; i++)
            {
                threadpool.Add(new Thread(new ParameterizedThreadStart(Randomarray)));
                threadpool[i].Start(count);
                count += averagetrial;
              }
            foreach (Thread t in threadpool)
                t.Join();
            //foreach (Thread t in threadpool)t.Abort();
            Program.increaseprogress(trials * steps);
            return St;
        }
    } 
}
