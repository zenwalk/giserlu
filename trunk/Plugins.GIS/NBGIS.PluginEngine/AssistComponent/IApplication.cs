using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

using System.Windows.Forms;

namespace NBGIS.PluginEngine
{
    public interface IApplication
    {
        /// <summary>
        /// 主程序标题
        /// </summary>
         string Caption { get; set; }

        /// <summary>
        /// 主程序当前使用工具
        /// </summary>
         string  CurrentTool { get; set; }

          /// <summary>
          /// 主程序存储GIS数据的数据集
          /// </summary>
         DataSet MainDataSet { get; set; }
            
        /// <summary>
        /// 主程序包含的文档对象
        /// </summary>
         IMapDocument Document { get; set; }
        /// <summary>
        /// 主程序包含的IMap对象
        /// </summary>
         IMap Map { get; set; }
         IMapControlDefault MapControl { get; set; }

         IPageLayoutControlDefault PageLayoutControl { get; set; }

        /// <summary>
        /// 主程序名称
        /// </summary>
         string Name { get;  }

        /// <summary>
        /// 主程序窗体对象
        /// </summary>
         Form MainPlatform { get; set; }

        /// <summary>
        /// 主窗体中的状态栏
        /// </summary>
         Janus.Windows.UI.StatusBar.UIStatusBar StatusBar { get; set; }

        /// <summary>
        /// 主程序窗体的Visible属性
        /// </summary>
         bool Visible { get; set; }
    }

}
