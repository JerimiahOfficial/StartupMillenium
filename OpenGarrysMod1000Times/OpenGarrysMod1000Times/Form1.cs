using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Startup_Millenium
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Button_CheckedChanged(object sender, EventArgs e)
        {
            if (start_Button.Checked == true)
            {
                timer1.Start();
                start_Button.Text = "Stop";
                start_Button.BackColor = Color.FromArgb(255, 0, 0);

            }
            else if(start_Button.Checked == false)
            {
                timer1.Stop();
                start_Button.Text = "Start";
                start_Button.BackColor = Color.FromArgb(0, 127, 0);
                foreach (Process proc in Process.GetProcessesByName("hl2"))
                {
                    proc.Kill();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int procKilled = 1;
            foreach (Process proc in Process.GetProcessesByName("hl2"))
            {
                proc.Kill();
                procKilled = 1;
            }

            if (procKilled == 1)
            {
                const string fileDir = "C:\\Program Files\\Steam\\steamapps\\common\\GarrysMod\\hl2.exe";
                Process.Start(fileDir);
                Thread.Sleep(1000);
                procKilled = 0;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/JerimiahOfficial");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCHi47xiIYDponERT6IXLRew");
        }
    }
}
