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

namespace _2nd_Blood_Bank
{
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

            Donor_Load(null,null);
            Clear();

           
   


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
            Donor_Load(null, null);
            Clear();
            
        }

       /* private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from donortab where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(idbox.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Done");
        }*/

        private void Donor_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from donortab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            

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

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection( @"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");

            con.Open();

            int loginid = DonorLogin.logid;

            SqlCommand cmd = new SqlCommand( "delete from donortab where id=@id AND id=@loginid", con);

            cmd.Parameters.AddWithValue("@id", int.Parse(idbox.Text));
            cmd.Parameters.AddWithValue("@loginid", loginid);

            int row = cmd.ExecuteNonQuery();

            con.Close();

            if (row > 0)
            {
                MessageBox.Show("Deleted Done");
                Donor_Load(null, null);
                Clear();
            }
            else
            {
                MessageBox.Show("You can delete only your own information");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
    
}
