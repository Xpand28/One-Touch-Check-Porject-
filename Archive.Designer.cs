namespace OneTouchCheck
{
    partial class Archive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Archive));
            label9 = new Label();
            pictureBox6 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            dgArchive = new DataGridView();
            Column8 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewButtonColumn();
            Column7 = new DataGridViewButtonColumn();
            gender = new ComboBox();
            panel1 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgArchive).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(401, 143);
            label9.Name = "label9";
            label9.Size = new Size(458, 47);
            label9.TabIndex = 28;
            label9.Text = "Archived Report Summary";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(27, 112);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(109, 106);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 29;
            pictureBox6.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(27, 224);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1174, 482);
            tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(223, 239, 255);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(dgArchive);
            tabPage1.Controls.Add(gender);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1166, 448);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Empty Page";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(21, 73, 135);
            comboBox1.ForeColor = SystemColors.Control;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(187, 17);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(135, 29);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "  Strand";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(934, 17);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Subject Name";
            textBox1.Size = new Size(204, 29);
            textBox1.TabIndex = 4;
            // 
            // dgArchive
            // 
            dgArchive.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgArchive.Columns.AddRange(new DataGridViewColumn[] { Column8, Column1, Column2, Column3, Column4, Column5, Column9, Column10, Column6, Column7 });
            dgArchive.Location = new Point(24, 62);
            dgArchive.Name = "dgArchive";
            dgArchive.Size = new Size(1114, 360);
            dgArchive.TabIndex = 1;
            // 
            // Column8
            // 
            Column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column8.HeaderText = "id";
            Column8.Name = "Column8";
            Column8.Visible = false;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Grade Level";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Strand";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Subject";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Blk #";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.HeaderText = "Teacher";
            Column5.Name = "Column5";
            // 
            // Column9
            // 
            Column9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column9.HeaderText = "Status";
            Column9.Name = "Column9";
            // 
            // Column10
            // 
            Column10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column10.HeaderText = "Date";
            Column10.Name = "Column10";
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column6.HeaderText = "Export";
            Column6.Name = "Column6";
            Column6.Resizable = DataGridViewTriState.True;
            Column6.SortMode = DataGridViewColumnSortMode.Automatic;
            Column6.Text = "";
            // 
            // Column7
            // 
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column7.HeaderText = "Delete";
            Column7.Name = "Column7";
            Column7.Resizable = DataGridViewTriState.True;
            Column7.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // gender
            // 
            gender.BackColor = Color.FromArgb(21, 73, 135);
            gender.ForeColor = SystemColors.Control;
            gender.FormattingEnabled = true;
            gender.Location = new Point(24, 17);
            gender.Name = "gender";
            gender.Size = new Size(135, 29);
            gender.TabIndex = 0;
            gender.Text = "   Grade Level";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 73, 135);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox9);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-21, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1257, 100);
            panel1.TabIndex = 26;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1111, 25);
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
            pictureBox3.Location = new Point(1037, 25);
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
            pictureBox9.Location = new Point(1184, 25);
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
            pictureBox2.Image = Properties.Resources.ion_notifcations;
            pictureBox2.Location = new Point(213, 39);
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
            label1.Location = new Point(48, 39);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 0;
            label1.Text = "Jov M. Felarca";
            // 
            // Archive
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 718);
            Controls.Add(label9);
            Controls.Add(pictureBox6);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "Archive";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Archive";
            FormClosing += Archive_FormClosing;
            Load += Archive_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgArchive).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private PictureBox pictureBox6;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private DataGridView dgArchive;
        private ComboBox gender;
        private Panel panel1;
        private PictureBox pictureBox9;
        private PictureBox pictureBox2;
        private Label label1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewButtonColumn Column6;
        private DataGridViewButtonColumn Column7;
    }
}