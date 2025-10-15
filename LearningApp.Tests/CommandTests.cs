using LearningApp.Commands;
using LearningApp.Models;
using LearningApp.Metrics;
using Xunit;
using System.Collections.Generic;

namespace LearningApp.Tests
{
    public class CommandTests
    {
        [Fact]
        public void MoveCommand_Executes_Correctly()
        {
            var character = new Character();
            var log = new List<string>();
            var command = new MoveCommand(5);

            command.Execute(character, log);

            Assert.Equal(5, character.X); 
            Assert.Equal(0, character.Y); 
            Assert.Single(log);
            Assert.Equal("Move 5", log[0]);
        }

        [Fact]
        public void TurnCommand_Executes_Correctly()
        {
            var character = new Character();
            var log = new List<string>();
            var command = new TurnCommand("right");

            command.Execute(character, log);

            Assert.Equal(0, character.X);
            Assert.Equal(0, character.Y); // To check the character doesn't move.
            Assert.Equal(Direction.South, character.Facing); 
            Assert.Single(log);
            Assert.Equal("Turn right", log[0]);
        }

        [Fact]
        public void RepeatCommand_Executes_Correctly()
        {
            var character = new Character();
            var log = new List<string>();

            var repeat = new RepeatCommand(2, new List<ICommand>
            {
                new MoveCommand(3),
                new TurnCommand("right")
            });

            repeat.Execute(character, log);

            Assert.Equal(3, character.X);
            Assert.Equal(-3, character.Y);
            Assert.Equal(Direction.West, character.Facing);

            Assert.Equal(4, log.Count);
        }
    }
}


