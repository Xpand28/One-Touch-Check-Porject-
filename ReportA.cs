
using ClosedXML.Excel;
using Microsoft.VisualBasic.FileIO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OneTouchCheck
{
    public partial class ReportA : Form
    {
        private System.Windows.Forms.ToolTip toolTip;
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
        public ReportA()
        {
            InitializeComponent();
            toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(pictureBox11, "Logout");
            toolTip.SetToolTip(pictureBox5, "Go to Management page");
            toolTip.SetToolTip(pictureBox3, "Go to Home page");
            toolTip.SetToolTip(pictureBox10, "Go to Report page");
            toolTip.SetToolTip(pictureBox9, "Go to archive page");
            toolTip.SetToolTip(pictureBox12, "Change Password page");
            toolTip.SetToolTip(pictureBox2, "Notification");
        }

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Program.mAdvisory = 0;
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
                Program.mAdvisory = 0;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form archive = new Archive();
            archive.Show();
            this.Hide();
            Program.mAdvisory = 0;
        }

        private void ReportA_Load(object sender, EventArgs e)
        {
            label1.Text = Program.fname;
            LoadReports();
            panel2.Visible = false;
        }

        private void LoadReports()
        {
            string query = "";
            try
            {
                dbCon();
                com.Connection = con;

                if (Program.mAdvisory == 1)
                {
                    query = @"
                SELECT 
                subjects.id,
                subjects.GradeLevel,
                subjects.Strand,
                subjects.Blk,
                subjects.SubjectName,
                subjects.Days
            FROM 
                subjects
            INNER JOIN 
                users ON subjects.TeacherUserId = users.id
            WHERE subjects.isDeactivated = 0 AND AdvicerUserId = '" + Program.userID + "';";

                }
                else
                {
                    query = @"
                SELECT 
                subjects.id,
                subjects.GradeLevel,
                subjects.Strand,
                subjects.Blk,
                subjects.SubjectName,
                subjects.Days
            FROM 
                subjects
            INNER JOIN 
                users ON subjects.TeacherUserId = users.id
            WHERE subjects.isDeactivated = 0 AND TeacherUserId = '" + Program.userID + "';";
                }

                com.CommandText = query;
                dr = com.ExecuteReader();

                Report.Rows.Clear();

                while (dr.Read())
                {
                    if (int.Parse(dr["Days"].ToString()) < 25)
                    {
                        int rowIndex = Report.Rows.Add(
                        dr["id"],
                        dr["GradeLevel"],
                        dr["Strand"],
                        dr["Blk"],
                        dr["SubjectName"],
                        dr["Days"],
                        "Incomplete",
                        "Export",
                        "Archive"
                    );
                        DataGridViewRow row = Report.Rows[rowIndex];
                        row.Cells[7].Style.BackColor = Color.FromArgb(21, 73, 135);
                        row.Cells[7].Style.ForeColor = Color.White;

                    }
                    else if (int.Parse(dr["Days"].ToString()) == 25)
                    {
                        int rowIndex = Report.Rows.Add(
                        dr["id"],
                        dr["GradeLevel"],
                        dr["Strand"],
                        dr["Blk"],
                        dr["SubjectName"],
                        dr["Days"],
                        "Complete",
                        "Export",
                        "Archive"
                    );
                        DataGridViewRow row = Report.Rows[rowIndex];
                        row.Cells[7].Style.BackColor = Color.FromArgb(21, 73, 135);
                        row.Cells[7].Style.ForeColor = Color.White;
                    }



                    //bool isDeactivated = dr.GetBoolean(6);

                    //if (isDeactivated)
                    //{
                    //    row.Cells[7].Value = "Activate";
                    //    row.Cells[7].Style.BackColor = Color.Green;
                    //}
                    //else
                    //{
                    //    row.Cells[7].Value = "Deactivate";
                    //    row.Cells[7].Style.BackColor = Color.Red;
                    //}
                    //row.Cells[7].Style.ForeColor = Color.White;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Report_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                Program.selsubjIdReport = Convert.ToInt32(Report.Rows[e.RowIndex].Cells[0].Value);

                try
                {
                    DialogResult confirmResult = MessageBox.Show(
                        "Do you want to export the attendance report?",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        panel2.Visible = true;
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    // Close the database connection
                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public void exportExcel()
        {
            int dropped = 0;
            int consecAb = 0;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                Title = "Save Attendance Report",
                FileName = "AttendanceReport.xlsx"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filePath = saveFileDialog.FileName;

            dbCon();
            string query = "";

            if (male.Checked)
            {
                query = @"
                SELECT 
                    s.name AS StudentName,
                    a.Days,
                    a.isPresent,
                    a.isAbsent,
                    a.isTardy
                FROM attendance a
                JOIN students s ON a.studentId = s.id
                WHERE s.subjectId = @SubjectId AND s.gender = 1
                ORDER BY s.id ASC, a.Days ASC;
            ";
            }
            else if (female.Checked)
            {
                query = @"
                SELECT 
                    s.name AS StudentName,
                    a.Days,
                    a.isPresent,
                    a.isAbsent,
                    a.isTardy
                FROM attendance a
                JOIN students s ON a.studentId = s.id
                WHERE s.subjectId = @SubjectId AND s.gender = 0
                ORDER BY s.id ASC, a.Days ASC;
            ";
            }
            com.Connection = con;
            com.CommandText = query;
            com.Parameters.AddWithValue("@SubjectId", Program.selsubjIdReport);

            DataTable attendanceTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(attendanceTable);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Attendance Report");

                worksheet.Cell(1, 1).Value = "NAME";
                string[] weekdays = { "M", "T", "W", "TH", "F" };
                for (int day = 1; day <= 25; day++)
                {
                    string dayLabel = weekdays[(day - 1) % 5];
                    worksheet.Cell(1, day + 1).Value = $"{dayLabel}(D{day})";
                }
                worksheet.Cell(1, 26).Value = "ABSENT";
                worksheet.Cell(1, 27).Value = "TARDY";

                int currentRow = 2;
                var students = attendanceTable.AsEnumerable()
                                               .GroupBy(row => row["StudentName"].ToString());
                int totalAttendance = 0;
                int totalStudents = 0;

                foreach (var studentGroup in students)
                {
                    string studentName = studentGroup.Key;
                    worksheet.Cell(currentRow, 1).Value = studentName;
                    int totalAbsent = 0;
                    int totalTardy = 0;

                    for (int day = 1; day <= 25; day++)
                    {
                        var attendanceRecord = studentGroup.FirstOrDefault(row => Convert.ToInt32(row["Days"]) == day);
                        if (attendanceRecord != null && Convert.ToBoolean(attendanceRecord["isPresent"]))
                        {
                            worksheet.Cell(currentRow, day + 1).Value = "/";
                            totalAttendance++;
                        }
                        else if (attendanceRecord != null && Convert.ToBoolean(attendanceRecord["isAbsent"]))
                        {
                            worksheet.Cell(currentRow, day + 1).Value = "X";
                            totalAbsent++;

                        }
                        else if (attendanceRecord != null && Convert.ToBoolean(attendanceRecord["isTardy"]))
                        {
                            worksheet.Cell(currentRow, day + 1).Value = "/";
                            totalTardy++;

                        }
                        else
                        {
                            worksheet.Cell(currentRow, day + 1).Value = "";
                        }
                    }
                    worksheet.Cell(currentRow, 26).Value = totalAbsent;
                    worksheet.Cell(currentRow, 27).Value = totalTardy;
                    totalStudents++;
                    currentRow++;
                }
                int TotalPossibleAttendance = totalStudents * 25;

                com.Connection = con;
                com.CommandText = "SELECT Dropped, ConsecAb FROM subjects WHERE id = @id";

                com.Parameters.AddWithValue("@id", Program.selsubjIdReport);

                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    dropped = reader.GetInt32(0);
                    consecAb = reader.GetInt32(1);

                }


                reader.Close(); // Close the reader
                currentRow += 3;
                worksheet.Cell(currentRow, 1).Value = "Average Daily Attendance";
                worksheet.Cell(currentRow, 2).Value = (totalAttendance / totalStudents).ToString();
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Percentage Of Attendance Of The Month";
                worksheet.Cell(currentRow, 2).Value = (((totalAttendance / TotalPossibleAttendance) * 100).ToString()) + "%";
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Number of students for 3 consecutive days";
                worksheet.Cell(currentRow, 2).Value = consecAb;
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Drop";
                worksheet.Cell(currentRow, 2).Value = dropped;
                currentRow++;

                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }

            MessageBox.Show(
                "Attendance report successfully exported!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to back?", "Continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel2.Visible = false;
                male.Checked = false;
                female.Checked = false;
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            exportExcel();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form HeadTeacherManage = new HeadTeacherManage();
            HeadTeacherManage.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
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

        private void pictureBox9_Click_1(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
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
