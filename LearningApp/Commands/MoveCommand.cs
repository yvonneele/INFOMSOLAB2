using System;
using System.Collections.Generic;
using LearningApp.Models;

namespace LearningApp.Commands
{
    public class MoveCommand : ICommand
    {
        private int steps;

        public MoveCommand(int steps)
        {
            this.steps = steps;
        }

        public void Execute(Character character, List<string> outputLog)
        {
            character.Move(steps);
            outputLog.Add($"Move {steps}");
        }
    }
}


