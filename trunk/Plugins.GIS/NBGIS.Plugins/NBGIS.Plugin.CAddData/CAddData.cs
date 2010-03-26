using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.Plugin.CAddData
{
    class CAddData:NBGIS.PluginEngine.ICommand
    {

        private NBGIS.PluginEngine.IApplication m_Application;
        private System.Drawing.Bitmap m_Bitmap = null;

        private ESRI.ArcGIS.SystemUI.ICommand m_CMD = null;

        public CAddData()
        {
            m_Bitmap =
                new System.Drawing.Bitmap(this.GetType().Assembly.GetManifestResourceStream("NBGIS.Plugin.CAddData.AddData.bmp"));
        }
        #region ICommand 成员

        public System.Drawing.Bitmap Bitmap
        {
            get { return m_Bitmap; }
        }

        public string Caption
        {
            get { return "Add Data"; }
        }

        public string Category
        {
            get { return "MainTool"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextID
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "Add Data"; }
        }

        public string Name
        {
            get { return "AddData"; }
        }

        public void OnClick()
        {
            m_CMD.OnClick();
        }

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {

            if (hook != null)
            {

                this.m_Application = hook;
                m_CMD = new ESRI.ArcGIS.Controls.ControlsAddDataCommandClass();
                m_CMD.OnCreate(this.m_Application.MapControl);
            }
        }

        public string Tooltip
        {
            get { return "Add Data"; }
        }

        #endregion
    }
}
