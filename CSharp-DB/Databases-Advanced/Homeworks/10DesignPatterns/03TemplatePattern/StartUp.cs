namespace TemplatePattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var sourdough = new Sourdough();
            sourdough.Make();

            var twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            var wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
