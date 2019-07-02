namespace P02_CarsSalesman
{
    public class EngineFactory
    {
        public Engine Create(string[] parameters)
        {
            var model = parameters[0];
            var power = int.Parse(parameters[1]);

            Engine engine = null;

            if (parameters.Length == 3)
            {
                var isDisplacement = int.TryParse(parameters[2], out int displacement);

                if (isDisplacement)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    var efficiency = parameters[2];
                    engine = new Engine(model, power, efficiency);
                }
            }
            else if (parameters.Length == 4)
            {
                var displacement = int.Parse(parameters[2]);
                var efficiency = parameters[3];

                engine = new Engine(model, power, displacement, efficiency);
            }
            else
            {
                engine = new Engine(model, power);
            }

            return engine;
        }
    }
}
