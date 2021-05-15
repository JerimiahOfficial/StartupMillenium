using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_Millenium
{
    class Filepaths
    {
        public static readonly string Gamepath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        public List<string> Paths { get; }

        public Filepaths()
        {
            Paths = Directory.EnumerateFiles(Gamepath, "*hl2.exe*", SearchOption.AllDirectories).ToList();
        }
    }
}
