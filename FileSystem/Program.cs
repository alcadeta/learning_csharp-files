using System;
using System.IO;

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
            var dirName = "TestFolder";

            if (Directory.Exists(dirName))
                Console.WriteLine($"Directory '{dirName}' already exists.");
            else
            {
                Directory.CreateDirectory(dirName);
                Console.WriteLine($"Directory '{dirName}' is created.");
            }
        }
    }
}