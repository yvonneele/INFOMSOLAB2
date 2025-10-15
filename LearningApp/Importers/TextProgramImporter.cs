using System;
using System.Collections.Generic;
using System.IO;
using LearningApp.Commands;

namespace LearningApp.Importers
{
    public class TextProgramImporter : IProgramImporter
    {
        public ProgramCommands Import(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int index = 0;

            var program = new ProgramCommands();
            program.Commands = ParseLines(lines, ref index, 0);
            return program;
        }

        private List<ICommand> ParseLines(string[] lines, ref int index, int currentIndent)
        {
            var commands = new List<ICommand>();

            while (index < lines.Length)
            {
                string line = lines[index];
                int indent = GetIndentationLevel(line);

                if (indent < currentIndent)
                    break;

                line = line.Trim();

                if (line.StartsWith("Move"))
                {
                    int steps = int.Parse(line.Split(' ')[1]);
                    commands.Add(new MoveCommand(steps));
                    index++;
                }
                else if (line.StartsWith("Turn"))
                {
                    string direction = line.Split(' ')[1];
                    commands.Add(new TurnCommand(direction));
                    index++;
                }
                else if (line.StartsWith("Repeat"))
                {
                    int times = int.Parse(line.Split(' ')[1]);
                    index++;

                    var innerCommands = ParseLines(lines, ref index, currentIndent + 4); // checks for spaces for indentation nested repeats.
                    commands.Add(new RepeatCommand(times, innerCommands));
                }
                else
                {
                    break;
                }
            }
            return commands;
        }

        //Indent checker (4 spaces)
        private int GetIndentationLevel(string line)
        {
            int count = 0;
            foreach (char c in line)
            {
                if (c == ' ') count++;
                else break;
            }
            return count;
        }
    }
}
