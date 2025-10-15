using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningApp.Commands;

namespace LearningApp.Objects
{
    public static class ExamplePrograms
    {
        public static ProgramCommands CreateBasicProgram() // Example program with basic moves and turns.
        {
            var program = new ProgramCommands();
            program.Commands.Add(new MoveCommand(5));
            program.Commands.Add(new TurnCommand("right"));
            program.Commands.Add(new MoveCommand(10));
            program.Commands.Add(new TurnCommand("left"));
            program.Commands.Add(new MoveCommand(7));
            program.Commands.Add(new TurnCommand("right"));
            program.Commands.Add(new MoveCommand(3));
            return program;
            // Metrics: NumberOfCommands: 7, NumberOfRepeats: 0, MaxNesting: 0
            // Endpoint: (12,-13) Facing South
        }
        
        public static ProgramCommands CreateAdvancedProgram() // Example program with repeat statements.
        {
            var program = new ProgramCommands();
            program.Commands.Add(new MoveCommand(10));
            program.Commands.Add(new TurnCommand("right"));
            program.Commands.Add(new RepeatCommand(3, new List<ICommand>
            {
                new MoveCommand(5),
                new TurnCommand("left"),
                new MoveCommand(2)
            }));
            program.Commands.Add(new TurnCommand("left"));
            program.Commands.Add(new MoveCommand(6));
            program.Commands.Add(new RepeatCommand(2, new List<ICommand>
            {
                new TurnCommand("right"),
                new MoveCommand(3)
            }));
            return program;
            // Metrics: NumberOfCommands: 11, NumberOfRepeats: 2, MaxNesting: 1
            // Endpoint: (12, -1) Facing North
        }
        
        public static ProgramCommands CreateExpertProgram() // Example program with nested repeats.
        {
            var program = new ProgramCommands();
            program.Commands.Add(new RepeatCommand(2, new List<ICommand>
            {
                new MoveCommand(3),
                new TurnCommand("right"),
                new RepeatCommand(2, new List<ICommand>
                {
                    new MoveCommand(2),
                    new TurnCommand("left")
                })
            }));
            program.Commands.Add(new MoveCommand(5));
            program.Commands.Add(new TurnCommand("left"));
            program.Commands.Add(new RepeatCommand(3, new List<ICommand>
            {
                new TurnCommand("right"),
                new MoveCommand(1),
                new RepeatCommand(2, new List<ICommand>
                {
                    new MoveCommand(1),
                    new TurnCommand("left")
                })
            }));
            program.Commands.Add(new MoveCommand(2));
            program.Commands.Add(new TurnCommand("right"));
            return program;
            // Metrics: NumberOfCommands: 16, NumberOfRepeats: 4, MaxNesting: 2
            // Endpoint: (1, 1) Facing North
        }
    }
}