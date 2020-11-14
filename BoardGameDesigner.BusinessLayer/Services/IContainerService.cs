using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameDesigner.BusinessLayer.Services
{
    public interface IContainerService
    {
        T ProvideInstance<T>();
    }
}
