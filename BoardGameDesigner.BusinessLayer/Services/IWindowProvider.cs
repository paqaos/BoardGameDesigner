using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.ViewModel.External;
using SimpleInjector;

namespace BoardGameDesigner.BusinessLayer.Services
{
    public interface IWindowProvider
    {
        IBoardWindow GetMainWindow();

        IBoardWindow GetWindowByName(string name);

        IList<IBoardWindow> GetAllWindows();
    }
}
