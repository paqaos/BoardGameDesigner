using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameDesigner.ViewModel.Metadata
{
    public class SingleMetadataGroupViewModel : BaseViewModel
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
    }
}
