using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Startup_Millenium
{
    public partial class Sm : Form
    {
        public static bool CurStatus;
        public static bool ProcKilled;
        public static string Dir;

        public Sm()
        {
            InitializeComponent();
            startButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            closeButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (Dir == null || Dir.Length <= 0)
            {
                MessageBox.Show(@"Startup Millenium couldn't find your Garrysmod directory.", @"Missing directory!", MessageBoxButtons.OK);
                return;
            }

            // Change status inside switch.
            CurStatus = !CurStatus;

            switch (CurStatus)
            {
                case false: 
                    // If program isn't running, set button back to Start.
                    startButton.Text = @"Start";
                    startButton.BackColor = Color.Green;
                    break;

                case true: 
                    // If program is running, set button to Stop.
                    startButton.Text = @"Stop";
                    startButton.BackColor = Color.Red;
                    // Start timer and process.
                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Exit application when clicked.
            Application.Exit();
        }

        private void Checker_Tick(object sender, EventArgs e)
        {
            var processes = Process.GetProcesses();

            if (CurStatus)
            {
                switch (ProcKilled)
                {
                    case false:
                        // Kills the process.
                        try
                        {
                            foreach (var proc in processes)
                            {
                                switch (proc.ProcessName)
                                {
                                    case "hl2":
                                        proc.Kill();
                                        break;

                                    case "gmod":
                                        proc.Kill();
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        ProcKilled = !ProcKilled;
                        break;

                    case true:
                        Process.Start(Dir);
                        ProcKilled = !ProcKilled;
                        break;
                    
                }
            }
        }

        private void SM_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Try to close all processes named hl2 when form closed.
            try
            {
                foreach (var proc in Process.GetProcessesByName("hl2"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Sm_Load(object sender, EventArgs e)
        {
            var gmod = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + 
                       "\\Steam\\steamapps\\common\\GarrysMod\\hl2.exe";
            var allDrives = DriveInfo.GetDrives();

            if (File.Exists(gmod))
            {
                Dir = gmod;
            }
            else
            {
                foreach (var d in allDrives)
                {
                    if (d.DriveType == DriveType.Fixed)
                    {
                        var newdir = d.Name + gmod.Substring(3);

                        if (File.Exists(newdir))
                        {
                            Dir = newdir;
                        }
                    }
                }
            }
            ProcKilled = true;
        }
    }
}