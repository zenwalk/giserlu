using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
//using ESRI.ArcGIS.esriSystem; 找不到这个引用 
using Janus.Windows.UI.StatusBar;//Janus控件
using System.Data;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// IApplication接口的实现
    /// </summary>
    public class Application:IApplication
    {
        string _Caption;
        string _CurrentTool;
        DataSet _MainDataSet;
        IMapDocument _Document;
        IMapControlDefault _MapControl;
        IPageLayoutControlDefault _PageLayoutControl;
        string _Name = String.Empty;
        Form _MainPlatform;
        UIStatusBar _StatusBar;
        bool _Visible;

        #region IApplication 成员

        public string Caption
        {
            get
            {
                return this._Caption;
            }
            set
            {
                this._Caption = value;
            }
        }

        public string CurrentTool
        {
            get
            {
                return this._CurrentTool;
            }
            set
            {
                this._CurrentTool=value;
            }
        }

        public DataSet MainDataSet
        {
            get
            {
                return this._MainDataSet;
            }
            set
            {
                this._MainDataSet = value;
            }
        }

        public IMapDocument Document
        {
            get
            {
                return this._Document;
            }
            set
            {
                this._Document = value;
            }
        }

        public IMapControlDefault MapControl
        {
            get
            {
                return this._MapControl;
            }
            set
            {
                this._MapControl = value;
            }
        }

        public IPageLayoutControlDefault PageLayoutControl
        {
            get
            {
                return this._PageLayoutControl;
            }
            set
            {
                this._PageLayoutControl = value;
            }
        }

        public string Name
        {
            get { return this._Name; }
        }

        public Form MainPlatForm
        {
            get
            {
                return this._MainPlatform;
            }
            set
            {
                this._MainPlatform = value;
            }
        }

        public UIStatusBar StatusBar
        {
            get
            {
                return this._StatusBar;
            }
            set
            {
                this._StatusBar = value;
            }
        }

        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this._Visible = value;
            }
        }

        #endregion
    }
}
