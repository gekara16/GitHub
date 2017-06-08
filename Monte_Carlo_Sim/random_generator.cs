using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Monte_Carlo_Sim
{
   public class random_generator
    {   
        public double[,] randomfun(int N,int trials)  // to generate a random number matrix
        {

            double[,] randommatrix = new double[trials, N];
            Random rnd = new Random();
            for (int i = 0; i < trials; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    double x1, x2, z1, z2;
                    x1 = rnd.NextDouble();
                    x2 = rnd.NextDouble();
                    z1 = Math.Sqrt(-2 * Math.Log(x1)) * Math.Cos(2 * Math.PI * x2);
                    z2 = Math.Sqrt(-2 * Math.Log(x1)) * Math.Sin(2 * Math.PI * x2);
                    randommatrix[i, j] = z1;
                }
            }
            return randommatrix;
        }
        // if we decide to use multithreading, we would use this method to generate the random number matrix
        public double[,] multithreadingrandomfun(int N,int trials)  // to generate a random number matrix
        {
            double[,] randommatrix = new double[trials, N];
            int cores = Environment.ProcessorCount;  // get the number of cores in my computer
            //if (trials % cores != 0)  // we need to make sure trial%cores equals integer
            //{
            //    trials = trials + cores - trials % cores;
            //}
            int numpercore = trials / cores;
            Action<object> todomulti = x =>
            {
                int startpoint = Convert.ToInt32(x);
                int end = startpoint + numpercore;
                //   Random rnd = new Random();
                Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF + (int)startpoint * 10 / numpercore);
                for (int i = startpoint; i < end; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        double x1, x2, z1, z2;
                        x1 = rnd.NextDouble();
                        x2 = rnd.NextDouble();
                        z1 = Math.Sqrt(-2 * Math.Log(x1)) * Math.Cos(2 * Math.PI * x2);
                        z2 = Math.Sqrt(-2 * Math.Log(x1)) * Math.Sin(2 * Math.PI * x2);
                        randommatrix[i, j] = z1;
                    }
                }
            };
            int start = 0;
            List<Thread> threadlist = new List<Thread>();  // build cores thread
            for (int i = 0; i < cores; i++)
            {
                Thread athread = new Thread(new ParameterizedThreadStart(todomulti));
                threadlist.Add(athread);
                athread.Start(start);// I want to pass the startpoint to method todomulti
                start = start + numpercore; // this is to get the new startpoint for the next thread
            }

            foreach (Thread athread in threadlist)
            {
                athread.Join();
            }
            foreach (Thread athread in threadlist)
            {
                athread.Abort();
            }
            
            return randommatrix;
            /* double u1, u2, w, z1, z2;
             Random rnd;

             public random_generator()
             {

                 rnd = new Random(GetHashCode());
             }
             public double[,] GetPaths(int trials, int steps,bool multithread)
             {
                 double[,] z = new double[trials, steps];
                 //This method utilizes polar rejection criteria to generate normally distributed values.
                 // inputs matrices 
                int numcores = System.Environment.ProcessorCount;

                 if (!multithread) numcores = 1;
                 /*int count = 0;
                 int NumSimsPerThread;                                   
                 if (trials % numcores == 0)
                     NumSimsPerThread =trials / numcores;
                 else NumSimsPerThread = trials / numcores+1;

                 List<Thread> threadpool = new List<Thread>();

                Action <object> Randomarray = (o) =>
                {
                    int start = Convert.ToInt32(o);
                    int end = start + NumSimsPerThread;
                    if (end > trials)
                    {
                        end = trials;
                    }
                    for (int i =0; i <trials; i++)

                    { 
                        for (int j = 0; j < steps; j++)

                        {                                          //for (int i= 0; i < start; 
                                u1 = 2 * rnd.NextDouble() - 1;        //u1 and u2 are uniformly distributed random  variables in range (-1,1)
                                u2 = 2 * rnd.NextDouble() - 1;
                                w = Math.Pow(u1, 2) + Math.Pow(u2, 2);

                             while (w > 1)
                                {
                                    u1 = 2 * rnd.NextDouble() - 1;
                                    u2 = 2 * rnd.NextDouble() - 1;
                                    w = Math.Pow(u1, 2) + Math.Pow(u2, 2);
                                }

                                z1 = Math.Sqrt(-2.0 * Math.Log(w) / w) * u1;//z1 and z2 are normally-distributed random variables.
                                z2 = Math.Sqrt(-2.0 * Math.Log(w) / w) * u2;
                                z[i, j] = z1;

                                if (i + 1 < trials)

                                {
                                    z[i + 1, j] = z2;
                                }

                            }

                        }
                 return z;
             }

                          /* for (int i = 0; i<numcores; i++)
                             {
                                 threadpool.Add(new Thread(new ParameterizedThreadStart(Randomarray)));
                                 threadpool[i].Start(count);
                                 count += NumSimsPerThread;
                                 }
                 foreach (Thread t in threadpool) t.Join();
                //foreach (Thread t in threadpool) t.Abort();
                 Program.increaseprogress(trials * steps);*/

        }
    }
}
