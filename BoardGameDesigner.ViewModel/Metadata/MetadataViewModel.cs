using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.ViewModel.DataSources;

namespace BoardGameDesigner.ViewModel.Metadata
{
    public class MetadataViewModel : BaseViewModel
    {
        private readonly IGameDataSource _gameDataSource;

        public MetadataGroupViewModel GroupViewModel { get; set; }

        public MetadataViewModel(IGameDataSource gameDataSource, MetadataGroupViewModel groupViewModel)
        {
            _gameDataSource = gameDataSource;
            GroupViewModel = groupViewModel;
            _gameDataSource.OnGameChanged += _gameDataSource_OnGameChanged;
        }

        private void _gameDataSource_OnGameChanged(object sender, Model.Events.ProjectEvents.GameChanged e)
        {
        }
    }
}
