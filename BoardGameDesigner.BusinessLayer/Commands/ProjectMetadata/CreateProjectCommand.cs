using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using BoardGameDesigner.BusinessLayer.External;
using BoardGameDesigner.BusinessLayer.Services;
using BoardGameDesigner.ViewModel.Commands.ProjectMetadata;

namespace BoardGameDesigner.BusinessLayer.Commands.ProjectMetadata
{
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private IGameStateService _gameStateService;
        private IFilePicker _filePicker;
        private IWindowProvider _windowProvider;

        public CreateProjectCommand(IGameStateService gameStateService, IFilePicker filePicker, IWindowProvider windowProvider)
        {
            _gameStateService = gameStateService;
            _filePicker = filePicker;
            _windowProvider = windowProvider;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var (stream, path) = _filePicker.GetFileToSave(_windowProvider.GetMainWindow());

            using (stream)
            {
                using var stringWriter = new StreamWriter(stream);
                _gameStateService.CreateNewGame();

                var jsonSerializer = JsonSerializer.Serialize(_gameStateService.GetData());

                _gameStateService.ApplicationSettings.ProjectFile = path;


                stringWriter.Write(jsonSerializer);
            }

            var pathBase = Path.GetDirectoryName(path);
            CreateCards(pathBase);
        }

        private void CreateCards(string path)
        {
            var cardLists = new List<string>
            {
                "aaa",
                "bbb",
                "ccc"
            };
            using (var cardsFile = File.Open(Path.Combine(path, "cards.json"), FileMode.Create))
            using (var writer = new StreamWriter(cardsFile))
            {
                var cardListSerialized = JsonSerializer.Serialize(cardLists);
                writer.Write(cardListSerialized);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
