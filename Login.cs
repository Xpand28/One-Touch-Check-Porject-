using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Net;

namespace OneTouchCheck
{
    public partial class Login : Form
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

        public void remember()
        {
            //If remember me 
            if (rememberMe.Checked)
            {
                Properties.Settings.Default.username = user.Text;
                Properties.Settings.Default.password = pass.Text;
                Properties.Settings.Default.rememberme = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.rememberme = false;
                Properties.Settings.Default.Save();
            }
        }

        public Login()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MakeButtonRounded(button1, 20);
            pass.UseSystemPasswordChar = true;
            if (Properties.Settings.Default.rememberme == true)
            {
                user.Text = Properties.Settings.Default.username;
                pass.Text = Properties.Settings.Default.password;
                if (Properties.Settings.Default.rememberme == true)
                {
                    rememberMe.Checked = Properties.Settings.Default.rememberme;
                }
                else
                {
                    rememberMe.Checked = Properties.Settings.Default.rememberme;
                }
            }
        }


        // Button design 
        private void MakeButtonRounded(Button button, int borderRadius)
        {

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(button.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(button.Width - borderRadius, button.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, button.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            forUserLogin();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }






        // Function to hash the password 
        private string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Function to check user roles
        private void CheckUserRoles()
        {
            dbCon();
            com.CommandText = "SELECT roleName FROM roles WHERE userId = @userId";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@userId", Program.userID);
            com.Connection = con;

            dr = com.ExecuteReader();
            while (dr.Read())
            {
                string roleName = dr.GetString(0);
                switch (roleName)
                {
                    case "Admin":
                        Program.isAdmin = 1;
                        break;
                    case "Advicer":
                        Program.isAdvicer = 1;
                        break;
                    case "SubjectTeacher":
                        Program.isTeacher = 1;
                        break;
                    case "HeadTeacher":
                        Program.isHeadTeacher = 1;
                        break;
                }
            }
            dr.Close();
        }

        private void RedirectUser()
        {
            if (Program.isAdmin == 1)
            {

                cmbok.Show("Welcome, " + Program.fname, "Login Success.", false);
                remember();
                Form form5 = new AdminManage();
                this.Hide();
                form5.Show();
            }
            else
            {

                cmbok.Show("Welcome, " + Program.fname, "Login Success.", false);
                remember();
                Form form2 = new TeacherHome();
                this.Hide();
                form2.Show();
            }
        }



        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;
            }
        }

        // Track the current toogle if is admin or user
        private bool isAdminMode = false;


        // Log in button function
        public void forUserLogin()
        {
            string username = user.Text.Trim();
            string password = pass.Text.Trim();

            // Validate Username
            if (string.IsNullOrWhiteSpace(username))
            {
                cmbok.Show("Username or Password cannot be empty", "Validation Error.", true);
                user.Focus();
                return;
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(password))
            {
                cmbok.Show("Username or Password cannot be empty", "Validation Error.", true);
                pass.Focus();
                return;
            }

            if (password.Length < 5 || password.Length > 30)
            {
                cmbok.Show("Password must be 5 to 30 characters long", "Validation Error.", true);
                pass.Focus();
                return;
            }

            try
            {
                dbCon();
                if (con.State != System.Data.ConnectionState.Open)
                {
                    cmbok.Show("Connection to the database failed. Please check your server", "Database Connection Error.", true);
                    return;
                }

                com.CommandText = "SELECT id, username, password, isDeactivated, isAdmin, fname, mname, lname FROM users WHERE username = @username";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@username", username);
                com.Connection = con;

                dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read(); // Only call Read() once
                    string storedUsername = dr["username"].ToString();  // Direct column access
                    string storedPassword = dr["password"].ToString();
                    bool isDeactivated = Convert.ToInt32(dr["isDeactivated"]) == 1;
                    bool isAdmin = Convert.ToInt32(dr["isAdmin"]) == 1;

                    // Fetching first, middle, and last name columns
                    string fname = dr["fname"].ToString();
                    string mname = dr["mname"].ToString();
                    string lname = dr["lname"].ToString();

                    if (!username.Equals(storedUsername))
                    {
                        cmbok.Show("Username incorrect", "Validation Error.", true);
                        return;
                    }

                    if (isDeactivated)
                    {
                        cmbok.Show("User account deactivated. Please contact the admin.", "User Deactivated", false);
                        return;
                    }

                    if (isAdminMode && !isAdmin)
                    {
                        cmbok.Show("This account is not an admin account.", "Access Denied", false);
                        return;
                    }

                    if (!isAdminMode && isAdmin)
                    {
                        cmbok.Show("This account is an admin account. Please switch to admin mode.", "Access Denied", false);
                        return;
                    }

                    string hashedPassword = ComputeHash(password);

                    if (storedPassword == hashedPassword)
                    {
                        // Successful login
                        Program.userID = Convert.ToInt32(dr["id"]); // Store user ID
                        Program.fname = fname; // Store first name
                        Program.mname = mname; // Store middle name
                        Program.lname = lname; // Store last name

                        dr.Close();  // Close the data reader here

                        // Now you can safely use fname, mname, and lname
                        CheckUserRoles();
                        RedirectUser();
                    }
                    else
                    {
                        cmbok.Show("Wrong Password", "Incorrect password. Please try again.", false);
                    }
                }
                else
                {
                    dr.Close();
                    cmbok.Show("User does not exist. Please try again", "User Not Exist.", false);
                }
            }
            catch (Exception ex)
            {
                cmbok.Show("Error", $"An error occurred: {ex.Message}", true);
            }
        }


        private void off_Click(object sender, EventArgs e)
        {
            isAdminMode = false;
            on.Show();
            main.BackColor = Color.FromArgb(21, 73, 135);
            changename.Text = "User";
            button1.BackColor = Color.FromArgb(84, 171, 215);
            button1.ForeColor = Color.White;

        }

        private void on_Click(object sender, EventArgs e)
        {
            isAdminMode = true;
            on.Hide();
            main.BackColor = Color.Black;
            changename.Text = "Admin";
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;


        }
        private void main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPasswordForm = new ForgotPassword();
            forgotPasswordForm.Show();
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }



        //// Function to send the email with the confirmation link
        //private void SendConfirmationEmail(string toEmail, string confirmationLink)
        //{
        //    var fromEmail = "yourgmail@gmail.com";  // Replace with your Gmail address
        //    var fromPassword = "yourapppassword";   // Replace with your Gmail app password

        //    var smtpClient = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential(fromEmail, fromPassword),
        //        EnableSsl = true,
        //    };

        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress(fromEmail),
        //        Subject = "Confirm Your Password Reset",
        //        Body = $"Click the link below to reset your password:\n\n{confirmationLink}\n\nThis link will expire in 10 minutes.",
        //        IsBodyHtml = false
        //    };

        //    mailMessage.To.Add(toEmail);
        //    smtpClient.Send(mailMessage);
        //}

        //// This will be triggered when the user clicks the reset password link (if used)
        //private void OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    // Open the Reset Password form
        //    ResetPasswordForm resetForm = new ResetPasswordForm();
        //    resetForm.Show();
        //}
    }
}
