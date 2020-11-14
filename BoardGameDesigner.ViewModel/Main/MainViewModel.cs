using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.ViewModel.Metadata;
using BoardGameDesigner.ViewModel.ProjectManagement;

namespace BoardGameDesigner.ViewModel.Main
{
    public class MainViewModel : BaseViewModel
    {
        public ProjectSettingsViewModel ProjectSettingsVm { get; set; }

        public ProjectManagementViewModel ProjectManagementVm { get; set; }

        public MetadataViewModel MetadataVm { get; set; }

        public MainViewModel(ProjectSettingsViewModel projectSettingsVm, ProjectManagementViewModel projectManagementVm, MetadataViewModel metadataVm)
        {
            ProjectSettingsVm = projectSettingsVm;
            ProjectManagementVm = projectManagementVm;
            MetadataVm = metadataVm;
        }
    }
}
