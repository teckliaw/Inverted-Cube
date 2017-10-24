using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;


namespace SerialCommTestApplication
{
    public partial class fmSerialCommTest : Form
    {
        const char ACK = (char)6;       // Acknowledge
        const char NAK = (char)21;      // Negative acknowledge
        const char STX = (char)2;       // Start of text
        const char ETX = (char)3;       // End of text

        Boolean InTestMode = false; 
        String MsgReceive = "", DebugMsg = "", DisplayMsg = "";
        int numericUpDownID;
        Boolean InDataReceived = false;
        Boolean IsSpeedTest = false;

        //int Counter = 0;      // counter for injecting error checksum

        public fmSerialCommTest()
        {
            InitializeComponent();
        }

        private int CalChksum(string dataToCalculate, int nByte = 1)
        {
            byte[] byteToCalculate = Encoding.ASCII.GetBytes(dataToCalculate);
            int checksum = 0;

            foreach (byte chData in byteToCalculate)
                checksum += chData;

            checksum &= ((nByte == 2)? 0xffff: 0xff);  // will expend to include 3 & 4 bytes
            return checksum;
        }

        private string CalChksumHexStr(string dataToCalculate, int nByte = 1)
        {
            int chksum = CalChksum(dataToCalculate,1);
            return chksum.ToString("X" + (nByte*2).ToString());
        }

        private String GenRamdomStr(int MinLen, int MaxLen, char CharFrom = '0', char CharTo = '~')
        {
            String RndStr = "";
            Random rnd = new Random();
            int StrLen = (MinLen == MaxLen? MinLen : rnd.Next(MinLen, MaxLen+1)); // MinLen <= StrLne <= MaxLen

            // generate a random string between MinLen to MaxLen characters
            while (StrLen-- > 0)
                RndStr += (char) rnd.Next(CharFrom, CharTo); 

            return RndStr;
        }

        private String GetTestStr()
        {
            String TestStr = GenRamdomStr(5, 300);
            //System.Threading.Thread.Sleep(100);
            return TestStr;
        }

        private void SendTestStr()
        {
            writeSerialPort(GetTestStr());
            timer1.Enabled = true;
        }

        // protocol: <STX> + <Msg> + <Checksum> + <ETX>
        private String prepareProtocol(String Msg)
        {
            String ChksumStr = CalChksumHexStr(Msg, 1);
            //Counter++;
            //if (Counter > 10)
            //{
            //    ChksumStr = "";   // inject errrFFor checksum for test
            //    Counter = 0;
            //}  
            Msg = STX + Msg + ChksumStr + ETX;         // protocal
            return Msg;
        }

