using System;
using System.Collections.Generic;
using System.IO;

public class TextProgramImporter : IProgramImporter
{
    public ProgramCommands Import(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        int index = 0;

        var program = new ProgramCommands();
        program.Commands = ParseLines(lines, ref index);
        return program;
    }

    private List<ICommand> ParseLines(string[] lines, ref int index)
    {
        var commands = new List<ICommand>();

        while (index < lines.Length)
        {
            string line = lines[index].Trim(); // trim so accidental whitespace won't break the program.
            
        }
    }
}