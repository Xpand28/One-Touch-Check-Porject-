using DocumentFormat.OpenXml.Spreadsheet;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OneTouchCheck
{
    public partial class TeacherAddStud : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        string conString = Program.ConnectionString;


        public void dbCon()
        {
            con = new SqlConnection(conString);
            con.Open();
            com = new SqlCommand();
        }
        public TeacherAddStud()
        {
            InitializeComponent();
        }

        private void TeacherAddStud_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Reporta = new ReportA();
            Reporta.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Go Form1 - Login
                Form form1 = new Login();
                this.Hide();
                form1.Show();
                //Remove stuff
                Program.isAdvicer = 0;
                Program.isHeadTeacher = 0;
                Program.isTeacher = 0;
                Program.isAdmin = 0;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form archive = new Archive();
            archive.Show();
            this.Hide();
        }

        private void TeacherAddStud_Load(object sender, EventArgs e)
        {
            label1.Text = Program.fname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Teacher.SelectedValue.ToString());

            if (male.Checked)
            {
                dbCon();
                com.CommandText = "insert into students (subjectId, name, gender, isDeactivated) VALUES ('" + Program.selsubjId + "','" + fullName.Text + "','" + 1 + "','" + 0 + "')";
                com.Connection = con;
                com.ExecuteNonQuery();
                com.Connection.Close();
            }
            else if (female.Checked)
            {
                dbCon();
                com.CommandText = "insert into students (subjectId, name, gender, isDeactivated) VALUES ('" + Program.selsubjId + "','" + fullName.Text + "','" + 0 + "','" + 0 + "')";
                com.Connection = con;
                com.ExecuteNonQuery();
                com.Connection.Close();
            }
            MessageBox.Show("User information added successfully.");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear?", "Continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fullName.Clear();
                male.Checked = false;
                female.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to go back?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form Form1 = new Attendance();
                Form1.Show();
                this.Hide();
            }
        }
    }
}
