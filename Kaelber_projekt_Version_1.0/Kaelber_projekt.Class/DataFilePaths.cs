using System;
using System.IO;

namespace Kaelber_projekt.Class
{
    public static class DataFilePaths
    {
        private static readonly string BaseDirectory = AppContext.BaseDirectory;

        public static string KaelberFile => Path.Combine(BaseDirectory, "Kaelber.txt");
        public static string AlleKaelberFile => Path.Combine(BaseDirectory, "AlleKaelber.txt");
        public static string BoxesFile => Path.Combine(BaseDirectory, "Boxes.txt");
    }
}
