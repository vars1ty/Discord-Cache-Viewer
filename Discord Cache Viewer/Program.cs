using System;
using System.IO;
using System.Threading.Tasks;

namespace Discord_Cache_Viewer
{
    internal struct Program
    {
        /// <summary>
        /// Startup function.
        /// </summary>
        public static async Task Main()
        {
            Console.WriteLine("Please enter the Discord cache path");
            begin_processing(Console.ReadLine());
            Console.WriteLine("Processed all files, closing in 10 seconds");
            await Task.Delay(10000);
            GC.Collect();
            Environment.Exit(0);
        }

        /// <summary>
        /// Begin checking and processing files.
        /// </summary>
        /// <param name="path">The cache folder path.</param>
        private static void begin_processing(string path)
        {
            var files = Directory.GetFiles(path);
            const string header = "PNG", extension = ".png";
            const ushort index = 0;
            for (short i = 0; i < files.Length; i++) // UShort has a greater max length than a signed Short.
            {
                var filePath = files[i];
                // We only have to read the first line and check if it has the PNG header.
                if (File.ReadAllLines(filePath)[index].Contains(header))
                    Console.WriteLine($"{filePath} - Added .png extension");
                File.Move(filePath, filePath + extension);
            }
        }
    }
}