using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;

namespace michiloginistgay
{
    public partial class Form1 : Form
    {
        private string HWID;
        private DialogResult result;
        public Form1()
        {
            InitializeComponent();
        }

        public DiscordRpcClient client;
        bool Initalized = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            Initalized = true;
            client = new DiscordRpcClient($"854427161577521204"); // Client ID
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.Initialize();
            {
                client.SetPresence(new RichPresence()
                {
                    Details = $"awdopiawojidjioapw",  // First line
                    State = $"clicking in Minecraft..",  // Second line
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = $"ccaight",  // Image Name (large)
                        LargeImageText = "aight clicker", //Image Text
                        SmallImageKey = $"ccaight", // Image Name (Small)
                    }
                });
            }
            {
                string webhook = "";

                WebRequest wr = (HttpWebRequest.Create(webhook));

                wr.ContentType = "application/json";
                wr.Method = "POST";

                using (var sw = new StreamWriter(wr.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        username = "Security",
                        embeds = new[]
                        {
                        new
                        {
                            description = "```"
                            + "UserName: "
                            + Environment.UserName
                            + Environment.NewLine
                            + "HWID: "
                            + GetMachineGuid()
                            + Environment.NewLine
                            + "Machinename: "
                            + Environment.MachineName
                            + Environment.NewLine
                            + "Version: "
                            + Environment.Version
                            + Environment.NewLine
                            + "BitProcess: "
                            + Environment.Is64BitProcess
                            + Environment.NewLine
                            + "OperatingSystem: "
                            + Environment.Is64BitOperatingSystem
                            + Environment.NewLine
                            + "OSVersion: "
                            + Environment.OSVersion
                            + "```",
                            title = "Security",
                            color = "8464385"
                        }
                    }
                    });
                    sw.Write(json);
                }
                var response = (HttpWebResponse)wr.GetResponse();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string User = wb.DownloadString("");
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
            string HWIDs = bw.DownloadString("");

            if (HWIDs.Contains(GetMachineGuid()))
            {
                Form2 frm = new Form2();
                this.Hide();
                frm.Show();
                showDialog("Success", Color.FromArgb(0, 150, 10));
            }
            else
            {
                showDialog("Error", Color.FromArgb(150, 10, 0));
            }
        }

        private void showDialog(String message, Color bgColor)
        {
            Form3 dialog = new Form3(message, bgColor);
            dialog.Show();
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show(GetMachineGuid() + "\n             [Copied to Clipboard]", "Get HWID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(GetMachineGuid());
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
