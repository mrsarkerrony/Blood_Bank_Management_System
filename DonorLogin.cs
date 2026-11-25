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
    public partial class DonorLogin : Form
    {
        public static int logid;
        public DonorLogin()
        {
            InitializeComponent();
        }

        private void DonorLogin_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DR10NJP\SQLEXPRESS;Initial Catalog=blooddata;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            String name, id;
            id = idbox.Text;
            name = namebox.Text;

            try
            {
                String query = " Select * from donortab  where id='" + idbox.Text + "' AND name='" + namebox.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

               
                if (dt.Rows.Count > 0)
                {
                    
                    logid = int.Parse(idbox.Text);

                    Donor d = new Donor();
                    d.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Error ...Please try again!!");
                    idbox.Clear();
                    namebox.Clear();

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
