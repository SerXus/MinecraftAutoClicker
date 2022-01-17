using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace michiloginistgay
{
    public partial class Form2 : Form
    {

        private int r = 244;
        private int g = 65;
        private int b = 65;

        private int Red;
        private int Green;
        private int Blue;



        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "mouse_event", ExactSpelling = true, SetLastError = true)]
        private static extern bool apimouse_event(int dwFlags, int dX, int dY, int cButtons, int dwExtraInfo);

        public Random rnd = new Random();
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        IntPtr hWnd;

        [DllImportAttribute("user32")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;

        public string HWID { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void leftClick_Tick(object sender, EventArgs e)
        {
            int minval; int maxval;

            minval = 1000 / guna2TrackBar1.Value + guna2TrackBar1.Value * (int)0.2; maxval = 1000 / guna2TrackBar1.Value + guna2TrackBar1.Value * (int)0.5;

            leftClick.Interval = rnd.Next(minval, maxval);

            Process[] processesByName = Process.GetProcessesByName("javaw");


            if (processesByName.Length != 0)
            {
                foreach (Process process in processesByName)
                {
                    hWnd = FindWindow(null, process.MainWindowTitle);
                }
            }

            switch (guna2CustomCheckBox1.Checked)
            {
                case true:
                    if (!hWnd.Equals(IntPtr.Zero))
                    {
                        switch (guna2CustomCheckBox5.Checked)
                        {
                            case true:
                                if (GetAsyncKeyState(Keys.LButton) < 0)
                                {
                                    PostMessage(hWnd, 513U, 0, 0);
                                    PostMessage(hWnd, 514U, 0, 0);
                                    if (rnd.Next(0, 100) <= guna2TrackBar2.Value)
                                    {
                                        PostMessage(hWnd, 516U, 0, 0);
                                        PostMessage(hWnd, 517U, 0, 0);
                                    }
                                }
                                break;
                            case false:
                                if (GetAsyncKeyState(Keys.LButton) < 0)
                                {
                                    PostMessage(hWnd, 513U, 0, 0);
                                    PostMessage(hWnd, 514U, 0, 0);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked)
            {
                guna2HtmlLabel3.Text = "Enabled";
                leftClick.Start();
            }
            else
            {
                guna2HtmlLabel3.Text = "Disabled";
                leftClick.Stop();
            }
        }

        private void guna2CustomCheckBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            guna2HtmlLabel4.Text = "" + guna2TrackBar1.Value.ToString();
        }

        private void guna2CustomCheckBox3_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox3.Checked)
            {
                guna2TrackBar1.Maximum = (50);
                guna2TrackBar1.Minimum = (30);
                guna2TrackBar1.Value = (30);
            }
            else
            {
                guna2TrackBar1.Value = (30);
                guna2TrackBar1.Minimum = (1);
                guna2TrackBar1.Maximum = (20);
            }
        }

        private void BindKey_Down(object sender, KeyEventArgs e)
        {
            if (guna2Button2.Text == "...") // when its listening for a key to be pressed
            {
                if (GetAsyncKeyState(Keys.Escape) < 0)
                    guna2Button2.Text = "none";
                else
                    guna2Button2.Text = e.KeyData.ToString();

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Button2.Text = "...";
        }

        private void bindTimer_Tick(object sender, EventArgs e)
        {
            if (guna2Button2.Text != "none" && guna2Button2.Text != "...")
            {
                KeysConverter Key = new KeysConverter();
                Keys binding = (Keys)Key.ConvertFromString(guna2Button2.Text);
                if (GetAsyncKeyState(binding) != 0)
                    if (guna2CustomCheckBox1.Checked == true)
                        guna2CustomCheckBox1.Checked = false;
                    else
                        guna2CustomCheckBox1.Checked = true;
            }

            if (guna2Button1.Text != "none" && guna2Button1.Text != "...")
            {
                KeysConverter Key = new KeysConverter();
                Keys binding = (Keys)Key.ConvertFromString(guna2Button1.Text);
                if (GetAsyncKeyState(binding) != 0)
                    if (guna2CustomCheckBox9.Checked == true)
                        guna2CustomCheckBox9.Checked = false;
                    else
                        guna2CustomCheckBox9.Checked = true;
            }
        }

        private void guna2TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            guna2HtmlLabel5.Text = "" + guna2TrackBar2.Value.ToString();
        }

        private void rightClick_Tick(object sender, EventArgs e)
        {
            int minval; int maxval;

            minval = 1000 / guna2TrackBar3.Value + guna2TrackBar3.Value * (int)0.2; maxval = 1000 / guna2TrackBar3.Value + guna2TrackBar3.Value * (int)0.5;

            rightClick.Interval = rnd.Next(minval, maxval);

            Process[] processesByName = Process.GetProcessesByName("javaw");

            if (processesByName.Length != 0)
            {
                foreach (Process process in processesByName)
                {
                    hWnd = FindWindow(null, process.MainWindowTitle);
                }
            }

            switch (guna2CustomCheckBox9.Checked)
            {
                case true:
                    if (!hWnd.Equals(IntPtr.Zero))
                    {
                        if (GetAsyncKeyState(Keys.RButton) < 0)
                        {
                            PostMessage(hWnd, 516U, 0, 0);
                            PostMessage(hWnd, 517U, 0, 0);
                        }
                        break;
                    }
                    break;
            }
        }

        private void guna2CustomCheckBox9_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox9.Checked)
            {
                guna2HtmlLabel10.Text = "Enabled";
                rightClick.Start();
            }
            else
            {
                guna2HtmlLabel10.Text = "Disabled";
                rightClick.Stop();
            }
        }

        private void guna2TrackBar3_Scroll(object sender, ScrollEventArgs e)
        {
            guna2HtmlLabel15.Text = "" + guna2TrackBar3.Value.ToString();
        }

        private void BindKey1_Down(object sender, KeyEventArgs e)
        {
            if (guna2Button1.Text == "...") // when its listening for a key to be pressed
            {
                if (GetAsyncKeyState(Keys.Escape) < 0)
                    guna2Button1.Text = "none";
                else
                    guna2Button1.Text = e.KeyData.ToString();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Text = "...";
        }

        private void guna2CustomCheckBox7_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox7.Checked)
            {
                guna2TrackBar3.Maximum = (50);
                guna2TrackBar3.Minimum = (30);
                guna2TrackBar3.Value = (30);
            }
            else
            {
                guna2TrackBar3.Value = (30);
                guna2TrackBar3.Minimum = (1);
                guna2TrackBar3.Maximum = (20);
            }
        }

        private void timerR_Tick(object sender, EventArgs e)
        {
            bool flag = b >= 244;
            if (flag)
            {
                r--;
                guna2TrackBar1.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar2.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar3.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar4.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar5.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar6.ThumbColor = Color.FromArgb(r, g, b);
                guna2Panel1.BackColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox2.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox3.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox4.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox5.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox7.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox9.CheckMarkColor = Color.FromArgb(r, g, b);



                bool flag2 = r <= 65;
                if (flag2)
                {
                    timerR.Stop();
                    timerG.Start();
                }
            }
            bool flag3 = b <= 65;
            if (flag3)
            {
                r++;
                guna2TrackBar1.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar2.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar3.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar4.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar5.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar6.ThumbColor = Color.FromArgb(r, g, b);
                guna2Panel1.BackColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox2.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox3.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox4.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox5.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox7.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox9.CheckMarkColor = Color.FromArgb(r, g, b);
                bool flag4 = r >= 244;
                if (flag4)
                {
                    timerR.Stop();
                    timerG.Start();
                }
            }
        }

        private void timerG_Tick(object sender, EventArgs e)
        {
            bool flag = r <= 65;
            if (flag)
            {
                g++;
                guna2TrackBar1.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar2.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar3.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar4.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar5.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar6.ThumbColor = Color.FromArgb(r, g, b);
                guna2Panel1.BackColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox2.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox3.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox4.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox5.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox7.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox9.CheckMarkColor = Color.FromArgb(r, g, b);
                bool flag2 = g >= 244;
                if (flag2)
                {
                    timerG.Stop();
                    timerB.Start();
                }
            }
            bool flag3 = r >= 244;
            if (flag3)
            {
                g--;
                guna2TrackBar1.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar2.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar3.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar4.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar5.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar6.ThumbColor = Color.FromArgb(r, g, b);
                guna2Panel1.BackColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox2.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox3.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox4.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox5.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox7.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox9.CheckMarkColor = Color.FromArgb(r, g, b);
                bool flag4 = g <= 65;
                if (flag4)
                {
                    timerG.Stop();
                    timerB.Start();
                }
            }
        }

        private void timerB_Tick(object sender, EventArgs e)
        {
            bool flag = g <= 65;
            if (flag)
            {
                b++;
                guna2TrackBar1.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar2.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar3.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar4.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar5.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar6.ThumbColor = Color.FromArgb(r, g, b);
                guna2Panel1.BackColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox2.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox3.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox4.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox5.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox7.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox9.CheckMarkColor = Color.FromArgb(r, g, b);
                bool flag2 = b >= 244;
                if (flag2)
                {
                    timerB.Stop();
                    timerR.Start();
                }
            }
            bool flag3 = g >= 244;
            if (flag3)
            {
                b--;
                guna2TrackBar1.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar2.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar3.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar4.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar5.ThumbColor = Color.FromArgb(r, g, b);
                guna2TrackBar6.ThumbColor = Color.FromArgb(r, g, b);
                guna2Panel1.BackColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox2.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox3.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox4.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox5.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox7.CheckMarkColor = Color.FromArgb(r, g, b);
                guna2CustomCheckBox9.CheckMarkColor = Color.FromArgb(r, g, b);
                bool flag4 = b <= 65;
                if (flag4)
                {
                    timerB.Stop();
                    timerR.Start();
                }
            }
        }

        private void guna2CustomCheckBox4_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox4.Checked)
            {
                guna2TrackBar4.Value = (0);
                guna2TrackBar4.Enabled = (false);
                guna2HtmlLabel8.Text = ("0");
                guna2TrackBar5.Value = (0);
                guna2TrackBar5.Enabled = (false);
                guna2HtmlLabel19.Text = ("0");
                guna2TrackBar6.Value = (0);
                guna2TrackBar6.Enabled = (false);
                guna2HtmlLabel16.Text = ("0");
                


                timerR.Start();
                timerG.Start();
                timerB.Start();
            }
            else
            {
                timerR.Stop();
                timerG.Stop();
                timerB.Stop();
                guna2TrackBar4.Enabled = (true);
                guna2TrackBar5.Enabled = (true);
                guna2TrackBar6.Enabled = (true);
                guna2TrackBar1.ThumbColor = Color.FromArgb(238, 197, 145);
                guna2TrackBar2.ThumbColor = Color.FromArgb(238, 197, 145);
                guna2TrackBar3.ThumbColor = Color.FromArgb(238, 197, 145);
                guna2TrackBar4.ThumbColor = Color.FromArgb(238, 197, 145);
                guna2TrackBar5.ThumbColor = Color.FromArgb(238, 197, 145);
                guna2TrackBar6.ThumbColor = Color.FromArgb(238, 197, 145);
                guna2Panel1.BackColor = Color.FromArgb(238, 197, 145);
                guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(238, 197, 145);
                guna2CustomCheckBox2.CheckMarkColor = Color.FromArgb(238, 197, 145);
                guna2CustomCheckBox3.CheckMarkColor = Color.FromArgb(238, 197, 145);
                guna2CustomCheckBox4.CheckMarkColor = Color.FromArgb(238, 197, 145);
                guna2CustomCheckBox5.CheckMarkColor = Color.FromArgb(238, 197, 145);
                guna2CustomCheckBox7.CheckMarkColor = Color.FromArgb(238, 197, 145);
                guna2CustomCheckBox9.CheckMarkColor = Color.FromArgb(238, 197, 145);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void guna2TrackBar6_Scroll(object sender, ScrollEventArgs e)
        {
            {
                Red = Convert.ToInt32(guna2TrackBar6.Value * 2.55);


                guna2HtmlLabel16.Text = "" + guna2TrackBar6.Value.ToString();
                ApplyColor();
            }
        }

        private void ApplyColor()
        {
            guna2TrackBar1.ThumbColor = Color.FromArgb(Red, Green, Blue);
            guna2TrackBar2.ThumbColor = Color.FromArgb(Red, Green, Blue);
            guna2TrackBar3.ThumbColor = Color.FromArgb(Red, Green, Blue);
            guna2TrackBar4.ThumbColor = Color.FromArgb(Red, Green, Blue);
            guna2TrackBar5.ThumbColor = Color.FromArgb(Red, Green, Blue);
            guna2TrackBar6.ThumbColor = Color.FromArgb(Red, Green, Blue);
            guna2Panel1.BackColor = Color.FromArgb(Red, Green, Blue);
            guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(Red, Green, Blue);
            guna2CustomCheckBox2.CheckMarkColor = Color.FromArgb(Red, Green, Blue);
            guna2CustomCheckBox3.CheckMarkColor = Color.FromArgb(Red, Green, Blue);
            guna2CustomCheckBox4.CheckMarkColor = Color.FromArgb(Red, Green, Blue);
            guna2CustomCheckBox5.CheckMarkColor = Color.FromArgb(Red, Green, Blue);
            guna2CustomCheckBox7.CheckMarkColor = Color.FromArgb(Red, Green, Blue);
            guna2CustomCheckBox9.CheckMarkColor = Color.FromArgb(Red, Green, Blue);
        }

        private void guna2TrackBar4_Scroll(object sender, ScrollEventArgs e)
        {
            {
                Green = Convert.ToInt32(guna2TrackBar4.Value * 2.55);


                guna2HtmlLabel8.Text = "" + guna2TrackBar4.Value.ToString();
                ApplyColor();
            }
        }

        private void guna2TrackBar5_Scroll(object sender, ScrollEventArgs e)
        {
            {
                Blue = Convert.ToInt32(guna2TrackBar5.Value * 2.55);


                guna2HtmlLabel19.Text = "" + guna2TrackBar5.Value.ToString();
                ApplyColor();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CustomCheckBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void guna2CustomCheckBox6_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox6.Checked)
            {
                leftClick.Interval = 6000;
            }
            else
            {
                leftClick.Interval = 100;
            }
        }

        private void showDialog(String message, Color bgColor)
        {
            Form3 dialog = new Form3(message, bgColor);
            dialog.Show();
        }

        private void checker_Tick(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string User = wb.DownloadString("https://pastebin.com/PKsYrpv9");
            string Acc = ("version.01");

            if (User.Contains(Acc))
            {

            }
            else
            {
                MessageBox.Show("Account Blocked!", "aight.cc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;

            WebClient bw = new WebClient();
            string HWIDs = bw.DownloadString("https://pastebin.com/LEjJXNTU");

            if (HWIDs.Contains(GetMachineGuid()))
            {
                
            }
            else
            {
                MessageBox.Show("Error! Not Whitelisted", "aight.cc");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        private static string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException(string.Format("Key not found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(string.Format("Index not found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
