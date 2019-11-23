namespace TemplatePattern
{
    using System;

    public abstract class Bread
    {
        public abstract void MixIngredients();

        public abstract void Bake();

        public void Slice()
        {
            Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
        }

        // The template method
        public void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}
