using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BoardGameDesigner.ViewModel
{
    public class CardFamilyViewModel : BaseViewModel
    {
        public CardFamilyViewModel()
        {
            _sourceList = new List<CardViewModel>();
            Cards = new ObservableCollection<CardViewModel>(_sourceList);
        }

        private IList<CardViewModel> _sourceList;
        public ObservableCollection<CardViewModel> Cards { get; }

        public string Name { get; set; }
     }
}
