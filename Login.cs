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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");

        private void loginbtn_Click(object sender, EventArgs e)
        {
            String username, password;
            username = userbox.Text;
            password = passbox.Text;

            try
            {
                String query = " Select * from logintab  where username='" + userbox.Text + "' AND password='" + passbox.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query,con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count>0)
                {
                    username = userbox.Text;
                    password = passbox.Text;

                    Hospital h1 = new Hospital();
                    h1.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid Error ...Please try again!!");
                    userbox.Clear();
                    passbox.Clear();

                }
            }

            catch
            {
                MessageBox.Show("Error...");
            }
            finally
            {
                con.Close();
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
