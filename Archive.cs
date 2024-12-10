using DocumentFormat.OpenXml.Bibliography;
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
    public partial class Archive : Form
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
        public Archive()
        {
            InitializeComponent();
        }

        private void Archive_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Archive_Load(object sender, EventArgs e)
        {
            label1.Text = Program.fname;
            LoadReports();

        }
        private void LoadReports()
        {
            try
            {
                // Establish the database connection using dbCon()
                dbCon();
                com.Connection = con;

                // Query to join attendanceArchive, students, and subjects
                com.CommandText = @"
            WITH TopAttendance AS (
                SELECT 
                    studentId, 
                    MonthDayYear,
                    ROW_NUMBER() OVER (PARTITION BY MonthDayYear ORDER BY MonthDayYear ASC) AS RowNum
                FROM 
                    attendanceArchive
            )
            SELECT 
                subj.Strand,
                subj.Blk,
                subj.SubjectName,
                subj.GradeLevel,
                u.name AS TeacherName,
                CASE 
                    WHEN subj.Days < 25 THEN 'Incomplete' 
                    ELSE 'Complete' 
                END AS Status,
                TopAttendance.MonthDayYear AS Date,
                subj.Days
            FROM 
                TopAttendance
            INNER JOIN 
                students st ON st.id = TopAttendance.studentId
            INNER JOIN 
                subjects subj ON subj.id = st.subjectId
            INNER JOIN 
                users u ON u.id = subj.TeacherUserId
            WHERE 
                TopAttendance.RowNum = 1
            ORDER BY 
                TopAttendance.MonthDayYear ASC";

                com.Parameters.Clear(); // Clear parameters, none needed for this query

                using (dr = com.ExecuteReader())
                {
                    dgArchive.Rows.Clear(); // Clear existing rows in the DataGridView

                    while (dr.Read())
                    {
                        // Parse data from the reader
                        string strand = dr["Strand"].ToString();
                        string blk = dr["Blk"].ToString();
                        string subjectName = dr["SubjectName"].ToString();
                        string gradeLevel = dr["GradeLevel"].ToString();
                        string teacher = dr["TeacherName"].ToString();
                        string status = dr["Status"].ToString();
                        string date = dr["Date"].ToString(); // Assumes MonthDayYear is in a readable format

                        // Add row to DataGridView
                        int rowIndex = dgArchive.Rows.Add(
                            gradeLevel,
                            strand,
                            subjectName,
                            blk,
                            teacher,
                            status,
                            date,
                            "Export"
                        );

                        // Format "Export" button column
                        DataGridViewRow row = dgArchive.Rows[rowIndex];
                        row.Cells[7].Style.BackColor = Color.FromArgb(21, 73, 135);
                        row.Cells[7].Style.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the database connection is closed
                if (con?.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }



    }
}
