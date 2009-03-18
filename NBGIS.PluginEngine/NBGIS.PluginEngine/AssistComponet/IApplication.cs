using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
//using ESRI.ArcGIS.esriSystem; 找不到这个引用 
using Janus.Windows.UI.StatusBar;//Janus控件
using System.Data;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// IApplication接口定义了宿主程序的属性
    /// </summary>
   public interface IApplication
    {
       /// <summary>
       /// 主程序标题
       /// </summary>
       string Caption { get; set;}

       /// <summary>
       /// 主程序当前使用工具名称
       /// </summary>
       string CurrentTool { get;set;}

       /// <summary>
       /// 主程序存储GIS数据的数据集
       /// </summary>
       DataSet MainDataSet { get;set;}

       /// <summary>
       /// 主程序包含的地图文档对象
       /// </summary>
       IMapDocument Document { get;set;}


       /// <summary>
       /// 主程序中的MapControl对象
       /// </summary>
       IMapControlDefault MapControl { get;set;}
        
       /// <summary>
       /// 主程序中的PageLayoutControl对象
       /// </summary>
       IPageLayoutControlDefault PageLayoutControl { get;set;}

       /// <summary>
       /// 主程序名称
       /// </summary>
       string Name { get;}

       /// <summary>
       /// 主程序窗体对象
       /// </summary>
       Form MainPlatForm { get; set;}

       /// <summary>
       /// 主程序窗体中的状态栏
       /// </summary>
       UIStatusBar StatusBar { get;set;}

       /// <summary>
       /// 主程序UI界面的Visible属性
       /// </summary>
       bool Visible { get;set;}
    }
}
