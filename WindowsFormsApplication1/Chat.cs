using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Chat : Form
    {

        Socket sck;
        EndPoint epLocal, epRemote;
        byte[] buffer;

        public Chat()
        {
            InitializeComponent();
            //set up socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //get user IP
            textLocalIp.Text = GetLocalIP();
            textRemoteIP.Text = GetLocalIP();

        }
        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }



            return "127.0.0.1";

        }
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                if (size > 0) 
                {



                    byte[] receivedData = new byte[1500];
                    receivedData = (byte[])aResult.AsyncState;
                    //converting byte[] to string
                    ASCIIEncoding aEncoding = new ASCIIEncoding();
                    string receivedMessage = aEncoding.GetString(receivedData);

                    //Adding this message into listbox
                    listMessage.Items.Add("Friend: " + receivedMessage);

                }

                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        


        private void listMessege_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Chat_Load(object sender, EventArgs e)
        {
           
        }
      


        


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            //binding socket
            epLocal = new IPEndPoint(IPAddress.Parse(textLocalIp.Text), Convert.ToInt32(textLocalPort.Text));
            sck.Bind(epLocal);
            //connecting to remote ip
            epRemote = new IPEndPoint(IPAddress.Parse(textRemoteIP.Text), Convert.ToInt32(textRemotePort.Text));
            sck.Connect(epRemote);
            //listening the specific port
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            button1.Text = "Connected";

            button1.Enabled = false;
            button2.Enabled = true;
            textMessage.Focus();


            }
        
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                //convert string message to byte[]
                System.Text.ASCIIEncoding aEncoding = new System.Text.ASCIIEncoding();
                byte[] sendingMessage = new byte[1500];
                sendingMessage = aEncoding.GetBytes(textMessage.Text);

                //sending encoded message
                sck.Send(sendingMessage);

                //add to the list box
                listMessage.Items.Add("Me: " + textMessage.Text);
                textMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            sign_in p = new sign_in();
            p.Show();

            this.Hide();
            MessageBox.Show("Successfully Log out");
        }
    }
}
