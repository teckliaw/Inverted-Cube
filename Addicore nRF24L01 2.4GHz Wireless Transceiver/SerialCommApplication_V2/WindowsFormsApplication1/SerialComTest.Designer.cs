namespace SerialCommTestApplication
{
    partial class fmSerialCommTest
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox11 = new System.Windows.Forms.RichTextBox();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox12 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DiscardNull = true;
            this.serialPort1.PortName = "COM14";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(50, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Open";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox11
            // 
            this.richTextBox11.Location = new System.Drawing.Point(152, 204);
            this.richTextBox11.Name = "richTextBox11";
            this.richTextBox11.Size = new System.Drawing.Size(512, 99);
            this.richTextBox11.TabIndex = 4;
            this.richTextBox11.Text = "";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(148, 14);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(91, 21);
            this.cbPort.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Serial Port";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(82, 321);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(50, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 22);
            this.button3.TabIndex = 8;
            this.button3.Text = "Start Test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(82, 354);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ACK Ok";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "ACK Failed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Rec Failed";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(82, 387);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown3.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // richTextBox12
            // 
            this.richTextBox12.Location = new System.Drawing.Point(152, 315);
            this.richTextBox12.Name = "richTextBox12";
            this.richTextBox12.Size = new System.Drawing.Size(512, 106);
            this.richTextBox12.TabIndex = 14;
            this.richTextBox12.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 20);
            this.tabControl1.Location = new System.Drawing.Point(148, 53);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(20, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 145);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(510, 117);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cmd 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(510, 117);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "Tab 1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(510, 117);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cmd 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(510, 117);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "Tab 2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(510, 117);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cmd 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox3.Location = new System.Drawing.Point(0, 0);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(510, 117);
            this.richTextBox3.TabIndex = 5;
            this.richTextBox3.Text = "Tab 3";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(510, 117);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cmd 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBox4
            // 
            this.richTextBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox4.Location = new System.Drawing.Point(0, 0);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(510, 117);
            this.richTextBox4.TabIndex = 5;
            this.richTextBox4.Text = "Tab 4";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.richTextBox5);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(510, 117);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Cmd 5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // richTextBox5
            // 
            this.richTextBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox5.Location = new System.Drawing.Point(0, 0);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(510, 117);
            this.richTextBox5.TabIndex = 5;
            this.richTextBox5.Text = "Tab 5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(703, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Zero Speed Point";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(860, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Set";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(706, 150);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 22);
            this.button5.TabIndex = 18;
            this.button5.Text = "Start Speed Test";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(800, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "1500";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(706, 178);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 21;
            this.textBox2.Text = "0";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(707, 203);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 21);
            this.button6.TabIndex = 22;
            this.button6.Text = "+1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_incdec_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(743, 203);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(30, 21);
            this.button7.TabIndex = 23;
            this.button7.Text = "-1";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_incdec_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(779, 203);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(30, 21);
            this.button8.TabIndex = 24;
            this.button8.Text = "+5";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_incdec_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(815, 203);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(30, 21);
            this.button9.TabIndex = 25;
            this.button9.Text = "-5";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button_incdec_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.Red;
            this.button10.Location = new System.Drawing.Point(707, 311);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(114, 60);
            this.button10.TabIndex = 26;
            this.button10.Text = "STOP";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // fmSerialCommTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 437);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.richTextBox12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.richTextBox11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "fmSerialCommTest";
            this.Text = "Serial Comm Test ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox11;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

