using System;
using System.IO;

namespace FileSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CreateDirectory();
            MoveDataIntoArchive();
            DeleteTemp();
        }

        private static readonly string[] _Folders =
        {
            @"Workspace/",
            @"Workspace/Archive/",
            @"Workspace/Temp/",
            @"Workspace/Temp/Data/"
        };

        /// Create directories the paths of which are specified in _Folders
        private static void CreateDirectory()
        {
            var total = _Folders.Length;
            for (var i = 0; i < total; i++)
            {
                var dirName = _Folders[i];

                if (Directory.Exists(dirName))
                {
                    Console.WriteLine($"Directory '{dirName}' already exists.");
                }
                else
                {
                    Directory.CreateDirectory(dirName);
                    Console.WriteLine($"Directory '{dirName}' is created.");
                }
            }
        }

        /// Delete the `Workspace/Temp` folder recursively
        private static void DeleteTemp()
        {
            var tempDir = _Folders[2];
            if (Directory.Exists(tempDir)) // Determine whether the folder exists
                Directory.Delete(tempDir, true); // Delete recursively if it does
        }

        /// Move the data directory into archive
        private static void MoveDataIntoArchive()
        {
            var dataDir = _Folders[3];
            if (Directory.Exists(dataDir))
            {
                var archiveFolder = $"{_Folders[1]}Data_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                Directory.Move(dataDir, archiveFolder);
            }
        }
    }
}