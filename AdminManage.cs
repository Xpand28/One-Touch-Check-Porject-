using Microsoft.VisualBasic.ApplicationServices;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Security.Cryptography;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace OneTouchCheck
{
    public partial class AdminManage : Form
    {



        private ToolTip toolTip;
        private bool isDragging = false;
        private Point startPoint;
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

        public AdminManage()
        {
            InitializeComponent();
            InitializeSearchUI();
            // Initialize the ToolTip
            toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox9, "Logout");
            toolTip.SetToolTip(pictureBox1, "Add Teacher");

            // Assign event handlers to the panel
            panel3.MouseDown += Panel3_MouseDown;
            panel3.MouseMove += Panel3_MouseMove;
            panel3.MouseUp += Panel3_MouseUp;


        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form form4 = new AdminCreate();
            this.Hide();
            form4.Show();

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();

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


        public void Popul()
        {
            try
            {
                if (dgv.Rows.Count > 0 && string.IsNullOrWhiteSpace(filter.Text.Trim()))
                {
                    return;
                }

                dgv.Rows.Clear();
                dbCon();

                string filterText = filter.Text.ToString().Trim();

                string query = @"
                SELECT 
                    users.id, 
                    CONCAT(users.fname, ' ', ISNULL(users.mname + ' ', ''), users.lname) AS fullName,
                    users.email, 
                    users.isDeactivated, 
                    (SELECT STRING_AGG(roles.roleName, '/') 
                     FROM roles 
                     WHERE roles.userId = users.id AND roles.roleName != 'Admin') AS roles
                FROM users
                WHERE users.id IN (SELECT userId FROM roles WHERE roleName != 'Admin')";

                if (filterText == "Deactivated")
                {
                    query += " AND users.isDeactivated = 1";
                }
                else if (filterText == "Activated")
                {
                    query += " AND users.isDeactivated = 0";
                }
                else if (filterText == "Head Teacher")
                {
                    query += " AND users.id IN (SELECT userId FROM roles WHERE roleName = 'HeadTeacher')";
                }
                else if (filterText == "Subject Teacher")
                {
                    query += " AND users.id IN (SELECT userId FROM roles WHERE roleName = 'SubjectTeacher')";
                }
                else if (filterText == "Advicer")
                {
                    query += " AND users.id IN (SELECT userId FROM roles WHERE roleName = 'Advicer')";
                }

                com.CommandText = query;
                com.Connection = con;

                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    int userId = dr.IsDBNull(0) ? -1 : dr.GetInt32(0);
                    string userName = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                    string userEmail = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                    bool isDeactivated = dr.IsDBNull(3) ? false : dr.GetBoolean(3);
                    string roles = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);  // This is where we get the concatenated roles

                    // Add the row to DataGridView
                    int rowIndex = dgv.Rows.Add(userId, userName, userEmail, roles, isDeactivated ? "Yes" : "No", "Update", "Deactivate");
                    DataGridViewRow row = dgv.Rows[rowIndex];

                    row.Cells[3].Style.ForeColor = Color.Black;
                    row.Cells[4].Value = "Update";
                    row.Cells[4].Style.BackColor = Color.Blue;
                    row.Cells[4].Style.ForeColor = Color.White;

                    if (isDeactivated)
                    {
                        row.Cells[5].Value = "Activate";
                        row.Cells[5].Style.BackColor = Color.Green;
                        row.Cells[5].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        row.Cells[5].Value = "Deactivate";
                        row.Cells[5].Style.BackColor = Color.Red;
                        row.Cells[5].Style.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }

                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }





        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Popul();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            Popul();
            label1.Text = Program.fname;
            searchbar.TextChanged += searchbar_TextChanged;
            dgv.Paint += dgv_Paint;



        }



        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && cmbyesno.Show("Are you sure you want to modify the account status of this user?", "Continue?"))
            {
                dbCon();
                int userId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                bool isDeactivated = dgv.Rows[e.RowIndex].Cells[5].Value.ToString() == "Deactivate";

                com.CommandText = isDeactivated ?
                    "UPDATE users SET isDeactivated = 1 WHERE id = @id" :
                    "UPDATE users SET isDeactivated = 0 WHERE id = @id";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@id", userId);
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();

                Popul();
            }

            if (e.ColumnIndex == 4 && cmbyesno.Show("Are you sure you want to update this user?", "Continue?"))
            {
                // Reset role checkboxes
                HeadTeacher.Checked = false;
                Advicer.Checked = false;
                SubjectTeacher.Checked = false;
                panel3.Visible = true;

                // Fetch user details
                dbCon();
                int userId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                Program.selID = userId;

                string query = @"
                    SELECT 
                        id, 
                        fname, 
                        ISNULL(mname, '') AS mname, 
                        lname, 
                        email, 
                        username, 
                        password 
                    FROM users 
                    WHERE id = @userId";

                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.AddWithValue("@userId", userId);

                    try
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Set the values to their respective textboxes
                                fname.Text = reader["fname"].ToString();
                                mname.Text = reader["mname"].ToString();
                                lname.Text = reader["lname"].ToString();
                                email.Text = reader["email"].ToString();
                                username.Text = reader["username"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        cmbyesno.Show($"An error occurred: {ex.Message}", "Error");
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                // Fetch roles
                dbCon();
                query = "SELECT roleName FROM roles WHERE userId = @userId";

                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.AddWithValue("@userId", userId);

                    try
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Reset the role checkboxes first
                                HeadTeacher.Checked = false;
                                Advicer.Checked = false;
                                SubjectTeacher.Checked = false;

                                while (reader.Read())
                                {
                                    string roleName = reader["roleName"].ToString();
                                    if (roleName == "HeadTeacher") HeadTeacher.Checked = true;
                                    if (roleName == "Advicer") Advicer.Checked = true;
                                    if (roleName == "SubjectTeacher") SubjectTeacher.Checked = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No roles found for this user.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }




        private void back_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to go back to Admin management?", "Continue ?");
            if (result)
            {
                panel3.Visible = false;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to clear the form", "Continue ?");
            if (result)
            {
                fname.Text = "";
                mname.Text = "";
                lname.Text = "";
                username.Text = "";
                email.Text = "";
                HeadTeacher.Checked = false;
                Advicer.Checked = false;
                SubjectTeacher.Checked = false;
            }
        }


        private void create_Click(object sender, EventArgs e)
        {
            // Validate email
            if (string.IsNullOrWhiteSpace(email.Text))
            {
                cmbok.Show("Email field cannot be empty.", "Validation Error", true);
                email.Focus();
                return;
            }
            else
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email.Text);
                    if (addr.Address != email.Text)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    cmbok.Show("Invalid email format. Please enter a valid email address.", "Validation Error", true);
                    email.Focus();
                    return;
                }
            }

            // Validate username
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                cmbok.Show("Username field cannot be empty.", "Validation Error", true);
                username.Focus();
                return;
            }

            // Validate fname
            if (string.IsNullOrWhiteSpace(fname.Text))
            {
                cmbok.Show("First Name field cannot be empty.", "Validation Error", true);
                fname.Focus();
                return;
            }

            // Validate Middle Name (optional)
            if (!string.IsNullOrWhiteSpace(mname.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(mname.Text, @"^[a-zA-Z\s.,]+$"))
            {
                cmbok.Show("Middle Name can only contain letters, spaces, '.', and ','. Numbers or other special characters are not allowed.", "Validation Error", true);
                mname.Focus();
                return;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(lname.Text))
            {
                cmbok.Show("Last Name field cannot be empty.", "Validation Error", true);
                lname.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(lname.Text, @"^[a-zA-Z\s.,]+$"))
            {
                cmbok.Show("Last Name can only contain letters, spaces, '.', and ','. Numbers or other special characters are not allowed.", "Validation Error", true);
                lname.Focus();
                return;
            }


            // Validate lname
            if (string.IsNullOrWhiteSpace(lname.Text))
            {
                cmbok.Show("Last Name field cannot be empty.", "Validation Error", true);
                lname.Focus();
                return;
            }

            // Validate role selection
            if (!Advicer.Checked && !SubjectTeacher.Checked && !HeadTeacher.Checked)
            {
                cmbok.Show("Please select at least one role: Adviser, Subject Teacher, or Head Teacher.", "Validation Error", true);
                return;
            }

            // Ensure only one of Advicer or HeadTeacher is selected
            if (HeadTeacher.Checked && Advicer.Checked)
            {
                cmbok.Show("Please select only one between Head Teacher & Advicer.", "Warning", true);
                HeadTeacher.Checked = false;
                Advicer.Checked = false;
                return;
            }

            // Confirmation dialog
            bool result = cmbyesno.Show("Are you sure that you want to update this user?", "Update User?");
            if (result)
            {
                try
                {
                    // Update user information in the database
                    dbCon();
                    com.CommandText = @"
            UPDATE users 
            SET 
                fname = @FirstName, 
                mname = @MiddleName, 
                lname = @LastName, 
                email = @Email, 
                username = @Username 
            WHERE ID = @UserID";
                    com.Connection = con;
                    com.Parameters.Clear(); // Clear parameters before adding new ones
                    com.Parameters.AddWithValue("@FirstName", fname.Text.Trim());
                    com.Parameters.AddWithValue("@MiddleName", string.IsNullOrWhiteSpace(mname.Text) ? DBNull.Value : mname.Text.Trim());
                    com.Parameters.AddWithValue("@LastName", lname.Text.Trim());
                    com.Parameters.AddWithValue("@Email", email.Text.Trim());
                    com.Parameters.AddWithValue("@Username", username.Text.Trim());
                    com.Parameters.AddWithValue("@UserID", Program.selID);

                    if (com.ExecuteNonQuery() > 0)
                    {
                        cmbok.Show("User information updated successfully.", "Success", false);
                    }
                    con.Close();

                    // Delete existing roles
                    dbCon();
                    com.CommandText = "DELETE FROM roles WHERE userId = @UserID";
                    com.Connection = con;
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@UserID", Program.selID);
                    com.ExecuteNonQuery();
                    con.Close();

                    // Insert selected roles
                    InsertRole(Advicer.Checked, "Advicer");
                    InsertRole(SubjectTeacher.Checked, "SubjectTeacher");
                    InsertRole(HeadTeacher.Checked, "HeadTeacher");

                    // Reset form and refresh UI
                    panel3.Visible = false;
                    HeadTeacher.Checked = false;
                    Advicer.Checked = false;
                    SubjectTeacher.Checked = false;
                    Popul();
                }
                catch (Exception ex)
                {
                    cmbok.Show($"An error occurred: {ex.Message}", "Error", true);
                }
            }
        }

        private void InsertRole(bool isChecked, string roleName)
        {
            if (isChecked)
            {
                dbCon();
                com.CommandText = "INSERT INTO roles (userId, roleName) VALUES (@UserID, @RoleName)";
                com.Connection = con;
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@UserID", Program.selID);
                com.Parameters.AddWithValue("@RoleName", roleName);
                com.ExecuteNonQuery();
                con.Close();
            }
        }




        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = e.Location;
            }
        }

        private void Panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {

                var newLocation = new Point(
                    panel3.Left + e.X - startPoint.X,
                    panel3.Top + e.Y - startPoint.Y);

                panel3.Location = newLocation;
            }
        }

        private void Panel3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
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


        private void InitializeSearchUI()
        {
            searchbar.Text = "Search...";
            searchbar.ForeColor = Color.Gray;


            searchbar.GotFocus += (s, e) =>
            {
                if (searchbar.Text == "Search...")
                {
                    searchbar.Text = "";
                    searchbar.ForeColor = Color.Black;
                }
            };
        }





        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            string sSelectedFolder, filePathName;
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sSelectedFolder = fbd.SelectedPath;

                // Include timestamp in the backup file name
                string timestamp = DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss"); // Include time in timestamp
                string fileName = $"AttendanceTrackingSystemBackup_{timestamp}.back";

                filePathName = System.IO.Path.Combine(sSelectedFolder, fileName);

                BackupRestore(filePathName, "Backup");
            }
            else
            {
                sSelectedFolder = string.Empty;
            }
        }

        private void RestoreBTN_Click(object sender, EventArgs e)
        {
            string filePathName;
            OpenFileDialog choofdlog = new OpenFileDialog
            {
                Filter = "Backup Files (*.back)|*.back",
                FilterIndex = 1,
                Multiselect = false
            };

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                filePathName = choofdlog.FileName;

                // Set database to single-user mode before restore
                SetDatabaseToSingleUserMode("Comtendance");

                // Perform restore operation
                BackupRestore(filePathName, "Restore");

                // After restoring, refresh the DataGridView
            }
            else
            {
                filePathName = string.Empty;
            }
        }
        private void BackupRestore(string path, string toDo)
        {
            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    conn.Open();
                    Log($"Connection opened for {toDo} operation.");

                    string sqlCommand = toDo == "Backup"
                        ? $"BACKUP DATABASE Comtendance TO DISK='{path}'"
                        : $"USE master; RESTORE DATABASE Comtendance FROM DISK='{path}' WITH REPLACE";

                    Log($"SQL Command: {sqlCommand}");
                    Log($"File Path: {path}");

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Log($"Database {toDo} operation completed successfully.");
                    }

                    MessageBox.Show($"Database {toDo} successful\n{path}");
                }
                catch (Exception ex)
                {
                    Log($"Error during {toDo}: {ex.Message}");
                    MessageBox.Show($"Error occurred: {ex.Message}");
                }
            }
        }

        private void Log(string message)
        {
            string logFile = "BackupRestoreDebug.log";
            string logEntry = $"{DateTime.Now}: {message}\n";
            System.IO.File.AppendAllText(logFile, logEntry);
        }


        private void SetDatabaseToSingleUserMode(string Comtendance)
        {
            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string sqlCommand = $"ALTER DATABASE [{Comtendance}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception to identify the issue

                    MessageBox.Show($"Error occurred while setting database to single-user mode: {ex.Message}");
                }
            }
        }

        private void username_TextChanged_1(object sender, EventArgs e)
        {
            // Username Validation
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                cmbok.Show("Username field cannot be empty.", "Validation Error", true);
                username.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(username.Text, @"^[a-zA-Z0-9]+$"))
            {
                cmbok.Show("Username can only contain letters and numbers. Special characters are not allowed.", "Validation Error", true);
                username.Focus();
                return;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchbar_TextChanged(object sender, EventArgs e)
        {
            string filterText = searchbar.Text.Trim().ToLower();
            bool hasMatches = false;

            if (!string.IsNullOrEmpty(filterText))
            {
                // Loop through rows to filter based on the search term
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    // Check if any cell in the row contains the filter text
                    bool matchesFilter = row.Cells.Cast<DataGridViewCell>()
                        .Any(cell => cell.Value != null && cell.Value.ToString().ToLower().Contains(filterText));

                    row.Visible = matchesFilter;

                    if (matchesFilter)
                    {
                        hasMatches = true; // If a match is found, set hasMatches to true
                    }
                }

                // Set the "Not Found" flag if no matches
                dgv.Tag = hasMatches ? null : "NotFound";
            }
            else
            {
                // If no search text, show all rows
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Visible = true;
                }

                dgv.Tag = null; // Clear "Not Found" state
            }

            dgv.Invalidate(); // Force DataGridView to repaint (to update display if needed)
        }






        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            // Check if the "Not Found" state is active and no visible rows are found after search
            if (dgv.Tag != null && dgv.Tag.ToString() == "NotFound" && dgv.Rows.Cast<DataGridViewRow>().All(row => !row.Visible))
            {
                string message = "No matching records found.";
                Font messageFont = new Font("Arial", 12, FontStyle.Bold);
                SizeF textSize = e.Graphics.MeasureString(message, messageFont);

                // Center the message in the DataGridView
                float x = (dgv.Width - textSize.Width) / 2;
                float y = (dgv.Height - textSize.Height) / 2;

                e.Graphics.DrawString(message, messageFont, Brushes.Red, x, y);
            }
        }
    }
}
