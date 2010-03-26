using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NBGIS.PluginEngine
{
    public class PluginCollection:CollectionBase
    {
        public  PluginCollection()
        {
            
        }
        public PluginCollection(IPlugin[] value)
        {
            this.AddRange(value);
        }

        public PluginCollection(PluginCollection value)
        {
            this.AddRange(value);
        }

        public IPlugin this[int index]
        {
            get
            {
                return (IPlugin)(this.List[index]);
            }
        }

        public int Add(IPlugin value)
        {
            return this.List.Add(value);
        }

        public int IndexOf(IPlugin value)
        {
            return this.List.IndexOf(value);
        }
        public bool Contains(IPlugin value)
        {
            return this.List.Contains(value);
        }

        public void CopyTo(IPlugin[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public IPlugin[] ToArray()
        {
            IPlugin[] array = new IPlugin[this.Count];
            this.CopyTo(array, 0);
            return array;
        }

        public void Insert(int index, IPlugin value)
        {
            this.List.Insert(index, value);
        }

        public void Remove(IPlugin value)
        {
            this.List.Remove(value);
        }

        public new PluginCollectionEnumerator GetEnumerator()
        {
            return new PluginCollectionEnumerator(this);
        }
        private void AddRange(PluginCollection value)
        {
            for (int i = 0; i < value.Capacity; i++)
            {
                this.Add((IPlugin)value.List[i]);
            }
        }

        private void AddRange(IPlugin[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                this.Add(value[i]);
            }
        }

    }
}
