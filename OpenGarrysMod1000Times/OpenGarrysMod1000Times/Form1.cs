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
        public static int curStatus = 0;

        public Form1()
        {
            InitializeComponent();
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
                const string fileDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\GarrysMod\\hl2.exe";
                Process.Start(fileDir);
                Thread.Sleep(1000);
                procKilled = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/JerimiahOfficial");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCHi47xiIYDponERT6IXLRew");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            curStatus += 1;
        }

        private void Status_Tick(object sender, EventArgs e)
        {
            switch (curStatus)
            {
                case 0:
                    startButton.ImageIndex = 0;
                    Checker.Stop();
                    break;
                case 1:
                    startButton.ImageIndex = 1;
                    Checker.Start();
                    break;
                case 2:
                    curStatus = 0;
                    break;
            }
        }
    }
}
