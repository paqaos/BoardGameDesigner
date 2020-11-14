using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model.Design.Metatada;

namespace BoardGameDesigner.Model.Design
{
    public class CardDesign : IGameComponent
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<IGameDesignComponent> CardComponents { get; set; }

        public List<IBaseComponentMetadata> ComponentMetadata { get; set; }
    }
}
