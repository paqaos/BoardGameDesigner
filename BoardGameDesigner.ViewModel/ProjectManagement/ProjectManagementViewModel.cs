using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.ViewModel.Commands.ProjectMetadata;

namespace BoardGameDesigner.ViewModel.ProjectManagement
{
    public class ProjectManagementViewModel : BaseViewModel
    {
        public ICreateProjectCommand CreateProjectCommand { get; set; }
        public ISaveProjectCommand SaveProjectCommand { get; set; }
        public ILoadProjectCommand LoadProjectCommand { get; set; }

        public ProjectManagementViewModel(ICreateProjectCommand createProjectCommand, ISaveProjectCommand saveProjectCommand, ILoadProjectCommand loadProjectCommand)
        {
            CreateProjectCommand = createProjectCommand;
            SaveProjectCommand = saveProjectCommand;
            LoadProjectCommand = loadProjectCommand;
        }
    }
}
