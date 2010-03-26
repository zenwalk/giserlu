using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.Plugin.MainTools
{
    class TMainTools : NBGIS.PluginEngine.IToolBarDef
    {

        #region IToolBarDef 成员

        public string Caption
        {
            get { return "MainTools"; }
        }

        public int ItemCount
        {
            get { return 5; }
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

        public string Name
        {
            get { return Caption; }
        }

        public bool IsVisible
        {
            get { return false; }
        }
        #endregion

       
    }
}
