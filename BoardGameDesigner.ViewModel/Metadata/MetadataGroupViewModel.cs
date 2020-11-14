using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using BoardGameDesigner.ViewModel.Commands.GameMetadata;

namespace BoardGameDesigner.ViewModel.Metadata
{
    public class MetadataGroupViewModel : BaseViewModel
    {
        public ObservableCollection<SingleMetadataGroupViewModel> MetadataGroups { get; }

        public MetadataGroupViewModel(IAddMetadataGroupCommand addMetadataGroupCommand)
        {
            AddMetadataGroupCommand = addMetadataGroupCommand;

            MetadataGroups = new ObservableCollection<SingleMetadataGroupViewModel>();
        }

        public IAddMetadataGroupCommand AddMetadataGroupCommand { get; set; }
    }
}
