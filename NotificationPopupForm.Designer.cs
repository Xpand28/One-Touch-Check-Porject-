namespace OneTouchCheck
{
    partial class NotificationPopupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvNotifications;
        

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
        /// 


        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvNotifications = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).BeginInit();
            SuspendLayout();
            // 
            // dgvNotifications
            // 
            dgvNotifications.ColumnHeadersVisible = true;
            dgvNotifications.EnableHeadersVisualStyles = false;
            dgvNotifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotifications.Location = new Point(10, 14);
            dgvNotifications.Margin = new Padding(3, 4, 3, 4);
            dgvNotifications.Name = "dgvNotifications";
            dgvNotifications.RowHeadersVisible = false; 
            dgvNotifications.BackgroundColor = Color.FromArgb(223, 239, 255); 
            dgvNotifications.DefaultCellStyle.BackColor = Color.FromArgb(223, 239, 255); 
            dgvNotifications.DefaultCellStyle.ForeColor = Color.Black; 
            dgvNotifications.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue; 
            dgvNotifications.Size = new Size(603, 292);
            dgvNotifications.TabIndex = 0;
            // 
            // NotificationPopupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 239, 255);
            ClientSize = new Size(631, 321);
            Controls.Add(dgvNotifications);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "NotificationPopupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Notifications";
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}