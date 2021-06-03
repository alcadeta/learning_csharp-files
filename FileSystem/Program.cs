using System;
using System.IO;

namespace FileSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CreateDirectory();
            DeleteTemp();
        }

        private static readonly string[] _Folders =
        {
            @"Workspace/",
            @"Workspace/Archive/",
            @"Workspace/Temp/",
            @"Workspace/Temp/Data"
        };


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

        private static void DeleteTemp()
        {
            var tempDir = _Folders[2];
            if (Directory.Exists(tempDir)) // Determine whether the folder exists
                Directory.Delete(tempDir, true); // Delete if it does
        }
    }
}