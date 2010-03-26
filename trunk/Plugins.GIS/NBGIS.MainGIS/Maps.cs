using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NBGIS.MainGIS
{
    class Maps:ESRI.ArcGIS.Carto.IMaps,IDisposable
    {

        ArrayList m_ArrayList;
        public Maps()
        {
            m_ArrayList = new ArrayList();
        }
        #region IMaps 成员

        public void Add(ESRI.ArcGIS.Carto.IMap map)
        {
            if (map == null)
            {
                NBGIS.PluginEngine.Applog.log.Error("Maps::Add\r\n加入的map对象为NUll");
            }
            else
            {
                m_ArrayList.Add(map);
            }
        }

        public int Count
        {
            get { return m_ArrayList.Count; }
        }

        public ESRI.ArcGIS.Carto.IMap Create()
        {
            ESRI.ArcGIS.Carto.IMap newMap = new ESRI.ArcGIS.Carto.MapClass();
            m_ArrayList.Add(newMap);

            return newMap;
        }

        public void Remove(ESRI.ArcGIS.Carto.IMap map)
        {
            m_ArrayList.Remove(map);
        }

        public void RemoveAt(int index)
        {
            if (index > m_ArrayList.Count || index < 0)
            {
                NBGIS.PluginEngine.Applog.log.Error("Maps:RemoveAt\r\n索引参数越界");
            }
            else
            {
                m_ArrayList.RemoveAt(index);
            }
        }

        public void Reset()
        {
            m_ArrayList.Clear();
        }

        public ESRI.ArcGIS.Carto.IMap get_Item(int index)
        {
            if (index > m_ArrayList.Count || index < 0)
            {
                NBGIS.PluginEngine.Applog.log.Error("Maps::get_Item\r\n索引参数越界");
                return null;
            }
            else
            {
                return (ESRI.ArcGIS.Carto.IMap)m_ArrayList[index];
            }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            if(m_ArrayList!=null)
            {
                m_ArrayList.Clear();
                m_ArrayList = null;
            }
        }

        #endregion
    }
}
