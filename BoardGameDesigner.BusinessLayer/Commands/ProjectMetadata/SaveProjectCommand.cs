using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using BoardGameDesigner.BusinessLayer.External;
using BoardGameDesigner.BusinessLayer.Services;
using BoardGameDesigner.ViewModel.Commands.ProjectMetadata;
using BoardGameDesigner.ViewModel.ProjectManagement;

namespace BoardGameDesigner.BusinessLayer.Commands.ProjectMetadata
{
    public class SaveProjectCommand : ISaveProjectCommand
    {
        private readonly IGameStateService _gameStateService;
        private readonly IFilePicker _filePicker;
        private readonly IWindowProvider _windowProvider;
        private readonly ProjectSettingsViewModel _projectSettingsViewModel;

        public SaveProjectCommand(IGameStateService gameStateService, IFilePicker filePicker, IWindowProvider windowProvider, ProjectSettingsViewModel projectSettingsViewModel)
        {
            _gameStateService = gameStateService;
            _filePicker = filePicker;
            _windowProvider = windowProvider;
            _projectSettingsViewModel = projectSettingsViewModel;
            _gameStateService.OnGameCreated += _gameStateService_OnGameCreated;
            _gameStateService.OnGameChanged += _gameStateService_OnGameChanged;
        }

        private void _gameStateService_OnGameChanged(object sender, Model.Events.ProjectEvents.GameChanged e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        private void _gameStateService_OnGameCreated(object sender, Model.Events.GameCreated e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            var projectFile = _gameStateService.ApplicationSettings.ProjectFile;
            return !string.IsNullOrWhiteSpace(projectFile);
        }

        public void Execute(object parameter)
        {
            var (stream, path) = _filePicker.GetFileToSave(_windowProvider.GetMainWindow());

            using (stream)
            {
                var gameData = _gameStateService.GetData();
                gameData.Name = _projectSettingsViewModel.ProjectName;
                gameData.Author = _projectSettingsViewModel.Author;
                using var stringWriter = new StreamWriter(stream);

                var jsonSerializer = JsonSerializer.Serialize(gameData);

                _gameStateService.ApplicationSettings.ProjectFile = path;


                stringWriter.Write(jsonSerializer);
            }

            var pathBase = Path.GetDirectoryName(path);
        }

        public event EventHandler CanExecuteChanged;
    }
}
