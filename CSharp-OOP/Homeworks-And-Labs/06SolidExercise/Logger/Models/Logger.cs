namespace Logger.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders 
            => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (var appender in this.Appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Logger info");

            foreach (var appender in this.Appenders)
            {
                result.AppendLine($"{appender}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
