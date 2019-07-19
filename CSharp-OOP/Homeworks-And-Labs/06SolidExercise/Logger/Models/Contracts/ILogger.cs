namespace Logger.Models.Contracts
{
    using System.Collections.Generic;

    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
