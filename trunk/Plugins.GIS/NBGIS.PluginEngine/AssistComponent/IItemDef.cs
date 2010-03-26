using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 定义菜单栏和工具条中的命令项
    /// </summary>
    public interface IItemDef
    {
        /// <summary>
        /// 该Item是否属于一个新组
        /// </summary>
        bool Group { get; set; }

        /// <summary>
        /// Item的ID
        /// </summary>
        string ID { get; set; }

        /// <summary>
        /// Item的子类Command或Tool
        /// </summary>
        long Sybtype { get; set; }
    }
}
