using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Monte_Carlo_Sim
{
    public partial class Form1 : Form
    {
        public void update(int i)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int >(update),new object[] {i});
                return;
            }
            progressBar1.Value = i;
       }
        int progress = 0;
        public delegate void increamentprogress();
        public increamentprogress mydelegate;

        public Form1()
        {
            InitializeComponent();
           
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;              
            timer1.Enabled = true;
           }
            public void increamentprogressmethod()
        {
            progress++;
            label1.Text = progress.ToString();
            progressBar1.Value = progress;
        }
        private void Form1_Load(Object sender,EventArgs e)
        {
            this.label_Time.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");//display time
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
    
            
            //Allow user input values
            double So = Convert.ToDouble(textBox_S.Text);//spot price of underlying
            double k = Convert.ToDouble(textBox_K.Text);//strike price
            double T = Convert.ToDouble(textBox_T.Text);//tenor
            double r = Convert.ToDouble(textBox_Rate.Text);//risk-free rate
            double sigma = Convert.ToDouble(textBox_Sigma.Text);//volatilty
            int trials = Convert.ToInt32(textBox_trials.Text);//number of simulations
            int steps = Convert.ToInt32(textBox_Steps.Text);//number of steps
            bool x = checkBox1.Checked;//use  antithetic variance reduction technique
            bool call = radioCall.Checked;//if checked computes call-option,otherwise the  will compute put-option.
            bool y = checkBox_CV.Checked;//use control-variate variance reduction technique 
            bool multithread = checkBox_Multithread.Checked;
            double barrier = Convert.ToDouble(textBox_Barrier.Text);
            double rebate = Convert.ToDouble(textBox_Rebate.Text);
            double SE;//standard error
            double Price;
            double delta;
            double gamma;
            double vega;
            double theta;
            double rho;

            if (checkBox_Multithread.Checked == false)
            {
                trials = Convert.ToInt32(textBox_trials.Text);//number of simulations
                int cores = Environment.ProcessorCount;
                if (trials % cores != 0)
                {
                    trials = trials + (cores - trials % cores);
                }
            }
            else
            {
                trials = Convert.ToInt32(textBox_trials.Text);//number of simulations
                int cores = Environment.ProcessorCount;
                if (trials % cores != 0)
                {
                    trials = trials + (cores - trials % cores);
                }
            }
            double dS = 0.001 * So;
            double dt = 0.00001 * T;
            double dsigma = 0.00001 * sigma;
            double dr = 0.00001 * r;
            double[,] randn = new double[trials, steps];

            random_generator c = new random_generator();
            European euro = new European(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);
            Asian asus = new Asian(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);
            Barrier_Down_IN bar = new Barrier_Down_IN(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);
            Barrier_DOWN_OUT bar1 = new Barrier_DOWN_OUT(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);
            Barrier_UP_IN bar2 = new Barrier_UP_IN(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);
            Barrier_UP_OUT bar3 = new Barrier_UP_OUT(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);
            Digital digi = new Digital(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);
            Range rng = new Range(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);
            Lookback lbk = new Lookback(So, k, T, r, steps, sigma, trials, x, call, multithread, barrier, rebate);

            Stopwatch timer = new Stopwatch();
            timer.Start();// start stop watch

            randn = c.multithreadingrandomfun(steps, trials);


            if (radioButton_european.Checked == true)//choose european option
            {  //calculate Price and Greeks for European Option
                if (radioCall.Checked == false && radioPut.Checked == false) { MessageBox.Show("please select option type (Call or Put)"); }//insist user to choose option type
                Price = euro.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE); update(10);
                delta = (euro.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - euro.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dS); update(30);
                gamma = (euro.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - (2 * euro.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) + euro.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (dS * dS); update(50);
                theta = (euro.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - euro.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dt); update(70);
                vega = (euro.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE) - euro.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dsigma); update(90);
                rho = (euro.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE) - euro.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dr); update(100);

                progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                {
                    //display output to user
                    textBox_Price.Text = Convert.ToString(Price); ;
                    textBox_delta.Text = Convert.ToString(delta);
                    textBox_gamma.Text = Convert.ToString(gamma);
                    textBox_theta.Text = Convert.ToString(theta);
                    textBox_vega.Text = Convert.ToString(vega);
                    textBox_rho.Text = Convert.ToString(rho);
                    textBox_std_error.Text = Convert.ToString(SE);
                   // label_Time.Text = DateTime.Now.ToString();
                    label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                    timer.Stop(); //stop stopwatch. 
                    TimeSpan ts = timer.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                    textBox_RunTime.Text = Convert.ToString(elapsedTime);
                }));
            }

            else if (radioButton_Asian.Checked == true)//choose Asian option
            {
                //calculate Price and Greeks for Asian Option
                if (radioCall.Checked == false && radioPut.Checked == false) { MessageBox.Show("please select option type (Call or Put)"); }//insist user to choose option type
                Price = asus.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE); update(10);
                delta = (asus.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - asus.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dS); update(30);
                gamma = (asus.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - (2 * asus.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) + asus.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (dS * dS); update(50);
                theta = (asus.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - asus.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dt); update(70);
                vega = (asus.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE) - asus.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dsigma); update(90);
                rho = (asus.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE) - asus.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dr); update(100);

                progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                {
                    //display output to user
                    textBox_Price.Text = Convert.ToString(Price); ;
                    textBox_delta.Text = Convert.ToString(delta);
                    textBox_gamma.Text = Convert.ToString(gamma);
                    textBox_theta.Text = Convert.ToString(theta);
                    textBox_vega.Text = Convert.ToString(vega);
                    textBox_rho.Text = Convert.ToString(rho);
                    textBox_std_error.Text = Convert.ToString(SE);
                   // label_Time.Text = DateTime.Now.ToString();
                    label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                    timer.Stop(); //stop stopwatch. 
                    TimeSpan ts = timer.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                    textBox_RunTime.Text = Convert.ToString(elapsedTime);
                }));
            }

            else if (radioButton_digital.Checked == true) //choose digital option
            {
                //calculate Price and Greeks for Digital Option
                if (radioCall.Checked == false && radioPut.Checked == false) { MessageBox.Show("please select option type(Call or Put)"); }//insist user to choose option type
                Price = digi.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate); update(10);
                delta = (digi.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate) - digi.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate)) / (2 * dS); update(30);
                gamma = (digi.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate) - (2 * digi.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate)) + digi.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate)) / (dS * dS); update(50);
                theta = (digi.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate) - digi.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate)) / (2 * dt); update(70);
                vega = (digi.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE, rebate) - digi.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE, rebate)) / (2 * dsigma); update(90);
                rho = (digi.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate) - digi.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, rebate)) / (2 * dr); update(100);

                progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                {
                    //display output to user
                    textBox_Price.Text = Convert.ToString(Price); ;
                    textBox_delta.Text = Convert.ToString(delta);
                    textBox_gamma.Text = Convert.ToString(gamma);
                    textBox_theta.Text = Convert.ToString(theta);
                    textBox_vega.Text = Convert.ToString(vega);
                    textBox_rho.Text = Convert.ToString(rho);
                    textBox_std_error.Text = Convert.ToString(SE);
                    //label_Time.Text = DateTime.Now.ToString();
                    label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                    timer.Stop(); //stop stopwatch. 
                    TimeSpan ts = timer.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                    textBox_RunTime.Text = Convert.ToString(elapsedTime);
                }));
            }

            else if (radioButton_barrier.Checked == true)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (radioCall.Checked == false && radioPut.Checked == false) { MessageBox.Show("please select option type(Call or Put)"); }//insist user to choose option type
                           // calculate Price and Greeks for Barrier Option                                                                                                                    //calculate Price and Greeks for Barrier Option
                     Price = bar.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier); update(10);
                    delta = (bar.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dS); update(30);
                    gamma = (bar.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - (2 * bar.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) + bar.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (dS * dS); update(50);
                    theta = (bar.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dt); update(70);
                    vega = (bar.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dsigma); update(90);
                    rho = (bar.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dr); update(100);
                
                progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                {
                    //display output to user
                    textBox_Price.Text = Convert.ToString(Price);
                    textBox_delta.Text = Convert.ToString(delta);
                    textBox_gamma.Text = Convert.ToString(gamma);
                    textBox_theta.Text = Convert.ToString(theta);
                    textBox_vega.Text = Convert.ToString(vega);
                    textBox_rho.Text = Convert.ToString(rho);
                    textBox_std_error.Text = Convert.ToString(SE);
                   // label_Time.Text = DateTime.Now.ToString();
                    label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                    timer.Stop(); //stop stopwatch. 
                    TimeSpan ts = timer.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                    textBox_RunTime.Text = Convert.ToString(elapsedTime);
                }));
            }

               else if (comboBox1.SelectedIndex == 1)
                {
                    if (radioCall.Checked == false && radioPut.Checked == false) { MessageBox.Show("please select option type(Call or Put)"); }//insist user to choose option type
                    //calculate Price and Greeks for Barrier Option
                    Price = bar1.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier); update(10);
                    delta = (bar1.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar1.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dS); update(30);
                    gamma = (bar1.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - (2 * bar1.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) + bar1.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (dS * dS); update(50);
                    theta = (bar1.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar1.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dt); update(70);
                    vega = (bar1.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar1.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dsigma); update(90);
                    rho = (bar1.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar1.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dr); update(100);
                    progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                    {
                        //display output to user
                        textBox_Price.Text = Convert.ToString(Price);
                        textBox_delta.Text = Convert.ToString(delta);
                        textBox_gamma.Text = Convert.ToString(gamma);
                        textBox_theta.Text = Convert.ToString(theta);
                        textBox_vega.Text = Convert.ToString(vega);
                        textBox_rho.Text = Convert.ToString(rho);
                        textBox_std_error.Text = Convert.ToString(SE);
                        //label_Time.Text = DateTime.Now.ToString();
                        label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                        timer.Stop(); //stop stopwatch. 
                        TimeSpan ts = timer.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                        textBox_RunTime.Text = Convert.ToString(elapsedTime);
                    }));
                }

               else if (comboBox1.SelectedIndex == 2)
                {
                    if (radioCall.Checked == false && radioPut.Checked == false) { MessageBox.Show("please select option type(Call or Put)"); }//insist user to choose option type

                    //calculate Price and Greeks for Barrier Option
                    Price = bar2.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier); update(10);
                    delta = (bar2.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar2.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dS); update(30);
                    gamma = (bar2.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - (2 * bar2.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) + bar2.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (dS * dS); update(50);
                    theta = (bar2.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar2.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dt); update(70);
                    vega = (bar2.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar2.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dsigma); update(90);
                    rho = (bar2.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar2.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dr); update(100);
                    progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                    {
                        //display output to user
                        textBox_Price.Text = Convert.ToString(Price);
                        textBox_delta.Text = Convert.ToString(delta);
                        textBox_gamma.Text = Convert.ToString(gamma);
                        textBox_theta.Text = Convert.ToString(theta);
                        textBox_vega.Text = Convert.ToString(vega);
                        textBox_rho.Text = Convert.ToString(rho);
                        textBox_std_error.Text = Convert.ToString(SE);
                        //label_Time.Text = DateTime.Now.ToString();
                        label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                        timer.Stop(); //stop stopwatch. 
                        TimeSpan ts = timer.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                        textBox_RunTime.Text = Convert.ToString(elapsedTime);
                    }));
                }
           
            
                else if (comboBox1.SelectedIndex == 3)
                {
                    if (radioCall.Checked == false && radioPut.Checked == false) { MessageBox.Show("please select option type(Call or Put)"); }//insist user to choose option type
                    //calculate Price and Greeks for Barrier Option
                    Price = bar3.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier); update(10);
                    delta = (bar3.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar3.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dS); update(30);
                    gamma = (bar3.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - (2 * bar3.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) + bar3.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (dS * dS); update(50);
                    theta = (bar3.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar3.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dt); update(70);
                    vega = (bar3.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar3.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dsigma); update(90);
                    rho = (bar3.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier) - bar3.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE, barrier)) / (2 * dr); update(100);
                    progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                    {
                        //display output to user
                        textBox_Price.Text = Convert.ToString(Price);
                        textBox_delta.Text = Convert.ToString(delta);
                        textBox_gamma.Text = Convert.ToString(gamma);
                        textBox_theta.Text = Convert.ToString(theta);
                        textBox_vega.Text = Convert.ToString(vega);
                        textBox_rho.Text = Convert.ToString(rho);
                        textBox_std_error.Text = Convert.ToString(SE);
                        //label_Time.Text = DateTime.Now.ToString();
                        label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                        timer.Stop(); //stop stopwatch. 
                        TimeSpan ts = timer.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                        textBox_RunTime.Text = Convert.ToString(elapsedTime);
                    }));
                }
            }
            else if (radioButton_lookback.Checked == true)
            {
                //calculte Price and greeks for Lookback option
                Price = lbk.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE); update(10);
                delta = (lbk.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - lbk.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dS); update(30);
                gamma = (lbk.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - (2 * lbk.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) + lbk.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (dS * dS); update(50);
                theta = (lbk.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - lbk.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dt); update(70);
                vega = (lbk.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE) - lbk.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dsigma); update(90);
                rho = (lbk.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE) - lbk.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dr); update(100);

                progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                {
                    //display output to user
                    textBox_Price.Text = Convert.ToString(Price); ;
                    textBox_delta.Text = Convert.ToString(delta);
                    textBox_gamma.Text = Convert.ToString(gamma);
                    textBox_theta.Text = Convert.ToString(theta);
                    textBox_vega.Text = Convert.ToString(vega);
                    textBox_rho.Text = Convert.ToString(rho);
                    textBox_std_error.Text = Convert.ToString(SE);
                  //  label_Time.Text = DateTime.Now.ToString();
                    label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                    timer.Stop(); //stop stopwatch. 
                    TimeSpan ts = timer.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                    textBox_RunTime.Text = Convert.ToString(elapsedTime);
                }));
            }

            else if (radioButton_range.Checked == true)
            {
                //calculate Price and Greeks for Range Option
                Price = rng.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE); update(10);
                delta = (rng.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - rng.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dS); update(30);
                gamma = (rng.Get_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - (2 * rng.Get_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) + rng.Get_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (dS * dS); update(50);
                theta = (rng.Get_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - rng.Get_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dt); update(70);
                vega = (rng.Get_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE) - rng.Get_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dsigma); update(90);
                rho = (rng.Get_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE) - rng.Get_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dr); update(100);

                progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

                {
                    //display output to user
                    textBox_Price.Text = Convert.ToString(Price); ;
                    textBox_delta.Text = Convert.ToString(delta);
                    textBox_gamma.Text = Convert.ToString(gamma);
                    textBox_theta.Text = Convert.ToString(theta);
                    textBox_vega.Text = Convert.ToString(vega);
                    textBox_rho.Text = Convert.ToString(rho);
                    textBox_std_error.Text = Convert.ToString(SE);
                    //label_Time.Text = DateTime.Now.ToString();
                    label2.Text = Convert.ToString(System.Environment.ProcessorCount);

                    timer.Stop(); //stop stopwatch. 
                    TimeSpan ts = timer.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                    textBox_RunTime.Text = Convert.ToString(elapsedTime);
                }));
            }
            /*else if (comboBox1.SelectedText == "American")
            {
                //calcuate Price and Greeks for American Option
             double   Price = euro.European_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE); update(10);
                delta = (euro.European_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - euro.European_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dS); update(30);
                gamma = (euro.European_price(So + dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - (2 * euro.European_price(So, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) + euro.European_price(So - dS, k, T, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (dS * dS); update(50);
                theta = (euro.European_price(So, k, T - dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE) - euro.European_price(So, k, T + dt, r, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dt); update(70);
                vega = (euro.European_price(So, k, T, r, sigma + dsigma, trials, steps, call, x, y, multithread, randn, out SE) - euro.European_price(So, k, T, r, sigma - dsigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dsigma); update(90);
                rho = (euro.European_price(So, k, T, r + dr, sigma, trials, steps, call, x, y, multithread, randn, out SE) - euro.European_price(So, k, T, r - dr, sigma, trials, steps, call, x, y, multithread, randn, out SE)) / (2 * dr); update(100);
            }
    

            progressBar1.BeginInvoke((Action)(() =>  // runs on UI thread

            {
                //display output to user
                textBox_Price.Text = Convert.ToString(Price);;
                textBox_delta.Text = Convert.ToString(delta); 
                textBox_gamma.Text = Convert.ToString(gamma); 
                textBox_theta.Text = Convert.ToString(theta); 
                textBox_vega.Text  = Convert.ToString(vega); 
                textBox_rho.Text   = Convert.ToString(rho);
                textBox_std_error.Text = Convert.ToString(SE);
                label_Time.Text = DateTime.Now.ToString();
                label2.Text= Convert.ToString(System.Environment.ProcessorCount);

                timer.Stop(); //stop stopwatch. 
                TimeSpan ts = timer.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);         // to show the run time in proper format.
                textBox_RunTime.Text = Convert.ToString(elapsedTime);
            }));  */
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {//error checking
            double d = 0.0;
            if (!double.TryParse(textBox_K.Text, out d))
            {
                textBox_K.BackColor = Color.LightPink;
            }
            else
            {
                textBox_K.BackColor = Color.White;
            }
     
            if (!double.TryParse(textBox_K.Text, out d))
                errorProvider1.SetError(textBox_K, "please enter a number");
            else
                errorProvider1.SetError(textBox_K, string.Empty);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {//error checking
            double d = 0.0;

            if (!double.TryParse(textBox_S.Text, out d))
            {
                textBox_S.BackColor = Color.LightPink;
            }

            else
            {
                textBox_S.BackColor = Color.White;
            }

            if (!double.TryParse(textBox_S.Text, out d))
                errorProvider1.SetError(textBox_S, "please enter a number");
            else
                errorProvider1.SetError(textBox_S, string.Empty);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {   //error checking
            double d = 0.0;

            if (!double.TryParse(textBox_T.Text, out d))
            {
                textBox_T.BackColor = Color.LightPink;
            }

            else
            {
                textBox_T.BackColor = Color.White;
            }
            
            if (!double.TryParse(textBox_T.Text, out d))
                errorProvider1.SetError(textBox_T, "please enter a number");
            else
                errorProvider1.SetError(textBox_T, string.Empty);
        }
        
        private void textBox9_TextChanged(object sender, EventArgs e)
        {//error checking
            double d = 0.0;
            if (!double.TryParse(textBox_K.Text, out d))
            {
                textBox_K.BackColor = Color.LightPink;
            }
            else
            {
                textBox_K.BackColor = Color.White;
            }
            
            if (!double.TryParse(textBox_K.Text, out d))
                errorProvider1.SetError(textBox_K, "please enter a number");
           else
                errorProvider1.SetError(textBox_K, string.Empty);
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {//error checking
            double d = 0.0;

            if (!double.TryParse(textBox_Rate.Text, out d))
            {
                textBox_Rate.BackColor = Color.LightPink;
            }

            else
            {
                textBox_Rate.BackColor = Color.White;
            }

            if (!double.TryParse(textBox_Rate.Text, out d))
                errorProvider1.SetError(textBox_Rate, "please enter a number");
            else
                errorProvider1.SetError(textBox_Rate, string.Empty);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        { //error checking
            int num= 0;
            if (!Int32.TryParse(textBox_Steps.Text, out num))
            {
                textBox_Steps.BackColor = Color.LightPink;
            }
            else
            {
                textBox_Steps.BackColor = Color.White;
            }
            if (!Int32.TryParse(textBox_Steps.Text, out num))
                errorProvider1.SetError(textBox_Steps, "please enter an integer");
            //else if (Convert.ToDouble(textBox_Steps.Text) != 2)
                //errorProvider1.SetError(textBox_Steps, "please just enter 2 !");
            else
                errorProvider1.SetError(textBox_Steps, string.Empty);
        }


        private void textBox_Sigma_TextChanged(object sender, EventArgs e)
        {   //error checking
            double d = 0.0;
            if (!double.TryParse(textBox_Sigma.Text, out d))
            {
                textBox_Sigma.BackColor = Color.LightPink;
            }
            else
            {
                textBox_Sigma.BackColor = Color.White;
            }

            if (!double.TryParse(textBox_Sigma.Text, out d))
                errorProvider1.SetError(textBox_Sigma, "please enter a number");
            else
                errorProvider1.SetError(textBox_Sigma, string.Empty);
        }

        private void label_Steps_Click(object sender, EventArgs e)
        {

        }

        private void label_S_Click(object sender, EventArgs e)
        {

        }

        private void label_K_Click(object sender, EventArgs e)
        {

        }

        private void label_trials_Click(object sender, EventArgs e)
        {

        }

        private void textBox_trials_TextChanged(object sender, EventArgs e)
        {   // error checking
            int d = 0;

            if (!Int32.TryParse(textBox_trials.Text , out d))
            {
                textBox_trials.BackColor = Color.LightPink;
            }

            else
            {
                textBox_trials.BackColor = Color.White;
            }

            if (!Int32.TryParse(textBox_trials.Text, out d))
                errorProvider1.SetError(textBox_trials, "please enter an integer");
            else
                errorProvider1.SetError(textBox_trials, string.Empty);
        }

        private void textBox_rho_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Price_Click(object sender, EventArgs e)
        {

        }

        private void label_gamma_Click(object sender, EventArgs e)
        {

        }

        private void label_stderror_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void textBox_Barrier_TextChanged(object sender, EventArgs e)
        {
            int d = 0;

            if (!Int32.TryParse(textBox_Barrier.Text, out d))
            {
                textBox_Barrier.BackColor = Color.LightPink;
            }

            else
            {
                textBox_Barrier.BackColor = Color.White;
            }

            if (!Int32.TryParse(textBox_Barrier.Text, out d))
                errorProvider1.SetError(textBox_Barrier, "please enter an integer");
            else
                errorProvider1.SetError(textBox_Barrier, string.Empty);
        }

        private void textBox_Rebate_TextChanged(object sender, EventArgs e)
        {
            int d = 0;

            if (!Int32.TryParse(textBox_Rebate.Text, out d))
            {
                textBox_Rebate.BackColor = Color.LightPink;
            }

            else
            {
                textBox_Rebate.BackColor = Color.White;
            }

            if (!Int32.TryParse(textBox_Rebate.Text, out d))
                errorProvider1.SetError(textBox_Rebate, "please enter an integer");
            else
                errorProvider1.SetError(textBox_Rebate, string.Empty);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label_Vega_Click(object sender, EventArgs e)
        {

        }

        private void label_rho_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}