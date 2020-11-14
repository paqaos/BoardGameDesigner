using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameDesigner.Model.Events.CardEvents
{
    public class SelectedCardChanged : EventArgs
    {
        public string NewCardId { get; set; }
    }
}
