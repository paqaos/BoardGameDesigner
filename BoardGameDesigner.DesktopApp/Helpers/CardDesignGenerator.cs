using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using BoardGameDesigner.BusinessLayer.External;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.Model.Design;

namespace BoardGameDesigner.DesktopApp.Helpers
{
    public class CardDesignGenerator : ICardDesignGenerator
    {
        public void ApplyToCanvas(Canvas canvas, CardDesign design, Card card)
        {
            foreach (var component in design.CardComponents)
            {
                if (component is RectangleComponent rectComponent)
                {
                    ApplyRectangle(canvas, rectComponent, card);
                }
            }
        }

        private void ApplyRectangle(Canvas canvas, RectangleComponent rectComponent, Card card)
        {
            var metadataValue = rectComponent.Color.ResolveValue(card);
            var rectButton = new Rectangle
            {
                Fill = new SolidColorBrush(ColorResolver(metadataValue.Name)),
                Height = rectComponent.Height,
                Width = rectComponent.Width
            };

            Canvas.SetTop(rectButton, rectComponent.PosY);
            Canvas.SetLeft(rectButton, rectComponent.PosX);

            canvas.Children.Add(rectButton);
        }

        private Color ColorResolver(string name)
        {
            return (Color) ColorConverter.ConvertFromString(name);
        }
    }
}
