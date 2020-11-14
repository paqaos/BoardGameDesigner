using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using BoardGameDesigner.ViewModel.External;

namespace BoardGameDesigner.DesktopApp.Windows
{
    public interface ILocalBoardWindow : IBoardWindow
    {
        Window GetWindow();
    }
}
