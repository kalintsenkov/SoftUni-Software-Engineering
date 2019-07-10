namespace PizzaCalories.Exceptions
{
    public static class ExceptionMessages
    {
        public static string InvalidDoughTypeException = "Invalid type of dough.";
        public static string InvalidDoughWeightException = "Dough weight should be in the range [1..200].";

        public static string InvalidToppingTypeException = "Cannot place {0} on top of your pizza.";
        public static string InvalidToppingWeightException = "{0} weight should be in the range [1..50].";
        public static string InvalidNumberOfToppingsException = "Number of toppings should be in range [0..10].";

        public static string InvalidPizzaNameException = "Pizza name should be between 1 and 15 symbols.";
    }
}
