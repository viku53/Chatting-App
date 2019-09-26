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

namespace WindowsFormsApplication1
{    
    public partial class profile : Form
    {
        SqlConnection cs = new SqlConnection("data source=KAZI\\SQLEXPRESS;initial catalog=chat1;integrated security=true");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
            
        public profile()
        {
            InitializeComponent();
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide(); ;
            MessageBox.Show("You have been signed out");
        }

        private void profile_Load(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("select * from info where username='"+sign_in.g.txt+"'", cs);
            ds.Clear();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bs.DataSource = ds.Tables[0];
            textBox1.DataBindings.Add(new Binding("text", bs, "name"));
            textBox2.DataBindings.Add(new Binding("text", bs, "username"));
            textBox3.DataBindings.Add(new Binding("text", bs, "iam"));
            textBox4.DataBindings.Add(new Binding("text", bs, "mobileno"));
       




        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Chat c = new Chat();
            c.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Can't Change");
            button1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Can't Change");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Can't Change");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Can't Change");
            button1.Focus();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Can't Change");
            button1.Focus();
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Can't Change");
            button1.Focus();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Can't Change");
            button1.Focus();
        }
    }
}
