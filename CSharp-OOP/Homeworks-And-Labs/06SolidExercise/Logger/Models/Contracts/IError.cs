namespace Logger.Models.Contracts
{
    using System;

    using Enumerations;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
