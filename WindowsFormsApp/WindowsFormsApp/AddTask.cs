using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp
{
    public partial class AddTask : Form
    {
        public AddTask()
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
                String str = "server=tcp:TESTAUTO-2;database=windowApp;User Id=TESTAUTO-2\\Administrator; TrustServerCertificate =true; Trusted_Connection=True";
                SqlConnection con = new SqlConnection(str);
                if (textBox1.Text != string.Empty && dateTimePicker1.Text != string.Empty && dateTimePicker2.Text != string.Empty  && domainUpDown1.Text != string.Empty)
                {
                    string SQL = "addData";
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Task", SqlDbType.VarChar));
                    cmd.Parameters["@Task"].Value = textBox1.Text;
                    cmd.Parameters.Add(new SqlParameter("@startDate", SqlDbType.Date));
                    cmd.Parameters["@startDate"].Value = dateTimePicker1.Text;
                    cmd.Parameters.Add(new SqlParameter("@endDate", SqlDbType.Date));
                    cmd.Parameters["@endDate"].Value = dateTimePicker2.Text;
                    cmd.Parameters.Add(new SqlParameter("@Progress", SqlDbType.Int));
                    cmd.Parameters["@Progress"].Value = textBox4.Text;
                    cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar));
                    cmd.Parameters["@Status"].Value = domainUpDown1.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected != null)
                    {
                        MessageBox.Show("Task added");
                        this.Hide();
                        TaskList f1 = new TaskList();
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
            TaskList f1 = new TaskList();
            f1.Closed += (s, args) => this.Close();
            f1.Show();
        }

        private void Progress_validating(object sender, CancelEventArgs e)
        {
            int parsedValue;
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider2.SetError(textBox4, "Field should not be left blank");
            }
            else if (!int.TryParse(textBox4.Text, out parsedValue))
            {
                errorProvider2.SetError(textBox4,"Progess contains only numbers");
                return;
            }
            else if(Convert.ToInt32(textBox4.Text) < 0 || Convert.ToInt32(textBox4.Text) > 100)
            {
                errorProvider2.SetError(textBox4, "Number should be between 0 and 100");

            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox4, "");
            }


        }
    }
}
