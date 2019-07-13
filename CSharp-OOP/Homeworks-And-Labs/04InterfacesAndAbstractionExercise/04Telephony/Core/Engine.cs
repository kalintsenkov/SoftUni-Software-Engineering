namespace Telephony.Core
{
    using Contracts;
    using System;
    using System.Linq;

    public class Engine
    {
        private ICallable caller;
        private IBrowsable browser;

        public Engine(ICallable caller, IBrowsable browser)
        {
            this.caller = caller;
            this.browser = browser;
        }

        public void Run()
        {
            var phoneNumbers = Console.ReadLine()
                .Split()
                .ToArray();

            var sites = Console.ReadLine()
                .Split()
                .ToArray();

            CallNumbers(phoneNumbers);
            BrowseSites(sites);
        }

        private void BrowseSites(string[] sites)
        {
            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(this.browser.Browse(site));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }
        }

        private void CallNumbers(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(this.caller.Call(number));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }
        }
    }
}
