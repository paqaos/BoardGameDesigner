using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using BoardGameDesigner.ViewModel.External;

namespace BoardGameDesigner.DesktopApp.Windows.CardViewer
{
    public interface ICardViewerWindow : IBoardWindow
    {
        Window GetWindow();
    }
}
