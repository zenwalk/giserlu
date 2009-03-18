using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// Item������
    /// </summary>
   public class ItemDef:IItemDef
    {

        bool _Group;
        string _ID;
        long _SubType;

        #region IItemDef ��Ա

        public bool Group
        {
            get
            {
                return this._Group;
            }
            set
            {
                this._Group = value;
            }
        }

        public string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public long Subtype
        {
            get
            {
                return this._SubType;
            }
            set
            {
                this._SubType = value;
            }
        }

        #endregion
    }
}
