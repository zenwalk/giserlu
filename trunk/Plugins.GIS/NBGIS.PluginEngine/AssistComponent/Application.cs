using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;

namespace NBGIS.PluginEngine
{
    public class Application:IApplication
    {
        string m_Caption;
        string m_CurrentTool;
        DataSet m_MainDataSet;
        IMapDocument m_MapDocument;
        IMapControlDefault m_MapControl;
        IPageLayoutControlDefault m_PageLayoutControl;
        string m_Name;
        Form m_MainPlatform;
        Janus.Windows.UI.StatusBar.UIStatusBar m_StatusBar;
        bool m_Visible;
        IMap m_Map;
        //值类型和String类型在对Application对象发生改变后，不能将值传递给主程序
        //修改Caption、Name和Visible属性，它们都为值类型或是String类型

        #region IApplication 成员
        public IMap Map
        {
            get
            {
                return m_Map;
            }
            set
            {
                if (m_Map == value)
                    return;
                m_Map = value;
            }
        }
        public string Caption
        {
            
            //get
            //{
            //    return this.m_Caption;
            //}
            //set
            //{
            //    m_Caption = value;
            //}

            get
            {
                this.m_Caption = this.MainPlatform.Text;
                return m_Caption;
            }
            set
            {
                this.m_Caption = value;
                this.m_MainPlatform.Text = this.m_Caption;
            }
        }

        public string CurrentTool
        {
            get
            {
                return this.m_CurrentTool;
            }
            set
            {
                this.m_CurrentTool = value;
            }
        }

        public System.Data.DataSet MainDataSet
        {
            get
            {
                return this.m_MainDataSet;
            }
            set
            {
                m_MainDataSet = value;
            }
        }

        public ESRI.ArcGIS.Carto.IMapDocument Document
        {
            get
            {
                return  this.m_MapDocument;
            }
            set
            {
                this.m_MapDocument = value;
            }
        }

        public ESRI.ArcGIS.Controls.IMapControlDefault MapControl
        {
            get
            {
                return this.m_MapControl;
            }
            set
            {
                this.m_MapControl = value;
            }
        }

        public ESRI.ArcGIS.Controls.IPageLayoutControlDefault PageLayoutControl
        {
            get
            {
                return this.m_PageLayoutControl;
            }
            set
            {
                this.m_PageLayoutControl = value;
            }
        }

        public string Name
        {
            //get { return this.m_Name; }
            get
            {
                this.m_Name = this.m_MainPlatform.Name;
                return m_Name ;
            }
        }

        public System.Windows.Forms.Form MainPlatform
        {
            get
            {
                return this.m_MainPlatform ;
            }
            set
            {
                this.m_MainPlatform = value;
            }
        }

        public Janus.Windows.UI.StatusBar.UIStatusBar StatusBar
        {
            get
            {
                return this.m_StatusBar ;
            }
            set
            {
                this.m_StatusBar = value;
            }
        }

        public bool Visible
        {
            //get
            //{
            //    return this.m_Visible;
            //}
            //set
            //{
            //    this.m_Visible = value;
            //}

            get
            {
                this.m_Visible = this.m_MainPlatform.Visible;
                return this.m_Visible;
            }
            set
            {
                this.m_Visible = value;
                this.m_MainPlatform.Visible = this.m_Visible;
            }
        }

        #endregion
    }
}
