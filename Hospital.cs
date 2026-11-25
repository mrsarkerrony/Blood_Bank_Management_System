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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _2nd_Blood_Bank
{
    public partial class Hospital : Form
    {
        public Hospital()
        {
            InitializeComponent();
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into hospitaltab values(@id,@name,@address)",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(idbox.Text));
            cmd.Parameters.AddWithValue("@name", namebox.Text);
            cmd.Parameters.AddWithValue("@address", addressbox.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Done");
            Hospital_Load(null, null);
            Clear();




        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("update hospitaltab set id=@id,name=@name,address=@address where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(idbox.Text));
            cmd.Parameters.AddWithValue("@name", namebox.Text);
            cmd.Parameters.AddWithValue("@address", addressbox.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Done");
            Hospital_Load(null, null);
            Clear();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete hospitaltab where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(idbox.Text));
           
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Done");
            Hospital_Load(null,null);
            Clear();
        }

        private void Hospital_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from hospitaltab",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void managebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Management mn = new Management();
            mn.Show();
        }

        public void Clear()
        {
            idbox.Text = "";
            namebox.Text = "";
            addressbox.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
