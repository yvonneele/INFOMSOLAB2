using System;
using System.Collections.Generic;

namespace LearningApp.Models
{
    public class Character
    {
        public Grid Grid { get; private set; }
        public void SetGrid( Grid grid)
        {
            Grid = grid;
        }
        public int X { get; private set; } = 0; // Starts at (0,0)
        public int Y { get; private set; } = 0;
        public Direction Facing { get; private set; } = Direction.East;

        public void Move(int steps)
        {
            // een stap per keer zetten, en voor elke stap checkt hij bij het grid of de cel geblokkeerd of buiten het grid ligt
            for (int i = 0; i < steps; i++)
            {
                int newX = X;
                int newY = Y;

                switch (Facing)
                {
                    case Direction.North: newY += steps; break;
                    case Direction.East: newX += steps; break;
                    case Direction.South: newY -= steps; break;
                    case Direction.West: newX -= steps; break;
                }
                // controleren of de nieuwe positie geblokkeerd is of buiten het grid is 
                if (Grid.IsBlocked(newX, newY) && Grid != null)
                {
                    Console.WriteLine($"Blocked at ({newX}, {newY}) - stopping move.");
                    break; // stop met bewegen als er een muur of een rand is
                }
                X = newX; Y = newY;
            }
        }

        public void turnLeft()
        {
            Facing = (Direction)(((int)Facing + 3) % 4);
        }

        public void turnRight()
        {
            Facing = (Direction)(((int)Facing + 1) % 4);
        }
    }
}
