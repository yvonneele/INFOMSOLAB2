using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningApp.Models;

namespace LearningApp.Importers
{
    public interface IGridImporter
    {
        Grid Import(string filePath);
    }
}

