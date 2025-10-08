using System.Collections.Generic;
public interface ICommand
{
    void Execute(Character character, List<string> outputLog);

}

