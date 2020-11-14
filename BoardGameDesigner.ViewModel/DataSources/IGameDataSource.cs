using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model;
using BoardGameDesigner.Model.Events.ProjectEvents;

namespace BoardGameDesigner.ViewModel.DataSources
{
    public interface IGameDataSource
    {
        GameModel GetData();

        event EventHandler<GameChanged> OnGameChanged;
    }
}
