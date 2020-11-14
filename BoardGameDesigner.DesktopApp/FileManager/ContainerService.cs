using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.BusinessLayer.Services;

namespace BoardGameDesigner.DesktopApp.FileManager
{
    public class ContainerService : IContainerService
    {
        public T ProvideInstance<T>()
        {
            throw new NotImplementedException();
        }
    }
}
