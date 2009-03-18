using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace NBGIS.PluginEngine
{
   public class PluginCollectionEnumerator:IEnumerator
    {
       private IEnumerable _temp;
       private IEnumerator _enumerator;

       public PluginCollectionEnumerator(PluginCollection mappings)
       {
           _temp = (IEnumerable)mappings;
           _enumerator = _temp.GetEnumerator();
       }

       #region IEnumerator ≥…‘±

       public object Current
       {
           get { return _enumerator.Current; }
       }

       public bool MoveNext()
       {
           return _enumerator.MoveNext();
       }

       public void Reset()
       {
           _enumerator.Reset();
       }

       #endregion
   }
}
