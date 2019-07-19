namespace Logger.Models.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
