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
    public partial class AvaiableBlood : Form
    {
        public AvaiableBlood()
        {
            InitializeComponent();
        }

       

        private void AvaiableBlood_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from donortab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
            con.Open();
            string key = searchbox.Text;
            SqlCommand cmd = new SqlCommand("select * from  donortab where name like '%"+key+"%' or id like '%"+key+"%' or [group] like '%"+key+"%' ", con);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
