using System;
using System.Collections.Generic;
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

        // Folders
        private enum FolderName { Workspace, Archive, Temp, Data }
        private static readonly Dictionary<FolderName, string> _Folders = new()
        {
            {FolderName.Workspace, @"Workspace/"},
            {FolderName.Archive, @"Workspace/Archive/"},
            {FolderName.Temp, @"Workspace/Temp/"},
            {FolderName.Data, @"Workspace/Temp/Data/"},
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

        /// Move the data directory into archive
        private static void MoveDataIntoArchive()
        {
            var dataDir = _Folders[FolderName.Data];
            if (Directory.Exists(dataDir))
            {
                var archiveFolder =
                    $"{_Folders[FolderName.Archive]}Data_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                Directory.Move(dataDir, archiveFolder);
            }
        }
    }
}