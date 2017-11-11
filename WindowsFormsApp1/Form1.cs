using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string port = "";
        Image image;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string portNum = "";

            serialPort1.Close();
            foreach (string ports in SerialPort.GetPortNames())
            {
                portNum = ports.ToString();
                comboBox1.Items.Add(portNum);
                port = portNum;
            }
            if(comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = (port);
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.Encoding = Encoding.Default;
                serialPort1.Open();
                txtArduino.Text += "Connection Success." + Environment.NewLine;
            }
            catch
            {
                txtArduino.Text += "port not avaiable !" + Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //serialPort1.IsOpen
            if(serialPort1.IsOpen) //Is Serialport Open
            {
                serialPort1.WriteLine("Start");
                txtArduino.Text += "Start" + Environment.NewLine;
                string log;
                while ((log = serialPort1.ReadLine()) != "Sending")
                {
                    txtArduino.Text += log;
                }
                //while end, log was Sending.

            }
        }
    }
}
