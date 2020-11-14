using System;
using System.Collections.Generic;
using System.Text;
using SimpleInjector;

namespace BoardGameDesigner.DesktopApp.Controls
{
    public interface IBoardGameControl
    {
        void InitializeControl(Container container);
    }
}
