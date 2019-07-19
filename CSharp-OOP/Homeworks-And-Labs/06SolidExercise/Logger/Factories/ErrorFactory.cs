namespace Logger.Factories
{
    using System;
    using System.Globalization;

    using Contracts;
    using Exceptions;
    using Models.Contracts;
    using Models.Enumerations;
    using Models.Errors;

    public class ErrorFactory : IErrorFactory
    {
        private const string DateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string dateString, string levelString, string message)
        {
            var isParsed = Enum.TryParse(levelString, out Level level);

            if (!isParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, DateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateTimeTypeException();
            }

            return new Error(dateTime, message, level);
        }
    }
}
