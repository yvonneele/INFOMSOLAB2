using LearningApp.Commands;
using LearningApp.Models;
using LearningApp.Metrics;
using Xunit;
using System.Collections.Generic;

namespace LearningApp.Tests
{
    public class MetricsTests
    {
        [Fact]
        public void Calculates_Correct_Metrics()
        {
            var program = new ProgramCommands();
            program.Commands.Add(new MoveCommand(1));
            program.Commands.Add(new RepeatCommand(2, new List<ICommand>
            {
                new MoveCommand(2),
                new TurnCommand("left")
            }));

            var calculator = new ProgramMetricsCalculator();
            var metrics = calculator.Calculate(program);

            Assert.Equal(4, metrics.NumberOfCommands); 
            Assert.Equal(1, metrics.NumberOfRepeats);
            Assert.Equal(1, metrics.MaxNesting); 
        }
    }
}