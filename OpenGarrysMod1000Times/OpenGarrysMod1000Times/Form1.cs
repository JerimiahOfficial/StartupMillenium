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
        public static int procKilled;
        public static string dir = "";

        public Form1() {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            
            foreach (Process proc in Process.GetProcessesByName("hl2")) {
                proc.Kill();
                procKilled = 1;
            }

            if (procKilled == 1) {
                if (dir.Length > 0) {
                    Process.Start(dir);
                    Thread.Sleep(1000);
                    procKilled = 0;
                }
            }
        }

        private void dirButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog gmoddir = new OpenFileDialog();
            gmoddir.ShowDialog();
            dir = gmoddir.FileName;
        }

        private void startButton_Click(object sender, EventArgs e) {
            curStatus += 1;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Status_Tick(object sender, EventArgs e) {
            switch (curStatus) {
                case 0:
                    startButton.Text = "Start";
                    startButton.BackColor = Color.Green;
                    Checker.Stop();
                    break;
                case 1:
                    startButton.Text = "Stop";
                    startButton.BackColor = Color.Red;
                    Checker.Start();
                    break;
                case 2:
                    curStatus = 0;
                    break;
            }
        }
    }
}
