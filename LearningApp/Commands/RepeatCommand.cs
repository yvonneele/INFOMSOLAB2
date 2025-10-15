using System;
using System.Collections.Generic;
using LearningApp.Models;

namespace LearningApp.Commands
{
    public class RepeatCommand : ICommand
    {
        public int Times { get; }
        public List<ICommand> CommandList { get; }

        public RepeatCommand(int times, List<ICommand> commands)
        {
            this.Times = times;
            this.CommandList = commands;
        }

        public void Execute(Character character, List<string> outputLog)
        {
            for (int i = 0; i < Times; i++)
            {
                foreach (var command in CommandList)
                {
                    command.Execute(character, outputLog);
                }
            }
        }
    }
}

