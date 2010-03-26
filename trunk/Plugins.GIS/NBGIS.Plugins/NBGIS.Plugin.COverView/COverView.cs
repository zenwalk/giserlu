using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.Plugin.COverView
{
    class COverView : NBGIS.PluginEngine.ICommand
    {

        private NBGIS.PluginEngine.IApplication m_Application;
        private System.Drawing.Bitmap m_Bitmap = null;
       
        public COverView()
        {
            //定义图标
            m_Bitmap =
                new System.Drawing.Bitmap(this.GetType().Assembly.GetManifestResourceStream("NBGIS.Plugin.COverView.NoIco.bmp"));
        }
        #region ICommand 成员

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {

            if (hook != null)
            {
                this.m_Application = hook;
               
            }
        }
        public void OnClick()
        {
            DOverView d = new DOverView();
            NBGIS.PluginEngine.CreateUI.CreateUIDockableWindow(d);
        }

        //定义标题
        public string Caption
        {
            get { return "Over View"; }
        }
        //定义名称
        public string Name
        {
            get { return "OVerView"; }
        }
        //定义命令分类目录
        public string Category
        {
            get { return "Unclassfied"; }
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
