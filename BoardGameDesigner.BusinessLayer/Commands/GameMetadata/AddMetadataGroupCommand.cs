using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.ViewModel.Commands.GameMetadata;

namespace BoardGameDesigner.BusinessLayer.Commands.GameMetadata
{
    public class AddMetadataGroupCommand : IAddMetadataGroupCommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

        }

        public event EventHandler CanExecuteChanged;
    }
}
