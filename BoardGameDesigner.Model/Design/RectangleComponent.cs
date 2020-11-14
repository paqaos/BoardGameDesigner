using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model.Design.Metatada;

namespace BoardGameDesigner.Model.Design
{
    public class RectangleComponent : IGameDesignComponent
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public IComponentMetadata<ColorMetadata> Color { get; set; }
        public string Name { get; set; }
    }
}
