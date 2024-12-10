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

namespace OneTouchCheck
{
    public partial class TeacherSubject : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        string conString = Program.ConnectionString;
        private ToolTip toolTip;


        public void dbCon()
        {
            con = new SqlConnection(conString);
            con.Open();
            com = new SqlCommand();
        }
        public TeacherSubject()
        {
            InitializeComponent();
            toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox2, "Go to Management page");
            toolTip.SetToolTip(pictureBox4, "Go to Home page");
            toolTip.SetToolTip(pictureBox10, "Go to Report Page");
            toolTip.SetToolTip(pictureBox9, "Go to Archives");
            toolTip.SetToolTip(pictureBox12, "Change Password page");
            toolTip.SetToolTip(pictureBox11, "Log Out");
            toolTip.SetToolTip(pictureBox3, "Notification");
        }

        private void TeacherSubject_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void TeacherSubject_Load(object sender, EventArgs e)
        {
            label1.Text = Program.fname;
            if (Program.isAdvicer == 1)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;

            }

            if (Program.isTeacher == 1)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;

            }

            if (Program.isHeadTeacher == 1) pictureBox2.Visible = true;
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            try
            {
                // Initialize ImageList for tabControl1 if not already done
                if (tabControl1.ImageList == null)
                {
                    tabControl1.ImageList = new ImageList();
                    tabControl1.ImageList.ImageSize = new Size(20, 20); // Set size for icons

                    // Add the subjects_icon to the ImageList
                    tabControl1.ImageList.Images.Add("subjects_icon.png", Properties.Resources.subjects_icon); // Assuming subjects_icon is added in Resources
                }

                tabControl1.BackColor = Color.FromArgb(223, 239, 255);
                dbCon();
                string query = Program.selsubj;
                com.Connection = con;
                com.CommandText = query;
                dr = com.ExecuteReader();

                tabControl1.TabPages.Clear();

                Dictionary<string, DataGridView> blkGrids = new Dictionary<string, DataGridView>();

                while (dr.Read())
                {
                    string blk = dr["Blk"].ToString();

                    if (!blkGrids.ContainsKey(blk))
                    {
                        TabPage newTab = new TabPage($"Blk {blk}")
                        {
                            Name = $"tabBlk{blk}",
                            BackColor = Color.FromArgb(223, 239, 255),
                            ImageIndex = 0 // Use the first image (subjects_icon) from ImageList
                        };

                        newTab.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                        newTab.ForeColor = Color.Black;

                        DataGridView dgv = new DataGridView
                        {
                            Dock = DockStyle.Fill,
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                            AllowUserToAddRows = false,
                            ReadOnly = true,
                            RowTemplate = { Height = 40 },
                            BackgroundColor = Color.FromArgb(223, 239, 255),
                            BorderStyle = BorderStyle.None,
                            GridColor = Color.Black,
                            EnableHeadersVisualStyles = false,
                            RowHeadersVisible = false,
                            AllowUserToResizeColumns = false,
                            AllowUserToResizeRows = false,
                            DefaultCellStyle = new DataGridViewCellStyle
                            {
                                BackColor = Color.FromArgb(223, 239, 255),
                                ForeColor = Color.Black,
                                SelectionBackColor = Color.LightBlue,
                                SelectionForeColor = Color.Black
                            },
                            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                            {
                                BackColor = Color.FromArgb(223, 239, 255),
                                ForeColor = Color.Black,
                                Font = new Font("Segoe UI", 10, FontStyle.Bold)
                            }
                        };

                        dgv.Columns.Add("id", "ID");
                        dgv.Columns["id"].Visible = false;
                        dgv.Columns.Add("GradeLevel", "Grade Level");
                        dgv.Columns.Add("Strand", "Strand");
                        dgv.Columns.Add("Blk", "Blk");
                        dgv.Columns.Add("SubjectName", "Subject Name");

                        DataGridViewButtonColumn viewButton = new DataGridViewButtonColumn
                        {
                            HeaderText = "Action",
                            Text = "View",
                            UseColumnTextForButtonValue = true,
                            DefaultCellStyle = new DataGridViewCellStyle
                            {
                                BackColor = Color.Transparent, // Set transparent so it can be changed dynamically
                                ForeColor = Color.Black,
                                Font = new Font("Segoe UI", 9, FontStyle.Bold)
                            }
                        };
                        dgv.Columns.Add(viewButton);

                        newTab.Controls.Add(dgv);
                        tabControl1.TabPages.Add(newTab);

                        blkGrids[blk] = dgv;

                        dgv.CellContentClick += (s, e) =>
                        {
                            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
                            {
                                int subjectId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                                Program.selsubjId = subjectId;

                                Form attendanceForm = new Attendance();
                                attendanceForm.Show();

                                Program.prevFormInstance1 = this;
                                this.Hide();
                            }
                        };

                        // Handle CellFormatting to set button color
                        dgv.CellFormatting += (s, e) =>
                        {
                            if (e.ColumnIndex == 5 && e.RowIndex >= 0) // The 'Action' column (index 5)
                            {
                                var buttonCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                                if (buttonCell != null)
                                {
                                    buttonCell.Style.BackColor = Color.Blue;  // Set button color to blue
                                    buttonCell.Style.ForeColor = Color.White; // Set text color to white
                                }
                            }
                        };
                    }

                    DataGridView targetDgv = blkGrids[blk];
                    targetDgv.Rows.Add(
                        dr["id"],
                        dr["GradeLevel"],
                        dr["Strand"],
                        dr["Blk"],
                        dr["SubjectName"]
                    );
                }

                var sortedTabs = blkGrids.Keys.OrderBy(blk => Convert.ToInt32(blk)).ToList();
                tabControl1.TabPages.Clear();

                foreach (var blk in sortedTabs)
                {
                    tabControl1.TabPages.Add(blkGrids[blk].Parent as TabPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                    dr.Close();
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void subjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                Program.selsubjId = Convert.ToInt32(subjects.Rows[e.RowIndex].Cells[0].Value);
                Form form1 = new Attendance();
                form1.Show();

                Program.prevFormInstance1 = this;

                this.Hide();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form HeadTeacherManage = new HeadTeacherManage();
            HeadTeacherManage.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form TeacherHome = new TeacherHome();
            TeacherHome.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form ReportA = new ReportA();
            ReportA.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form Archive = new Archive();
            Archive.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Changepass = new Changepass();
            Changepass.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
