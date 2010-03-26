using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.Plugin.TPan
{
    class TPan : NBGIS.PluginEngine.ITool
    {
        private NBGIS.PluginEngine.IApplication m_Application;
        private System.Drawing.Bitmap m_Bitmap;
        //private ESRI.ArcGIS.Carto.IActiveView m_ActiveView;
        private ESRI.ArcGIS.SystemUI.ICommand m_Cmd;
        private ESRI.ArcGIS.SystemUI.ITool m_Tool;

        public TPan()
        {
            m_Bitmap = new System.Drawing.Bitmap(this.GetType().Assembly.GetManifestResourceStream("NBGIS.Plugin.TPan.TPan.ico"));
        }
        #region ITool 成员

        public System.Drawing.Bitmap Bitmap
        {
            get { return m_Bitmap; }
        }

        public string Caption
        {
            get { return "Pan"; }
        }

        public string Category
        {
            get { return "MainTool"; }
        }

        public bool Checked
        {
            get { return false; ; }
        }

        public int Cursor
        {
            get { return (int)ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerPan; }
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

        public string Message
        {
            get { return "Pan"; }
        }

        public string Name
        {
            get { return "Pan"; }
        }

        public void OnClick()
        {
            m_Cmd.OnClick();
            this.m_Application.MapControl.CurrentTool = m_Tool;
        }

        public bool OnContextMenu(int x, int y)
        {
            return false;
        }

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {
            if (hook != null)
            {
                this.m_Application = hook;
                m_Tool = new ESRI.ArcGIS.Controls.ControlsMapPanToolClass();
                m_Cmd = m_Tool as ESRI.ArcGIS.SystemUI.ICommand;
                m_Cmd.OnCreate(this.m_Application.MapControl);
            }
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
            //m_ActiveView = m_Application.MapControl.ActiveView;
            //m_Application.MapControl.Pan();

            //ESRI.ArcGIS.esriSystem.ITrackCancel pTrackCancel = new ESRI.ArcGIS.Display.CancelTrackerClass();
            //m_ActiveView.Draw(0, pTrackCancel);

            //if(pTrackCancel.Continue())
            //{
            //    m_Application.StatusBar.Panels[0].Text = "Map drawing...";
            //}
            //else
            //{
            //    m_Application.StatusBar.Panels[0].Text ="Drawing finish";
            //}
            //m_ActiveView.Refresh();
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

        public string Tooltip
        {
            get { return "Pan"; }
        }

        #endregion
    }
}
