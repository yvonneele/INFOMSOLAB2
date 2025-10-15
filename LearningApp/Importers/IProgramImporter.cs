using LearningApp.Commands;

namespace LearningApp.Importers
{
    public interface IProgramImporter
    {
        ProgramCommands Import(string filePath);
    }
}
