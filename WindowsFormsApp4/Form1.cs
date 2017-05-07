using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Diagnostics;


namespace WindowsFormsApp4
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Setting Default ComboBox Setting
            metroComboBox1.SelectedIndex = 1;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            // Hide/show panel when tile is selected
            metroPanel1.Visible = Visible;
        }

        private void metroButton1_Click(object sender, EventArgs e)

        {
            if (string.IsNullOrEmpty(metroTextBox1.Text))
            {
                // Checking for IP Addess in entered
                metroTextBox1.AppendText("Enter IP Address");
                metroTextBox1.BackColor = Color.Red;

            }
            else
            {
                // Clearing textbox before next ping
                metroTextBox2.Clear();
                // If IP text bos is empty notify
                metroTextBox1.BackColor = default(Color);

                // Get Start Ping Proess
                ProcessStartInfo getPing = new ProcessStartInfo("cmd");
                getPing.UseShellExecute = false;
                getPing.RedirectStandardOutput = true;
                getPing.CreateNoWindow = true;
                getPing.RedirectStandardInput = true;
                var proc = Process.Start(getPing);
                proc.StandardInput.WriteLine($"ping " + metroTextBox1.Text);
                proc.StandardInput.WriteLine("exit");

                // Return console output to string and enter into textbox 
                string s = proc.StandardOutput.ReadToEnd();
                metroTextBox2.Text = s;
            }


        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
                // hide/show panel

                metroPanel1.Visible = !Visible;
        }


        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Setting theme from comboBox
            switch (metroComboBox1.SelectedIndex)
            {
                case 0:
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                    metroPanel1.BackColor = Color.Black;
                    metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
                    metroLabel1.BackColor = Color.Black;  
                break;

                case 1:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                    metroPanel1.BackColor = Color.White;
                    metroLabel1.BackColor = Color.White;
                    break;

            }
            
        }

    }
    } 
