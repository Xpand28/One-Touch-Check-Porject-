using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DocumentFormat.OpenXml.Spreadsheet;

namespace OneTouchCheck
{
    public partial class Attendance : Form
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

        int studentId;
        int selSub;
        public Attendance()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 3 && e.ColumnIndex <= 6)
            {
                for (int i = 3; i <= 6; i++)
                {
                    if (i != e.ColumnIndex)
                    {
                        students.Rows[e.RowIndex].Cells[i].Value = false;
                    }
                }
                bool currentValue = Convert.ToBoolean(students.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                students.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !currentValue;
            }

            if (e.ColumnIndex == 7)
            {
                panel2.Visible = true;

                dbCon();
                com.Connection = con;

                studentId = Convert.ToInt32(students.Rows[e.RowIndex].Cells[0].Value);
                selSub = Convert.ToInt32(students.Rows[e.RowIndex].Cells[1].Value);

                string query = @"
                    SELECT name, gender 
                    FROM students 
                    WHERE id = @StudentId AND subjectId = @SubjectId";

                com.CommandText = query;

                com.Parameters.AddWithValue("@StudentId", studentId);
                com.Parameters.AddWithValue("@SubjectId", selSub);

                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    string studentName = reader["name"].ToString();
                    int gender = Convert.ToInt32(reader["gender"]);

                    fullName.Text = studentName;

                    if (gender == 1)
                    {
                        male.Checked = true;
                    }
                    else
                    {
                        female.Checked = true;
                    }
                }

                reader.Close();

                com.Connection.Close();
            }

            if (e.ColumnIndex == 8)
            {
                if (gender.Text == "Dropped")
                {
                    bool result = cmbyesno.Show("Are you sure you want to Undrop this student?", "Continue ? ");
                    if (result)
                    {
                        dbCon();
                        com.Connection = con;

                        string query = @"
                        UPDATE students 
                        SET isDeactivated = 0
                        WHERE id = @StudentId";

                        com.CommandText = query;

                        com.Parameters.AddWithValue("@StudentId", Convert.ToInt32(students.Rows[e.RowIndex].Cells[0].Value));

                        com.ExecuteNonQuery();
                        com.Connection.Close();

                        dbCon();
                        com.Connection = con;
                        com.CommandText = "UPDATE subjects SET Dropped = Dropped - 1 WHERE id =" + Program.selsubjId.ToString();
                        com.ExecuteNonQuery();
                        con.Close();

                        gender.Text = "All";
                    }
                }
                else if (gender.Text != "Dropped")
                {
                    panel3.Visible = true;

                    dbCon();
                    com.Connection = con;

                    studentId = Convert.ToInt32(students.Rows[e.RowIndex].Cells[0].Value);
                    selSub = Convert.ToInt32(students.Rows[e.RowIndex].Cells[1].Value);

                    string query = @"
                    SELECT name
                    FROM students 
                    WHERE id = @StudentId AND subjectId = @SubjectId";

                    com.CommandText = query;

                    com.Parameters.AddWithValue("@StudentId", studentId);
                    com.Parameters.AddWithValue("@SubjectId", selSub);

                    SqlDataReader reader = com.ExecuteReader();

                    if (reader.Read())
                    {
                        string studentName = reader["name"].ToString();
                        name2.Text = studentName;
                    }

                    reader.Close();

                    com.Connection.Close();
                }
            }


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form Form2 = new TeacherHome();
            Form2.Close();
            label1.Text = Program.fname;
            label3.Text = Program.selStrand;

            dbCon();
            com.CommandText = "SELECT Days FROM subjects where id = '" + Program.selsubjId + "'";
            com.Connection = con;
            dr = com.ExecuteReader();
            dr.Read();

            Program.selsubjDays = dr.GetInt32(0);
            com.Connection.Close();

            gender.Items.Add("All");
            gender.Items.Add("Dropped");
            gender.Items.Add("Male");
            gender.Items.Add("Female");
            label1.Text = Program.fname;

            panel2.Visible = false;
            panel3.Visible = false;
            LoadStudents();

        }

        private void LoadStudents()
        {
            try
            {
                dbCon();

                string query = "SELECT id, subjectId, name FROM students WHERE subjectId = '" + Program.selsubjId + "' AND isDeactivated = 0 "; ;
                com.Connection = con;
                com.CommandText = query;
                dr = com.ExecuteReader();

                students.Rows.Clear();

                while (dr.Read())
                {
                    int rowIndex = students.Rows.Add(
                        dr["id"],
                        dr["subjectId"],
                        dr["name"],
                        false,
                        false,
                        false,
                        false,
                        "Update",
                        "Drop"
                    );
                    //DataGridViewRow row = students.Rows[rowIndex];
                    //row.Cells[5].Style.BackColor = Color.FromArgb(21, 73, 135);
                    //row.Cells[5].Style.ForeColor = Color.White;
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

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form Form2 = new TeacherHome();
            Form2.Show();
            this.Hide();

        }

        private void Attendance_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Reporta = new ReportA();
            Reporta.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form archive = new Archive();
            archive.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to go back?", "Continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Program.prevFormInstance1.Show();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form form1 = new TeacherAddStud();
            form1.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Send to reports ?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbCon(); // Ensure connection setup here.

                    int subjectId = Program.selsubjId; // Replace with your method to get Subject ID.
                    int thresholdDays = 25; // Days threshold for processing.

                    // Step 1: Check for attendance records with Days = 25
                    string selectQuery = @"
                                        SELECT 
                                            attendance.id AS AttendanceID,
                                            students.name AS StudentName,
                                            subjects.SubjectName,
                                            subjects.GradeLevel,
                                            subjects.Strand,
                                            subjects.Blk AS Block,
                                            attendance.isPresent,
                                            attendance.isAbsent,
                                            attendance.isTardy,
                                            attendance.Days,
                                            attendance.remarks
                                        FROM 
                                            attendance
                                        JOIN 
                                            students ON attendance.studentId = students.id
                                        JOIN 
                                            subjects ON students.subjectId = subjects.id
                                        WHERE 
                                            subjects.id = @subjectId AND
                                            attendance.Days = @thresholdDays;";

                    com.Connection = con;
                    com.CommandText = selectQuery;
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@subjectId", subjectId);
                    com.Parameters.AddWithValue("@thresholdDays", thresholdDays);

                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close(); // Close reader to avoid conflict with the next commands.

                        // Step 2: Move records to AttendanceArchive
                        string insertQuery = @"
                                            INSERT INTO AttendanceArchive (studentId, isPresent, isAbsent, isTardy, Days, remarks, MonthDayYear)
                                            SELECT 
                                                attendance.studentId,
                                                attendance.isPresent,
                                                attendance.isAbsent,
                                                attendance.isTardy,
                                                attendance.Days,
                                                attendance.remarks,
                                                CONVERT(VARCHAR(8), GETDATE(), 112)
                                            FROM 
                                                attendance
                                            JOIN 
                                                students ON attendance.studentId = students.id
                                            JOIN 
                                                subjects ON students.subjectId = subjects.id
                                            WHERE 
                                                subjects.id = @subjectId";

                        com.CommandText = insertQuery;
                        com.Parameters.Clear();
                        com.Parameters.AddWithValue("@subjectId", subjectId);

                        int rowsInserted = com.ExecuteNonQuery();

                        // Step 3: Remove records from Attendance
                        if (rowsInserted > 0)
                        {
                            string deleteQuery = @"
                                                    DELETE attendance
                                                    FROM 
                                                        attendance
                                                    JOIN 
                                                        students ON attendance.studentId = students.id
                                                    JOIN 
                                                        subjects ON students.subjectId = subjects.id
                                                    WHERE 
                                                        subjects.id = @subjectId";

                            com.CommandText = deleteQuery;
                            com.Parameters.Clear();
                            com.Parameters.AddWithValue("@subjectId", subjectId);

                            int rowsDeleted = com.ExecuteNonQuery();

                            dbCon();
                            com.Connection = con;

                            string query5 = @"
                                    UPDATE subjects 
                                    SET Days = @Days
                                    WHERE id = @SubjectId";

                            com.CommandText = query5;
                            com.Parameters.AddWithValue("@Days", 0);
                            com.Parameters.AddWithValue("@SubjectId", Program.selsubjId);

                            com.ExecuteNonQuery();
                            com.Connection.Close();

                            Program.selsubjDays = 0;
                        }
                    }

                    com.Connection.Close();
                    con.Close();




                    foreach (DataGridViewRow row in students.Rows)
                    {
                        if (row.IsNewRow) continue;
                        dbCon();

                        int studentId = Convert.ToInt32(row.Cells[0].Value);

                        string query2 = "INSERT INTO attendance (studentId,isPresent,isAbsent,isTardy, Days) VALUES (@studentId,@present, @absent, @tardy, @Days)";
                        com.Connection = con;
                        com.CommandText = query2;

                        com.Parameters.Clear();
                        com.Parameters.AddWithValue("@studentId", studentId);

                        bool cell3Checked = row.Cells[3].Value != null && Convert.ToBoolean(row.Cells[3].Value);
                        bool cell6Checked = row.Cells[6].Value != null && Convert.ToBoolean(row.Cells[6].Value);
                        com.Parameters.AddWithValue("@present", (cell3Checked || cell6Checked) ? 1 : 0);
                        com.Parameters.AddWithValue("@absent", Convert.ToBoolean(row.Cells[4].Value) ? 1 : 0);
                        com.Parameters.AddWithValue("@tardy", Convert.ToBoolean(row.Cells[5].Value) ? 1 : 0);
                        com.Parameters.AddWithValue("@Days", Program.selsubjDays + 1);
                        com.ExecuteNonQuery();
                        com.Connection.Close();
                        con.Close();
                        if (Convert.ToBoolean(row.Cells[4].Value))
                        {
                            CheckConsecutiveAbsences(studentId, row.Cells[2].Value.ToString());
                        }

                    }
                    MessageBox.Show("Attendance records inserted successfully.");


                    dbCon();
                    com.Connection = con;

                    string query1 = @"
                        UPDATE subjects 
                        SET Days = @Days
                        WHERE id = @SubjectId";

                    com.CommandText = query1;
                    com.Parameters.AddWithValue("@Days", Program.selsubjDays + 1);
                    com.Parameters.AddWithValue("@SubjectId", Program.selsubjId);

                    com.ExecuteNonQuery();
                    com.Connection.Close();

                    Program.selsubjDays += 1;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
            LoadStudents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this student?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel2.Visible = true;

                dbCon();
                com.Connection = con;

                string fullName1 = fullName.Text;
                int gender = male.Checked ? 1 : 0;

                string query = @"
                        UPDATE students 
                        SET name = @FullName, gender = @Gender
                        WHERE id = @StudentId AND subjectId = @SubjectId";

                com.CommandText = query;

                com.Parameters.AddWithValue("@FullName", fullName1);
                com.Parameters.AddWithValue("@Gender", gender);
                com.Parameters.AddWithValue("@StudentId", studentId);
                com.Parameters.AddWithValue("@SubjectId", selSub);

                com.ExecuteNonQuery();
                com.Connection.Close();

                panel2.Visible = false;
                LoadStudents();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to go back?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear this form", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fullName.Clear();
                male.Checked = false;
                female.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to go back?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel3.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to drop this student?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel3.Visible = true;

                dbCon();
                com.Connection = con;

                string query = @"
                        UPDATE students 
                        SET isDeactivated = 1
                        WHERE id = @StudentId AND subjectId = @SubjectId";

                com.CommandText = query;

                com.Parameters.AddWithValue("@StudentId", studentId);
                com.Parameters.AddWithValue("@SubjectId", selSub);

                com.ExecuteNonQuery();
                com.Connection.Close();


                dbCon();
                com.Connection = con;
                com.CommandText = "UPDATE subjects SET Dropped = Dropped + 1 WHERE id =" + Program.selsubjId.ToString();
                com.ExecuteNonQuery();
                con.Close();

                panel3.Visible = false;

                try
                {
                    dbCon();

                    string query1 = "INSERT INTO attendance (studentId, Days, remarks) VALUES (@studentId, @days, @remarks)";
                    com.Connection = con;
                    com.CommandText = query1;

                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@studentId", studentId);
                    com.Parameters.AddWithValue("@days", Program.selsubjDays + 1);
                    com.Parameters.AddWithValue("@remarks", remarks.Text);

                    com.ExecuteNonQuery();

                    MessageBox.Show("Dropped Successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (con != null && con.State == ConnectionState.Open)
                        con.Close();
                }
                LoadStudents();
            }
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gender.Text == "Male")
            {
                try
                {
                    dbCon();

                    string query = "SELECT id, subjectId, name FROM students WHERE subjectId = '" + Program.selsubjId + "' AND isDeactivated = 0 AND gender = 1"; ;
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();

                    students.Rows.Clear();

                    while (dr.Read())
                    {
                        int rowIndex = students.Rows.Add(
                            dr["id"],
                            dr["subjectId"],
                            dr["name"],
                            false,
                            false,
                            false,
                            false,
                            "Update",
                            "Drop"
                        );
                        //DataGridViewRow row = students.Rows[rowIndex];
                        //row.Cells[5].Style.BackColor = Color.FromArgb(21, 73, 135);
                        //row.Cells[5].Style.ForeColor = Color.White;
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
            else if (gender.Text == "Female")
            {
                try
                {
                    dbCon();

                    string query = "SELECT id, subjectId, name FROM students WHERE subjectId = '" + Program.selsubjId + "' AND isDeactivated = 0 AND gender = 0"; ;
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();

                    students.Rows.Clear();

                    while (dr.Read())
                    {
                        int rowIndex = students.Rows.Add(
                            dr["id"],
                            dr["subjectId"],
                            dr["name"],
                            false,
                            false,
                            false,
                            false,
                            "Update",
                            "Drop"
                        );
                        //DataGridViewRow row = students.Rows[rowIndex];
                        //row.Cells[5].Style.BackColor = Color.FromArgb(21, 73, 135);
                        //row.Cells[5].Style.ForeColor = Color.White;
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
            else if (gender.Text == "Dropped")
            {
                try
                {
                    dbCon();

                    string query = "SELECT id, subjectId, name FROM students WHERE subjectId = '" + Program.selsubjId + "' AND isDeactivated = 1"; ;
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();

                    students.Rows.Clear();

                    while (dr.Read())
                    {
                        int rowIndex = students.Rows.Add(
                            dr["id"],
                            dr["subjectId"],
                            dr["name"],
                            false,
                            false,
                            false,
                            false,
                            "Update",
                            "Undrop"
                        );
                        //DataGridViewRow row = students.Rows[rowIndex];
                        //row.Cells[5].Style.BackColor = Color.FromArgb(21, 73, 135);
                        //row.Cells[5].Style.ForeColor = Color.White;
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
            else
            {
                try
                {
                    dbCon();

                    string query = "SELECT id, subjectId, name FROM students WHERE subjectId = '" + Program.selsubjId + "' AND isDeactivated = 0"; ;
                    com.Connection = con;
                    com.CommandText = query;
                    dr = com.ExecuteReader();

                    students.Rows.Clear();

                    while (dr.Read())
                    {
                        int rowIndex = students.Rows.Add(
                            dr["id"],
                            dr["subjectId"],
                            dr["name"],
                            false,
                            false,
                            false,
                            false,
                            "Update",
                            "Drop"
                        );
                        //DataGridViewRow row = students.Rows[rowIndex];
                        //row.Cells[5].Style.BackColor = Color.FromArgb(21, 73, 135);
                        //row.Cells[5].Style.ForeColor = Color.White;
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
        }
        public void CheckConsecutiveAbsences(int studentId, string fname)
        {
            try
            {
                dbCon();
                com.Connection = con;
                string query = @"
                SELECT TOP 3 attendance.Days
                FROM attendance
                WHERE attendance.studentId = @StudentId
                  AND attendance.isAbsent = 1
                ORDER BY attendance.Days DESC;";

                com.CommandText = query;
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@StudentId", studentId);


                dr = com.ExecuteReader();

                int day1 = -1, day2 = -1, day3 = -1;
                string email = "";

                if (dr.Read())
                {
                    day1 = dr.GetInt32(0);

                    if (dr.Read())
                    {
                        day2 = dr.GetInt32(0);
                        if (dr.Read())
                        {
                            day3 = dr.GetInt32(0);
                            if (day1 - 1 == day2 && day2 - 1 == day3)
                            {
                                dr.Close();
                                con.Close();

                                MessageBox.Show($"Three consecutive absences found for the student'" + fname + "'", "Consecutive Absences Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                dbCon();
                                com.Connection = con;
                                com.CommandText = "UPDATE subjects SET ConsecAb = ConsecAb + 1 WHERE id =" + Program.selsubjId.ToString();
                                com.ExecuteNonQuery();
                                con.Close();


                                dbCon();
                                com.Connection = con;
                                string advisorQuery = @"
                                SELECT AdvicerUserId
                                FROM subjects
                                JOIN students ON students.subjectId = subjects.id
                                WHERE students.id = @StudentId;";

                                com.CommandText = advisorQuery;
                                com.Parameters.Clear();
                                com.Parameters.AddWithValue("@StudentId", studentId);
                                dr = com.ExecuteReader();
                                if (dr.Read())
                                {
                                    int advisorUserId = dr.GetInt32(0);
                                    dr.Close();
                                    con.Close();

                                    dbCon();
                                    com.Connection = con;
                                    string Query2 = @"
                                    SELECT email
                                    FROM users
                                    WHERE id = @Id;";

                                    com.CommandText = Query2;
                                    com.Parameters.Clear();
                                    com.Parameters.AddWithValue("@Id", advisorUserId);
                                    dr = com.ExecuteReader();
                                    if (dr.Read())
                                    {

                                        email = dr.GetString(0);
                                        dr.Close();
                                        con.Close();
                                    }
                                    dr.Close();
                                    con.Close();

                                    dbCon();
                                    com.Connection = con;

                                    string insertNotificationQuery = @"
                                    INSERT INTO notifications (userId, Title, StudentName, GradeLevel, Strand, SubjectName, Block)
                                    VALUES (@UserId, @Title, @StudentName, @GradeLevel, @Strand, @SubjectName, @Block);";

                                    com.CommandText = @"SELECT GradeLevel, Strand, SubjectName, Blk, students.name
                                                    FROM subjects
                                                    JOIN students ON students.subjectId = subjects.id
                                                    WHERE students.id = @StudentId;";
                                    com.Parameters.Clear();
                                    com.Parameters.AddWithValue("@StudentId", studentId);

                                    dr = com.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        int gradeLevel = dr.GetInt32(0);
                                        string strand = dr.GetString(1);
                                        string subjectName = dr.GetString(2);
                                        int block = dr.GetInt32(3);
                                        string name = dr.GetString(4);
                                        dr.Close();

                                        dbCon();
                                        com.Connection = con;

                                        com.CommandText = insertNotificationQuery;
                                        com.Parameters.Clear();
                                        com.Parameters.AddWithValue("@UserId", advisorUserId);
                                        com.Parameters.AddWithValue("@Title", "Consecutive Absences Alert");
                                        com.Parameters.AddWithValue("@StudentName", name); // You can replace this with actual student name
                                        com.Parameters.AddWithValue("@GradeLevel", gradeLevel);
                                        com.Parameters.AddWithValue("@Strand", strand);
                                        com.Parameters.AddWithValue("@SubjectName", subjectName);
                                        com.Parameters.AddWithValue("@Block", block);

                                        com.ExecuteNonQuery();
                                        dr.Close();

                                        SendEmailToAdvisor(email, gradeLevel, strand, subjectName, block, name);
                                    }

                                }

                            }
                        }
                    }
                }


                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void SendEmailToAdvisor(string advisorEmail, int gradeLevel, string strand, string subjectName, int block, string name)
        {
            try
            {
                string from = "comteqbusiness@gmail.com";
                string pass = "wgce swen dvwt gbbx";
                string subject = "Consecutive Absences Notification";
                string body = "Dear Advisor,\n\n" +
                   "This is to inform you that the student has been absent for three consecutive days.\n" +
                   "Name: " + name + "\n" +
                   "Grade Level: " + gradeLevel + "\n" +
                   "Strand: " + strand + "\n" +
                   "Subject: " + subjectName + "\n" +
                   "Block: " + block + "\n\n" +
                   "Please take appropriate action.\n\n" +
                   "Best regards,\n" +
                   "COMTEQ Computer and Business College INC";
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                message.To.Add(advisorEmail);
                message.Subject = subject;
                message.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);

                smtp.Send(message);
                MessageBox.Show("Email sent to the advisor successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void students_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (students.CurrentCell is DataGridViewCheckBoxCell)
            {
                students.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
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

            Brush brush = new SolidBrush(System.Drawing.Color.FromArgb(223, 239, 255));
            g.FillPath(brush, path);

            Pen borderPen = new Pen(System.Drawing.Color.Black, 2);
            g.DrawPath(borderPen, path);
        }
    }
}

