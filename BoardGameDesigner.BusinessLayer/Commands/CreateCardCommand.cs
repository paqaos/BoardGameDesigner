using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.BusinessLayer.Services;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.ViewModel.Commands;
using BoardGameDesigner.ViewModel.DataSources;

namespace BoardGameDesigner.BusinessLayer.Commands
{
    public class CreateCardCommand : ICreateCardCommand
    {
        private IDataSource<Card> _cardDataSource;
        private IGameStateService _gameStateService;

        public CreateCardCommand(IGameStateService gameStateService, IDataSource<Card> cardDataSource)
        {
            _gameStateService = gameStateService;
            _cardDataSource = cardDataSource;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _cardDataSource.Add(new Card());
        }

        public event EventHandler CanExecuteChanged;
    }
}
