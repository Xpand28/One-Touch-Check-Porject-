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
    public partial class NotificationPopupForm : Form
    {
        public NotificationPopupForm()
        {
            InitializeComponent();
        }

        // Method to load notifications into the DataGridView
        public void LoadNotifications(DataTable notifications)
        {
            dgvNotifications.DataSource = notifications; // Assign DataTable as the data source
        }
    }
}
