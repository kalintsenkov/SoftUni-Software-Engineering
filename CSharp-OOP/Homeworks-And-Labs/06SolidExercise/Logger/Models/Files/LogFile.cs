namespace Logger.Models.Files
{
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using Contracts;
    using IOManagment;

    public class LogFile : IFile
    {
        private const string DateFormat = "M/dd/yyyy h:mm:ss tt";

        private const string CurrentDirectory = "\\logs\\";
        private const string CurrentFile = "log.txt";

        private readonly string currentPath;
        private readonly IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(CurrentDirectory, CurrentFile);
            this.currentPath = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExist();
            this.Path = this.currentPath + CurrentDirectory + CurrentFile;
        }

        public string Path { get; }

        public ulong Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            var format = layout.Format;

            var dateTime = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            return string.Format(
                format,
                dateTime.ToString(
                    DateFormat, 
                    CultureInfo.InvariantCulture),
                level.ToString(),
                message);
        }

        private ulong GetFileSize()
        {
            var text = File.ReadAllText(this.Path);

            var size = (ulong)text
                .ToCharArray()
                .Where(x => char.IsLetter(x))
                .Sum(x => x);

            return size;
        }
    }
}
