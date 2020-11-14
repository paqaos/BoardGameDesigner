using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.BusinessLayer.Services;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.ViewModel.Commands;
using BoardGameDesigner.ViewModel.DataSources;

namespace BoardGameDesigner.BusinessLayer.Commands
{
    public class SaveCardCommand : ISaveCardCommand
    {
        private IDataSource<Card> _cardDataSource;
        private string _selectedCardId;

        public SaveCardCommand(IDataSource<Card> cardDataSource)
        {
            _cardDataSource = cardDataSource;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(SelectedCardId);
        }

        public void Execute(object parameter)
        {
            var card = _cardDataSource.Get(SelectedCardId);


        }

        public event EventHandler CanExecuteChanged;

        public string SelectedCardId
        {
            get => _selectedCardId;
            set
            {
                if (_selectedCardId != value)
                {
                    _selectedCardId = value;
                    CanExecuteChanged?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
