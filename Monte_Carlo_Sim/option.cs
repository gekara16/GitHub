using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Sim
{
    public  class option
    {//fields
     //public double spot   { get; set; }
     //public double strike { get; set; }
     //public double tenor  { get; set; }
     //public double rate   { get; set; }
     //public double volatility  { get; set; }
     //public int   sims  { get; set; }
     //public int   stepsize   { get; set; }

        protected double _So;
        protected double _k;
        protected double _T;
        protected double _r;
        protected double _sigma;
        protected double[,] _randn;
        protected double _barrier;
        protected double _rebate;
        protected int _trials;
        protected int _steps;
        protected bool _x;
        protected bool _multithread;
        protected bool _y;
        public option(double So, double k, double T, double r, double sigma, bool y, int trials, int steps, bool x, bool multithread,double barrier,double rebate)
        {
            _So = So;
            _k  = k;
            _T = T;
            _r = r;
            _y  = y;
        _sigma  = sigma;
        _trials = trials;
         _steps = steps;
            _x  = x;
   _multithread = multithread;
            _barrier = barrier;
            _rebate = rebate;    
            random_generator rnd = new random_generator();
       _randn = rnd.multithreadingrandomfun(_steps, _trials);

        }
       // public double Get_price(double So, double k, double T, double r, double sigma, int trials, int steps, bool call, bool x, bool y, bool multithread, double[,] randn, out double SE) { }
        public void d(bool Y)
        {
             _y=Y;
        }
        public double[,] random_matrix
        {
            set { this._randn = value; }
            get { return this._randn; }
        }

        public double stockPrice                                  //property corresponding to stock price.
        {
            get
            {
                return this._So;
            }
            set
            {
                this._So = value;
            }

        }
        public double strike_price                               //property corresponding to exercise price.
        {
            get
            {
                return this._k;
            }
            set
            {
                this._k = value;
            }
        }
        public double rate                                        //property corresponding to risk fee rate.
        {
            get
            {
                return this._r;
            }
            set
            {
                this._r = value;
            }
        }
        public double tenor                                    
        {
            get
            {
                return this._T;
            }
            set
            {
                this._T = value;
            }
        }
        public int Steps                                       
        {
            get
            {
                return this._steps;
            }
            set
            {
                this._steps = value;
            }
        }
        public double volatility                                  
        {
            get
            {
                return this._sigma;
            }
            set
            {
                this._sigma = value;
            }

        }
        public int Trials                                        
        {
            get
            {
                return this._trials;
            }
            set
            {
                this._trials = value;
            }
        }
        public void antithetic(bool X )     //Property corresponding to if we are going to use antithetic variance reduction approach or not.
        {
             _x=X;
        }

        public void thread(bool multithread)
        {
            _multithread = multithread;
        }
        public double Rebate
        {
            get
            {
                return this._rebate;
            }
            set
            {
                this._rebate = value;
            }
        }
        public double Barrier
        {
            get
            {
                return this._barrier;
            }
            set
            {
                this._barrier = value;
            }

        }

    }

}
