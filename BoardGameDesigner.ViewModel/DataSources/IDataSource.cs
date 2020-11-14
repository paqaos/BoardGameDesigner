using System;
using System.Collections.Generic;
using System.Text;
using BoardGameDesigner.Model;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.Model.Events;

namespace BoardGameDesigner.ViewModel.DataSources
{
    public interface IDataSource<T> where T : IGameComponent
    {
        IList<T> GetAll();
        void Add(T newItem);

        event EventHandler CollectionChanged;
        T Get(string itemId);

        public event EventHandler<GameComponentCreated<T>> ComponentCreated;
    }
}
