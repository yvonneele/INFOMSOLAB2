using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LearningApp.Models;

namespace LearningApp.Importers
{
    public class TextGridImporter : IGridImporter
    {
        public Grid Import(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            //validation
            if (lines.Length == 0)
                throw new Exception("Grid file is empty.");

            int height = lines.Length;
            int width = lines[0].Length;

            char[,] cells = new char[height, width];

            for (int row = 0; row < height; row++)
            {
                string line = lines[row];

                if (line.Length != width)
                    throw new Exception($"Inconsistent row length in line {row + 1}");

                for (int col = 0; col < width; col++)
                {
                    char c = line[col];
                    if (c != 'o' && c != '+' && c != 'x')
                        throw new Exception($"Invalid character '{c}' in grid file.");
                    cells[row, col] = c;
                }
            }

            return new Grid(cells);
        }
    }
}

