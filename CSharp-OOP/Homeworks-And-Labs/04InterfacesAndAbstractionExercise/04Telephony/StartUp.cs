namespace Telephony
{
    using Core;
    using Contracts;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            ICallable caller = new Smartphone();
            IBrowsable browser = new Smartphone();
            Engine engine = new Engine(caller, browser);

            engine.Run();
        }
    }
}
