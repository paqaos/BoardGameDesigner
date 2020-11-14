using System.Windows.Controls;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.Model.Design;

namespace BoardGameDesigner.DesktopApp.Helpers
{
    public interface ICardDesignGenerator
    {
        public void ApplyToCanvas(Canvas canvas, CardDesign design, Card card);
    }
}
