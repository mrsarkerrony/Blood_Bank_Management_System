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

namespace _2nd_Blood_Bank
{
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from donortab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
               private void insertbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into donortab values(@id,@name,@group,@gender,@address,@phone)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(idbox.Text));
            cmd.Parameters.AddWithValue("@name", namebox.Text);
            cmd.Parameters.AddWithValue("@group", groupbox.Text);
            cmd.Parameters.AddWithValue("@gender", genderbox.Text);
            cmd.Parameters.AddWithValue("@address", addressbox.Text);
            cmd.Parameters.AddWithValue("@phone", phonebox.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Inserted Done");
            Management_Load(null, null);
            Clear();

        }

      

        private void backbtn_Click(object sender, EventArgs e)
        {
            Hospital h1 = new Hospital();
            this.Hide();
            h1.Show();
            
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
           

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("update donortab set name=@name,[group]=@group,gender=@gender,address=@address,phone=@phone where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(idbox.Text));
            cmd.Parameters.AddWithValue("@name", namebox.Text);
            cmd.Parameters.AddWithValue("@group", groupbox.Text);
            cmd.Parameters.AddWithValue("@gender", genderbox.Text);
            cmd.Parameters.AddWithValue("@address", addressbox.Text);
            cmd.Parameters.AddWithValue("@phone", phonebox.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Done");
            Management_Load(null, null);
            Clear();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete donortab where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(idbox.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Done");
            Management_Load(null, null);
            Clear();
        }

        public void Clear()
        {
            idbox.Text = "";
            namebox.Text = "";
            groupbox.Text = "";
            genderbox.Text = "";
            addressbox.Text = "";
            phonebox.Text = "";

        }


    }
}
