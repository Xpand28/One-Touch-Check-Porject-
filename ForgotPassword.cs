using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace OneTouchCheck
{
    public partial class ForgotPassword : Form
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

        public ForgotPassword()
        {
            InitializeComponent();
        }


        int vCode = 9999;


        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGmail.Text))
            {
                MessageBox.Show("Please enter an email address before sending.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!txtGmail.Text.Contains("@") || !txtGmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid and complete email address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!txtGmail.Text.ToLower().Contains("gmail") || !txtGmail.Text.ToLower().EndsWith("com"))
            {
                MessageBox.Show("Please ensure the email address is a valid Gmail address (e.g., example@gmail.com).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int atIndex = txtGmail.Text.IndexOf("@");
            if (atIndex == 0 || txtGmail.Text.Substring(0, atIndex).Trim().Length == 0)
            {
                MessageBox.Show("Please ensure the email address includes a username before '@gmail.com' (e.g., example@gmail.com).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            timvcode.Stop();
            string to, from, pass, mail;
            to = txtGmail.Text;
            from = "comteqbusiness@gmail.com";
            mail = vCode.ToString();
            pass = "wgce swen dvwt gbbx";
            MailMessage message = new MailMessage();

            string recipientName = null;


            try
            {
                dbCon();
                com.Connection = con;
                com.CommandText = "SELECT name FROM users WHERE LOWER(email) = LOWER(@Email)";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Email", txtGmail.Text.Trim());

                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    recipientName = dr["name"].ToString();
                }
                dr.Close();

                if (string.IsNullOrEmpty(recipientName))
                {
                    MessageBox.Show("The email is not registered in the database.", "Not Registered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


            message.From = new MailAddress(from);
            message.To.Add(to);
            message.Subject = "Verification Code";

            if (!string.IsNullOrEmpty(recipientName))
            {
                message.Body = $"Hello {recipientName},\n\nHere's your verification code: {mail}.\nPlease don't share this code with anyone.\n\nBest regards,\nCOMTEQ Computer and Business College INC";
            }
            else
            {
                message.Body = $"Hello,\n\nHere's your verification code: {mail}.\nPlease don't share this code with anyone.\n\nBest regards,\nCOMTEQ Computer and Business College INC.";
            }

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Verification code sent, go to gmail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirm.Enabled = true;
                btnConfirm.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timvcode_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            vCode = random.Next(10000, 99999); 


            vCode += 10;
            if (vCode == 99999)
            {
                vCode = 99999;
            }
        }


        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            string input = txtConfirm.Text;

            string numericInput = new string(input.Where(char.IsDigit).ToArray());

            if (input != numericInput)
            {
                txtConfirm.Text = numericInput;
                txtConfirm.SelectionStart = txtConfirm.Text.Length; 
            }
        }


        private void txtGmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            password.Enabled = false;
            retypepassword.Enabled = false;
            confirmUpdate.Enabled = false;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtConfirm.Text))
            {
                MessageBox.Show("Verification code cannot be empty. Please enter the code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtConfirm.Text == vCode.ToString())
            {
                MessageBox.Show("Verification successful! Proceeding to set a new password.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                password.Enabled = true;
                retypepassword.Enabled = true;
                confirmUpdate.Enabled = true;

                txtConfirm.Enabled = false;
            }
            else
            {
                MessageBox.Show("The verification code is incorrect. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void retypepassword_TextChanged(object sender, EventArgs e)
        {
            if (password.Text != retypepassword.Text)
            {
                retypepassword.BackColor = Color.LightCoral;
                confirmUpdate.Enabled = false;
            }
            else
            {
                retypepassword.BackColor = Color.LightGreen;
                confirmUpdate.Enabled = true;
            }
        }


        private void confirmUpdate_Click(object sender, EventArgs e)
        {
            string newPassword = password.Text.Trim();
            string confirmPassword = retypepassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Password fields cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = HashPassword(newPassword);

            try
            {

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("SELECT password FROM users WHERE LOWER(email) = LOWER(@Email)", con))
                    {
                        com.Parameters.AddWithValue("@Email", txtGmail.Text.Trim());

                        string currentPassword = (string)com.ExecuteScalar();

                        if (currentPassword == hashedPassword)
                        {
                            MessageBox.Show("The new password cannot be the same as the old password. Please choose a different password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (SqlCommand com = new SqlCommand("UPDATE users SET password = @Password WHERE LOWER(email) = LOWER(@Email)", con))
                    {
                        com.Parameters.AddWithValue("@Password", hashedPassword);
                        com.Parameters.AddWithValue("@Email", txtGmail.Text.Trim());

                        int rowsAffected = com.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }






    /////////////////////////////////////////
    // Credits to this youtuber AppStudioLK//
    /////////////////////////////////////////

    // Don't remove this code thanks.

    //{
    //    timvcode.Stop();
    //    string to, from, pass, mail;
    //    to = txtGmail.Text;
    //    from = "kramsetlab99@gmail.com";
    //    mail = vCode.ToString();
    //    pass = "cfvm fnav ewfv sxwk";
    //    MailMessage message = new MailMessage();
    //    message.To.Add(to);
    //    message.From = new MailAddress(from);
    //    message.Body = "Here's your Verification code, please don't show this code to anyone " + mail;
    //    message.Subject = "COMTEQ Computer and Business College INC. - Verification code";
    //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
    //    smtp.EnableSsl = true;
    //    smtp.Port = 587;
    //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    //    smtp.Credentials = new NetworkCredential(from, pass);
    //    try
    //    {
    //        smtp.Send(message);
    //        MessageBox.Show("Verify code sent, goto gmail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //        txtConfirm.Enabled = true;
    //        btnConfirm.Enabled = true;
    //    }
    //    catch(Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //    }

    //}
}

