namespace Musaca.App
{
    using System.Threading.Tasks;
    using SIS.MvcFramework;

    public class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
