using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///  该接口与AO库中的ICommand接口
    /// Bitmap属性返回的是Bitmap对象而非资源号
    /// </summary>
   public interface ICommand:NBGIS.PluginEngine.IPlugin
    {
       /// <summary>
       /// 命令按钮图标
       /// </summary>
       Bitmap Bitmap { get;}

       /// <summary>
       /// 命令按钮的文字
       /// </summary>
       string Caption { get;}

       /// <summary>
       /// 命令按钮所属类别
       /// </summary>
       string Category { get;}

       /// <summary>
       /// 命令按钮是否被选中
       /// </summary>
       bool Checked { get;}

       /// <summary>
       /// 命令按钮是否可用
       /// </summary>
       bool Enabled { get;}

       /// <summary>
       /// 快捷帮助ID
       /// </summary>
       int HelpContexID { get;}

       /// <summary>
       /// 帮助文件路径
       /// </summary>
       string HelpFile { get;}

       /// <summary>
       /// 鼠标移到按钮上时状态栏出现文字
       /// </summary>
       string Message { get;}

       /// <summary>
       /// 按钮名称
       /// </summary>
       string Name { get;}

       /// <summary>
       /// 按钮点击时触发方法
       /// </summary>
       void OnClick();

       /// <summary>
       /// 按钮创建时触发方法
       /// </summary>
       /// <param name="hook">宿主程序对象hook,与框架程序进行信息交互</param>
       void OnCreate(NBGIS.PluginEngine.IApplication hook);

       /// <summary>
       /// 鼠标移到按钮上时出现文字
       /// </summary>
       string Tooltip { get;}
    }
}
