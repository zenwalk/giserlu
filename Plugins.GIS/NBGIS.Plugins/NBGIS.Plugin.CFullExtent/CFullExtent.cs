using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.Plugin.CFullExtent
{
    class CFullExtent : NBGIS.PluginEngine.ICommand
    {

        private NBGIS.PluginEngine.IApplication m_Application;
        private System.Drawing.Bitmap m_Bitmap = null;
        private ESRI.ArcGIS.SystemUI.ICommand m_CMD = null;

        public CFullExtent()
        {
            //定义图标
            m_Bitmap =
                new System.Drawing.Bitmap(this.GetType().Assembly.GetManifestResourceStream("NBGIS.Plugin.CFullExtent.FullExtent.bmp"));
        }
        #region ICommand 成员

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {

            if (hook != null)
            {
                this.m_Application = hook;
                //添加代码
                m_CMD = new ESRI.ArcGIS.Controls.ControlsMapFullExtentCommandClass();
               m_CMD.OnCreate(this.m_Application.MapControl);
            }
        }
        public void OnClick()
        {
            m_CMD.OnClick();
        }

        //定义标题
        public string Caption
        {
            get { return "Full Extent"; }
        }
        //定义名称
        public string Name
        {
            get { return "FullExtent"; }
        }
        //定义命令分类目录
        public string Category
        {
            get { return "MainTool"; }
        }

        public string Message
        {
            get { return Caption; }
        }

        public string Tooltip
        {
            get { return Caption; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }
        public System.Drawing.Bitmap Bitmap
        {
            get { return m_Bitmap; }
        }

        public int HelpContextID
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }


        #endregion
    }
}
