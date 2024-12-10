using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OneTouchCheck
{
    public partial class TeacherStrand11 : Form
    {
        private ToolTip toolTip;
        SqlConnection con;
        SqlCommand com;
        int subjectCount;
        int subjectCountone;
        int subjectCounttwo;
        int subjectCountthree;
        int subjectCountfour;
        SqlDataReader dr;
        string conString = Program.ConnectionString;



        public void dbCon()
        {
            con = new SqlConnection(conString);
            con.Open();
            com = new SqlCommand();
        }





        public TeacherStrand11()
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


        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
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
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "ABM" + "' AND GradeLevel = '" + 11 + "'";
            com.Connection = con;

            dr = com.ExecuteReader();
            subjectCountone = 0;
            while (dr.Read())
            {
                subjectCountone++;
            }

            lbl1.Text = subjectCountone.ToString();

            lbl1.Width = 40;
            lbl1.Height = 40;
            lbl1.BackColor = Color.Red;
            lbl1.ForeColor = Color.White;
            lbl1.Font = new Font("Arial", 13, FontStyle.Bold);
            lbl1.TextAlign = ContentAlignment.MiddleCenter;

            GraphicsPath path1 = new GraphicsPath();
            path1.AddEllipse(0, 0, lbl1.Width, lbl1.Height);
            lbl1.Region = new Region(path1);
            lbl1.Invalidate();

            // lbl 2
            dbCon();
            com.CommandText = "Select * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "HUMSS" + "' AND GradeLevel = '" + 11 + "'";
            com.Connection = con;

            dr = com.ExecuteReader();
            subjectCounttwo = 0;
            while (dr.Read())
            {
                subjectCounttwo++;
            }


            lblRedDot2.Text = subjectCounttwo.ToString();

            lblRedDot2.Width = 40;
            lblRedDot2.Height = 40;
            lblRedDot2.BackColor = Color.Red;
            lblRedDot2.ForeColor = Color.White;
            lblRedDot2.Font = new Font("Arial", 13, FontStyle.Bold);
            lblRedDot2.TextAlign = ContentAlignment.MiddleCenter;

            lblRedDot1.Region = new Region(new Rectangle(0, 0, lblRedDot2.Width, lblRedDot2.Height));
            GraphicsPath path2 = new GraphicsPath();
            path2.AddEllipse(0, 0, lblRedDot2.Width, lblRedDot2.Height);
            lblRedDot2.Region = new Region(path2);

            // lblred3
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "ICT" + "' AND GradeLevel = '" + 11 + "'";
            com.Connection = con;

            dr = com.ExecuteReader();
            subjectCountthree = 0;
            while (dr.Read())
            {
                subjectCountthree++;
            }

            lblRedDot3.Text = subjectCountthree.ToString();

            lblRedDot3.Width = 40; 
            lblRedDot3.Height = 40; 
            lblRedDot3.BackColor = Color.Red; 
            lblRedDot3.ForeColor = Color.White;
            lblRedDot3.Font = new Font("Arial", 13, FontStyle.Bold); 
            lblRedDot3.TextAlign = ContentAlignment.MiddleCenter; 

            lblRedDot3.Region = new Region(new Rectangle(0, 0, lblRedDot3.Width, lblRedDot3.Height)); 
            GraphicsPath path3 = new GraphicsPath();
            path3.AddEllipse(0, 0, lblRedDot3.Width, lblRedDot3.Height); 
            lblRedDot3.Region = new Region(path3);



            // lbl 4
            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "H.E" + "' AND GradeLevel = '" + 11 + "'";
            com.Connection = con;

            dr = com.ExecuteReader();
            subjectCountfour = 0;
            while (dr.Read())
            {
                subjectCountfour++;
            }

            lblRedDot4.Text = subjectCountfour.ToString();

            lblRedDot4.Width = 40;
            lblRedDot4.Height = 40;
            lblRedDot4.BackColor = Color.Red;
            lblRedDot4.ForeColor = Color.White;
            lblRedDot4.Font = new Font("Arial", 13, FontStyle.Bold);
            lblRedDot4.TextAlign = ContentAlignment.MiddleCenter;

            lblRedDot4.Region = new Region(new Rectangle(0, 0, lblRedDot4.Width, lblRedDot4.Height));
            GraphicsPath path4 = new GraphicsPath();
            path4.AddEllipse(0, 0, lblRedDot4.Width, lblRedDot4.Height);
            lblRedDot4.Region = new Region(path4);
        }



        private void button1_Click(object sender, EventArgs e)
        {

            dbCon();
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "ABM" + "' AND GradeLevel = '" + 11 + "'";
            com.Connection = con;

            try
            {
                dr = com.ExecuteReader();
                subjectCountone = 0;
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
                    cmbok.Show("No subjects found in HUMSS.", "Information", false);
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
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "HUMSS" + "' AND GradeLevel = '" + 11 + "'";
            com.Connection = con;

            try
            {
                dr = com.ExecuteReader();
                subjectCounttwo = 0;
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
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "ICT" + "' AND GradeLevel = '" + 11 + "'";
            com.Connection = con;

            try
            {
                dr = com.ExecuteReader();
                subjectCountthree = 0;

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
            com.CommandText = "SELECT * FROM subjects WHERE TeacherUserId = '" + Program.userID + "' and Strand = '" + "H.E" + "' AND GradeLevel = '" + 11 + "'";
            com.Connection = con;

            try
            {
                dr = com.ExecuteReader();
                subjectCountfour = 0;

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

        // Design 

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


        // Button homepage
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form HeadTeacherManage = new HeadTeacherManage();
            HeadTeacherManage.Show();
            this.Hide();
        }

        // Report navigation
        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            Form ReportA = new ReportA();
            ReportA.Show();
            this.Hide();
        }


        // Archive Nav
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form Archive = new Archive();
            Archive.Show();
            this.Hide();
        }

        // Change pass nav
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Changepass = new Changepass();
            Changepass.Show();
        }

        // Homepage
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form TeacherHome = new TeacherHome();
            TeacherHome.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        // Notification
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

        // Design for rounded buttons
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

        private void button3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void lblRedDot_Click(object sender, EventArgs e)
        {
            
        }
    }
}
