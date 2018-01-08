using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoREMobile.Helpers
{
    /// <summary>
    /// Grouping class used to help group collection items for use in the
    /// master/detail display of grouped navigation items 
    /// </summary>
    /// <typeparam name="K">Searchable Key</typeparam>
    /// <typeparam name="T">Datatype of the grouping collection</typeparam>
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
