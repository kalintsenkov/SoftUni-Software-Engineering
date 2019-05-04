using System;
using System.Linq;

namespace P10LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] bugsOnIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < field.Length; i++) // making new inital field
            {
                if (bugsOnIndexes.Contains(i)) // Checking if there are ladyBugs inside the field
                {
                    field[i] = 1; // if cell has ladybug 
                }
                else
                {
                    field[i] = 0; // if cell is empty
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commands = command.Split();

                int bugIndex = int.Parse(commands[0]); // takes bugIndex
                string direction = commands[1]; // takes directions
                int flightLength = int.Parse(commands[2]); // takes flightLength

                if (bugIndex >= 0 && bugIndex < fieldSize)
                {
                    if (field[bugIndex] == 1) // Check if there is a ladybug
                    {
                        field[bugIndex] = 0; // Make this index 0, because ladybugs changes its position
                        if (direction == "right") // Check direction
                        {
                            if (flightLength >= 0) // if flightLength is bigger or equal to 0, ladybug flies to its right
                            {
                                for (int i = bugIndex + flightLength; i < field.Length; i = i + flightLength)
                                {
                                    if (field[i] == 0) // if cell is empty, change bug position
                                    {
                                        field[i] = 1; 
                                        break;
                                    }
                                }
                            }
                            else // if flightLength is less than 0, ladybug flies to its left
                            {
                                flightLength = Math.Abs(flightLength);
                                for (int i = bugIndex - flightLength; i >= 0; i = i - flightLength)
                                {
                                    if (field[i] == 0) // if cell is empty, change bug position
                                    {
                                        field[i] = 1; 
                                        break;
                                    }
                                }
                            }
                        }
                        else if (direction == "left") // Check direction
                        {
                            if (flightLength >= 0) // if flightLength is bigger or equal to 0, ladybug flies to its left
                            {
                                for (int i = bugIndex - flightLength; i >= 0; i = i - flightLength)
                                {
                                    if (field[i] == 0) // if cell is empty, change bug position
                                    {
                                        field[i] = 1; 
                                        break;
                                    }
                                }
                            }
                            else // if flightLength is less than 0, ladybug flies to its right
                            {
                                flightLength = Math.Abs(flightLength);
                                for (int i = bugIndex + flightLength; i < field.Length; i = i + flightLength)
                                {
                                    if (field[i] == 0) // if cell is empty, change bug position
                                    {
                                        field[i] = 1; 
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine(); // reading new command
            }
            Console.WriteLine(string.Join(" ", field)); //prints the final field
        }
    }
}
