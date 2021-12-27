﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace UDP_Socket
{
    public partial class Form1 : Form
    {
        Socket clientSocket;
        IPEndPoint serverAddress;
        public Form1()  
        {
            InitializeComponent();
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6767);
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Trim() == null)
            {
                MessageBox.Show("Emoty");
                richTextBox1.Focus();
                return;
            }
            byte[] buffer = Encoding.ASCII.GetBytes(richTextBox1.Text.Trim());
            clientSocket.SendTo(buffer,serverAddress);
            richTextBox1.Text = "";
        }

        
    }
}
