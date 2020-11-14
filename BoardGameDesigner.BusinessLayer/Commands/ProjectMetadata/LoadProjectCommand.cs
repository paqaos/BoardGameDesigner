using System;
using BoardGameDesigner.BusinessLayer.External;
using BoardGameDesigner.BusinessLayer.Services;
using BoardGameDesigner.Model;
using BoardGameDesigner.ViewModel.Commands.ProjectMetadata;
using BoardGameDesigner.ViewModel.External;

namespace BoardGameDesigner.BusinessLayer.Commands.ProjectMetadata
{
    public class LoadProjectCommand : ILoadProjectCommand 
    {
        public IFilePicker FilePicker { get; }
        public IBoardWindow BoardWindow { get; set; }

        private readonly IGameStateService _gameStateService;

        public LoadProjectCommand(IFilePicker filePicker, IGameStateService gameStateService)
        {
            FilePicker = filePicker;
            _gameStateService = gameStateService;
        }

        public bool CanExecute(object parameter)
        {
            return FilePicker != null;
        }

        public void Execute(object parameter)
        {
            var file = FilePicker.GetFile<GameModel>(BoardWindow);

            this._gameStateService.ApplicationSettings.ProjectFile = file.path;
            
            _gameStateService.SetData(file.content);

        }

        public event EventHandler CanExecuteChanged;
    }
}
