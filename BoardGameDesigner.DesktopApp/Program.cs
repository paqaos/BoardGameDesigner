using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.DesktopApp.Management;
using BoardGameDesigner.DesktopApp.Windows;
using SimpleInjector;

namespace BoardGameDesigner.DesktopApp
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {

                var container = AppStartup.StartContainer();
                RunApplication(container);
            }
            catch (Exception ex)
            {

            }

        }

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();

                var mainWindow = container.GetInstance<IMainWindow>();

                app.Run(mainWindow.GetWindow());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
