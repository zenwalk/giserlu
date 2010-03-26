using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NBGIS.MainGIS
{
   /// <summary>
    ///重新对ILayer对象进行封装，用于PropertyGrid显示
    /// </summary>
    public class LayerInfo
    {
        private ESRI.ArcGIS.Carto.ILayer m_Layer;


        private string m_Name;
        private bool m_Cached;
        private double m_MaximumScale;
        private double m_MinimumScale;

        private bool m_ShowTips;
        private int m_SupportedDrawPhases;
        private bool m_Visible;
        private bool m_Valid;



        [CategoryAttribute("Informations of the Layer"), DefaultValueAttribute(true)]
        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
                this.m_Layer.Name = m_Name;
            }
        }

        [CategoryAttribute("Informations of the Layer"), DefaultValueAttribute(true)]
        public double MaximumScale
        {
            get
            {
                return m_MaximumScale;
            }

            set
            {
                m_MaximumScale = value;
                this.m_Layer.MaximumScale = m_MaximumScale;
            }
        }

        [CategoryAttribute("Informations of the Layer"), DefaultValueAttribute(true)]
        public double MinimumScale
        {
            get { return m_MinimumScale; }
            set
            {
                m_MinimumScale = value;
                this.m_Layer.MinimumScale = m_MinimumScale;
            }
        }

        [CategoryAttribute("Informations of the Layer"), DefaultValueAttribute(true)]
        public bool Cached
        {
            get { return m_Cached; }

        }


        [CategoryAttribute("Informations of the Others"), DefaultValueAttribute(true)]
        public bool ShowTips
        {
            get { return m_ShowTips; }
            set { 
                m_ShowTips = value;
                m_Layer.ShowTips = m_ShowTips;
            }
        }

        [CategoryAttribute("Informations of the Others"), DefaultValueAttribute(true)]
        public int SupportedDrawPhases
        {
            get { return m_SupportedDrawPhases; }
           
        }

        [CategoryAttribute("Informations of the Others"), DefaultValueAttribute(true)]
        public bool Valid
        {
            get { return m_Valid; }
           
        }

        [CategoryAttribute("Informations of the Others"), DefaultValueAttribute(true)]
        public bool Visible
        {
            get { return m_Visible; }
            set {
                m_Visible = value;
                m_Layer.Visible = m_Visible;
            }
        }

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="layer"></param>
        public LayerInfo(ESRI.ArcGIS.Carto.ILayer layer)
        {
            m_Layer = layer;
            m_Name = m_Layer.Name;
            m_MaximumScale = m_Layer.MaximumScale;
            m_MinimumScale = m_Layer.MinimumScale;
            m_Cached = m_Layer.Cached;
            m_ShowTips = m_Layer.ShowTips;
            m_SupportedDrawPhases = m_Layer.SupportedDrawPhases;
            m_Valid = m_Layer.Valid;
            m_Visible = m_Layer.Visible;
        }
















    }
}
