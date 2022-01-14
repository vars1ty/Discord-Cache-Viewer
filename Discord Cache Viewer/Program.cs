using System;
using System.IO;
using System.Threading.Tasks;

namespace Discord_Cache_Viewer
{
    internal struct Program
    {
        #region Variables
        /// <summary>
        /// Time to wait (ms) before the program closes after a successful conversion.
        /// </summary>
        private const short kill = 10000;
        #endregion
        /// <summary>
        /// Startup function.
        /// </summary>
        public static async Task Main()
        {
            Console.WriteLine("Please enter the Discord cache path down below:");
            // Begin the processing after a new console line has been received from the user
            begin_processing(Console.ReadLine());
            Console.WriteLine("Processed all files, closing in 10 seconds");
            // Wait a few seconds before closing
            await Task.Delay(kill);
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
            for (int i = 0; i < files.Length; i++)
            {
                // Cache the file path
                var filePath = files[i];
                // We only have to read the first line and check if it has the PNG header.
                // This also saves some processing time, as we don't have to check the entire file for "PNG", and it reduces false positives.
                if (File.ReadAllLines(filePath)[index].Contains(header)) {
                    Console.WriteLine($"{filePath} - Added {extension} extension");
                    // "Move" => "Rename", alright then Microsoft.
                    File.Move(filePath, filePath + extension);
                }
            }
        }
    }
}
