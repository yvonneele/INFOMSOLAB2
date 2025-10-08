using System.Collections.Generic;

public class TurnCommand : ICommand
{
    private string direction;

    public TurnCommand(string direction)
    {
        this.direction = direction;
    }

    public void Execute(Character character, List<string> outputLog)
    {
        if (direction == "left")
            character.turnLeft();
        else if (direction == "right")
            character.turnRight();
        outputLog.Add($"Turn {direction}");
    }
}
