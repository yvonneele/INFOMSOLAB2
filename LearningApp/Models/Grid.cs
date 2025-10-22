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
            Width = cells.GetLength(0); //geeft het aantal rijen in de array 
            Height = cells.GetLength(1); // geeft het aantal kolommen in de array 
            // want 2d array: [rijnummer, kolomnummer] 
        }

        public bool IsEdge(int x, int y)
        {
            return x < 0 || x >= Width || y < 0 || y >= Height; 
        }

        public bool IsBlocked(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return true;
            else 
                return Cells[x, y] == '+'; // Vergelijkt de inhoud van die cel met het teken '+' en kijkt dus of deze cel een muur is 
            // het geeft dan true terug is als ht een "+" is en false als het geen "+" is. 
        }

        // positie van het eindpunt 'x' in het grid teruggeeft 

        public (int X, int Y) EndPosition() //geeft tuple terug met x en y coordinaat
        {
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    if (Cells[i, j] == 'x')
                        return (i, j);
            return (-1, -1); // dit is een foutcode, want zo weet de programma dat er geen eindpunt aanwezig is.
        }
    }

}
