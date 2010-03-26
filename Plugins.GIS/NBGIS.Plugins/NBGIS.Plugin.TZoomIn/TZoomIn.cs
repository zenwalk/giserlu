using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.Plugin.TZoomIn
{
    class TZoomIn:NBGIS.PluginEngine.ITool
    {
        private NBGIS.PluginEngine.IApplication m_Application;
        private System.Drawing.Bitmap m_Bitmap;
        private ESRI.ArcGIS.SystemUI.ITool tool = null;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
       public TZoomIn()
           {
                   m_Bitmap = new System.Drawing.Bitmap(this.GetType().Assembly.GetManifestResourceStream("NBGIS.Plugin.TZoomIn.ZoomIn.ico"));
           }

       public System.Drawing.Bitmap Bitmap
       {
           get { return m_Bitmap; }
       }

       public string Caption
       {
           get { return "Zoom In"; }
       }

       public string Category
       {
           get { return "MainTool"; }
       }

       public bool Checked
       {
           get { return false ; }
       }

       public int Cursor
       {
           get { return (int)ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerZoomIn; }
       }

       public bool Deactivate()
       {
           return false; ;
       }

       public bool Enabled
       {
           get { return true ; }
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
           get { return "ZoomIn"; }
       }

       public string Name
       {
           get { return "ZoomIn"; }
       }

       public void OnClick()
       {
           cmd.OnClick();
           this.m_Application.MapControl.CurrentTool = tool;
       }

       public bool OnContextMenu(int x, int y)
       {
           return false; ;
       }

       public void OnCreate(NBGIS.PluginEngine.IApplication hook)
       {
           if(hook!=null)
           {
               this.m_Application = hook;
               tool = new ESRI.ArcGIS.Controls.ControlsMapZoomInToolClass();
               cmd = tool as ESRI.ArcGIS.SystemUI.ICommand;
               cmd.OnCreate(this.m_Application.MapControl);
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
           get { return "Zoom In"; }
       }
    }
}
