using System;
using System.Windows.Forms;

namespace OneTouchCheck
{
    public partial class cmbok : Form
    {
        public cmbok(string message, bool isError)
        {
            InitializeComponent();
            label.Text = message;
            error.Visible = isError;
            info.Visible = !isError;
        }

        private Label lblMessage;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cmbok));
            button1 = new Button();
            label = new Label();
            info = new PictureBox();
            error = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)info).BeginInit();
            ((System.ComponentModel.ISupportInitialize)error).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(65, 168);
            button1.Name = "button1";
            button1.Size = new Size(122, 40);
            button1.TabIndex = 1;
            button1.Text = "Okay";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label.BackColor = Color.Transparent;
            label.FlatStyle = FlatStyle.Popup;
            label.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label.ForeColor = Color.White;
            label.Location = new Point(-1, 65);
            label.Name = "label";
            label.Size = new Size(253, 100);
            label.TabIndex = 2;
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // info
            // 
            info.BackColor = Color.Transparent;
            info.Image = Properties.Resources.icons8_information_50;
            info.Location = new Point(100, 12);
            info.Name = "info";
            info.Size = new Size(54, 50);
            info.SizeMode = PictureBoxSizeMode.Zoom;
            info.TabIndex = 3;
            info.TabStop = false;
            // 
            // error
            // 
            error.BackColor = Color.Transparent;
            error.Image = Properties.Resources.computer__2_;
            error.Location = new Point(100, 12);
            error.Name = "error";
            error.Size = new Size(54, 50);
            error.SizeMode = PictureBoxSizeMode.Zoom;
            error.TabIndex = 4;
            error.TabStop = false;
            // 
            // cmbok
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 73, 135);
            BackgroundImage = Properties.Resources.logo1;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(252, 220);
            ControlBox = false;
            Controls.Add(error);
            Controls.Add(info);
            Controls.Add(label);
            Controls.Add(button1);
            DoubleBuffered = true;
            ForeColor = SystemColors.ButtonHighlight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "cmbok";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "CustomMessageBox";
            ((System.ComponentModel.ISupportInitialize)info).EndInit();
            ((System.ComponentModel.ISupportInitialize)error).EndInit();
            ResumeLayout(false);
        }

        // Static method to show the custom message box
        public static void Show(string message, string title, bool isError)
        {
            cmbok messageBox = new cmbok(message, isError);
            messageBox.Text = title;
            messageBox.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
