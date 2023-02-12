using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DBForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            // connection
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DotNetFullStack;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select E.* , D.Name from Employee E , Department D Where E.dept_id=D.ID");
            cmd.Connection = con;
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //adapter.Fill(dt);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GEmployee.DataSource = GetAll();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void GEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void clear()
        {
            textBox1.Text = textBox3.Text = textBox2.Text = string.Empty;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DotNetFullStack;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into Employee values (@id,@name,@dept_id)");
            cmd.Parameters.AddWithValue("id", textBox1.Text);
            cmd.Parameters.AddWithValue("name", textBox3.Text);
            cmd.Parameters.AddWithValue("Dept_Id", textBox2.Text);
            cmd.Connection = con;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                GEmployee.DataSource = GetAll();
                MessageBox.Show("Insertion Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Insertion Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clear();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DotNetFullStack;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("update Employee set name=@name , dept_Id=@Dept_Id  where id=@id");
            cmd.Parameters.AddWithValue("id", textBox1.Text);
            cmd.Parameters.AddWithValue("name", textBox3.Text);
            cmd.Parameters.AddWithValue("Dept_Id", textBox2.Text);
            cmd.Connection = con;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                GEmployee.DataSource = GetAll();
                MessageBox.Show("Update Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("update Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clear();
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DotNetFullStack;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("delete from Employee where id=@id");
            cmd.Parameters.AddWithValue("id", textBox1.Text);
            cmd.Connection = con;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                GEmployee.DataSource = GetAll();
                MessageBox.Show("Delete Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Delete Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clear();
            con.Close();

        }
    }
}
