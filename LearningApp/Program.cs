using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n=== PROGRAM MENU ===");
        Console.WriteLine("[1] Import porgram from file");
        Console.WriteLine("[2] Choose from example objects"); // Gives 3 example options
        Console.Write("Enter choice: ");

        string input = Console.ReadLine();

        ProgramCommands myProgram;
        Character jan = new Charachter();

        if (input == "1")
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();

            if (!File.Exists(path)) // checkes if path exist maybe move to different place
            {
                Console.WriteLine("File not found!");
                return;
            }
            // code voor importeren
        }
        else if (input == "2")
        {
            Console.WriteLine("\n=== CHOOSE EXAMPLE PROGRAM ===");
            Console.WriteLine("[1] Basic program (just moves and turns)");
            Console.WriteLine("[2] Advanced program (with repeats)");
            Console.WriteLine("[3] Expert program (nested repeats)");
            Console.Write("Enter choice: ");

            string exampleChoice = Console.ReadLine();

            if (exampleChoice == "1") ;
            //myProgram = CreateBasicProgram();
            else if (exampleChoice == "2") ;
            //myProgram = CreateAdvancedProgram();
            else if (exampleChoice == "3") ;
            //myProgram = CreateExpertProgram();
            else
            {
                Console.WriteLine("Invalid choice. Please restart and enter 1, 2, or 3!");
            }

        }
        else
        {
            Console.WriteLine("Invalid choice. Please restart and enter 1 or 2!");
        }

        Console.WriteLine("\n=== ACTION MENU ===");
        Console.WriteLine("[1] Run program");
        Console.WriteLine("[2] Show program metrics");
        Console.Write("Enter choice: ");

        string actionChoice = Console.ReadLine();

        if (actionChoice == "1")
        {
            myProgram.ExecuteProgram(jan);
        }
        else if (actionChoice == "2")
        {
            var calculator = new ProgramMetricsCalculator();
            var metrics = calculator.Calculate(myProgram);

            Console.WriteLine(metrics);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please restart and enter 1 or 2!");
        }


        /*Character Jan = new Character();

        var myProgram = new ProgramCommands();

        myProgram.Commands.Add(new MoveCommand(10));
        myProgram.Commands.Add(new TurnCommand("right"));

        myProgram.Commands.Add(new RepeatCommand(3, new List<ICommand>
        {
            new MoveCommand(5),
            new TurnCommand("left")
        }));

        myProgram.Commands.Add(new MoveCommand(10));

        myProgram.Commands.Add(new RepeatCommand(2, new List<ICommand>
        {
            new TurnCommand("right"),
            new RepeatCommand(2, new List<ICommand>
            {
                new MoveCommand(2),
                new TurnCommand("left")
            })
        }));
        var calculator = new ProgramMetricsCalculator();
        var metrics = calculator.Calculate(myProgram);

        // Print the result
        Console.WriteLine(metrics);

        //myProgram.executeProgram(Jan);*/
    }


}
