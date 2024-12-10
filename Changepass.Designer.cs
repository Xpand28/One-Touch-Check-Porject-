namespace OneTouchCheck
{
    partial class Changepass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Changepass));
            oldpass = new TextBox();
            newpass = new TextBox();
            conpass = new TextBox();
            btnchange = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            username = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // oldpass
            // 
            oldpass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            oldpass.Location = new Point(61, 180);
            oldpass.Name = "oldpass";
            oldpass.PlaceholderText = "Old password";
            oldpass.Size = new Size(252, 33);
            oldpass.TabIndex = 0;
            // 
            // newpass
            // 
            newpass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newpass.Location = new Point(61, 262);
            newpass.Name = "newpass";
            newpass.PlaceholderText = "New password";
            newpass.Size = new Size(252, 33);
            newpass.TabIndex = 1;
            // 
            // conpass
            // 
            conpass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            conpass.Location = new Point(61, 335);
            conpass.Name = "conpass";
            conpass.PlaceholderText = "Confirm password";
            conpass.Size = new Size(252, 33);
            conpass.TabIndex = 2;
            // 
            // btnchange
            // 
            btnchange.BackColor = Color.Lime;
            btnchange.FlatStyle = FlatStyle.Flat;
            btnchange.Location = new Point(131, 408);
            btnchange.Name = "btnchange";
            btnchange.Size = new Size(110, 35);
            btnchange.TabIndex = 0;
            btnchange.Text = "CHANGE";
            btnchange.UseVisualStyleBackColor = false;
            btnchange.Click += btnchange_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(61, 143);
            label1.Name = "label1";
            label1.Size = new Size(146, 30);
            label1.TabIndex = 3;
            label1.Text = "Old Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(61, 223);
            label2.Name = "label2";
            label2.Size = new Size(156, 30);
            label2.TabIndex = 4;
            label2.Text = "New Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(61, 302);
            label3.Name = "label3";
            label3.Size = new Size(191, 30);
            label3.TabIndex = 5;
            label3.Text = "Confirm Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(61, 62);
            label4.Name = "label4";
            label4.Size = new Size(120, 30);
            label4.TabIndex = 7;
            label4.Text = "User Name";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // username
            // 
            username.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username.Location = new Point(61, 100);
            username.Name = "username";
            username.PlaceholderText = "User Name";
            username.Size = new Size(252, 33);
            username.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(74, 17);
            label5.Name = "label5";
            label5.Size = new Size(223, 30);
            label5.TabIndex = 8;
            label5.Text = "CHANGE PASSWORD";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Changepass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 73, 135);
            BackgroundImage = Properties.Resources.Picsart_24_11_07_23_02_23_303_1;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(377, 472);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(username);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnchange);
            Controls.Add(conpass);
            Controls.Add(newpass);
            Controls.Add(oldpass);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Changepass";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Changepass";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox oldpass;
        private TextBox newpass;
        private TextBox conpass;
        private Button btnchange;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox username;
        private Label label5;
    }
}