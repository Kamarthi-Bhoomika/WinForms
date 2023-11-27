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
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String str = "server=DESKTOP-CHNJ5UD;database=windowApp;User Id=DESKTOP-CHNJ5UD\\HP; TrustServerCertificate =true; Trusted_Connection=True";
                SqlConnection con = new SqlConnection(str);
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty)
                {
                    string SQL = "addData";
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Task", SqlDbType.VarChar));
                    cmd.Parameters["@Task"].Value = textBox1.Text;
                    cmd.Parameters.Add(new SqlParameter("@startDate", SqlDbType.Date));
                    cmd.Parameters["@startDate"].Value = textBox2.Text;
                    cmd.Parameters.Add(new SqlParameter("@endDate", SqlDbType.Date));
                    cmd.Parameters["@endDate"].Value = textBox3.Text;
                    cmd.Parameters.Add(new SqlParameter("@Progress", SqlDbType.Int));
                    cmd.Parameters["@Progress"].Value = textBox4.Text;
                    cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar));
                    cmd.Parameters["@Status"].Value = textBox5.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected != null)
                    {
                        MessageBox.Show("Task added");
                        this.Hide();
                        Form1 f1 = new Form1();
                        f1.Closed += (s, args) => this.Close();
                        f1.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter All Fields", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Closed += (s, args) => this.Close();
            f1.Show();
        }
    }
}
