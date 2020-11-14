using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameDesigner.Model
{
    public interface IGameComponent
    {
        string Id { get; set; }
        string Name { get; set; }
    }
}
