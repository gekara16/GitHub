using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Monte_Carlo_Sim
{
    static class Program
    {    //The original author of this program is Joseph Gekara. Please send review ratings of this program to ogega009@umn.edu
        ///Great thanks to Amin Sabzivand and Ruitao Wu for your contribution.
        /// <summary>
        /// The main entry point for the application.
        /////This program intends to price a European Option using Monte-carlo simulation method.To improve effeciency of this model ,i found two mathematical techniques useful;namely Polar-rejection and antithetic variance reduction.
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread t = new Thread(RunGUI);
            t.Start();
        }

       public static Form1 GUI = new Form1();
        
        delegate void threadcheck(int amount);
        public static void increaseprogress(int input)
        {
            if (Program.GUI.progressBar1.InvokeRequired)
            {
                threadcheck progressdelegate = new threadcheck(threadcheckmethod);
            GUI.progressBar1.Invoke(progressdelegate, input);
            }
            else
            {
                threadcheckmethod(input);
            }
    }
        public static void threadcheckmethod(int amount)
        {
            if (GUI.progressBar1.Value +amount < GUI.progressBar1.Maximum)
            {
                GUI.progressBar1.Value += amount;
            }
            else
            {
                GUI.progressBar1.Value = GUI.progressBar1.Maximum;
            }
            GUI.progressBar1.Update();
        }
        
        static void RunGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GUI);
        }
    }
}
