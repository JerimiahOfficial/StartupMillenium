using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Startup_Millenium {

    public partial class SM : Form {
        private Thread thread = new Thread(Open);
        private static bool CurStatus = false;
        private static string Dir;

        private static string GetInstallPath() {
            var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);

            var registryPath = key.View == RegistryView.Registry64
                ? @"SOFTWARE\Wow6432Node\Valve\Steam"
                : @"SOFTWARE\Valve\Steam";

            var registryValue = key.OpenSubKey(registryPath)?.GetValue("InstallPath");

            return registryValue?.ToString();
        }

        private static IEnumerable<string> GetInstallLibrary() {
            var steamPath = GetInstallPath();

            if (steamPath is null) {
                yield break;
            }

            var filePath = $@"{steamPath}\steamapps\libraryfolders.vdf";

            var lines = File.ReadAllLines(filePath);

            var paths = File.ReadAllLines(filePath)
                .Where(s => s.Contains("path"))
                .Select(s => s.Split('\"')[3])
                .Select(Path.GetFullPath);

            foreach (var path in paths) {
                yield return path;
            }
        }

        public SM() {
            InitializeComponent();

            startButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            closeButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            thread.Start();
            thread.Suspend();
        }

        private static void Open() {
            if (Dir != null) {
                while (CurStatus) {
                    Process proc = new Process();
                    proc.StartInfo.FileName = Dir;
                    proc.StartInfo.Arguments = "-windowed -w 200 -h 100";
                    proc.Start();

                    Thread.Sleep(10000);

                    foreach (Process p in Process.GetProcessesByName("gmod"))
                        p.Kill();
                }
            }
        }

        private void ButtonHandler(object s, EventArgs e) {
            Button b = (Button)s;

            switch (b.Name) {
                case "startButton":
                    CurStatus = !CurStatus;

                    startButton.Text = CurStatus ? "Stop" : "Start";
                    startButton.BackColor = CurStatus ? Color.Red : Color.Green;

                    GetInstallLibrary().ToList().ForEach(p => {
                        if (File.Exists(p + @"\steamapps\common\GarrysMod\hl2.exe"))
                            Dir = p + @"\steamapps\common\GarrysMod\hl2.exe";
                    });

                    if (CurStatus)
                        thread.Resume();
                    else
                        thread.Suspend();
                    break;

                case "closeButton":
                    Application.Exit();
                    break;

                default:
                    break;
            }
        }

        private void SM_FormClosed(object sender, FormClosedEventArgs e) {
            if (Process.GetProcessesByName("gmod") != null)
                foreach (Process p in Process.GetProcessesByName("gmod"))
                    p.Kill();

            thread.Resume();
            thread.Abort(true);
        }
    }
}