using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model;
using BoardGameDesigner.Model.ApplicationSettings;
using BoardGameDesigner.Model.Events;
using BoardGameDesigner.ViewModel.DataSources;

namespace BoardGameDesigner.BusinessLayer.Services
{
    public interface IGameStateService : IGameDataSource
    {
        AppSettings ApplicationSettings { get; }

        void CreateNewGame();

        public event EventHandler<GameCreated> OnGameCreated;
        void SetData(GameModel file);
    }
}
