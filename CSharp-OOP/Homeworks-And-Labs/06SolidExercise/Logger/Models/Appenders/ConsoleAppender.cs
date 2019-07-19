namespace Logger.Models.Appenders
{
    using System;
    using System.Globalization;

    using Contracts;
    using Enumerations;

    public class ConsoleAppender : IAppender
    {
        private const string DateFormat = "M/dd/yyyy h:mm:ss tt";

        private int messagesAppended;

        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public void Append(IError error)
        {
            var format = this.Layout.Format;

            var dateTime = error.DateTime;
            var level = error.Level;
            var message = error.Message;

            string formattedMessage = string.Format(
                format,
                dateTime.ToString(
                    DateFormat,
                    CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            Console.WriteLine(formattedMessage);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
