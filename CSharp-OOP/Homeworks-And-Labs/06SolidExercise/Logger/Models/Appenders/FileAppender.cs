namespace Logger.Models.Appenders
{
    using System;

    using Contracts;
    using Enumerations;

    public class FileAppender : IAppender
    {
        private int messagesAppended;

        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error)
                + Environment.NewLine;

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}, File size {this.File.Size}";
        }
    }
}
