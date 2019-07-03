namespace Animals
{
    using System;

    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                try
                {
                    var command = Console.ReadLine();

                    if (command == "Beast!")
                    {
                        break;
                    }

                    var animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var animalName = animalInfo[0];
                    var animalAge = int.Parse(animalInfo[1]);
                    var animalGenger = animalInfo[2];

                    if (command == "Dog")
                    {
                        var dog = new Dog(animalName, animalAge, animalGenger);
                        Console.WriteLine(dog);
                    }
                    else if (command == "Cat")
                    {
                        var cat = new Cat(animalName, animalAge, animalGenger);
                        Console.WriteLine(cat);
                    }
                    else if (command == "Frog")
                    {
                        var frog = new Frog(animalName, animalAge, animalGenger);
                        Console.WriteLine(frog);
                    }
                    else if (command == "Kitten")
                    {
                        var kitten = new Kitten(animalName, animalAge);
                        Console.WriteLine(kitten);
                    }
                    else if (command == "Tomcat")
                    {
                        var tomcat = new Tomcat(animalName, animalAge);
                        Console.WriteLine(tomcat);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
