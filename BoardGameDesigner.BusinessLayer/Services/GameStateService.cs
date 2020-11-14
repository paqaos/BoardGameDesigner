using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model;
using BoardGameDesigner.Model.ApplicationSettings;
using BoardGameDesigner.Model.Events;
using BoardGameDesigner.Model.Events.ProjectEvents;

namespace BoardGameDesigner.BusinessLayer.Services
{
    public class GameStateService : IGameStateService
    {
        public AppSettings ApplicationSettings { get; }
        private int _iteration = 0;
        private GameModel _model;

        public GameStateService()
        {
            _model = new GameModel();
            SetName();
            _iteration++;
            ApplicationSettings = new AppSettings();
        }

        public void CreateNewGame()
        {
            _model = new GameModel();
            SetName();
            _iteration++;
            OnGameCreated?.Invoke(this, new GameCreated());
            OnGameChanged?.Invoke(this, new GameChanged());
        }

        private void SetName()
        {
            _model.Name = $"Game {_iteration}";
        }

        public event EventHandler<GameCreated> OnGameCreated;
        public GameModel GetData()
        {
            return _model;
        }

        public event EventHandler<GameChanged> OnGameChanged; 
        public void SetData(GameModel gameData)
        {
            _iteration++;
            _model = gameData;

            OnGameChanged?.Invoke(this, new GameChanged());
        }
    }
}
