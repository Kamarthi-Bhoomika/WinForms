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

namespace WindowsFormsApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String str = "server=DESKTOP-CHNJ5UD;database=windowApp;User Id=DESKTOP-CHNJ5UD\\HP; TrustServerCertificate =true; Trusted_Connection=True";
                SqlConnection con = new SqlConnection(str);
                if (textID.Text != string.Empty || textPWD.Text != string.Empty)
                {

                    SqlCommand cmd = new SqlCommand("select * from user_login where id='" + textID.Text + "' and password='" + textPWD.Text + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        this.Hide();
                        Form1 f1 = new Form1();
                        f1.Closed += (s, args) => this.Close();
                        f1.Show();
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("No Account avilable with this Id and password ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter Id and password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
