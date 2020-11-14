using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameDesigner.Model.Events
{
    public class GameComponentCreated<T> : EventArgs where T : IGameComponent
    {
        public T CreatedItem { get; set; }
    }
}
