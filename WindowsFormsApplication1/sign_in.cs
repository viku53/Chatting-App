using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
namespace WindowsFormsApplication1
{   

    public partial class sign_in : Form
    {
        SqlConnection cs = new SqlConnection("data source=KAZI\\SQLEXPRESS;initial catalog=chat1;integrated security=true");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public class g
        {
           public static String txt;
        }
        public sign_in()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {   
            
            da.SelectCommand = new SqlCommand("select username,password from info where username='"+textBox1.Text+"'AND password='"+textBox2.Text+"'",cs);
            da.Fill(ds);
            
            if(ds.Tables[0].Rows.Count>0)
            {
                cs.Open();
                g.txt = textBox1.Text;
                profile p = new profile();
                
                p.Show();
               
                this.Hide();
              

            }
            else
            {
                MessageBox.Show("you have not registered");
                textBox1.Clear();
                textBox2.Clear();
                cs.Close();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void sign_in_Load(object sender, EventArgs e)
        {

        }
        
    }
}
