using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BoardGameDesigner.ViewModel.External;

namespace BoardGameDesigner.BusinessLayer.External
{
    public interface IFilePicker
    {
        (T content, string path) GetFile<T>(IBoardWindow window);

        (FileStream stream, string path) GetFileToSave(IBoardWindow window);
    }
}
