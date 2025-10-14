public class ProgramCommands
{
    public List<ICommand> Commands = new List<ICommand>(); // tijdelijk public
    public void ExecuteProgram(Character character)
    {
        List<string> log = new List<string>(); // misschien later buiten methode halen

        foreach (var command in Commands)
        {
            command.Execute(character, log);
        }

        Console.WriteLine(string.Join(", ", log) + ".");
        Console.WriteLine($"End state ({character.X},{character.Y}) facing {character.Facing}.");
    }
}
