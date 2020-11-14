using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model.Components;

namespace BoardGameDesigner.Model.Design.Metatada
{
    public class StaticMetadata<T> : IComponentMetadata<T> where T : class, IMetadataType
    {
        public StaticMetadata(T initialValue)
        {
            Value = initialValue;
        }

        public T Value { get; }

        public T ResolveValue(Card card)
        {
            return Value;
        }

        public string Name { get; set; }
    }
}
