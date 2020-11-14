using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model.Components;

namespace BoardGameDesigner.Model.Design.Metatada
{
    public interface IComponentMetadata<out T> : IBaseComponentMetadata where T : class, IMetadataType
    {
        T ResolveValue(Card card);
    }
}
