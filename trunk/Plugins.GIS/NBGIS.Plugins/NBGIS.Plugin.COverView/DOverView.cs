using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.Plugin.COverView
{
    public class DOverView:NBGIS.PluginEngine.IDockableWindowDef
    {
        private FrmOverView frmOV = null;

        #region IDockableWindowDef 成员

        public string Caption
        {
            get { return "Over View"; }
        }

        public System.Windows.Forms.Control ChildHWND
        {
            get { return frmOV.axMapControl; }
        }

        public string Name
        {
            get { return"OverView"; }
        }

        public void OnCreate(NBGIS.PluginEngine.IApplication hook)
        {
            frmOV = new FrmOverView();
            if (hook != null)
            {
                frmOV.Hook = hook;
            }
        }

        public object UserData
        {
            get { return null; }
        }

        public bool IsVisible
        {
            get { return false; }
        }
        #endregion
    }
}
