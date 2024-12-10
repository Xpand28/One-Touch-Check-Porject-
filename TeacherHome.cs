using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneTouchCheck
{
    public partial class TeacherHome : Form
    {
        private ToolTip toolTip;
        private bool isDragging = false;
        private Point startPoint;
        int ctr = 1;
        Form Form6 = new TeacherStrand11();
        Form Form7 = new TeacherStrand12();



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
        public TeacherHome()
        {
            InitializeComponent();
            CustomizeButtons(button1, button2);
            toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox11, "Logout");
            toolTip.SetToolTip(pictureBox5, "Go to Management page");
            toolTip.SetToolTip(pictureBox3, "Go to Home page");
            toolTip.SetToolTip(pictureBox10, "Go to Report page");
            toolTip.SetToolTip(pictureBox9, "Go to archive page");
            toolTip.SetToolTip(pictureBox12, "Change Password page");
            toolTip.SetToolTip(pictureBox2, "Notification");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Program.fname;
            dgv1.Visible = false;
            Form Form1 = new Login();
            Form1.Close();

            AdvClass.Visible = false;
            pictureBox2.Visible = false;
            pictureBox0.Visible = false;
            label1.Text = Program.fname;
            if (Program.isAdvicer == 1)
            {
                pictureBox5.Visible = false;
                pictureBox2.Visible = true;
                pictureBox0.Visible = true;
                AdvClass.Visible = true;
            }

            if (Program.isTeacher == 1)
            {
                pictureBox5.Visible = false;
                pictureBox2.Visible = true;

            }

            if (Program.isHeadTeacher == 1) pictureBox5.Visible = true;
        }

        // Grade 11
        private void button1_Click(object sender, EventArgs e)
        {
            Form6.Show();
            this.Hide();
        }

        // Grade 12
        private void button2_Click(object sender, EventArgs e)
        {
            Form7.Show();
            this.Hide();
        }
        // My advisory
        private void button3_Click(object sender, EventArgs e)
        {
            Program.mAdvisory = 1;
            Form form1 = new ReportA();
            form1.Show();
            this.Hide();
        }


        private void CustomizeButtons(params Button[] buttons)
        {
            foreach (Button btn in buttons)
            {
                // Set the button to flat style
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0; // Optional: Remove border

                // Create a rounded rectangle region
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, 20, 20, 180, 90); // Top-left corner
                path.AddArc(btn.Width - 20, 0, 20, 20, 270, 90); // Top-right corner
                path.AddArc(btn.Width - 20, btn.Height - 20, 20, 20, 0, 90); // Bottom-right corner
                path.AddArc(0, btn.Height - 20, 20, 20, 90, 90); // Bottom-left corner
                path.CloseFigure();

                // Assign the region to the button
                btn.Region = new Region(path);
                btn.ForeColor = Color.White;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

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

        // Button homepage
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Form HeadTeacherManage = new HeadTeacherManage();
            HeadTeacherManage.Show();
            this.Hide();


        }

        // Report navigation
        private void pictureBox10_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        // Notification
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ctr++;
            if (ctr % 2 == 0)
            {
                dbCon();
                com.Connection = con;

                string Query2 = @"
                SELECT TOP (25) [Title], [StudentName],
                       [GradeLevel], [Strand], [SubjectName], [Block]
                FROM [Comtendance].[dbo].[notifications]
                WHERE [userId] = @Id";

                com.CommandText = Query2;
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Id", Program.userID);

                using (SqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dgv1.Rows.Add(
                            dr.GetString(0), // Title
                            $"{dr.GetString(1)}, {dr.GetInt32(2).ToString()}, {dr.GetString(3)}, {dr.GetString(4)}, {"Block No:" + (dr.GetInt32(5).ToString())}");
                    }
                }
                con.Close();


                dgv1.Visible = true;
            }
            else
            {
                dgv1.Visible = false;
                dgv1.Rows.Clear();
            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
