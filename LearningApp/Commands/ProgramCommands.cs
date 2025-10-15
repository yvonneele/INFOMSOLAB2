using LearningApp.Models;

namespace LearningApp.Commands
{
    public class ProgramCommands
    {
        public List<ICommand> Commands = new List<ICommand>(); 
        public void ExecuteProgram(Character character)
        {
            List<string> log = new List<string>(); 

            foreach (var command in Commands)
            {
                command.Execute(character, log);
            }

            Console.WriteLine(string.Join(", ", log) + ".");
            Console.WriteLine($"End state ({character.X},{character.Y}) facing {character.Facing}.");
        }
    }
}

