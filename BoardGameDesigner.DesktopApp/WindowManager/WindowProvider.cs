using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoardGameDesigner.BusinessLayer.Services;
using BoardGameDesigner.DesktopApp.Windows;
using BoardGameDesigner.ViewModel.External;
using SimpleInjector;

namespace BoardGameDesigner.DesktopApp.WindowManager
{
    public class WindowProvider : IWindowProvider
    {
        private Container _container;
        public IDictionary<string, IBoardWindow> Windows { get; private set; }

        public WindowProvider(Container container)
        {
            _container = container;
            Windows = new Dictionary<string, IBoardWindow>();
        }

        public IBoardWindow GetMainWindow()
        {
            return _container.GetInstance<IMainWindow>();
        }

        public IBoardWindow GetWindowByName(string name)
        {
            return Windows[name];
        }

        public IList<IBoardWindow> GetAllWindows()
        {
            return Windows.Select(x => x.Value).ToList();
        }
    }
}
