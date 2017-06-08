namespace Monte_Carlo_Sim
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radioCall = new System.Windows.Forms.RadioButton();
            this.radioPut = new System.Windows.Forms.RadioButton();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.textBox_theta = new System.Windows.Forms.TextBox();
            this.textBox_rho = new System.Windows.Forms.TextBox();
            this.textBox_vega = new System.Windows.Forms.TextBox();
            this.textBox_gamma = new System.Windows.Forms.TextBox();
            this.textBox_delta = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_stderror = new System.Windows.Forms.Label();
            this.label_rho = new System.Windows.Forms.Label();
            this.label_Vega = new System.Windows.Forms.Label();
            this.label_gamma = new System.Windows.Forms.Label();
            this.label_theta = new System.Windows.Forms.Label();
            this.label_delta = new System.Windows.Forms.Label();
            this.label_Price = new System.Windows.Forms.Label();
            this.textBox_Sigma = new System.Windows.Forms.TextBox();
            this.textBox_S = new System.Windows.Forms.TextBox();
            this.textBox_K = new System.Windows.Forms.TextBox();
            this.textBox_T = new System.Windows.Forms.TextBox();
            this.textBox_Rate = new System.Windows.Forms.TextBox();
            this.textBox_std_error = new System.Windows.Forms.TextBox();
            this.label_S = new System.Windows.Forms.Label();
            this.label_K = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Steps = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Steps = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_trials = new System.Windows.Forms.Label();
            this.textBox_trials = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label_Runtime = new System.Windows.Forms.Label();
            this.textBox_RunTime = new System.Windows.Forms.TextBox();
            this.label_Time = new System.Windows.Forms.Label();
            this.checkBox_CV = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox_Multithread = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Barrier = new System.Windows.Forms.TextBox();
            this.textBox_Rebate = new System.Windows.Forms.TextBox();
            this.radioButton_european = new System.Windows.Forms.RadioButton();
            this.radioButton_Asian = new System.Windows.Forms.RadioButton();
            this.radioButton_range = new System.Windows.Forms.RadioButton();
            this.radioButton_lookback = new System.Windows.Forms.RadioButton();
            this.radioButton_digital = new System.Windows.Forms.RadioButton();
            this.radioButton_barrier = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioCall
            // 
            this.radioCall.AutoSize = true;
            this.radioCall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioCall.Location = new System.Drawing.Point(3, 3);
            this.radioCall.Name = "radioCall";
            this.radioCall.Size = new System.Drawing.Size(46, 17);
            this.radioCall.TabIndex = 0;
            this.radioCall.TabStop = true;
            this.radioCall.Text = "Call";
            this.radioCall.UseVisualStyleBackColor = true;
            this.radioCall.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioPut
            // 
            this.radioPut.AutoSize = true;
            this.radioPut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioPut.Location = new System.Drawing.Point(3, 30);
            this.radioPut.Name = "radioPut";
            this.radioPut.Size = new System.Drawing.Size(44, 17);
            this.radioPut.TabIndex = 1;
            this.radioPut.TabStop = true;
            this.radioPut.Text = "Put";
            this.radioPut.UseVisualStyleBackColor = true;
            this.radioPut.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(102, 19);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(104, 20);
            this.textBox_Price.TabIndex = 2;
            this.textBox_Price.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_theta
            // 
            this.textBox_theta.Location = new System.Drawing.Point(102, 69);
            this.textBox_theta.Name = "textBox_theta";
            this.textBox_theta.Size = new System.Drawing.Size(104, 20);
            this.textBox_theta.TabIndex = 3;
            this.textBox_theta.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox_rho
            // 
            this.textBox_rho.Location = new System.Drawing.Point(102, 146);
            this.textBox_rho.Name = "textBox_rho";
            this.textBox_rho.Size = new System.Drawing.Size(104, 20);
            this.textBox_rho.TabIndex = 4;
            this.textBox_rho.TextChanged += new System.EventHandler(this.textBox_rho_TextChanged);
            // 
            // textBox_vega
            // 
            this.textBox_vega.Location = new System.Drawing.Point(102, 122);
            this.textBox_vega.Name = "textBox_vega";
            this.textBox_vega.Size = new System.Drawing.Size(104, 20);
            this.textBox_vega.TabIndex = 5;
            this.textBox_vega.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox_gamma
            // 
            this.textBox_gamma.Location = new System.Drawing.Point(102, 95);
            this.textBox_gamma.Name = "textBox_gamma";
            this.textBox_gamma.Size = new System.Drawing.Size(104, 20);
            this.textBox_gamma.TabIndex = 6;
            // 
            // textBox_delta
            // 
            this.textBox_delta.Location = new System.Drawing.Point(102, 43);
            this.textBox_delta.Name = "textBox_delta";
            this.textBox_delta.Size = new System.Drawing.Size(104, 20);
            this.textBox_delta.TabIndex = 7;
            this.textBox_delta.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.radioCall);
            this.panel1.Controls.Add(this.radioPut);
            this.panel1.Location = new System.Drawing.Point(1, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 50);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(78, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 2;
            // 
            // label_stderror
            // 
            this.label_stderror.AutoSize = true;
            this.label_stderror.Location = new System.Drawing.Point(3, 177);
            this.label_stderror.Name = "label_stderror";
            this.label_stderror.Size = new System.Drawing.Size(93, 13);
            this.label_stderror.TabIndex = 9;
            this.label_stderror.Text = "Standard Error:";
            this.label_stderror.Click += new System.EventHandler(this.label_stderror_Click);
            // 
            // label_rho
            // 
            this.label_rho.AutoSize = true;
            this.label_rho.Location = new System.Drawing.Point(16, 153);
            this.label_rho.Name = "label_rho";
            this.label_rho.Size = new System.Drawing.Size(34, 13);
            this.label_rho.TabIndex = 10;
            this.label_rho.Text = "Rho:";
            this.label_rho.Click += new System.EventHandler(this.label_rho_Click);
            // 
            // label_Vega
            // 
            this.label_Vega.AutoSize = true;
            this.label_Vega.Location = new System.Drawing.Point(10, 129);
            this.label_Vega.Name = "label_Vega";
            this.label_Vega.Size = new System.Drawing.Size(40, 13);
            this.label_Vega.TabIndex = 11;
            this.label_Vega.Text = "Vega:";
            this.label_Vega.Click += new System.EventHandler(this.label_Vega_Click);
            // 
            // label_gamma
            // 
            this.label_gamma.AutoSize = true;
            this.label_gamma.Location = new System.Drawing.Point(6, 103);
            this.label_gamma.Name = "label_gamma";
            this.label_gamma.Size = new System.Drawing.Size(52, 13);
            this.label_gamma.TabIndex = 12;
            this.label_gamma.Text = "Gamma:";
            this.label_gamma.Click += new System.EventHandler(this.label_gamma_Click);
            // 
            // label_theta
            // 
            this.label_theta.AutoSize = true;
            this.label_theta.Location = new System.Drawing.Point(6, 78);
            this.label_theta.Name = "label_theta";
            this.label_theta.Size = new System.Drawing.Size(44, 13);
            this.label_theta.TabIndex = 13;
            this.label_theta.Text = "Theta:";
            // 
            // label_delta
            // 
            this.label_delta.AutoSize = true;
            this.label_delta.Location = new System.Drawing.Point(5, 47);
            this.label_delta.Name = "label_delta";
            this.label_delta.Size = new System.Drawing.Size(41, 13);
            this.label_delta.TabIndex = 14;
            this.label_delta.Text = "Delta:";
            this.label_delta.Click += new System.EventHandler(this.label6_Click);
            // 
            // label_Price
            // 
            this.label_Price.AutoSize = true;
            this.label_Price.Location = new System.Drawing.Point(6, 20);
            this.label_Price.Name = "label_Price";
            this.label_Price.Size = new System.Drawing.Size(40, 13);
            this.label_Price.TabIndex = 15;
            this.label_Price.Text = "Price:";
            this.label_Price.Click += new System.EventHandler(this.label_Price_Click);
            // 
            // textBox_Sigma
            // 
            this.textBox_Sigma.Location = new System.Drawing.Point(77, 169);
            this.textBox_Sigma.Name = "textBox_Sigma";
            this.textBox_Sigma.Size = new System.Drawing.Size(116, 20);
            this.textBox_Sigma.TabIndex = 16;
            this.textBox_Sigma.Text = "0.5";
            this.textBox_Sigma.TextChanged += new System.EventHandler(this.textBox_Sigma_TextChanged);
            // 
            // textBox_S
            // 
            this.textBox_S.Location = new System.Drawing.Point(77, 14);
            this.textBox_S.Name = "textBox_S";
            this.textBox_S.Size = new System.Drawing.Size(116, 20);
            this.textBox_S.TabIndex = 17;
            this.textBox_S.Text = "50";
            this.textBox_S.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // textBox_K
            // 
            this.textBox_K.Location = new System.Drawing.Point(77, 40);
            this.textBox_K.Name = "textBox_K";
            this.textBox_K.Size = new System.Drawing.Size(116, 20);
            this.textBox_K.TabIndex = 18;
            this.textBox_K.Text = "50";
            this.textBox_K.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // textBox_T
            // 
            this.textBox_T.Location = new System.Drawing.Point(77, 66);
            this.textBox_T.Name = "textBox_T";
            this.textBox_T.Size = new System.Drawing.Size(116, 20);
            this.textBox_T.TabIndex = 19;
            this.textBox_T.Text = "1";
            this.textBox_T.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // textBox_Rate
            // 
            this.textBox_Rate.Location = new System.Drawing.Point(77, 89);
            this.textBox_Rate.Name = "textBox_Rate";
            this.textBox_Rate.Size = new System.Drawing.Size(116, 20);
            this.textBox_Rate.TabIndex = 20;
            this.textBox_Rate.Text = "0.05";
            this.textBox_Rate.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // textBox_std_error
            // 
            this.textBox_std_error.Location = new System.Drawing.Point(102, 170);
            this.textBox_std_error.Name = "textBox_std_error";
            this.textBox_std_error.Size = new System.Drawing.Size(104, 20);
            this.textBox_std_error.TabIndex = 21;
            // 
            // label_S
            // 
            this.label_S.AutoSize = true;
            this.label_S.Location = new System.Drawing.Point(9, 17);
            this.label_S.Name = "label_S";
            this.label_S.Size = new System.Drawing.Size(65, 13);
            this.label_S.TabIndex = 23;
            this.label_S.Text = "Spot price";
            this.label_S.Click += new System.EventHandler(this.label_S_Click);
            // 
            // label_K
            // 
            this.label_K.AutoSize = true;
            this.label_K.Location = new System.Drawing.Point(1, 46);
            this.label_K.Name = "label_K";
            this.label_K.Size = new System.Drawing.Size(73, 13);
            this.label_K.TabIndex = 24;
            this.label_K.Text = "Strike Price";
            this.label_K.Click += new System.EventHandler(this.label_K_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tenor";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Rate";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_Steps
            // 
            this.textBox_Steps.Location = new System.Drawing.Point(77, 115);
            this.textBox_Steps.Name = "textBox_Steps";
            this.textBox_Steps.Size = new System.Drawing.Size(116, 20);
            this.textBox_Steps.TabIndex = 27;
            this.textBox_Steps.Text = "2";
            this.textBox_Steps.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Volatility";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label_Steps
            // 
            this.label_Steps.AutoSize = true;
            this.label_Steps.Location = new System.Drawing.Point(31, 122);
            this.label_Steps.Name = "label_Steps";
            this.label_Steps.Size = new System.Drawing.Size(39, 13);
            this.label_Steps.TabIndex = 29;
            this.label_Steps.Text = "Steps";
            this.label_Steps.Click += new System.EventHandler(this.label_Steps_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Monte_Carlo_Sim.Properties.Resources.maxresdefault;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(130, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 63);
            this.button1.TabIndex = 30;
            this.button1.Text = "Compute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // label_trials
            // 
            this.label_trials.AutoSize = true;
            this.label_trials.Location = new System.Drawing.Point(28, 147);
            this.label_trials.Name = "label_trials";
            this.label_trials.Size = new System.Drawing.Size(38, 13);
            this.label_trials.TabIndex = 31;
            this.label_trials.Text = "Trials";
            this.label_trials.Click += new System.EventHandler(this.label_trials_Click);
            // 
            // textBox_trials
            // 
            this.textBox_trials.Location = new System.Drawing.Point(77, 144);
            this.textBox_trials.Name = "textBox_trials";
            this.textBox_trials.Size = new System.Drawing.Size(116, 20);
            this.textBox_trials.TabIndex = 32;
            this.textBox_trials.Text = "100000";
            this.textBox_trials.TextChanged += new System.EventHandler(this.textBox_trials_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Location = new System.Drawing.Point(6, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "Antithetic";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label_Runtime
            // 
            this.label_Runtime.AutoSize = true;
            this.label_Runtime.BackColor = System.Drawing.Color.Transparent;
            this.label_Runtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Runtime.Location = new System.Drawing.Point(268, 453);
            this.label_Runtime.Name = "label_Runtime";
            this.label_Runtime.Size = new System.Drawing.Size(145, 24);
            this.label_Runtime.TabIndex = 34;
            this.label_Runtime.Text = "Time Elapsed:";
            // 
            // textBox_RunTime
            // 
            this.textBox_RunTime.Location = new System.Drawing.Point(432, 458);
            this.textBox_RunTime.Name = "textBox_RunTime";
            this.textBox_RunTime.Size = new System.Drawing.Size(178, 20);
            this.textBox_RunTime.TabIndex = 35;
            this.textBox_RunTime.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Location = new System.Drawing.Point(348, 2);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(65, 13);
            this.label_Time.TabIndex = 36;
            this.label_Time.Text = "DateTime:";
            // 
            // checkBox_CV
            // 
            this.checkBox_CV.AutoSize = true;
            this.checkBox_CV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox_CV.Location = new System.Drawing.Point(7, 31);
            this.checkBox_CV.Name = "checkBox_CV";
            this.checkBox_CV.Size = new System.Drawing.Size(110, 17);
            this.checkBox_CV.TabIndex = 37;
            this.checkBox_CV.Text = "Control Variate";
            this.checkBox_CV.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.checkBox_Multithread);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.checkBox_CV);
            this.panel3.Location = new System.Drawing.Point(1, 407);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(123, 76);
            this.panel3.TabIndex = 38;
            // 
            // checkBox_Multithread
            // 
            this.checkBox_Multithread.AutoSize = true;
            this.checkBox_Multithread.Location = new System.Drawing.Point(7, 54);
            this.checkBox_Multithread.Name = "checkBox_Multithread";
            this.checkBox_Multithread.Size = new System.Drawing.Size(89, 17);
            this.checkBox_Multithread.TabIndex = 39;
            this.checkBox_Multithread.Text = "Multithread";
            this.checkBox_Multithread.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 229);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 18);
            this.progressBar1.TabIndex = 39;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Number of cores used";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Rebate";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Barrier";
            // 
            // textBox_Barrier
            // 
            this.textBox_Barrier.Location = new System.Drawing.Point(77, 196);
            this.textBox_Barrier.Name = "textBox_Barrier";
            this.textBox_Barrier.Size = new System.Drawing.Size(116, 20);
            this.textBox_Barrier.TabIndex = 47;
            this.textBox_Barrier.Text = "60";
            this.textBox_Barrier.TextChanged += new System.EventHandler(this.textBox_Barrier_TextChanged);
            // 
            // textBox_Rebate
            // 
            this.textBox_Rebate.Location = new System.Drawing.Point(77, 219);
            this.textBox_Rebate.Name = "textBox_Rebate";
            this.textBox_Rebate.Size = new System.Drawing.Size(116, 20);
            this.textBox_Rebate.TabIndex = 48;
            this.textBox_Rebate.Text = "5";
            this.textBox_Rebate.TextChanged += new System.EventHandler(this.textBox_Rebate_TextChanged);
            // 
            // radioButton_european
            // 
            this.radioButton_european.AutoSize = true;
            this.radioButton_european.Location = new System.Drawing.Point(6, 65);
            this.radioButton_european.Name = "radioButton_european";
            this.radioButton_european.Size = new System.Drawing.Size(79, 17);
            this.radioButton_european.TabIndex = 49;
            this.radioButton_european.TabStop = true;
            this.radioButton_european.Text = "European";
            this.radioButton_european.UseVisualStyleBackColor = true;
            // 
            // radioButton_Asian
            // 
            this.radioButton_Asian.AutoSize = true;
            this.radioButton_Asian.Location = new System.Drawing.Point(6, 19);
            this.radioButton_Asian.Name = "radioButton_Asian";
            this.radioButton_Asian.Size = new System.Drawing.Size(56, 17);
            this.radioButton_Asian.TabIndex = 50;
            this.radioButton_Asian.TabStop = true;
            this.radioButton_Asian.Text = "Asian";
            this.radioButton_Asian.UseVisualStyleBackColor = true;
            this.radioButton_Asian.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // radioButton_range
            // 
            this.radioButton_range.AutoSize = true;
            this.radioButton_range.Location = new System.Drawing.Point(6, 42);
            this.radioButton_range.Name = "radioButton_range";
            this.radioButton_range.Size = new System.Drawing.Size(62, 17);
            this.radioButton_range.TabIndex = 51;
            this.radioButton_range.TabStop = true;
            this.radioButton_range.Text = "Range";
            this.radioButton_range.UseVisualStyleBackColor = true;
            // 
            // radioButton_lookback
            // 
            this.radioButton_lookback.AutoSize = true;
            this.radioButton_lookback.Location = new System.Drawing.Point(91, 41);
            this.radioButton_lookback.Name = "radioButton_lookback";
            this.radioButton_lookback.Size = new System.Drawing.Size(81, 17);
            this.radioButton_lookback.TabIndex = 52;
            this.radioButton_lookback.TabStop = true;
            this.radioButton_lookback.Text = "Lookback";
            this.radioButton_lookback.UseVisualStyleBackColor = true;
            // 
            // radioButton_digital
            // 
            this.radioButton_digital.AutoSize = true;
            this.radioButton_digital.Location = new System.Drawing.Point(91, 18);
            this.radioButton_digital.Name = "radioButton_digital";
            this.radioButton_digital.Size = new System.Drawing.Size(61, 17);
            this.radioButton_digital.TabIndex = 53;
            this.radioButton_digital.TabStop = true;
            this.radioButton_digital.Text = "Digital";
            this.radioButton_digital.UseVisualStyleBackColor = true;
            this.radioButton_digital.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton_barrier
            // 
            this.radioButton_barrier.AutoSize = true;
            this.radioButton_barrier.Location = new System.Drawing.Point(91, 64);
            this.radioButton_barrier.Name = "radioButton_barrier";
            this.radioButton_barrier.Size = new System.Drawing.Size(62, 17);
            this.radioButton_barrier.TabIndex = 54;
            this.radioButton_barrier.TabStop = true;
            this.radioButton_barrier.Text = "Barrier";
            this.radioButton_barrier.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Down_&_In",
            "Down_&_Out",
            "Up_&_In",
            "Up_&Out"});
            this.comboBox1.Location = new System.Drawing.Point(159, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(99, 21);
            this.comboBox1.TabIndex = 55;
            this.comboBox1.Text = "Barrier Style";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton_Asian);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.radioButton_range);
            this.groupBox1.Controls.Add(this.radioButton_barrier);
            this.groupBox1.Controls.Add(this.radioButton_european);
            this.groupBox1.Controls.Add(this.radioButton_lookback);
            this.groupBox1.Controls.Add(this.radioButton_digital);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(7, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 91);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option Style";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label_S);
            this.groupBox2.Controls.Add(this.textBox_S);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox_Rebate);
            this.groupBox2.Controls.Add(this.textBox_Barrier);
            this.groupBox2.Controls.Add(this.textBox_K);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label_K);
            this.groupBox2.Controls.Add(this.textBox_T);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_Rate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_Steps);
            this.groupBox2.Controls.Add(this.label_Steps);
            this.groupBox2.Controls.Add(this.textBox_trials);
            this.groupBox2.Controls.Add(this.label_trials);
            this.groupBox2.Controls.Add(this.textBox_Sigma);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(8, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 253);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label_Price);
            this.groupBox3.Controls.Add(this.textBox_Price);
            this.groupBox3.Controls.Add(this.label_delta);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_delta);
            this.groupBox3.Controls.Add(this.label_theta);
            this.groupBox3.Controls.Add(this.textBox_theta);
            this.groupBox3.Controls.Add(this.label_gamma);
            this.groupBox3.Controls.Add(this.textBox_gamma);
            this.groupBox3.Controls.Add(this.label_Vega);
            this.groupBox3.Controls.Add(this.textBox_vega);
            this.groupBox3.Controls.Add(this.textBox_rho);
            this.groupBox3.Controls.Add(this.textBox_std_error);
            this.groupBox3.Controls.Add(this.label_rho);
            this.groupBox3.Controls.Add(this.label_stderror);
            this.groupBox3.Location = new System.Drawing.Point(667, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(231, 273);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Monte_Carlo_Sim.Properties.Resources.maxresdefault;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(941, 502);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.textBox_RunTime);
            this.Controls.Add(this.label_Runtime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Magenta;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monte_Carlo_Sim";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCall;
        private System.Windows.Forms.RadioButton radioPut;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.TextBox textBox_theta;
        private System.Windows.Forms.TextBox textBox_rho;
        private System.Windows.Forms.TextBox textBox_vega;
        private System.Windows.Forms.TextBox textBox_gamma;
        private System.Windows.Forms.TextBox textBox_delta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_stderror;
        private System.Windows.Forms.Label label_rho;
        private System.Windows.Forms.Label label_Vega;
        private System.Windows.Forms.Label label_gamma;
        private System.Windows.Forms.Label label_theta;
        private System.Windows.Forms.Label label_delta;
        private System.Windows.Forms.Label label_Price;
        private System.Windows.Forms.TextBox textBox_Sigma;
        private System.Windows.Forms.TextBox textBox_S;
        private System.Windows.Forms.TextBox textBox_K;
        private System.Windows.Forms.TextBox textBox_T;
        private System.Windows.Forms.TextBox textBox_Rate;
        private System.Windows.Forms.TextBox textBox_std_error;
        private System.Windows.Forms.Label label_S;
        private System.Windows.Forms.Label label_K;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Steps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_Steps;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_trials;
        private System.Windows.Forms.TextBox textBox_trials;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox textBox_RunTime;
        private System.Windows.Forms.Label label_Runtime;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.CheckBox checkBox_CV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_Multithread;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Rebate;
        private System.Windows.Forms.TextBox textBox_Barrier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton_digital;
        private System.Windows.Forms.RadioButton radioButton_lookback;
        private System.Windows.Forms.RadioButton radioButton_range;
        private System.Windows.Forms.RadioButton radioButton_Asian;
        private System.Windows.Forms.RadioButton radioButton_european;
        private System.Windows.Forms.RadioButton radioButton_barrier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

