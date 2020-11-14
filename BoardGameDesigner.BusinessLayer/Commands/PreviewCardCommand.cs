using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoardGameDesigner.BusinessLayer.Services;
using BoardGameDesigner.ViewModel.Commands;
using BoardGameDesigner.ViewModel.External;

namespace BoardGameDesigner.BusinessLayer.Commands
{
    public class PreviewCardCommand : IPreviewCardCommand
    {
        private IWindowProvider _windowProvider;

        public PreviewCardCommand(IWindowProvider windowProvider)
        {
            _windowProvider = windowProvider;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var previewCardWindow = this._windowProvider.GetWindowByName("CardPreview");
            previewCardWindow.ShowWindow();
        }

        public event EventHandler CanExecuteChanged;
    }
}
