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
    public partial class HeadTeacherManage : Form
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
        public HeadTeacherManage()
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
            toolTip.SetToolTip(pictureBox1, "Add Subject and Blk");
        }


        private void HeadTeacherManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void HeadTeacherManage_Load(object sender, EventArgs e)
        {
            LoadTeachers();
            panel2.Visible = false;
            label1.Text = Program.fname;
        }
        private void LoadTeachers()
        {
            try
            {
                dbCon();

                string query = @"
                SELECT 
                    subjects.id,
                    subjects.GradeLevel,
                    subjects.Strand,
                    subjects.Blk,
                    subjects.SubjectName,
                    users.name,
                    subjects.isDeactivated
                FROM 
                    subjects
                INNER JOIN 
                    users ON subjects.TeacherUserId = users.id";

                com.CommandText = query;
                dr = com.ExecuteReader();

                Teachers.Rows.Clear();

                while (dr.Read())
                {
                    int rowIndex = Teachers.Rows.Add(
                        dr["id"],
                        dr["GradeLevel"],
                        dr["Strand"],
                        dr["Blk"],
                        dr["SubjectName"],
                        dr["name"],
                        "Update",
                        "Deactivate"
                    );
                    DataGridViewRow row = Teachers.Rows[rowIndex];
                    row.Cells[6].Style.BackColor = Color.FromArgb(21, 73, 135);
                    row.Cells[6].Style.ForeColor = Color.White;
                    bool isDeactivated = dr.GetBoolean(6);

                    if (isDeactivated)
                    {
                        row.Cells[7].Value = "Activate";
                        row.Cells[7].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        row.Cells[7].Value = "Deactivate";
                        row.Cells[7].Style.BackColor = Color.Red;
                    }
                    row.Cells[7].Style.ForeColor = Color.White;
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

        private void LoadTeachers1()
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

        private void ApplyFilters()
        {
            try
            {
                dbCon();

                string query = @"
            SELECT 
                subjects.id,
                subjects.GradeLevel,
                subjects.Strand,
                subjects.Blk,
                subjects.SubjectName,
                users.name,
                subjects.isDeactivated
            FROM 
                subjects
            INNER JOIN 
                users ON subjects.TeacherUserId = users.id
            WHERE 1 = 1";
                if (GradeLevel.Text != "ALL")
                {
                    query += " AND subjects.GradeLevel = @GradeLevel";
                }
                if (Strand.Text != "ALL")
                {
                    query += " AND subjects.Strand = @Strand";
                }

                com.CommandText = query;
                com.Parameters.Clear();

                if (GradeLevel.Text != "ALL")
                {
                    com.Parameters.AddWithValue("@GradeLevel", GradeLevel.Text);
                }
                if (Strand.Text != "ALL")
                {
                    com.Parameters.AddWithValue("@Strand", Strand.Text);
                }

                dr = com.ExecuteReader();
                Teachers.Rows.Clear();

                while (dr.Read())
                {
                    int rowIndex = Teachers.Rows.Add(
                        dr["id"],
                        dr["GradeLevel"],
                        dr["Strand"],
                        dr["Blk"],
                        dr["SubjectName"],
                        dr["name"],
                        "Update",
                        "Deactivate"
                    );

                    DataGridViewRow row = Teachers.Rows[rowIndex];
                    row.Cells[6].Style.BackColor = Color.FromArgb(21, 73, 135);
                    row.Cells[6].Style.ForeColor = Color.White;
                    bool isDeactivated = dr.GetBoolean(6);

                    if (isDeactivated)
                    {
                        row.Cells[7].Value = "Activate";
                        row.Cells[7].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        row.Cells[7].Value = "Deactivate";
                        row.Cells[7].Style.BackColor = Color.Red;
                    }
                    row.Cells[7].Style.ForeColor = Color.White;
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

        private void Teachers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && MessageBox.Show("Are you sure you want to modify account status of this user?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dbCon();
                int userId = Convert.ToInt32(Teachers.Rows[e.RowIndex].Cells[0].Value);
                bool isDeactivated = Teachers.Rows[e.RowIndex].Cells[7].Value.ToString() == "Deactivate";

                com.CommandText = isDeactivated ?
                    "UPDATE subjects SET isDeactivated = 1 WHERE id = @id" :
                    "UPDATE subjects SET isDeactivated = 0 WHERE id = @id";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@id", userId);
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();

                LoadTeachers();
            }
            if (e.ColumnIndex == 6 && MessageBox.Show("Are you sure you want to update this user?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                panel2.Visible = true;
                dbCon();
                LoadAdvisers();
                dbCon();
                LoadTeachers1();

                dbCon();
                int userId = Convert.ToInt32(Teachers.Rows[e.RowIndex].Cells[0].Value);
                Program.selSub = Convert.ToInt32(Teachers.Rows[e.RowIndex].Cells[0].Value);
                string query = @"
                SELECT 
                    subjects.id,
                    subjects.AdvicerUserId,
                    subjects.TeacherUserId,
                    subjects.GradeLevel,
                    subjects.Strand,
                    subjects.Blk,
                    subjects.SubjectName,
                    users.name,
                    subjects.isDeactivated
                FROM 
                    subjects
                INNER JOIN 
                    users ON subjects.TeacherUserId = users.id
                WHERE subjects.id = '" + userId + "'";

                com.CommandText = query;
                dr = com.ExecuteReader();
                dr.Read();
                Adviser.SelectedValue = dr["AdvicerUserId"];
                Teacher.SelectedValue = dr["TeacherUserId"];
                comboBox2.SelectedItem = dr["GradeLevel"].ToString();
                comboBox1.SelectedItem = dr["Strand"].ToString();
                SubjectName.Text = dr["SubjectName"].ToString();
                Block.Text = dr["Blk"].ToString();
                dr.Close();
                com.Connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Trim().ToLower();

            foreach (DataGridViewRow row in Teachers.Rows)
            {
                if (row.IsNewRow)
                    continue;
                bool isVisible = row.Cells.Cast<DataGridViewCell>()
                    .Any(cell => cell.Value != null && cell.Value.ToString().ToLower().Contains(filterText));

                row.Visible = isVisible;
            }

        }

        private void GradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void Strand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to go back to User Management?", "Continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel2.Visible = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Adviser.SelectedIndex == -1 ||
                Teacher.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(comboBox2.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(SubjectName.Text) ||
                string.IsNullOrWhiteSpace(Block.Text))
            {
                MessageBox.Show("Please fill in all required fields before updating.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var qst = MessageBox.Show("Are you sure that you want to update this user?", "Update User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qst == DialogResult.Yes)
            {
                try
                {
                    dbCon();
                    string query = @"
            UPDATE subjects 
            SET 
                AdvicerUserId = @AdvicerUserId,
                TeacherUserId = @TeacherUserId,
                GradeLevel = @GradeLevel,
                Strand = @Strand,
                Blk = @Blk,
                SubjectName = @SubjectName
            WHERE 
                id = @SubjectId";

                    com.CommandText = query;
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@AdvicerUserId", Adviser.SelectedValue);
                    com.Parameters.AddWithValue("@TeacherUserId", Teacher.SelectedValue);
                    com.Parameters.AddWithValue("@GradeLevel", comboBox2.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                    com.Parameters.AddWithValue("@Strand", comboBox1.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                    com.Parameters.AddWithValue("@Blk", Block.Text.Trim());
                    com.Parameters.AddWithValue("@SubjectName", SubjectName.Text.Trim());
                    com.Parameters.AddWithValue("@SubjectId", Program.selSub);

                    int rowsAffected = com.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Subject details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No changes were made. Verify the data and try again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating subject: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                        LoadTeachers();
                        panel2.Visible = false;
                    }
                }
            }
        }

        // Clear button

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the form?", "Continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Adviser.SelectedIndex = -1;
                Teacher.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;

                SubjectName.Text = string.Empty;
                Block.Text = string.Empty;
            }
        }

        // Add management

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Form HeadTeacherAdd = new HeadTeacherAdd();
            HeadTeacherAdd.Show();
            this.Hide();
        }

        // Homepage
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Form TeacherHome = new TeacherHome();
            TeacherHome.Show();
            this.Hide();
        }

        // report
        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            Form ReportA = new ReportA();
            ReportA.Show();
            this.Hide();
        }
        // Archive

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            Form Archive = new Archive();
            Archive.Show();
            this.Hide();
        }

        // change pass
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Changepass = new Changepass();
            Changepass.Show();
        }


        // design paint for background of table 
        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, panel3.Width, panel3.Height);

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

        // logout

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

        //Button design


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
