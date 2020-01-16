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
namespace c_Sharp_Project
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=telephone;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from [Table] where (Mobile like '%" + textBox5.Text + "%') or (FirstName like '%" + textBox5.Text + "%') or (LastName like '%" + textBox5.Text + "%') or (EmailID like '%" + textBox5.Text + "%') or (Category like '%" + textBox5.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["LastName"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Mobile"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["EmailID"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Category"].ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            //or
            textBox2.Clear();
            textBox3.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            //-1 because items start in box is from 0 & -1 will make it point to empty data
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from [Table] where (Mobile like '%"+textBox5.Text+"%') or(FirstName like '%"+textBox5.Text+"%') or (LastName like '%"+textBox5.Text+"%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["LastName"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Mobile"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["EmailID"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Category"].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* SqlCommand->insert, update,delete operations
             SqlDataReader->select operation
             SqlDataAdapter-> it can perform both sqlcommand & sqldatareader operations & no need to open and close connection
       
            */
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [Table](FirstName,LastName,Mobile,EmailID,Category)VALUES
            ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Saved...!");
            Display();
        }
        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from [Table]",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["LastName"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Mobile"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["EmailID"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Category"].ToString();

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           textBox1.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString() ;
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           comboBox1.Text= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"delete from [Table] where
            (Mobile='"+textBox3.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully...!");
            Display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update [Table] set FirstName='"+textBox1.Text+"',LastName='"+textBox2.Text+"',Mobile='"+textBox3.Text+"'," +
                "EmailID='"+textBox4.Text+"',Category='"+comboBox1.Text+"'where" +
                " (Mobile='"+textBox3.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully...!");
            Display();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
