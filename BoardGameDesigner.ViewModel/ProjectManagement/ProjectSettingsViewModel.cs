using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model;
using BoardGameDesigner.ViewModel.DataSources;

namespace BoardGameDesigner.ViewModel.ProjectManagement
{
    public class ProjectSettingsViewModel : BaseViewModel
    {
        private readonly IGameDataSource _gameDataSource;
        private string _author;
        private string _projectName;

        public ProjectSettingsViewModel(IGameDataSource gameDataSource)
        {
            _gameDataSource = gameDataSource;
            _gameDataSource.OnGameChanged += _gameDataSource_OnGameChanged;
        }

        private void _gameDataSource_OnGameChanged(object sender, Model.Events.ProjectEvents.GameChanged e)
        {
            var actualData = _gameDataSource.GetData();

            Author = actualData.Author;
            ProjectName = actualData.Name;
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                if (_projectName != value)
                {
                    _projectName = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
