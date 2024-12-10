namespace OneTouchCheck
{
    partial class AdminCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminCreate));
            label3 = new Label();
            panel2 = new Panel();
            lname = new TextBox();
            mname = new TextBox();
            label10 = new Label();
            label9 = new Label();
            HeadTeacher = new CheckBox();
            SubjectTeacher = new CheckBox();
            Advicer = new CheckBox();
            back = new Button();
            create = new Button();
            clear = new Button();
            label8 = new Label();
            label7 = new Label();
            retypepassword = new TextBox();
            label6 = new Label();
            password = new TextBox();
            label5 = new Label();
            username = new TextBox();
            label4 = new Label();
            email = new TextBox();
            label2 = new Label();
            fname = new TextBox();
            pictureBox6 = new PictureBox();
            panel1 = new Panel();
            pictureBox9 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(443, 128);
            label3.Name = "label3";
            label3.Size = new Size(271, 32);
            label3.TabIndex = 17;
            label3.Text = "User Account Creation";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(223, 239, 255);
            panel2.Controls.Add(lname);
            panel2.Controls.Add(mname);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(HeadTeacher);
            panel2.Controls.Add(SubjectTeacher);
            panel2.Controls.Add(Advicer);
            panel2.Controls.Add(back);
            panel2.Controls.Add(create);
            panel2.Controls.Add(clear);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(retypepassword);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(password);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(username);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(email);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(fname);
            panel2.Location = new Point(31, 198);
            panel2.Name = "panel2";
            panel2.Size = new Size(1109, 358);
            panel2.TabIndex = 16;
            panel2.Paint += panel2_Paint;
            // 
            // lname
            // 
            lname.Anchor = AnchorStyles.Left;
            lname.Location = new Point(38, 241);
            lname.Name = "lname";
            lname.PlaceholderText = "Dela Cruz";
            lname.Size = new Size(290, 29);
            lname.TabIndex = 21;
            // 
            // mname
            // 
            mname.Anchor = AnchorStyles.Left;
            mname.Location = new Point(37, 159);
            mname.Name = "mname";
            mname.PlaceholderText = "T. (Optional)";
            mname.Size = new Size(290, 29);
            mname.TabIndex = 20;
            mname.TextChanged += mname_TextChanged;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.Location = new Point(37, 205);
            label10.Name = "label10";
            label10.Size = new Size(87, 21);
            label10.TabIndex = 19;
            label10.Text = "Last name";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.Location = new Point(37, 124);
            label9.Name = "label9";
            label9.Size = new Size(111, 21);
            label9.TabIndex = 18;
            label9.Text = "Middle name";
            // 
            // HeadTeacher
            // 
            HeadTeacher.Anchor = AnchorStyles.Right;
            HeadTeacher.AutoSize = true;
            HeadTeacher.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            HeadTeacher.Location = new Point(878, 78);
            HeadTeacher.Name = "HeadTeacher";
            HeadTeacher.Size = new Size(128, 25);
            HeadTeacher.TabIndex = 17;
            HeadTeacher.Text = "Head Teacher";
            HeadTeacher.UseVisualStyleBackColor = true;
            // 
            // SubjectTeacher
            // 
            SubjectTeacher.Anchor = AnchorStyles.Right;
            SubjectTeacher.AutoSize = true;
            SubjectTeacher.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            SubjectTeacher.Location = new Point(878, 140);
            SubjectTeacher.Name = "SubjectTeacher";
            SubjectTeacher.Size = new Size(144, 25);
            SubjectTeacher.TabIndex = 16;
            SubjectTeacher.Text = "Subject Teacher";
            SubjectTeacher.UseVisualStyleBackColor = true;
            // 
            // Advicer
            // 
            Advicer.Anchor = AnchorStyles.Right;
            Advicer.AutoSize = true;
            Advicer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Advicer.Location = new Point(878, 109);
            Advicer.Name = "Advicer";
            Advicer.Size = new Size(85, 25);
            Advicer.TabIndex = 15;
            Advicer.Text = "Advicer";
            Advicer.UseVisualStyleBackColor = true;
            // 
            // back
            // 
            back.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            back.BackColor = Color.Red;
            back.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            back.ForeColor = Color.White;
            back.Location = new Point(697, 303);
            back.Name = "back";
            back.Size = new Size(163, 35);
            back.TabIndex = 14;
            back.Text = "Back";
            back.UseVisualStyleBackColor = false;
            back.Click += button3_Click;
            // 
            // create
            // 
            create.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            create.BackColor = Color.FromArgb(21, 73, 135);
            create.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            create.ForeColor = Color.White;
            create.Location = new Point(467, 303);
            create.Name = "create";
            create.Size = new Size(163, 36);
            create.TabIndex = 13;
            create.Text = "Create";
            create.UseVisualStyleBackColor = false;
            create.Click += create_Click;
            // 
            // clear
            // 
            clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clear.BackColor = Color.White;
            clear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            clear.ForeColor = Color.Red;
            clear.Location = new Point(236, 303);
            clear.Name = "clear";
            clear.Size = new Size(163, 35);
            clear.TabIndex = 12;
            clear.Text = "Clear";
            clear.UseVisualStyleBackColor = false;
            clear.Click += clear_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(828, 78);
            label8.Name = "label8";
            label8.Size = new Size(44, 21);
            label8.TabIndex = 11;
            label8.Text = "Role";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(811, 205);
            label7.Name = "label7";
            label7.Size = new Size(139, 21);
            label7.TabIndex = 9;
            label7.Text = "Retype Password";
            // 
            // retypepassword
            // 
            retypepassword.Anchor = AnchorStyles.Right;
            retypepassword.Location = new Point(811, 241);
            retypepassword.Name = "retypepassword";
            retypepassword.Size = new Size(256, 29);
            retypepassword.TabIndex = 8;
            retypepassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(370, 205);
            label6.Name = "label6";
            label6.Size = new Size(82, 21);
            label6.TabIndex = 7;
            label6.Text = "Password";
            // 
            // password
            // 
            password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            password.Location = new Point(370, 241);
            password.Name = "password";
            password.Size = new Size(402, 29);
            password.TabIndex = 6;
            password.UseSystemPasswordChar = true;
            password.TextChanged += password_TextChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(370, 124);
            label5.Name = "label5";
            label5.Size = new Size(53, 21);
            label5.TabIndex = 5;
            label5.Text = "Email";
            // 
            // username
            // 
            username.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            username.Location = new Point(371, 78);
            username.Name = "username";
            username.PlaceholderText = "Johndough";
            username.Size = new Size(401, 29);
            username.TabIndex = 4;
            username.TextChanged += username_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(370, 48);
            label4.Name = "label4";
            label4.Size = new Size(87, 21);
            label4.TabIndex = 3;
            label4.Text = "Username";
            // 
            // email
            // 
            email.Anchor = AnchorStyles.Left;
            email.Location = new Point(372, 159);
            email.Name = "email";
            email.PlaceholderText = "example@gmail.com";
            email.Size = new Size(400, 29);
            email.TabIndex = 2;
            email.TextChanged += email_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(37, 48);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 1;
            label2.Text = "First Name";
            // 
            // fname
            // 
            fname.Anchor = AnchorStyles.Left;
            fname.Location = new Point(38, 79);
            fname.Name = "fname";
            fname.PlaceholderText = "Juan";
            fname.Size = new Size(290, 29);
            fname.TabIndex = 0;
            fname.TextChanged += fullName_TextChanged;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(1031, 97);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(109, 106);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 15;
            pictureBox6.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(pictureBox9);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1169, 100);
            panel1.TabIndex = 18;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Cursor = Cursors.Hand;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(42, 36);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(20, 25);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 5;
            pictureBox9.TabStop = false;
            pictureBox9.Click += pictureBox9_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(68, 36);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 0;
            label1.Text = "Admin";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(31, 117);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // AdminCreate
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 611);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(pictureBox6);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminCreate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admincreate";
            FormClosing += Form4_FormClosing;
            Load += Form4_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Panel panel2;
        private PictureBox pictureBox6;
        private Panel panel1;
        private PictureBox pictureBox9;
        private Label label1;
        private Label label8;
        private Label label7;
        private TextBox retypepassword;
        private Label label6;
        private TextBox password;
        private Label label5;
        private TextBox username;
        private Label label4;
        private TextBox email;
        private Label label2;
        private TextBox fname;
        private Button back;
        private Button create;
        private Button clear;
        private CheckBox SubjectTeacher;
        private CheckBox Advicer;
        private CheckBox HeadTeacher;
        private PictureBox pictureBox1;
        private TextBox lname;
        private TextBox mname;
        private Label label10;
        private Label label9;
    }
}