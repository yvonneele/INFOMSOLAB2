using System;
using System.Collections.Generic;
using LearningApp.Models;
using LearningApp.Importers;
using LearningApp.Commands;
using LearningApp.Metrics;

namespace LearningApp
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("\n=== PROGRAM MENU ===");
            Console.WriteLine("[1] Import program from file");
            Console.WriteLine("[2] Choose from example objects"); // Gives 3 example options
            Console.Write("Enter choice: ");

            string input = Console.ReadLine();

            ProgramCommands myProgram = null;
            Character jan = new Character();

            if (input == "1")
            {
                Console.Write("Enter file path (without quotes): ");
                string path = Console.ReadLine();

                if (!File.Exists(path)) // checkes if path exist maybe move to different place
                {
                    Console.WriteLine("File not found! Make sure you did not include quotes.");
                    return;
                }
                IProgramImporter importer = new TextProgramImporter();
                myProgram = importer.Import(path);
                Console.WriteLine("Program imported successfully!");

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
        }
    }
}

