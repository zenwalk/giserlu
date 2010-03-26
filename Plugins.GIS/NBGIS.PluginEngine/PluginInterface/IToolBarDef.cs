using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 定义一个工具栏
    /// </summary>
    public interface IToolBarDef:NBGIS.PluginEngine.IPlugin
    {
        /// <summary>
        /// 工具栏标题
        /// </summary>
        string  Caption { get;  }

        /// <summary>
        /// 工具栏名称
        /// </summary>
        string  Name { get;  }

        /// <summary>
        /// 工具栏携带的Item数量
        /// </summary>
        int ItemCount { get;  }

        /// <summary>
        /// 返回工具栏上指定Item的信息
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="itemDef"></param>
        void GetItemInfo(int pos,IItemDef itemDef);
        /// <summary>
        /// 是否可见
        /// </summary>
        bool IsVisible { get;}
    }
}
