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
    public partial class SM : Form
    {
        public static bool      curStatus   = false;
        public static bool      procKilled  = false;
        public static string    dir         = "";

        public SM() {
            InitializeComponent();
        }

        private void dirButton_Click(object sender, EventArgs e) {
            // Create OFD.
            OpenFileDialog gmoddir = new OpenFileDialog();

            // Show OFD.
            gmoddir.ShowDialog();

            // Set directory to the file name.
            dir = gmoddir.FileName;
        }

        private void startButton_Click(object sender, EventArgs e) {
            if (dir.Length <= 0) {
                MessageBox.Show("You must use the garrysmod directory button to set a directory.", "Missing directory!", MessageBoxButtons.OK);
                return;
            }

            // Change status inside switch.
            curStatus = !curStatus;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            // Exit application when clicked.
            Application.Exit();
        }

        private void Status_Tick(object sender, EventArgs e) {
            switch (curStatus) {
                case false: // If program isn't running, set button back to Start.
                    startButton.Text = "Start";
                    startButton.BackColor = Color.Green;
                    Checker.Stop();
                    break;

                case true: // If program is running, set button to Stop.
                    startButton.Text = "Stop";
                    startButton.BackColor = Color.Red;
                    Checker.Start();
                    break;
            }
        }

        private void Checker_Tick(object sender, EventArgs e) {
            // If the process was killed then start garrysmod.
            if (!procKilled) {
                Process.Start(dir);
                procKilled = !procKilled;
            }

            // Close hl2.exe everytime there is and instance.
            if (procKilled) {
                try {
                    foreach (Process proc in Process.GetProcessesByName("hl2")) {
                        proc.Kill();
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SM_FormClosed(object sender, FormClosedEventArgs e) {
            // Try to close all processes named hl2 when form closed.
            try {
                foreach (Process proc in Process.GetProcessesByName("hl2")) {
                    proc.Kill();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}