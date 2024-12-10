using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneTouchCheck
{
    public partial class cmbyesno : Form
    {
        public bool Result { get; private set; }
        public cmbyesno(string message)
        {
            InitializeComponent();
            label.Text = message;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(cmbyesno));
            button1 = new Button();
            button2 = new Button();
            label = new Label();
            pictureBox2 = new PictureBox();
            ((ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(65, 98);
            button1.Name = "button1";
            button1.Size = new Size(75, 30);
            button1.TabIndex = 0;
            button1.Text = "Yes";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(198, 98);
            button2.Name = "button2";
            button2.Size = new Size(75, 30);
            button2.TabIndex = 1;
            button2.Text = "No";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label.BackColor = Color.Transparent;
            label.FlatStyle = FlatStyle.Popup;
            label.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label.ForeColor = Color.White;
            label.Location = new Point(75, 9);
            label.Name = "label";
            label.Size = new Size(253, 86);
            label.TabIndex = 3;
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.computer__1_;
            pictureBox2.Location = new Point(15, 26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(54, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // cmbyesno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 73, 135);
            BackgroundImage = Properties.Resources.logo1;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(340, 146);
            ControlBox = false;
            Controls.Add(pictureBox2);
            Controls.Add(label);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "cmbyesno";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "cmbyesno";
            ((ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        public static bool Show(string message, string title)
        {
            cmbyesno messageBox = new cmbyesno(message);
            messageBox.Text = title;
            messageBox.ShowDialog();
            return messageBox.Result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }

    }
}