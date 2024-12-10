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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace OneTouchCheck
{
    public partial class HeadTeacherAdd : Form
    {
        private ToolTip toolTip;
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        string conString = Program.ConnectionString;

        public void dbCon()
        {
            con = new SqlConnection(conString);
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
        }

        public HeadTeacherAdd()
        {
            InitializeComponent();
            Block.KeyPress += Block_KeyPress;
            toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox2, "Go to Management page");
            toolTip.SetToolTip(pictureBox4, "Go to Home page");
            toolTip.SetToolTip(pictureBox10, "Go to Report Page");
            toolTip.SetToolTip(pictureBox9, "Go to Archives");
            toolTip.SetToolTip(pictureBox12, "Change Password page");
            toolTip.SetToolTip(pictureBox11, "Log Out");
            toolTip.SetToolTip(pictureBox3, "Notification");
        }

        private void HeadTeacherAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void HeadTeacherAdd_Load(object sender, EventArgs e)
        {
            dbCon();
            LoadAdvisers();
            LoadTeachers();
            Adviser.SelectedIndex = -1;
            Teacher.SelectedIndex = -1;
            label1.Text = Program.fname;
        }

        private void LoadAdvisers()
        {

            string query = "SELECT users.id, users.name " +
                           "FROM users " +
                           "JOIN roles ON roles.userId = users.id " +
                           "WHERE roles.roleName = 'Advicer'";

            com.CommandText = query;
            dr = com.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);

            Adviser.DataSource = dataTable;
            Adviser.DisplayMember = "name";
            Adviser.ValueMember = "id";

            dr.Close();
        }

        private void LoadTeachers()
        {
            string query = "SELECT users.id, users.name " +
                           "FROM users " +
                           "JOIN roles ON roles.userId = users.id " +
                           "WHERE roles.roleName = 'SubjectTeacher'";

            com.CommandText = query;
            dr = com.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);

            Teacher.DataSource = dataTable;
            Teacher.DisplayMember = "name";
            Teacher.ValueMember = "id";

            dr.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to logout?", "Continue ?");
            if (result)
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to Add Subject&Block?", "Continue ?");
            if (result)
            {
                if (Adviser.SelectedIndex == -1 ||
                Teacher.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(GradeLevel.Text) ||
                string.IsNullOrWhiteSpace(Strand.Text) ||
                string.IsNullOrWhiteSpace(SubjectName.Text) ||
                string.IsNullOrWhiteSpace(Block.Text))
                {
                    cmbok.Show("Please fill in all fields before adding a subject.", "Validation Error", true);
                    return;
                }


                try
                {
                    dbCon();
                    com.CommandText = "INSERT INTO subjects (AdvicerUserId, TeacherUserId, GradeLevel, Strand, SubjectName, Blk) " +
                                      "VALUES (@AdvicerUserId, @TeacherUserId, @GradeLevel, @Strand, @SubjectName, @Blk)";
                    com.Parameters.AddWithValue("@AdvicerUserId", Adviser.SelectedValue);
                    com.Parameters.AddWithValue("@TeacherUserId", Teacher.SelectedValue);
                    com.Parameters.AddWithValue("@GradeLevel", int.Parse(GradeLevel.Text));
                    com.Parameters.AddWithValue("@Strand", Strand.Text);
                    com.Parameters.AddWithValue("@SubjectName", SubjectName.Text);
                    com.Parameters.AddWithValue("@Blk", int.Parse(Block.Text));

                    com.ExecuteNonQuery();
                    cmbok.Show("You successfully added a subject and block to the teacher.", "Add", false);
                }
                catch (Exception ex)
                {
                    cmbok.Show("An error occurred while adding the subject: " + ex.Message, "Error", true);
                }
                finally
                {

                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to clear the form?", "Continue ?");
            if (result)
            {
                Adviser.SelectedIndex = -1;
                Teacher.SelectedIndex = -1;
                GradeLevel.SelectedIndex = -1;
                Strand.SelectedIndex = -1;

                SubjectName.Text = string.Empty;
                Block.Text = string.Empty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to go back to User Management?", "Continue ?");
            if (result)
            {
                Form HeadTeacherManage = new HeadTeacherManage();
                HeadTeacherManage.Show();
                this.Hide();
            }
        }


        private void Block_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                e.Handled = true;
            }
        }



        private void pictureBox11_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to logout?", "Continue ?");
            if (result)
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

        // Home page
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form TeacherHome = new TeacherHome();
            TeacherHome.Show();
            this.Hide();
        }
        // Report page
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form Reporta = new ReportA();
            Reporta.Show();
            this.Hide();
        }
        //archive page
        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            Form archive = new Archive();
            archive.Show();
            this.Hide();
        }
        // change pass 
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Changepass = new Changepass();
            Changepass.Show();
        }

        // Notification
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        // Management 
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Form HeadTeacherManage = new HeadTeacherManage();
            HeadTeacherManage.Show();
            this.Hide();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
