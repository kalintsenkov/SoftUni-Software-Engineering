using System;

public class StartUp
{
    public static void Main()
    {
        var spy = new Spy();
        var result = spy.CollectGettersAndSetters("Hacker");

        Console.WriteLine(result);
    }
}

