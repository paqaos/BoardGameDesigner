using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using AutoMapper;
using BoardGameDesigner.BusinessLayer.Commands;
using BoardGameDesigner.BusinessLayer.Commands.ProjectMetadata;
using BoardGameDesigner.BusinessLayer.DataSources;
using BoardGameDesigner.BusinessLayer.External;
using BoardGameDesigner.BusinessLayer.Mapping;
using BoardGameDesigner.BusinessLayer.Services;
using BoardGameDesigner.DesktopApp.FileManager;
using BoardGameDesigner.DesktopApp.Helpers;
using BoardGameDesigner.DesktopApp.WindowManager;
using BoardGameDesigner.DesktopApp.Windows;
using BoardGameDesigner.DesktopApp.Windows.CardDesigner;
using BoardGameDesigner.DesktopApp.Windows.CardViewer;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.Model.Design;
using BoardGameDesigner.Model.Design.Metatada;
using BoardGameDesigner.ViewModel;
using BoardGameDesigner.ViewModel.Commands;
using BoardGameDesigner.ViewModel.Commands.ProjectMetadata;
using BoardGameDesigner.ViewModel.DataSources;
using BoardGameDesigner.ViewModel.Main;
using BoardGameDesigner.ViewModel.ProjectManagement;
using SimpleInjector;

namespace BoardGameDesigner.DesktopApp.Management
{
    public class AppStartup
    {
        public static SimpleInjector.Container StartContainer()
        {
            var container = new Container();
            AutoMapperConfiguration.ConfigureMappings().AssertConfigurationIsValid();
            var mapper = AutoMapperConfiguration.ConfigureMappings().CreateMapper();

            container.Register(() => mapper, Lifestyle.Singleton);
            
            container.RegisterSingleton<IMainWindow, MainWindow>();

            container.RegisterSingleton<ICardViewerWindow, CardViewerWindow>();
            container.RegisterSingleton<ICardDesignerWindow, CardDesignerWindow>();

            container.RegisterSingleton<MainViewModel>();
            container.RegisterSingleton<ProjectManagementViewModel>();
            container.RegisterSingleton<GameDetailsViewModel>();
            container.RegisterSingleton<ProjectSettingsViewModel>();

#region Project management
            container.RegisterSingleton<ICreateProjectCommand, CreateProjectCommand>();
#endregion

            container.RegisterSingleton<ILoadProjectCommand, LoadProjectCommand>();
            container.RegisterSingleton<IPreviewCardCommand, PreviewCardCommand>();
            container.RegisterSingleton<ICreateCardCommand, CreateCardCommand>();
            container.RegisterSingleton<ISaveCardCommand, SaveCardCommand>();
            container.RegisterSingleton<ISaveProjectCommand, SaveProjectCommand>();

            container.RegisterSingleton<IFilePicker, FilePicker>();
            container.RegisterSingleton<ICardDesignGenerator, CardDesignGenerator>();

            container.RegisterSingleton<IWindowProvider, WindowProvider>();

            container.RegisterInitializer<WindowProvider>(x =>
                {
                    x.Windows["CardPreview"] = container.GetInstance<ICardViewerWindow>();
                    x.Windows["CardDesigner"] = container.GetInstance<ICardDesignerWindow>();
                });

            container.RegisterSingleton<GameStateService>();
            container.RegisterSingleton<IGameStateService>(() => container.GetInstance<GameStateService>());
            container.RegisterSingleton<IGameDataSource>(() => container.GetInstance<GameStateService>());

            container.RegisterSingleton<IDataSource<Card>, MemoryDataSource<Card>>();
            container.RegisterSingleton<IDataSource<CardDesign>, MemoryDataSource<CardDesign>>();

            container.RegisterInitializer<MemoryDataSource<CardDesign>>(x =>
            {
                x.Add(new CardDesign
                {
                    CardComponents = new List<IGameDesignComponent>
                    {
                        new RectangleComponent
                        {
                            Height = 30,
                            PosY = 100,
                            PosX = 30,
                            Width = 460,
                            Color = new StaticMetadata<ColorMetadata>(new ColorMetadata
                            {
                                Name = "Blue"
                            })
                        }
                    },
                    ComponentMetadata = new List<IBaseComponentMetadata>
                    {
                        new StaticMetadata<ColorMetadata>(new ColorMetadata())
                        {
                            Name = "Card Color"
                        }
                    }
                });
            });

            container.RegisterInitializer<MemoryDataSource<Card>>(x =>
            {
                x.Add(new Card
                {
                    Name = "Card name"
                });
            });

            container.Verify();

            return container;
        }
    }
}
