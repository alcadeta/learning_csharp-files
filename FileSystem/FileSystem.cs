using System.IO;

namespace FileSystem
{
    public class FileSystem
    {
        public bool DirectoryExists(string path) =>
            Directory.Exists(path);

        public void CreateDirectory(string path) =>
            Directory.CreateDirectory(path);

        public void DeleteDirectory(string path, bool recursive = true) =>
            Directory.Delete(path, recursive);

        public void MoveDirectory(string sourcePath, string destinationPath) =>
            Directory.Move(sourcePath, destinationPath);
    }
}