using System.Collections.Generic;
using LearningApp.Models;

namespace LearningApp.Commands
{
    public interface ICommand
    {
        void Execute(Character character, List<string> outputLog);
    }
}
