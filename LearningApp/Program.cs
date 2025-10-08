using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Character Jan = new Character();

        var myProgram = new ProgramCommands();
        myProgram.Commands.Add(new MoveCommand(10));
        myProgram.Commands.Add(new TurnCommand("right"));
        myProgram.Commands.Add(new MoveCommand(10));
        myProgram.Commands.Add(new TurnCommand("right"));
        myProgram.Commands.Add(new MoveCommand(10));
        myProgram.Commands.Add(new TurnCommand("right"));
        myProgram.Commands.Add(new MoveCommand(10));
        myProgram.Commands.Add(new TurnCommand("right"));
        
        myProgram.executeProgram(Jan);
    }
    
}