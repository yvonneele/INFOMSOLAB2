using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Commands
{
    public class RepeatUntilCommand : ICommand
    {
        private readonly List<ICommand> _commands;
        private readonly RepeatUntilCondition _condition;
        private const int MaxIterations = 1000;

        public RepeatUntilCommand(RepeatUntilCondition condition, List<ICommand> commands)
        { _commands = commands; _condition = condition; }

        public void Execute(Character character, List<string> outputLog)
        {
            if (character.Grid == null)
            {
                outputLog.Add("No grid assigned to character.");
                return;
            }
            /* Ik heb dit even outgecomment want we zijn denk ik nog niet zo ver 

            var endPos = character.Grid.EndPosition();
            if (endPos == (-1, -1))
            {
                Console.WriteLine("Grid had no end point ('x') - cannot use RepeatUntilCommand.");
                return;

            }
            */
            // herhalen totdat de character op het eindpunt staat 
            int iteration = 0;
            while (!CheckCondition(character) && iteration < MaxIterations)
            {
                iteration++;

                foreach (var command in _commands)
                {
                    command.Execute(character, outputLog);
                    //check na elke stap of we op het eindpunt staan
                    if (CheckCondition(character))
                        break;
                }
            }

            if (iteration >= MaxIterations)
            {
                outputLog.Add("Stopped.");
            }
            else
            {
                outputLog.Add($"RepeatUntil finished after {iteration} iterations.");
            }
        }


            private bool CheckCondition(Character character)
        {
            int nextX = character.X;
            int nextY = character.Y;

            // bepaal de volgende positie gebaseerd op de facing
            switch (character.Facing)
            {
                case Direction.North: nextX -= 1; break;
                case Direction.East: nextY += 1; break;
                case Direction.South: nextX += 1; break;
                case Direction.West: nextY -= 1; break;
            }

            return _condition switch
            {
                RepeatUntilCondition.WallAhead => character.Grid.IsBlocked(nextX, nextY),
                RepeatUntilCondition.GridEdge => character.Grid.IsEdge(nextX, nextY),
                _ => false
            };
        }

        public override string ToString()
        {
            return $"RepeatUntil({_condition}) {{ {_commands.Count} commands }}";
        }


    } }
