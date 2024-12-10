namespace OneTouchCheck
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            user = new TextBox();
            main = new Panel();
            linkLabel1 = new LinkLabel();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            changename = new Label();
            on = new PictureBox();
            off = new PictureBox();
            rememberMe = new CheckBox();
            showPassword = new CheckBox();
            button1 = new Button();
            label2 = new Label();
            pass = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)on).BeginInit();
            ((System.ComponentModel.ISupportInitialize)off).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(421, 20);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(482, 474);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // user
            // 
            user.Anchor = AnchorStyles.Left;
            user.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            user.Location = new Point(57, 127);
            user.Margin = new Padding(4);
            user.Name = "user";
            user.PlaceholderText = "Type your username";
            user.Size = new Size(303, 29);
            user.TabIndex = 2;
            user.TextChanged += user_TextChanged;
            // 
            // main
            // 
            main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            main.BackColor = Color.FromArgb(21, 73, 135);
            main.Controls.Add(linkLabel1);
            main.Controls.Add(pictureBox2);
            main.Controls.Add(label1);
            main.Controls.Add(changename);
            main.Controls.Add(on);
            main.Controls.Add(off);
            main.Controls.Add(rememberMe);
            main.Controls.Add(showPassword);
            main.Controls.Add(button1);
            main.Controls.Add(label2);
            main.Controls.Add(pass);
            main.Controls.Add(user);
            main.Location = new Point(0, 1);
            main.Margin = new Padding(4);
            main.Name = "main";
            main.Size = new Size(430, 473);
            main.TabIndex = 4;
            main.Paint += main_Paint;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.LinkColor = SystemColors.GradientActiveCaption;
            linkLabel1.Location = new Point(57, 238);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(126, 21);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot Password";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Image = Properties.Resources.New_logo_w_inc_white_1;
            pictureBox2.Location = new Point(99, 33);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(213, 55);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(57, 101);
            label1.Name = "label1";
            label1.Size = new Size(168, 17);
            label1.TabIndex = 12;
            label1.Text = "Username";
            // 
            // changename
            // 
            changename.Anchor = AnchorStyles.Left;
            changename.AutoSize = true;
            changename.BackColor = Color.Transparent;
            changename.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changename.ForeColor = SystemColors.Control;
            changename.Location = new Point(126, 335);
            changename.Margin = new Padding(4, 0, 4, 0);
            changename.Name = "changename";
            changename.Size = new Size(44, 21);
            changename.TabIndex = 11;
            changename.Text = "User";
            // 
            // on
            // 
            on.Anchor = AnchorStyles.Left;
            on.Image = (Image)resources.GetObject("on.Image");
            on.Location = new Point(57, 316);
            on.Name = "on";
            on.Size = new Size(62, 62);
            on.SizeMode = PictureBoxSizeMode.Zoom;
            on.TabIndex = 10;
            on.TabStop = false;
            on.Click += on_Click;
            // 
            // off
            // 
            off.Anchor = AnchorStyles.Left;
            off.Image = (Image)resources.GetObject("off.Image");
            off.Location = new Point(57, 316);
            off.Name = "off";
            off.Size = new Size(62, 62);
            off.SizeMode = PictureBoxSizeMode.Zoom;
            off.TabIndex = 9;
            off.TabStop = false;
            off.Click += off_Click;
            // 
            // rememberMe
            // 
            rememberMe.Anchor = AnchorStyles.Left;
            rememberMe.AutoSize = true;
            rememberMe.Font = new Font("Segoe UI", 12F);
            rememberMe.ForeColor = Color.White;
            rememberMe.Location = new Point(57, 295);
            rememberMe.Name = "rememberMe";
            rememberMe.Size = new Size(132, 25);
            rememberMe.TabIndex = 8;
            rememberMe.Text = "Remember Me";
            rememberMe.UseVisualStyleBackColor = true;
            // 
            // showPassword
            // 
            showPassword.Anchor = AnchorStyles.Left;
            showPassword.AutoSize = true;
            showPassword.Font = new Font("Segoe UI", 12F);
            showPassword.ForeColor = Color.White;
            showPassword.Location = new Point(57, 267);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(139, 25);
            showPassword.TabIndex = 7;
            showPassword.Text = "Show password";
            showPassword.UseVisualStyleBackColor = true;
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left;
            button1.BackColor = Color.FromArgb(84, 171, 215);
            button1.FlatAppearance.BorderColor = Color.FromArgb(84, 171, 215);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(83, 384);
            button1.Name = "button1";
            button1.Size = new Size(252, 38);
            button1.TabIndex = 6;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(57, 172);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // pass
            // 
            pass.Anchor = AnchorStyles.Left;
            pass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pass.Location = new Point(57, 199);
            pass.Margin = new Padding(4);
            pass.Name = "pass";
            pass.PlaceholderText = "Type your password";
            pass.Size = new Size(303, 29);
            pass.TabIndex = 4;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 239, 255);
            ClientSize = new Size(885, 474);
            Controls.Add(main);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            main.ResumeLayout(false);
            main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)on).EndInit();
            ((System.ComponentModel.ISupportInitialize)off).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox user;
        private Panel main;
        private Label label2;
        private TextBox pass;
        private CheckBox showPassword;
        private CheckBox rememberMe;
        private Button button1;
        private PictureBox on;
        private PictureBox off;
        private Label changename;
        private Label label1;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel1;
    }
}
