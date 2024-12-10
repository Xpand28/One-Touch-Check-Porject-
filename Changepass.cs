using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneTouchCheck
{

    public partial class Changepass : Form
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
            com.Connection = con;
        }

        public Changepass()
        {
            InitializeComponent();
        }


        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); 
                }
                return builder.ToString();
            }
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            string Username = username.Text; 
            string oldPassword = oldpass.Text; 
            string newPassword = newpass.Text; 
            string confirmPassword = conpass.Text; 

            try
            {
                dbCon();

      
                com.CommandText = "SELECT password FROM users WHERE username = @username";
                com.Parameters.AddWithValue("@username", Username);
                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    string storedPasswordHash = dr["password"].ToString();

           
                    string hashedOldPassword = HashPassword(oldPassword);
                    if (storedPasswordHash == hashedOldPassword)
                    {
                        dr.Close();

                        if (oldPassword == newPassword)
                        {
                            MessageBox.Show("Dont use old password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (newPassword == confirmPassword)
                        {

                            string hashedNewPassword = HashPassword(newPassword);

                            com.CommandText = "UPDATE users SET password = @newPassword WHERE username = @username";
                            com.Parameters.Clear();
                            com.Parameters.AddWithValue("@username", Username);
                            com.Parameters.AddWithValue("@newPassword", hashedNewPassword);
                            com.ExecuteNonQuery();

                            MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("New password and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("please fill out all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                cmbok.Show($"An error occurred: {ex.Message}", "Error", true);
            }
        }
    }
}