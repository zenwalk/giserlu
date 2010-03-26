using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.Plugin.TZoomOut
{
    class TZoomOut : NBGIS.PluginEngine.ITool
    {

        private NBGIS.PluginEngine.IApplication m_Application;
        private System.Drawing.Bitmap m_Bitmap;
        private ESRI.ArcGIS.SystemUI.ICommand m_Cmd;
        private ESRI.ArcGIS.SystemUI.ITool m_Tool;

        public TZoomOut()
        {
            //定义图标
            m_Bitmap =
                new System.Drawing.Bitmap(this.GetType().Assembly.GetManifestResourceStream("NBGIS.Plugin.TZoomOut.ZoomOut.ico"));
        }
        #region ITool 成员

        public void OnClick()
        {
           m_Cmd.OnClick();
            this.m_Application.MapControl.CurrentTool = m_Tool;
        }

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {
            if (hook != null)
            {

                this.m_Application = hook;
                m_Tool = new ESRI.ArcGIS.Controls.ControlsMapZoomOutToolClass();
                m_Cmd = m_Tool as ESRI.ArcGIS.SystemUI.ICommand;
                m_Cmd.OnCreate(this.m_Application.MapControl);
            }
        }
        public int Cursor
        {
            get
            {
                return (int)ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerZoomOut;
               
            }
        }

        public string Caption
        {
            get { return "Zoom Out"; }
        }
        public string Message
        {
            get { return Caption; }
        }

        public string Name
        {
            get { return "ZoomOut"; }
        }
        public string Category
        {
            get { return "MainTool"; }
        }
        public string Tooltip
        {
            get { return Caption; }
        }

        public System.Drawing.Bitmap Bitmap
        {
            get { return m_Bitmap; }
        }
        public bool Checked
        {
            get { return false; ; }
        }



        public bool Deactivate()
        {
            return false; ;
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


        public bool OnContextMenu(int x, int y)
        {
            return false;
        }



        public void OnDblClick()
        {

        }

        public void OnKeyDown(int keyCode, int shift)
        {

        }

        public void OnKeyUp(int keyCode, int shift)
        {

        }

        public void OnMouseDown(int button, int shift, int x, int y)
        {

        }

        public void OnMouseMove(int button, int shift, int x, int y)
        {

        }

        public void OnMouseUp(int button, int shift, int x, int y)
        {

        }

        public void Refresh(int hDC)
        {

        }



        #endregion
    }
}
