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
    public partial class Register : Form
    {
        SqlConnection cs = new SqlConnection("data source=KAZI\\SQLEXPRESS;initial catalog=chat1;integrated security=true");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
       
        
        public Register()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            da.InsertCommand = new SqlCommand("insert into info values (@name,@dob,@iam,@username,@password,@mobileno)", cs);
            da.InsertCommand.Parameters.Add("name", SqlDbType.VarChar).Value = textBox1.Text;
            da.InsertCommand.Parameters.Add("dob", SqlDbType.VarChar).Value = dateTimePicker1.Text;
            da.InsertCommand.Parameters.Add("iam", SqlDbType.Char).Value = comboBox1.Text;
            da.InsertCommand.Parameters.Add("username", SqlDbType.VarChar).Value = textBox2.Text;
            da.InsertCommand.Parameters.Add("password", SqlDbType.VarChar).Value = textBox3.Text;
            da.InsertCommand.Parameters.Add("mobileno", SqlDbType.VarChar).Value = textBox4.Text;
           
                      
            cs.Open();
            da.InsertCommand.ExecuteNonQuery();
            cs.Close();
            MessageBox.Show("Registration scucesfull");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.ResetText();
            textBox4.Clear();
            dateTimePicker1.ResetText();

            
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void registor_Load(object sender, EventArgs e)
        {

        }
    }
}
