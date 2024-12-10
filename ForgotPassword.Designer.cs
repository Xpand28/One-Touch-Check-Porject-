namespace OneTouchCheck
{
    partial class ForgotPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
            label1 = new Label();
            txtGmail = new TextBox();
            btnSend = new Button();
            btnConfirm = new Button();
            txtConfirm = new TextBox();
            label2 = new Label();
            timvcode = new System.Windows.Forms.Timer(components);
            retypepassword = new TextBox();
            label3 = new Label();
            password = new TextBox();
            label4 = new Label();
            confirmUpdate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(36, 53);
            label1.Name = "label1";
            label1.Size = new Size(176, 30);
            label1.TabIndex = 0;
            label1.Text = "Enter your gmail";
            // 
            // txtGmail
            // 
            txtGmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGmail.Location = new Point(36, 86);
            txtGmail.Name = "txtGmail";
            txtGmail.Size = new Size(277, 29);
            txtGmail.TabIndex = 8;
            txtGmail.TextChanged += txtGmail_TextChanged;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(0, 192, 0);
            btnSend.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSend.ForeColor = SystemColors.Info;
            btnSend.Location = new Point(351, 86);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 30);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(0, 192, 0);
            btnConfirm.Enabled = false;
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = SystemColors.Info;
            btnConfirm.Location = new Point(351, 161);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 30);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtConfirm
            // 
            txtConfirm.Enabled = false;
            txtConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirm.Location = new Point(36, 161);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(277, 29);
            txtConfirm.TabIndex = 4;
            txtConfirm.TextChanged += txtConfirm_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(36, 128);
            label2.Name = "label2";
            label2.Size = new Size(290, 30);
            label2.TabIndex = 3;
            label2.Text = "Enter your Verification Code";
            // 
            // timvcode
            // 
            timvcode.Enabled = true;
            timvcode.Interval = 1000;
            timvcode.Tick += timvcode_Tick;
            // 
            // retypepassword
            // 
            retypepassword.Enabled = false;
            retypepassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            retypepassword.Location = new Point(36, 322);
            retypepassword.Name = "retypepassword";
            retypepassword.Size = new Size(390, 29);
            retypepassword.TabIndex = 11;
            retypepassword.TextChanged += retypepassword_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(36, 289);
            label3.Name = "label3";
            label3.Size = new Size(178, 30);
            label3.TabIndex = 10;
            label3.Text = "Retype Password";
            // 
            // password
            // 
            password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            password.Location = new Point(36, 249);
            password.Name = "password";
            password.Size = new Size(390, 29);
            password.TabIndex = 12;
            password.TextChanged += password_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(36, 212);
            label4.Name = "label4";
            label4.Size = new Size(213, 30);
            label4.TabIndex = 9;
            label4.Text = "Enter New Password";
            // 
            // confirmUpdate
            // 
            confirmUpdate.BackColor = Color.FromArgb(0, 192, 0);
            confirmUpdate.Enabled = false;
            confirmUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmUpdate.ForeColor = SystemColors.Info;
            confirmUpdate.Location = new Point(158, 375);
            confirmUpdate.Name = "confirmUpdate";
            confirmUpdate.Size = new Size(135, 30);
            confirmUpdate.TabIndex = 13;
            confirmUpdate.Text = "Confirm";
            confirmUpdate.UseVisualStyleBackColor = false;
            confirmUpdate.Click += confirmUpdate_Click;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(21, 73, 135);
            BackgroundImage = Properties.Resources.Picsart_24_11_07_23_02_23_303_1;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(458, 426);
            Controls.Add(confirmUpdate);
            Controls.Add(retypepassword);
            Controls.Add(label3);
            Controls.Add(password);
            Controls.Add(label4);
            Controls.Add(btnConfirm);
            Controls.Add(txtConfirm);
            Controls.Add(label2);
            Controls.Add(btnSend);
            Controls.Add(txtGmail);
            Controls.Add(label1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ForgotPassword";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Forgot Password";
            Load += ForgotPassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtGmail;
        private Button btnSend;
        private Button btnConfirm;
        private TextBox txtConfirm;
        private Label label2;
        private System.Windows.Forms.Timer timvcode;
        private TextBox retypepassword;
        private Label label3;
        private TextBox password;
        private Label label4;
        private Button confirmUpdate;
    }
}