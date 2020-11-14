using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.ViewModel.ProjectManagement;

namespace BoardGameDesigner.ViewModel.Main
{
    public class MainViewModel : BaseViewModel
    {
        public ProjectSettingsViewModel ProjectSettingsVm { get; set; }

        public ProjectManagementViewModel ProjectManagementVm { get; set; }

        public MainViewModel(ProjectSettingsViewModel projectSettingsVm, ProjectManagementViewModel projectManagementVm)
        {
            ProjectSettingsVm = projectSettingsVm;
            ProjectManagementVm = projectManagementVm;
        }
    }
}
