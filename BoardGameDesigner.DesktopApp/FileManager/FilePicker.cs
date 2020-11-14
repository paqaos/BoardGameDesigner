using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using BoardGameDesigner.BusinessLayer.External;
using BoardGameDesigner.DesktopApp.Windows;
using BoardGameDesigner.ViewModel.External;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace BoardGameDesigner.DesktopApp.FileManager
{
    public class FilePicker : IFilePicker
    {
     
        private bool HasValue(bool? value)
        {
            if (!value.HasValue)
                return false;

            return value.Value;
        }

        public (T content, string path) GetFile<T>(IBoardWindow window)
        {
            var boardWindow = window as ILocalBoardWindow;
            var openDirDialog = new OpenFileDialog();
            openDirDialog.Multiselect = false;
            openDirDialog.DefaultExt = ".bgd";
            string content = "";
            var realWindow = boardWindow?.GetWindow();

            if ((realWindow != null && HasValue(openDirDialog.ShowDialog(realWindow))) || (realWindow == null && HasValue(openDirDialog.ShowDialog())))
            {
                var path = openDirDialog.FileName;
                using (var fileStream = File.Open(path, FileMode.Open))
                {
                    using var streamReader = new StreamReader(fileStream);
                    content = streamReader.ReadToEnd();
                }

                var jsonConverter = JsonSerializer.Deserialize<T>(content);

                return (jsonConverter, path);
            }

            return default((T, string));
        }

        public (FileStream, string) GetFileToSave(IBoardWindow window)
        {
            var boardWindow = window as ILocalBoardWindow;
            var openDirDialog = new SaveFileDialog();
            openDirDialog.DefaultExt = ".bgd";
            openDirDialog.OverwritePrompt = true;
            openDirDialog.AddExtension = true;
            string content = "";
            var realWindow = boardWindow?.GetWindow();

            if ((realWindow != null && HasValue(openDirDialog.ShowDialog(realWindow))) || (realWindow == null && HasValue(openDirDialog.ShowDialog())))
            {
                var path = openDirDialog.FileName;

                return (File.Open(path, FileMode.Create), path);
            }

            throw new Exception("something is not yes");
        }
    }
}
