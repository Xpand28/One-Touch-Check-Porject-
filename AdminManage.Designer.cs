namespace OneTouchCheck
{
    partial class AdminManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManage));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            pictureBox6 = new PictureBox();
            label1 = new Label();
            pictureBox9 = new PictureBox();
            panel1 = new Panel();
            RestoreBTN = new Button();
            backBTN = new Button();
            dgv = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewButtonColumn();
            Column6 = new DataGridViewButtonColumn();
            filter = new ComboBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            fname = new TextBox();
            label7 = new Label();
            label6 = new Label();
            lname = new TextBox();
            mname = new TextBox();
            clear = new Button();
            HeadTeacher = new CheckBox();
            SubjectTeacher = new CheckBox();
            Advicer = new CheckBox();
            back = new Button();
            create = new Button();
            label8 = new Label();
            label5 = new Label();
            username = new TextBox();
            label4 = new Label();
            email = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label9 = new Label();
            pictureBox5 = new PictureBox();
            searchbar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(1041, 101);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(109, 106);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 19;
            pictureBox6.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(77, 41);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 0;
            label1.Text = "Admin";
            label1.Click += label1_Click;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Cursor = Cursors.Hand;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(42, 36);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(29, 35);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 5;
            pictureBox9.TabStop = false;
            pictureBox9.Click += pictureBox9_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(RestoreBTN);
            panel1.Controls.Add(backBTN);
            panel1.Controls.Add(pictureBox9);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-5, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1168, 100);
            panel1.TabIndex = 22;
            // 
            // RestoreBTN
            // 
            RestoreBTN.Location = new Point(1010, 31);
            RestoreBTN.Name = "RestoreBTN";
            RestoreBTN.Size = new Size(125, 42);
            RestoreBTN.TabIndex = 7;
            RestoreBTN.Text = "Restore";
            RestoreBTN.UseVisualStyleBackColor = true;
            RestoreBTN.Visible = false;
            RestoreBTN.Click += RestoreBTN_Click;
            // 
            // backBTN
            // 
            backBTN.Location = new Point(860, 31);
            backBTN.Name = "backBTN";
            backBTN.Size = new Size(125, 42);
            backBTN.TabIndex = 6;
            backBTN.Text = "Backup";
            backBTN.UseVisualStyleBackColor = true;
            backBTN.Visible = false;
            backBTN.Click += backBTN_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(223, 239, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(223, 239, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(223, 239, 255);
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv.BackgroundColor = Color.FromArgb(223, 239, 255);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(223, 239, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(223, 239, 255);
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Role, Column5, Column6 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(223, 239, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(223, 239, 255);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle3;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(223, 239, 255);
            dgv.Location = new Point(3, 53);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(223, 239, 255);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 51;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(223, 239, 255);
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.RowTemplate.DividerHeight = 4;
            dgv.RowTemplate.Height = 40;
            dgv.RowTemplate.ReadOnly = true;
            dgv.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv.Size = new Size(1134, 325);
            dgv.TabIndex = 0;
            dgv.CellContentClick += dgv_CellContentClick;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "id";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Visible = false;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Name";
            Column2.MinimumWidth = 3;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Resizable = DataGridViewTriState.True;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Email";
            Column3.MinimumWidth = 4;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Role
            // 
            Role.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Role.FillWeight = 200F;
            Role.HeaderText = "Role";
            Role.MinimumWidth = 4;
            Role.Name = "Role";
            Role.ReadOnly = true;
            Role.Width = 69;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column5.FillWeight = 200F;
            Column5.FlatStyle = FlatStyle.Popup;
            Column5.HeaderText = "Information";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.SortMode = DataGridViewColumnSortMode.Automatic;
            Column5.Width = 127;
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column6.FillWeight = 200F;
            Column6.FlatStyle = FlatStyle.Popup;
            Column6.HeaderText = "Control";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Resizable = DataGridViewTriState.False;
            Column6.SortMode = DataGridViewColumnSortMode.Automatic;
            Column6.Width = 92;
            // 
            // filter
            // 
            filter.BackColor = Color.FromArgb(21, 73, 135);
            filter.ForeColor = SystemColors.Control;
            filter.FormattingEnabled = true;
            filter.Items.AddRange(new object[] { "All", "Activated", "Deactivated", "Head Teacher", "Advicer", "Subject Teacher" });
            filter.Location = new Point(28, 12);
            filter.Name = "filter";
            filter.Size = new Size(144, 29);
            filter.TabIndex = 1;
            filter.Text = "All";
            filter.SelectedIndexChanged += filter_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(223, 239, 255);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(1081, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(223, 239, 255);
            panel2.Controls.Add(searchbar);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(filter);
            panel2.Controls.Add(dgv);
            panel2.Location = new Point(12, 208);
            panel2.Name = "panel2";
            panel2.Size = new Size(1140, 391);
            panel2.TabIndex = 20;
            panel2.Paint += panel2_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.BackgroundImage = Properties.Resources.Picsart_24_11_07_23_02_23_303_1;
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.Controls.Add(fname);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(lname);
            panel3.Controls.Add(mname);
            panel3.Controls.Add(clear);
            panel3.Controls.Add(HeadTeacher);
            panel3.Controls.Add(SubjectTeacher);
            panel3.Controls.Add(Advicer);
            panel3.Controls.Add(back);
            panel3.Controls.Add(create);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(username);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(email);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Cursor = Cursors.SizeAll;
            panel3.Location = new Point(269, 106);
            panel3.Name = "panel3";
            panel3.Size = new Size(633, 375);
            panel3.TabIndex = 15;
            panel3.Paint += panel3_Paint;
            // 
            // fname
            // 
            fname.Location = new Point(18, 90);
            fname.Name = "fname";
            fname.PlaceholderText = "Juan";
            fname.Size = new Size(261, 29);
            fname.TabIndex = 45;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(18, 205);
            label7.Name = "label7";
            label7.Size = new Size(87, 21);
            label7.TabIndex = 44;
            label7.Text = "Last name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(19, 131);
            label6.Name = "label6";
            label6.Size = new Size(111, 21);
            label6.TabIndex = 43;
            label6.Text = "Middle name";
            // 
            // lname
            // 
            lname.Location = new Point(19, 235);
            lname.Name = "lname";
            lname.PlaceholderText = "Dela Cruz";
            lname.Size = new Size(260, 29);
            lname.TabIndex = 42;
            // 
            // mname
            // 
            mname.Location = new Point(19, 164);
            mname.Name = "mname";
            mname.PlaceholderText = "T.  (Optional)";
            mname.Size = new Size(260, 29);
            mname.TabIndex = 41;
            // 
            // clear
            // 
            clear.BackColor = Color.White;
            clear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            clear.ForeColor = Color.Red;
            clear.Location = new Point(39, 292);
            clear.Name = "clear";
            clear.Size = new Size(163, 35);
            clear.TabIndex = 40;
            clear.Text = "Clear";
            clear.UseVisualStyleBackColor = false;
            clear.Click += clear_Click;
            // 
            // HeadTeacher
            // 
            HeadTeacher.AutoSize = true;
            HeadTeacher.BackColor = Color.Transparent;
            HeadTeacher.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            HeadTeacher.ForeColor = Color.Transparent;
            HeadTeacher.Location = new Point(323, 245);
            HeadTeacher.Name = "HeadTeacher";
            HeadTeacher.Size = new Size(128, 25);
            HeadTeacher.TabIndex = 39;
            HeadTeacher.Text = "Head Teacher";
            HeadTeacher.UseVisualStyleBackColor = false;
            // 
            // SubjectTeacher
            // 
            SubjectTeacher.AutoSize = true;
            SubjectTeacher.BackColor = Color.Transparent;
            SubjectTeacher.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            SubjectTeacher.ForeColor = Color.Transparent;
            SubjectTeacher.Location = new Point(464, 245);
            SubjectTeacher.Name = "SubjectTeacher";
            SubjectTeacher.Size = new Size(144, 25);
            SubjectTeacher.TabIndex = 38;
            SubjectTeacher.Text = "Subject Teacher";
            SubjectTeacher.UseVisualStyleBackColor = false;
            // 
            // Advicer
            // 
            Advicer.AutoSize = true;
            Advicer.BackColor = Color.Transparent;
            Advicer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Advicer.ForeColor = Color.Transparent;
            Advicer.Location = new Point(464, 214);
            Advicer.Name = "Advicer";
            Advicer.Size = new Size(85, 25);
            Advicer.TabIndex = 37;
            Advicer.Text = "Advicer";
            Advicer.UseVisualStyleBackColor = false;
            // 
            // back
            // 
            back.BackColor = Color.Red;
            back.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            back.ForeColor = Color.White;
            back.Location = new Point(421, 292);
            back.Name = "back";
            back.Size = new Size(163, 35);
            back.TabIndex = 36;
            back.Text = "Back";
            back.UseVisualStyleBackColor = false;
            back.Click += back_Click;
            // 
            // create
            // 
            create.BackColor = Color.FromArgb(21, 73, 135);
            create.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            create.ForeColor = Color.White;
            create.Location = new Point(227, 292);
            create.Name = "create";
            create.Size = new Size(163, 35);
            create.TabIndex = 35;
            create.Text = "Update";
            create.UseVisualStyleBackColor = false;
            create.Click += create_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = SystemColors.Window;
            label8.Location = new Point(323, 210);
            label8.Name = "label8";
            label8.Size = new Size(52, 21);
            label8.TabIndex = 34;
            label8.Text = "Role: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Transparent;
            label5.Location = new Point(318, 61);
            label5.Name = "label5";
            label5.Size = new Size(53, 21);
            label5.TabIndex = 29;
            label5.Text = "Email";
            // 
            // username
            // 
            username.Location = new Point(319, 164);
            username.Name = "username";
            username.PlaceholderText = "Johndough";
            username.Size = new Size(289, 29);
            username.TabIndex = 28;
            username.TextChanged += username_TextChanged_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(318, 131);
            label4.Name = "label4";
            label4.Size = new Size(87, 21);
            label4.TabIndex = 27;
            label4.Text = "Username";
            // 
            // email
            // 
            email.Location = new Point(318, 90);
            email.Name = "email";
            email.PlaceholderText = "example@gmail.com";
            email.Size = new Size(290, 29);
            email.TabIndex = 26;
            email.TextChanged += email_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(18, 61);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 25;
            label3.Text = "First name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(227, 18);
            label2.Name = "label2";
            label2.Size = new Size(180, 25);
            label2.TabIndex = 14;
            label2.Text = "UPDATE ACCOUNT";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(443, 128);
            label9.Name = "label9";
            label9.Size = new Size(277, 45);
            label9.TabIndex = 6;
            label9.Text = "Welcome Admin!";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.New_logo_w_inc__1__3;
            pictureBox5.Location = new Point(12, 128);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(175, 50);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 23;
            pictureBox5.TabStop = false;
            // 
            // searchbar
            // 
            searchbar.Location = new Point(878, 12);
            searchbar.Name = "searchbar";
            searchbar.Size = new Size(197, 29);
            searchbar.TabIndex = 15;
            searchbar.TextChanged += searchbar_TextChanged;
            // 
            // AdminManage
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 611);
            Controls.Add(pictureBox5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pictureBox6);
            Controls.Add(label9);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "AdminManage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Management";
            FormClosing += Form5_FormClosing;
            Load += Form5_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox6;
        private Label label1;
        private PictureBox pictureBox9;
        private Panel panel1;
        private DataGridView dgv;
        private ComboBox filter;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private TextBox email;
        private Label label4;
        private TextBox username;
        private Label label5;
        private Label label8;
        private Button create;
        private Button back;
        private CheckBox Advicer;
        private CheckBox SubjectTeacher;
        private CheckBox HeadTeacher;
        private Button clear;
        private Panel panel3;
        private Label label9;
        private PictureBox pictureBox5;
        private Button backBTN;
        private Button RestoreBTN;
        private Label label7;
        private Label label6;
        private TextBox lname;
        private TextBox mname;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewButtonColumn Column5;
        private DataGridViewButtonColumn Column6;
        private TextBox fname;
        private TextBox searchbar;
    }
}