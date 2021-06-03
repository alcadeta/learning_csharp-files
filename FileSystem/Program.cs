using System;
using System.IO;
using System.Collections.Generic;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDirectory();
            Console.Read();
        }

        private static void CreateDirectory()
        {
            var folders = new []
            {
                @"Workspace/",
                @"Workspace/Archive/",
                @"Workspace/Temp/"
            };

            var total = folders.Length;
            for (var i = 0; i < total; i++)
            {
                var dirName = folders[i];

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
    }
}