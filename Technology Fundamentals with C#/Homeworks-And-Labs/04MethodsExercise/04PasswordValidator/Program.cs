using System;
using System.Linq;

namespace _04PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string passwordInput = Console.ReadLine();

            bool isBetweeenSixAndTenChars = StringLengthChecker(passwordInput);
            bool isOnlyLettersAndDigits = StringCharsCheckers(passwordInput);
            bool haveAtLeastTwoDigits = DigitCountChecker(passwordInput);

            if (isBetweeenSixAndTenChars == true && 
                isOnlyLettersAndDigits == true && 
                haveAtLeastTwoDigits == true)
            {
                Console.WriteLine("Password is valid");
            }
            if (!isBetweeenSixAndTenChars)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!isOnlyLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!haveAtLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        private static bool DigitCountChecker(string passwordInput)
        {
            int counter = 0;

            for (int i = 0; i < passwordInput.Length; i++)
            {
                if (char.IsDigit(passwordInput[i]))
                {
                    counter++;
                }
            }

            if(counter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool StringCharsCheckers(string passwordInput)
        {
            for (int i = 0; i < passwordInput.Length; i++)
            {
                if (!char.IsLetterOrDigit(passwordInput[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool StringLengthChecker(string passwordInput)
        {
            if (passwordInput.Length >= 6 && passwordInput.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
