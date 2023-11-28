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
    public partial class TaskList : Form
    {
        public TaskList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTask f2 = new AddTask();
            f2.Closed += (s, args) => this.Close();
            f2.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'windowAppDataSet2.addTask' table. You can move, or remove it, as needed.
            this.addTaskTableAdapter1.Fill(this.windowAppDataSet2.addTask);
            

        }
    }
}
