namespace Logger.Models.Errors
{
    using System;

    using Contracts;
    using Enumerations;

    public class Error : IError
    {
        public Error(
            DateTime dateTime, 
            string message,
            Level level = Level.INFO)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
