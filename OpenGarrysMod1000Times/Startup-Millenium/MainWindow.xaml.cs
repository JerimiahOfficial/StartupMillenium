using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Startup_Millenium {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private static string?  Dir;
        private static bool     Status;
        private Thread          thread = new(SM);

        public MainWindow() {
            InitializeComponent();
        }

        private static string? GetInstallPath() {
            var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
            var registryPath = key.View == RegistryView.Registry64 ? @"SOFTWARE\Wow6432Node\Valve\Steam" : @"SOFTWARE\Valve\Steam";
            var registryValue = key.OpenSubKey(registryPath)?.GetValue("InstallPath");

            return registryValue?.ToString();
        }

        private static IEnumerable<string> GetInstallLibrary() {
            var steamPath = GetInstallPath();

            if (steamPath is null) {
                yield break;
            }

            var filePath = $@"{steamPath}\steamapps\libraryfolders.vdf";
            var paths = File.ReadAllLines(filePath)
                .Where(s => s.Contains("path"))
                .Select(s => s.Split('\"')[3])
                .Select(Path.GetFullPath);

            foreach (var path in paths) {
                yield return path;
            }
        }

        private static void SM() {
            Debug.WriteLine("Running");

            GetInstallLibrary().ToList().ForEach(p => {
                if (File.Exists(p + @"\steamapps\common\GarrysMod\hl2.exe"))
                    Dir = p + @"\steamapps\common\GarrysMod\hl2.exe";
            });

            if (Dir is null) {
                Debug.WriteLine("Not Found");
                return;
            }

            while (true) {
                if (!Status)
                    break;

                if (Process.GetProcessesByName("gmod").Length <= 0) {
                    using Process process = Process.Start(Dir);
                }

                Thread.Sleep(10000);

                foreach (Process proc in Process.GetProcessesByName("gmod"))
                    proc.Kill();
            }
        }

        private void SM_Close(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void SM_Check(object s, RoutedEventArgs e) {
            Status = true;

            thread.Start();
            Debug.WriteLine("Thread opened.");
        }

        private void SM_Uncheck(object sender, RoutedEventArgs e) {
            Status = false;

            foreach (Process proc in Process.GetProcessesByName("gmod"))
                proc.Kill();
            Debug.WriteLine("Killing leftover processes.");

            thread.Join();
            Debug.WriteLine("Thread closed.");
        }
    }
}
