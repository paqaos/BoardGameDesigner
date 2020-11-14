using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BoardGameDesigner.ViewModel.Commands
{
    public interface ISaveCardCommand : ICommand
    {
        string SelectedCardId { get; set; }
    }
}
