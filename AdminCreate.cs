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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace OneTouchCheck
{
    public partial class AdminCreate : Form
    {
        public AdminCreate()
        {
            InitializeComponent();
        }

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




        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = Program.fname;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to go back to Admin management?", "Continue ?");
            if (result)
            {
                // Go Form5 - User Management
                Form form5 = new AdminManage();
                this.Hide();
                form5.Show();
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }


        public void checkUser()
        {
            dbCon();

            // Check if the user already exists by username
            com.CommandText = "SELECT fname FROM users WHERE username = @username";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@username", username.Text);
            com.Connection = con;

            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                cmbok.Show("User already exists.", "User Exist.", false);
                dr.Close();
                return;
            }
            else
            {
                bool result = cmbyesno.Show("Are you sure you want to register this user?", "Register ?");
                if (result)
                {
                    dr.Close();  // Close the reader before executing next command

                    // Hash the password before storing it
                    string hashedPassword = HashPassword(password.Text);

                    // Insert the new user into the database
                    com.CommandText = "INSERT INTO users (fname, mname, lname, email, username, password) VALUES (@fname, @mname, @lname, @email, @username, @password)";
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@fname", fname.Text);
                    com.Parameters.AddWithValue("@mname", mname.Text);  // Ensure the field exists
                    com.Parameters.AddWithValue("@lname", lname.Text);
                    com.Parameters.AddWithValue("@email", email.Text);
                    com.Parameters.AddWithValue("@username", username.Text);
                    com.Parameters.AddWithValue("@password", hashedPassword);
                    com.Connection = con;

                    if (com.ExecuteNonQuery() > 0)
                    {
                        cmbok.Show("Account Created Successfully", "Success", false);
                    }

                    // Fetch the created user's ID
                    com.CommandText = "SELECT TOP 1 ID FROM Users ORDER BY ID DESC";
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        Program.createdID = Convert.ToInt32(dr.GetValue(0));
                    }
                    dr.Close();

                    // Assign roles based on checked checkboxes
                    if (Advicer.Checked)
                    {
                        AddRoleToUser(Program.createdID, "Advicer");
                    }

                    if (SubjectTeacher.Checked)
                    {
                        AddRoleToUser(Program.createdID, "SubjectTeacher");
                    }

                    if (HeadTeacher.Checked)
                    {
                        AddRoleToUser(Program.createdID, "HeadTeacher");
                    }
                }
            }
        }

        private void AddRoleToUser(int userId, string roleName)
        {
            dbCon();
            com.CommandText = "INSERT INTO roles (userId, roleName) VALUES (@userId, @roleName)";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@userId", userId);
            com.Parameters.AddWithValue("@roleName", roleName);
            com.Connection = con;

            com.ExecuteNonQuery();
            com.Connection.Close();
        }



        // Password security
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fname.Text))
            {
                cmbok.Show("First Name field cannot be empty.", "Validation Error", true);
                fname.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(fname.Text, @"^[a-zA-Z\s.,]+$"))
            {
                cmbok.Show("First Name can only contain letters, spaces, '.', and ','.", "Validation Error", true);
                fname.Focus();
                return;
            }

            // Validate Middle Name (optional)
            if (!string.IsNullOrWhiteSpace(mname.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(mname.Text, @"^[a-zA-Z\s.,]+$"))
            {
                cmbok.Show("Middle Name can only contain letters, spaces, '.', and ','.", "Validation Error", true);
                mname.Focus();
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


            // Validate Last Name
            if (string.IsNullOrWhiteSpace(lname.Text))
            {
                cmbok.Show("Last Name field cannot be empty.", "Validation Error", true);
                lname.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(lname.Text, @"^[a-zA-Z\s.,]+$"))
            {
                cmbok.Show("Last Name can only contain letters, spaces, '.', and ','.", "Validation Error", true);
                lname.Focus();
                return;
            }

            // Check for duplicate name (combine fname, mname, and lname for comparison)
            dbCon();
            com.CommandText = @"SELECT COUNT(*) FROM users 
                        WHERE fname = @fname AND 
                              mname = @mname AND 
                              lname = @lname";
            com.Connection = con;
            com.Parameters.AddWithValue("@fname", fname.Text.Trim());
            com.Parameters.AddWithValue("@mname", string.IsNullOrWhiteSpace(mname.Text) ? DBNull.Value : mname.Text.Trim());
            com.Parameters.AddWithValue("@lname", lname.Text.Trim());

            int count = Convert.ToInt32(com.ExecuteScalar());
            if (count > 0)
            {
                cmbok.Show("A user with the same name already exists in the system.", "Duplication Error", true);
                fname.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(fname.Text, @"^[a-zA-Z\s.,]+$"))
            {
                cmbok.Show("Name can only contain letters, spaces, '.', and ','. Numbers or other special characters are not allowed.", "Validation Error", true);
                fname.Focus();
                return;
            }
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



            if (string.IsNullOrWhiteSpace(email.Text))
            {
                cmbok.Show("Email field cannot be empty.", "Validation Error", true);
                email.Focus();
                return;
            }

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

            if (!email.Text.EndsWith("@gmail.com"))
            {
                cmbok.Show("Please enter a valid Gmail address (e.g., example@gmail.com).", "Validation Error", true);
                email.Focus();
                return;
            }

            // Check for duplicate email
            dbCon();
            com.CommandText = $"SELECT email FROM users WHERE email = '{email.Text}'";
            com.Connection = con;
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                cmbok.Show("This Gmail address is already registered. Please use a different Gmail.", "Duplicate Gmail", true);
                dr.Close();
                con.Close();
                return;
            }
            dr.Close();
            con.Close();


            // Password Validation
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                cmbok.Show("Password field cannot be empty.", "Validation Error", true);
                password.Focus();
                return;
            }

            if (password.Text.Length < 5)
            {
                cmbok.Show("Password must be at least 5 characters long.", "Validation Error", true);
                password.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(retypepassword.Text))
            {
                cmbok.Show("Retype Password field cannot be empty.", "Validation Error", true);
                retypepassword.Focus();
                return;
            }

            if (!password.Text.Equals(retypepassword.Text))
            {
                cmbok.Show("Passwords do not match. Please retype the passwords correctly.", "Validation Error", true);
                password.Focus();
                return;
            }

            // Role Selection Validation
            if (!Advicer.Checked && !SubjectTeacher.Checked && !HeadTeacher.Checked)
            {
                cmbok.Show("Please select at least one role: Adviser, Subject Teacher, or Head Teacher.", "Validation Error", true);
                return;
            }

            if (Advicer.Checked && HeadTeacher.Checked)
            {
                cmbok.Show("Please select only one role between: Adviser or Head Teacher.", "Validation Error", true);
                HeadTeacher.Checked = false;
                Advicer.Checked = false;
                return;
            }
            else
            {
                checkUser();
            }
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

        private void clear_Click(object sender, EventArgs e)
        {
            bool result = cmbyesno.Show("Are you sure you want to Clear the form?", "Continue ?");
            if (result)
            {
                fname.Text = "";
                mname.Text = "";
                lname.Text = "";
                username.Text = "";
                email.Text = "";
                password.Text = "";
                retypepassword.Text = "";
                HeadTeacher.Checked = false;
                Advicer.Checked = false;
                SubjectTeacher.Checked = false;
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

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void fullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void mname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