        private Boolean isSerialPortOpened()
        {
            if (serialPort1.IsOpen)
                return true;

            richTextBox11.AppendText("Error - Serial port not opened yet!\n");
            return false;
        }
        private void writeSerialPort(String Msg)
        {
            Msg = prepareProtocol(Msg);     // pad with STX (Start of Text), ETX  (End of Text) and checksum
            if (isSerialPortOpened())
                serialPort1.Write(Msg);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                switch (tabControl1.SelectedIndex)
                {
                    case 0: writeSerialPort(richTextBox1.Text); break;
                    case 1: writeSerialPort(richTextBox2.Text); break;
                    case 2: writeSerialPort(richTextBox3.Text); break;
                    case 3: writeSerialPort(richTextBox4.Text); break;
                    case 4: writeSerialPort(richTextBox5.Text); break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Meaasge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private String TranslateMsg(String Msg)
        {
            String TranslatedText = "";
            int n = 0;

            while (n < Msg.Length)
            {
                if (32 <= Msg[n] && Msg[n] <= 126)
                    TranslatedText += Msg[n];
                else
                    TranslatedText += "<" + (int)Msg[n] + ">";

                n++;
            }
            return TranslatedText;
        }

        private void displayText(object o, EventArgs e)
        {
            String MsgText = TranslateMsg(DisplayMsg);
            richTextBox11.AppendText(MsgText+'\n');
            richTextBox11.ScrollToCaret();

            switch (numericUpDownID)
            {
                case 1:
                    numericUpDown1.Value++;
                    break;
                case 2:
                    numericUpDown2.Value++;
                    break;
                case 3:
                    numericUpDown3.Value++;
                    break;
                default:
                    break;
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String ReceivedText = serialPort1.ReadExisting();
            String Msg = "";

            // Upon reentry to serialPort1_DataReceived(), the ReceivedText must append to
            // MsgReceive and exit quickly to continue the previous invocation.
            if (InDataReceived)
            {
                showDebugMsg("Reentrance InDataReceived, Received Text =" + ReceivedText);
                MsgReceive += ReceivedText;
                return;
            }
            else
                MsgReceive += ReceivedText;

            showDebugMsg("MsgReceive = [" + MsgReceive + "]");
            InDataReceived = true;
            try
            {
                int n = 0;
                char ch;
                
                // ReveivedText can be multiple lines contains multiple STX and ETX
                timer1.Enabled = false;
                while (n < MsgReceive.Length)
                {
                    ch = MsgReceive[n];   n++;
                    switch (ch)
                    {
                        case STX:               // Start of Text
                            Msg = "";           //reset Msg buffer if encounter STX signal 
                            showDebugMsg("Received STX");
                            break;

                        case ETX:               // End of message text received
                            string ChecksumStr = Msg.Substring(Msg.Length - 2, 2);
                            Msg = Msg.Substring(0, Msg.Length - 2); // remove checksum bytes
                            showDebugMsg("Received ETX Msg = [" + Msg + "]");
                            if (CalChksumHexStr(Msg) != ChecksumStr)
                            {
                                showDebugMsg("Chksum Error: CalChksumHexStr(Msg) = " +
                                        CalChksumHexStr(Msg) + "   ChecksumStr = " + ChecksumStr);
                                // genareate receive checksum error
                                numericUpDownID = 3;
                            }
                            else
                            {
                                if (Msg[0] == ACK)
                                    numericUpDownID = 1;
                                else if (Msg[0] == NAK)
                                    numericUpDownID = 2;
                                else
                                {
                                    // need to parse the incoming msg to take appropriate actions. 
                                    numericUpDownID = -1;
                                    DisplayMsg = Msg;
                                    this.Invoke(new EventHandler(displayText));
                                }
                            }                            
                            Msg = "";
                            break;

                        default:
                            Msg += ch;
                            break;
                    }
                }
                //else
                    //timer1.Enabled = true;
            }
            finally
            {
                showDebugMsg("Exiting serialPort1_DataReceived Msg = [" + Msg + "]");
                MsgReceive = Msg;       // remaining of completely processed message if any
                InDataReceived = false;
                if (InTestMode)
                    SendTestStr();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Open")
            {
                try
                {
                    serialPort1.PortName = cbPort.Text;
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                        richTextBox12.AppendText("Serial port open successfully!\n");
                    }
                    else
                        richTextBox12.AppendText("Serial port already opened.\n");

                    button1.Enabled = true;
                    button3.Enabled = true;
                    button2.Text = "Close";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Meaasge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                button2.Text = "Open";
                try
                {
                    if (serialPort1.IsOpen)
                        serialPort1.Close();

                    button1.Enabled = false;
                    button3.Enabled = false;
                    richTextBox12.AppendText("Serial port closed\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Meaasge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Inv3DSettings");
            key.SetValue("Number", cbPort.SelectedIndex);
            key.SetValue("SelectedIndex", tabControl1.SelectedIndex);
            key.SetValue("ZeroSpeedPoint", textBox1.Text);
            key.SetValue("SpeedTest", textBox2.Text);

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Inv3DCommand");
            key.SetValue("CmdText1", richTextBox1.Text);
            key.SetValue("CmdText2", richTextBox2.Text);
            key.SetValue("CmdText3", richTextBox3.Text);
            key.SetValue("CmdText4", richTextBox4.Text);
            key.SetValue("CmdText5", richTextBox5.Text);
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            Microsoft.Win32.RegistryKey key;  
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Inv3DSettings");
            
            string[] ports = SerialPort.GetPortNames();
            cbPort.Items.AddRange(ports);
            cbPort.SelectedIndex = (int) key.GetValue("Number", 0);
            tabControl1.SelectedIndex = (int)key.GetValue("SelectedIndex", 0);
            textBox1.Text = (String)key.GetValue("ZeroSpeedPoint", "1500");
            textBox2.Text = (String)key.GetValue("SpeedTest", "0");
            button2.Text = "Open";

            // when using numericUpDown components, for some unknown reasons, it will keeps resetting
            // the following to blanks values, so textBox1 is used instead
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Inv3DCommand");
            richTextBox1.Text = (String)key.GetValue("CmdText1", "");
            richTextBox2.Text = (String)key.GetValue("CmdText2", "");
            richTextBox3.Text = (String)key.GetValue("CmdText3", "");
            richTextBox4.Text = (String)key.GetValue("CmdText4", "");
            richTextBox5.Text = (String)key.GetValue("CmdText5", "");
            key.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Start Test")
            {
                button3.Text = "Stop Test";
                InTestMode = true;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
                SendTestStr();
            }
            else
            {
                button3.Text = "Start Test";
                InTestMode = false;
            }
            button2.Enabled = ! InTestMode;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            showDebugMsg("time out for ETX");
            serialPort1.Write("FF"+ETX.ToString()); 
            numericUpDown2.Value++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String cmdStr = "ZP:" + textBox1.Text + ";";
            writeSerialPort(cmdStr);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int n;

            if (! int.TryParse(textBox1.Text, out n))
            {
                MessageBox.Show(this, "Zero Speed Point must be a number!", "Error");
                textBox1.Undo();
            }
        }

        private void setSpeed()
        {
            int n;
            String cmd;

            if (IsSpeedTest)
            {
                if (int.TryParse(textBox2.Text, out n))
                {

                    if (n >= 0)
                        writeSerialPort("CW:" + textBox2.Text + ";");
                    else
                    {
                        n = -n;
                        writeSerialPort("CC:" + n.ToString() + ";");
                    }
                }
            }
        }

        private void button_incdec_Click(object sender, EventArgs e)
        {
            int n;

            if (int.TryParse(textBox2.Text, out n))
            {
                if (((Button)sender).Name == "button6")
                    n++;
                else if (((Button)sender).Name == "button7")
                    n--;
                else
                    n += (((Button)sender).Name == "button8") ? 5 : -5;
             }                    
             textBox2.Text = n.ToString();
             setSpeed();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isSerialPortOpened())
            {
                if (IsSpeedTest)
                {
                    button5.Text = "Start Speed Test";
                    IsSpeedTest = false;
                    writeSerialPort("ST;");     // Stop spinning 
                }
                else
                {
                    button5.Text = "Stop Speed Test";
                    IsSpeedTest = true;
                    setSpeed();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (IsSpeedTest)
                button5_Click(sender, e);   // stop speed test 

            
            writeSerialPort("ES;");         // Emergency Stop spinning, it will kill the task queus first
        }

        private void debugText(object o, EventArgs e)
        {
            richTextBox12.AppendText(DebugMsg + '\n');
            richTextBox12.ScrollToCaret();
        }


        private void showDebugMsg(String Msg)
        {
            DebugMsg = TranslateMsg(Msg);
            this.Invoke(new EventHandler(debugText));
        }
    }
}
