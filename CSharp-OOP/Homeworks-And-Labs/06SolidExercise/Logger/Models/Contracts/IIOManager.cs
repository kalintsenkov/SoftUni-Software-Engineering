namespace Logger.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        void EnsureDirectoryAndFileExist();

        string GetCurrentPath();
    }
}
