using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using BoardGameDesigner.ViewModel.Commands.ProjectMetadata;

namespace BoardGameDesigner.BusinessLayer.Commands.ProjectMetadata
{
    public class OpenProjectMetadataCommand : IOpenProjectMetadataCommand
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
