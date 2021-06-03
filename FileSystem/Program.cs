using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CreateConfig();
            CreateDirectory();
            CreateFile();
            MoveDataIntoArchive();
            DeleteTemp();
        }

        // Folder paths
        private enum FolderName { Workspace, Archive, Temp, SavedData }
        private static readonly string _ConfigFile = "Config.txt";
        private static readonly Dictionary<FolderName, string> _Folders = new()
        {
            {FolderName.Workspace, @"Workspace/"},
            {FolderName.Archive, @"Workspace/Archive/"},
            {FolderName.Temp, @"Workspace/Temp/"},
            {FolderName.SavedData, @"Workspace/Temp/Data/"},
        };

        /// Create directories the paths of which are specified in _Folders
        private static void CreateDirectory()
        {
            var total = _Folders.Count;
            for (var i = 0; i < total; i++)
            {
                var dirName = _Folders[(FolderName) i];

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
            var tempDir = _Folders[FolderName.Temp];
            if (Directory.Exists(tempDir)) // Determine whether the folder exists
                Directory.Delete(tempDir, true); // Delete recursively if it does
        }

        /// Move the SavedData directory into archive
        private static void MoveDataIntoArchive()
        {
            var dataDir = _Folders[FolderName.SavedData];
            if (Directory.Exists(dataDir))
            {
                var archiveFolder = $"{_Folders[FolderName.Archive]}SavedData_" +
                                    $"{DateTime.Now:yyyyMMddHHmmss}";
                Directory.Move(dataDir, archiveFolder);
            }
        }

        /// Create a new file in SavedData, and write some string to it
        private static void CreateFile()
        {
            var path = _Folders[FolderName.SavedData] + "TestFile.txt";

            File.WriteAllText(path, "Hello world!");

            var fileInfo = new FileInfo(path);
            var name = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            var extension = fileInfo.Extension;
            var size = fileInfo.Length;

            Console.WriteLine($"Created the file '{name}' with the extension of " +
                              $"'{extension}' and the size of {size} bytes.");
        }

        // Create a config file that contains all folder names, one per line
        private static void CreateConfig()
        {
            if (!File.Exists(_ConfigFile))
                File.WriteAllLines(_ConfigFile, _Folders.Values.ToArray());
        }
    }
}