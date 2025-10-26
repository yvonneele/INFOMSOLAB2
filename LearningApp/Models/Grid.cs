using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Models
{
    public class Grid
    {
        public char[,] Cells { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Grid(char[,] cells) {
            Cells = cells;
            Height = cells.GetLength(0); //geeft het aantal rijen in de array 
            Width = cells.GetLength(1); // geeft het aantal kolommen in de array 
            // want 2d array: [rijnummer, kolomnummer] 
        }

        public bool IsEdge(int x, int y)
        {
            return x < 0 || x >= Width || y < 0 || y >= Height; 
        }

        public bool IsBlocked(int x, int y)
        {
            if (IsEdge(x, y))
                return true;

            return Cells[y, x] == '+';
        }

        // positie van het eindpunt 'x' in het grid teruggeeft 

        public (int X, int Y) EndPosition() //geeft tuple terug met x en y coordinaat
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    if (Cells[y, x] == 'x')
                        return (x, y);
            return (-1, -1); // dit is een foutcode, want zo weet de programma dat er geen eindpunt aanwezig is.
        }

        public void Draw(Character character)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == character.X && y == character.Y)
                        Console.Write('C');
                    else
                        Console.Write(Cells[y, x]);
                }
                Console.WriteLine();
            }
        }
    }

}
