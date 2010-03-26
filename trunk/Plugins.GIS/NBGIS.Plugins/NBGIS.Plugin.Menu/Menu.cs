using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.Plugin.Menu
{
    class Menu : NBGIS.PluginEngine.IMenuDef
    {


        #region IMenuDef 成员

        public string Caption
        {
            get { return "NewMenu(&N)"; }
        }

        public void GetItemInfo(int pos, NBGIS.PluginEngine.IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    {
                        itemDef.ID = "NBGIS.Plugin.CAddData";
                        itemDef.Group = false;
                        break;
                    }
                case 1:
                    {
                        itemDef.ID = "NBGIS.Plugin.CFullExtent";
                        itemDef.Group = true;

                        break;
                    }
                case 2:
                    {
                        itemDef.ID = "NBGIS.Plugin.TPan";
                        itemDef.Group = false;
                        break;
                    }
                case 3:
                    {
                        itemDef.ID = "NBGIS.Plugin.TZoomIn";
                        itemDef.Group = false;
                        break;
                    }
                case 4:
                    {
                        itemDef.ID = "NBGIS.Plugin.TZoomOut";
                        itemDef.Group = false;
                        break;
                    }
                default:
                    break;
            }
        }

        public Janus.Windows.UI.InheritableBoolean IsVisible
        {
            get { return Janus.Windows.UI.InheritableBoolean.True; }
        }

        public long ItemCount
        {
            get { return 5; }
        }

        public string Name
        {
            get { return Caption; }
        }

        #endregion
    }
}
