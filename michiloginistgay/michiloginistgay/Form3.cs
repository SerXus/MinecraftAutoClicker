using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace michiloginistgay
{
    public partial class Form3 : Form
    {
        public Form3(String message, Color bgColor)
        {
            InitializeComponent();

            this.BackColor = bgColor;
            guna2HtmlLabel1.Text = message;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Top = 20;
            Left = Screen.PrimaryScreen.Bounds.Width - Width - 20;
            timerClose.Start();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
