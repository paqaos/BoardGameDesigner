using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameDesigner.Model.Components
{
    public class Card : IGameComponent
    {
        public string Name { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
