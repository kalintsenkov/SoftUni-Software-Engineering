namespace SULS.App
{
    using System.Threading.Tasks;
    using SIS.MvcFramework;

    public class Program
    {
        public async static Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}