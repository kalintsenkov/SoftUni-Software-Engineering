namespace Telephony.Models
{
    using Exceptions;
    using Contracts;
    using System;
    using System.Linq;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (number.Any(x => char.IsLetter(x)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberException);
            }

            return $"Calling... {number}";
        }

        public string Browse(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidUrlException);
            }

             return $"Browsing: {site}!";
        }
    }
}
