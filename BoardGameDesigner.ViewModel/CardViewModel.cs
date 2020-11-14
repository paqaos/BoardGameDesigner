using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameDesigner.ViewModel
{
    public class CardViewModel : BaseViewModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CardId { get; set; } = Guid.NewGuid().ToString();


    }
}
