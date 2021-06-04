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
            ReadConfig();
            CreateDirectory();
            CreateFile();
            MoveDataIntoArchive();
            DeleteTemp();
        }

        /// Config path
        private const string CONFIG_FILE = "Config.txt";

        // Folder paths
        private enum FolderName { Workspace, Archive, Temp, SavedData }
        private static string[] _folders =
        {
            @"Workspace",
            @"Workspace/Archive",
            @"Workspace/Temp",
            @"Workspace/Temp/SavedData"
        };

        /// Create directories the paths of which are specified in _Folders
        private static void CreateDirectory()
        {
            var total = _folders.Length;
            for (var i = 0; i < total; i++)
            {
                var dirName = _folders[i];

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
            var tempDir = _folders[(int) FolderName.Temp];
            if (Directory.Exists(tempDir)) // Determine whether the folder exists
                Directory.Delete(tempDir, true); // Delete recursively if it does
        }

        /// Move the SavedData directory into archive
        private static void MoveDataIntoArchive()
        {
            var dataDir = _folders[(int) FolderName.SavedData];
            if (Directory.Exists(dataDir))
                Directory.Move(dataDir, _folders[(int) FolderName.Archive] +
                                        $"/{Path.GetFileName(dataDir)}" +
                                        $"_{DateTime.Now:yyyyMMddHHmmss}");
        }

        /// Create a new file in SavedData, and write some string to it
        private static void CreateFile()
        {
            var path = $"{_folders[(int) FolderName.SavedData]}/TestFile.txt";

            File.WriteAllText(path, "Hello world!");

            var fileInfo = new FileInfo(path);
            var name = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            var extension = fileInfo.Extension;
            var size = fileInfo.Length;

            Console.WriteLine($"Created the file '{name}' with the extension of " +
                              $"'{extension}' and the size of {size} bytes.");
        }

        /// Create a config file that contains all folder names, one per line
        private static void CreateConfig()
        {
            if (!File.Exists(CONFIG_FILE))
                File.WriteAllLines(CONFIG_FILE, _folders);
        }

        private static void ReadConfig()
        {
            var lines = File.ReadAllLines(CONFIG_FILE);
            var total = lines.Length;

            // Account for there being more or less lines in the config than
            // there are elements in the folders array.
            Array.Resize(ref _folders, total);

            for (var i = 0; i < total; i++)
            {
                var path = lines[i];
                Console.WriteLine($"Setting path — {path}");
                _folders[i] = path;
            }
        }
    }
}