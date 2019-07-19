namespace Logger.Models.IOManagment
{
    using System.IO;

    using Contracts;

    public class IOManager : IIOManager
    {
        private readonly string currentPath;
        private readonly string currentDirectory;
        private readonly string currentFile;

        public IOManager(string currentDirectory, string currentFile)
            : this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        private IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        public string CurrentDirectoryPath 
            => this.currentPath + this.currentDirectory;

        public string CurrentFilePath
            => this.CurrentDirectoryPath + this.currentFile;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentPath() 
            => Directory.GetCurrentDirectory();
    }
}
