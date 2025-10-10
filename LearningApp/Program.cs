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

        myProgram.executeProgram(Jan);
    }
}
