using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OneTouchCheck
{
    public partial class TeacherStrand12 : Form
    {

        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        string conString = Program.ConnectionString;
        private ToolTip toolTip;
        int subjectCount;
        int subjectCountones;
        int subjectCounttwos;
        int subjectCountthrees;
        int subjectCountfours;


        public void dbCon()
        {
            con = new SqlConnection(conString);
            con.Open();
            com = new SqlCommand();
        }
        public TeacherStrand12()
        {
            InitializeComponent();
            CustomizeButtons(button1, button2, button3, button4, button5);
            toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox5, "Go to Management page");
            toolTip.SetToolTip(pictureBox8, "Go to Home page");
            toolTip.SetToolTip(pictureBox10, "Go to Report Page");
            toolTip.SetToolTip(pictureBox9, "Go to Archives");
            toolTip.SetToolTip(pictureBox12, "Change Password page");
            toolTip.SetToolTip(pictureBox11, "Log Out");
            toolTip.SetToolTip(pictureBox7, "Notification");
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label1.Text = Program.fname;

            if (Program.isAdvicer == 1)
            {
                pictureBox5.Visible = false;
                pictureBox7.Visible = true;
            }

            if (Program.isTeacher == 1)
            {
                pictureBox5.Visible = false;
                pictureBox7.Visible = true;

            }

            if (Program.isHeadTeacher == 1) pictureBox5.Visible = true;




            //lbl1 
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "ABM" + "' AND GradeLevel = '" + 12 + "'";
            com.Connection = con;

            dr = com.ExecuteReader();
            subjectCountones = 0;
            while (dr.Read())
            {
                subjectCountones++;
            }

            label4.Text = subjectCountones.ToString();

            label4.Width = 40;
            label4.Height = 40;
            label4.BackColor = Color.Red;
            label4.ForeColor = Color.White;
            label4.Font = new Font("Arial", 13, FontStyle.Bold);
            label4.TextAlign = ContentAlignment.MiddleCenter;

            GraphicsPath path1 = new GraphicsPath();
            path1.AddEllipse(0, 0, label4.Width, label4.Height);
            label4.Region = new Region(path1);
            label4.Invalidate();

            // lbl 2
            dbCon();
            com.CommandText = "Select * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "HUMSS" + "' AND GradeLevel = '" + 12 + "'";
            com.Connection = con;

            dr = com.ExecuteReader();
            subjectCounttwos = 0;
            while (dr.Read())
            {
                subjectCounttwos++;
            }


            label5.Text = subjectCounttwos.ToString();

            label5.Width = 40;
            label5.Height = 40;
            label5.BackColor = Color.Red;
            label5.ForeColor = Color.White;
            label5.Font = new Font("Arial", 13, FontStyle.Bold);
            label5.TextAlign = ContentAlignment.MiddleCenter;

            label5.Region = new Region(new Rectangle(0, 0, label5.Width, label5.Height));
            GraphicsPath path2 = new GraphicsPath();
            path2.AddEllipse(0, 0, label5.Width, label5.Height);
            label5.Region = new Region(path2);



            //// lblred3
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "ICT" + "' AND GradeLevel = '" + 12 + "'";
            com.Connection = con;

            dr = com.ExecuteReader();
            subjectCountthrees = 0;
            while (dr.Read())
            {
                subjectCountthrees++;
            }

            label6.Text = subjectCountthrees.ToString();

            label6.Width = 40;
            label6.Height = 40;
            label6.BackColor = Color.Red;
            label6.ForeColor = Color.White;
            label6.Font = new Font("Arial", 13, FontStyle.Bold);
            label6.TextAlign = ContentAlignment.MiddleCenter;

            label6.Region = new Region(new Rectangle(0, 0, label6.Width, label6.Height));
            GraphicsPath path3 = new GraphicsPath();
            path3.AddEllipse(0, 0, label6.Width, label6.Height);
            label6.Region = new Region(path3);



            // lbl 4
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "H.E" + "' AND GradeLevel = '" + 12 + "'";
            com.Connection = con;

            dr = com.ExecuteReader();
            subjectCountfours = 0;
            while (dr.Read())
            {
                subjectCountfours++;
            }

            label7.Text = subjectCountfours.ToString();

            label7.Width = 40;
            label7.Height = 40;
            label7.BackColor = Color.Red;
            label7.ForeColor = Color.White;
            label7.Font = new Font("Arial", 13, FontStyle.Bold);
            label7.TextAlign = ContentAlignment.MiddleCenter;

            label7.Region = new Region(new Rectangle(0, 0, label7.Width, label7.Height));
            GraphicsPath path4 = new GraphicsPath();
            path4.AddEllipse(0, 0, label7.Width, label7.Height);
            label7.Region = new Region(path4);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "ABM" + "' AND GradeLevel = '" + 12 + "'";
            com.Connection = con;

            try
            {
                dr = com.ExecuteReader();
                subjectCountones = 0;
                while (dr.Read())
                {
                    subjectCount++;
                }


                if (subjectCount > 0)
                {
                    button1.Text = $"Subjects in ABM: {subjectCount}";

                    Program.selsubj = com.CommandText;
                    Form teachersubject = new TeacherSubject();
                    teachersubject.Show();
                    Program.prevFormInstance = this;
                    this.Hide();
                }
                else
                {
                    cmbok.Show("No subjects found in ABM.", "Information", false);
                }
            }
            catch (Exception ex)
            {
                cmbok.Show("An error occurred: " + ex.Message, "Error", true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "HUMSS" + "' AND GradeLevel = '" + 12 + "'";
            com.Connection = con;

            try
            {
                dr = com.ExecuteReader();
                subjectCounttwos = 0;
                while (dr.Read())
                {
                    subjectCount++;
                }

                if (subjectCount > 0)
                {

                    button2.Text = $"Subjects in HUMSS: {subjectCount}";

                    Program.selsubj = com.CommandText;
                    Form teachersubject = new TeacherSubject();
                    teachersubject.Show();
                    Program.prevFormInstance = this;
                    this.Hide();
                }
                else
                {
                    cmbok.Show("No subjects found in HUMSS.", "Information", false);
                }
            }
            catch (Exception ex)
            {
                cmbok.Show("An error occurred: " + ex.Message, "Error", true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "ICT" + "' AND GradeLevel = '" + 12 + "'";
            com.Connection = con;

            try
            {
                dr = com.ExecuteReader();
                subjectCountthrees = 0;

                while (dr.Read())
                {
                    subjectCount++;
                }

                if (subjectCount > 0)
                {
                    button3.Text = $"Subjects in ICT: {subjectCount}";

                    Program.selsubj = com.CommandText;
                    Form teachersubject = new TeacherSubject();
                    teachersubject.Show();
                    Program.prevFormInstance = this;
                    this.Hide();
                }
                else
                {
                    cmbok.Show("No subjects found in ICT.", "Information", false);
                }
            }
            catch (Exception ex)
            {
                cmbok.Show("An error occurred: " + ex.Message, "Error", true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "H.E" + "' AND GradeLevel = '" + 12 + "'";
            com.Connection = con;

            try
            {
                dr = com.ExecuteReader();
                subjectCountfours = 0;

                while (dr.Read())
                {
                    subjectCount++;
                }


                if (subjectCount > 0)
                {
                    button4.Text = $"Subjects in H.E: {subjectCount}";

                    Program.selsubj = com.CommandText;
                    Form teachersubject = new TeacherSubject();
                    teachersubject.Show();
                    Program.prevFormInstance = this;
                    this.Hide();
                }
                else
                {
                    cmbok.Show("No subjects found in H.E.", "Information", false);
                }
            }
            catch (Exception ex)
            {
                cmbok.Show("An error occurred: " + ex.Message, "Error", true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to go back to home page?", "Continue ? ");
            if (result)
            {
                // Navigate to TeacherHome
                Form teacherhome = new TeacherHome();
                this.Hide();
                teacherhome.Show();
            }
        }


        //Design
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, panel2.Width, panel2.Height);

            int radius = 30;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            Brush brush = new SolidBrush(Color.FromArgb(223, 239, 255));
            g.FillPath(brush, path);

            Pen borderPen = new Pen(Color.Black, 2);
            g.DrawPath(borderPen, path);
        }

        // Logout
        private void pictureBox11_Click_1(object sender, EventArgs e)
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

        // Management
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Form HeadTeacherManage = new HeadTeacherManage();
            HeadTeacherManage.Show();
            this.Hide();
        }

        // Home page
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form Form2 = new TeacherHome();
            Form2.Show();
            this.Hide();
        }

        // Report page
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form Reporta = new ReportA();
            Reporta.Show();
            this.Hide();
        }
        // Archive page
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form archive = new Archive();
            archive.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Changepass = new Changepass();
            Changepass.Show();
        }

        // Design for buttons
        private void CustomizeButtons(params Button[] buttons)
        {
            foreach (Button btn in buttons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(btn.Width - 20, 0, 20, 20, 270, 90);
                path.AddArc(btn.Width - 20, btn.Height - 20, 20, 20, 0, 90);
                path.AddArc(0, btn.Height - 20, 20, 20, 90, 90);
                path.CloseFigure();
                btn.Region = new Region(path);
                btn.ForeColor = Color.White;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
                dbCon();
                com.Connection = con;

                // SQL query to fetch notifications
                string query = @"
            SELECT TOP (25) [Title], [StudentName],
                   [GradeLevel], [Strand], [SubjectName], [Block]
            FROM [Comtendance].[dbo].[notifications]
            WHERE [userId] = @Id";

                com.CommandText = query;
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Id", Program.userID);

                // Load data into a DataTable
                DataTable notifications = new DataTable();
                using (SqlDataReader dr = com.ExecuteReader())
                {
                    notifications.Load(dr);
                }

                // Close the database connection
                con.Close();

                // Show the popup form with notifications
                NotificationPopupForm popup = new NotificationPopupForm();
                popup.LoadNotifications(notifications); // Pass the data to the popup
                popup.ShowDialog(); // Display the popup
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
