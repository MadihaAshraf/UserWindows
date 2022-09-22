using MySql.Data.MySqlClient;
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

namespace SummerTask01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM users", "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "users");
            userDataGridView.DataSource = ds.Tables["users"].DefaultView;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string Insertquery = "Insert into users(name,email) values ('" + textBox2.Text + "','" + textBox3 + "')";
            SqlCommand cmd = new SqlCommand(Insertquery, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Inserted Successfully...!");
            }
            else
            {
                MessageBox.Show("ERROR...Please try again....");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string Updatequery = "Update users set name = '" + textBox2.Text + "', email = '" + textBox3 + "' where id = " + textBox1.Text + " ";
            SqlCommand cmd = new SqlCommand(Updatequery, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Updated Successfully...!");
            }
            else
            {
                MessageBox.Show("ERROR...Please try again....");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string Deletequery = "delete from users where id = '" + textBox1.Text + "';";

            SqlCommand cmd = new SqlCommand(Deletequery, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data deleted Successfully...!");
            }
            else
            {
                MessageBox.Show("ERROR...Please try again....");
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            String SelectQry = " Select * from users where id = " + textBox1.Text + " ";
            SqlDataAdapter sda = new SqlDataAdapter(SelectQry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                textBox2.Text = dt.Rows[0]["name"].ToString();
                textBox3.Text = dt.Rows[0]["email"].ToString();
            }
            
            else
            {
                MessageBox.Show("no data found");
            }
          
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
