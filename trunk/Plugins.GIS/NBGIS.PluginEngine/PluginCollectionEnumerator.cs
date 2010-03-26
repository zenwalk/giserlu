using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NBGIS.PluginEngine
{
   
  public class PluginCollectionEnumerator:IEnumerator
    {
      private IEnumerable m_temp;
      private IEnumerator m_Enumerator;

      /// <summary>
      /// Initializes a new instance of the PluginCollectionEnumerator class.
      /// </summary>
      /// <param name="p_temp"></param>
      /// <param name="p_Enumerator"></param>
      public PluginCollectionEnumerator(PluginCollection mappings)
      {
          m_temp = (IEnumerable)mappings;
          m_Enumerator = m_temp.GetEnumerator();
      }

      #region IEnumerator 成员

      public object Current
      {
          get { return m_Enumerator.Current; }
      }

      public bool MoveNext()
      {
          return m_Enumerator.MoveNext();
      }

      public void Reset()
      {
          m_Enumerator.Reset();
      }

      #endregion
    }
}
