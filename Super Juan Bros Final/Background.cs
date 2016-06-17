using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Super_Juan_Bros_Final
{
    public partial class Background : Form
    {
        public Background()
        {
            InitializeComponent();
        }

        private void Background_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
        }
    }
}
