using System;
using System.Collections.Generic;

public class ProgramMetricsCalculator
{
    public ProgramMetrics Calculate(ProgramCommands program)
    {
        var metrics = new ProgramMetrics();
        CalculateRecursive(program.Commands, metrics, 0);
        return metrics;
    }

    private void CalculateRecursive(List<ICommand> commands, ProgramMetrics metrics, int depth)
    {
        metrics.MaxNesting = Math.Max(metrics.MaxNesting, depth);

        foreach (var command in commands)
        {
            metrics.NumberOfCommands++;

            if (command is RepeatCommand repeat)
            {
                metrics.NumberOfRepeats++;
                CalculateRecursive(repeat.CommandList, metrics, depth + 1);
            }
        }
    }
}
