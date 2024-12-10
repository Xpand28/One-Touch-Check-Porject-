namespace OneTouchCheck
{
    partial class TeacherAddStud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherAddStud));
            panel2 = new Panel();
            fullName = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            female = new RadioButton();
            male = new RadioButton();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label8 = new Label();
            panel1 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox6 = new PictureBox();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(21, 73, 135);
            panel2.Controls.Add(fullName);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(0, 95);
            panel2.Name = "panel2";
            panel2.Size = new Size(403, 538);
            panel2.TabIndex = 9;
            // 
            // fullName
            // 
            fullName.Location = new Point(52, 157);
            fullName.Name = "fullName";
            fullName.PlaceholderText = "Dela Cruz, Juan T.";
            fullName.Size = new Size(290, 29);
            fullName.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(42, 107);
            label3.Name = "label3";
            label3.Size = new Size(306, 21);
            label3.TabIndex = 16;
            label3.Text = "Full Name (Last Name, First Name, M.I)";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(female);
            groupBox1.Controls.Add(male);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(52, 213);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 114);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gender";
            // 
            // female
            // 
            female.AutoSize = true;
            female.Location = new Point(11, 69);
            female.Name = "female";
            female.Size = new Size(78, 25);
            female.TabIndex = 1;
            female.TabStop = true;
            female.Text = "Female";
            female.UseVisualStyleBackColor = true;
            // 
            // male
            // 
            male.AutoSize = true;
            male.Location = new Point(11, 28);
            male.Name = "male";
            male.Size = new Size(62, 25);
            male.TabIndex = 0;
            male.TabStop = true;
            male.Text = "Male";
            male.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(68, 456);
            button3.Name = "button3";
            button3.Size = new Size(259, 29);
            button3.TabIndex = 14;
            button3.Text = "Back";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DeepSkyBlue;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(68, 409);
            button2.Name = "button2";
            button2.Size = new Size(259, 29);
            button2.TabIndex = 13;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(68, 356);
            button1.Name = "button1";
            button1.Size = new Size(259, 29);
            button1.TabIndex = 12;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(68, 36);
            label8.Name = "label8";
            label8.Size = new Size(243, 25);
            label8.TabIndex = 6;
            label8.Text = "Student Account Creation";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 73, 135);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox9);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1028, 100);
            panel1.TabIndex = 7;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(881, 29);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(47, 50);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = Properties.Resources.icon_park_solid_table_report;
            pictureBox3.Location = new Point(807, 29);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Cursor = Cursors.Hand;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(954, 29);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(50, 50);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 5;
            pictureBox9.TabStop = false;
            pictureBox9.Click += pictureBox9_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(195, 38);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(38, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(42, 41);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 0;
            label1.Text = "Jov M. Felarca";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(534, 179);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(364, 369);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 8;
            pictureBox6.TabStop = false;
            // 
            // TeacherAddStud
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 630);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox6);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "TeacherAddStud";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeacherAddStud";
            FormClosing += TeacherAddStud_FormClosing;
            Load += TeacherAddStud_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label8;
        private Panel panel1;
        private PictureBox pictureBox9;
        private PictureBox pictureBox2;
        private Label label1;
        private PictureBox pictureBox6;
        private GroupBox groupBox1;
        private RadioButton female;
        private RadioButton male;
        private Label label3;
        private TextBox fullName;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
    }
}