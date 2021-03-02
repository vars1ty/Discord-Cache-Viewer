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
            Console.WriteLine("Please enter the Discord cache path down below:");
            // Begin the processing after a new console line has been received from the user
            begin_processing(Console.ReadLine());
            Console.WriteLine("Processed all files, closing in 10 seconds");
            // Wait 10,000ms (10s)
            await Task.Delay(10000);
            // Collect the garbage and close
            GC.Collect();
            Environment.Exit(0);
        }

        /// <summary>
        /// Begin checking and processing files.
        /// </summary>
        /// <param name="path">The cache folder path.</param>
        private static void begin_processing(string path)
        {
            // Get all file paths
            var files = Directory.GetFiles(path);
            // Constants for more efficient memory management
            const string header = "PNG", extension = ".png";
            const ushort index = 0;
            for (short i = 0; i < files.Length; i++) // UShort has a greater max length than a signed Short.
            {
                // Cache the file path
                var filePath = files[i];
                // We only have to read the first line and check if it has the PNG header.
                // This also saves some processing time, as we don't have to check the entire file for "PNG", and it reduces false positives.
                if (File.ReadAllLines(filePath)[index].Contains(header))
                    Console.WriteLine($"{filePath} - Added .png extension");
                // "Move" => "Rename", alright then Microsoft.
                File.Move(filePath, filePath + extension);
            }
        }
    }
}
