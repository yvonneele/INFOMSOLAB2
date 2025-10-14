using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProgramMetrics
{
    public int NumberOfCommands { get; set; }
    public int NumberOfRepeats { get; set; }
    public int MaxNesting { get; set; }

    public override string ToString()
    {
        return
            "\nProgram Metrics:\n" +
            $"  Commands    : {NumberOfCommands, -4}\n" +
            $"  Repeats     : {NumberOfRepeats, -4}\n" +
            $"  Max Nesting : {MaxNesting, -4}";
    }
}

