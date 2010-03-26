using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NBGIS.MainGIS
{
    /// <summary>
    /// 重新对IMap对象进行封装,用于在PropertyGrid控件中显示
    /// </summary>
    public class MapInfo
    {

        private int m_LayerCount;
        private int m_SelectionCount;
        private int m_MapsurroundCount;

        private string m_Name;
        private string m_Description;
        private double m_ReferenceScale;
        private ESRI.ArcGIS.esriSystem.esriUnits m_MapUnits;
        private ESRI.ArcGIS.esriSystem.esriUnits m_DistanceUnits;


        private bool m_UseSymbolLevels;
        private bool m_Expanded;
        private bool m_IsFramed;

      


        private ESRI.ArcGIS.Carto.IMap m_Map;



        public MapInfo(ESRI.ArcGIS.Carto.IMap map)
        {
            this.m_Map = map;
            this.m_Description = map.Description;
            this.m_Name = map.Name;
            this.m_Expanded = map.Expanded;
            this.m_IsFramed = map.IsFramed;
            this.m_LayerCount = map.LayerCount;
            this.m_MapsurroundCount = map.MapSurroundCount;
            this.m_MapUnits = map.MapUnits;
            this.m_ReferenceScale = map.ReferenceScale;
            this.m_DistanceUnits = map.DistanceUnits;
            this.m_SelectionCount = map.SelectionCount;
            this.m_UseSymbolLevels = map.UseSymbolLevels;

        }

        [CategoryAttribute("Informations of the Map"), DefaultValueAttribute(true)]
        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
                m_Map.Name = m_Name;
            }
        }

        [CategoryAttribute("Informations of the Map"), DefaultValueAttribute(true)]
        public string Description
        {
            get { return m_Description; }

            set
            {
                m_Description = value;
                m_Map.Description = m_Description;
            }
        }

        [CategoryAttribute("Informations of the Map"), DefaultValueAttribute(true)]
        public double ReferenceScale
        {
            get { return m_ReferenceScale; }
            set
            {
                m_ReferenceScale = value;
                m_Map.ReferenceScale = m_ReferenceScale;
            }
        }

        [CategoryAttribute("Informations of the Map"), DefaultValueAttribute(true)]
        public ESRI.ArcGIS.esriSystem.esriUnits MapUnits
        {
            get { return m_MapUnits; }
            set
            {
                m_MapUnits = value;
                m_Map.MapUnits = m_MapUnits;
            }
        }

        [CategoryAttribute("Informations of the Map"), DefaultValueAttribute(true)]
        public ESRI.ArcGIS.esriSystem.esriUnits DistanceUnits
        {
            get { return m_DistanceUnits; }
            set
            {
                m_DistanceUnits = value;
                m_Map.DistanceUnits = m_DistanceUnits;
            }
        }


        [CategoryAttribute("Content of the Map"), DefaultValueAttribute(true)]
        public int LayerCount
        {
            get { return m_LayerCount; }

        }

        [CategoryAttribute("Content of the Map"), DefaultValueAttribute(true)]
        public int SelectionCount
        {
            get { return m_SelectionCount; }

        }

        [CategoryAttribute("Content of the Map"), DefaultValueAttribute(true)]
        public int MapsurroundCount
        {
            get { return m_MapsurroundCount; }

        }



        [CategoryAttribute("Others"), DefaultValueAttribute(true)]
        public bool UseSymbolLevels
        {
            get { return m_UseSymbolLevels; }
            set
            {
                m_UseSymbolLevels = value;
                m_Map.UseSymbolLevels = m_UseSymbolLevels;
            }
        }

        [CategoryAttribute("Others"), DefaultValueAttribute(true)]
        public bool Expanded
        {
            get { return m_Expanded; }
            set 
            { 
                m_Expanded = value;
                m_Map.Expanded = m_Expanded;
            }
        }

        [CategoryAttribute("Others"), DefaultValueAttribute(true)]
        public bool IsFramed
        {
            get { return m_IsFramed; }
            set 
            {
                m_IsFramed = value;
                m_Map.IsFramed = m_IsFramed;
            }
        }
    }
}
