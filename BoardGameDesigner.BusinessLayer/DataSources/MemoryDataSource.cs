using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoardGameDesigner.Model;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.Model.Events;
using BoardGameDesigner.ViewModel.DataSources;

namespace BoardGameDesigner.BusinessLayer.DataSources
{
    public class MemoryDataSource<T> : IDataSource<T> where T : class, IGameComponent
    {
        private IList<T> Items { get; set; }

        public MemoryDataSource()
        {
            Items = new List<T>();
        }

        public IList<T> GetAll()
        {
            return Items;
        }

        public void Add(T card)
        {
            Items.Add(card);

            CollectionChanged?.Invoke(this, new EventArgs());

            ComponentCreated?.Invoke(this, new GameComponentCreated<T>
            {
                CreatedItem = card
            });
        }

        public event EventHandler CollectionChanged;
        public T Get(string itemId)
        {
            return Items.First(x => string.Equals(x.Id,itemId, StringComparison.InvariantCultureIgnoreCase));
        }

        public event EventHandler<GameComponentCreated<T>> ComponentCreated;
    }
}
