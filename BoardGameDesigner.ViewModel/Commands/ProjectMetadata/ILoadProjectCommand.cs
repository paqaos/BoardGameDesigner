using System.Windows.Input;
using BoardGameDesigner.ViewModel.External;

namespace BoardGameDesigner.ViewModel.Commands.ProjectMetadata
{
    public interface ILoadProjectCommand : ICommand
    {
        IBoardWindow BoardWindow { get; set; }
    }
}
