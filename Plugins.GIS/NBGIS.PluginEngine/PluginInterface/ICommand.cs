using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ICommad 接口类似AO库中的ICommand接口
    /// Bitmap属性返回的是Bitmap对象而非资源号
    /// </summary>
    public interface ICommand:NBGIS.PluginEngine.IPlugin
    {
        /// <summary>
        /// 命令按钮的图标
        /// </summary>
        Bitmap Bitmap { get; }

        /// <summary>
        /// 命令按钮的文字
        /// </summary>
        string  Caption { get;}

        /// <summary>
        /// 命令按钮的目录
        /// </summary>
        string Category { get; }

        /// <summary>
        /// 命令按钮是否被选择
        /// </summary>
        bool Checked { get;  }

        /// <summary>
        /// 命令按钮是否可用
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 快捷帮助ID
        /// </summary>
        int HelpContextID { get; }

        /// <summary>
        /// 帮助文件路径
        /// </summary>
        string  HelpFile { get; }

        /// <summary>
        /// 鼠标移动到按钮上时状态栏出现的文字
        /// </summary>
        string  Message { get; }

        /// <summary>
        /// 按钮的名称
        /// </summary>
        string Name { get;}
        /// <summary>
        /// 鼠标移动到按钮上时弹出的文字
        /// </summary>
        string Tooltip { get; }

        /// <summary>
        /// 按钮点击时触发的方法
        /// </summary>
        void OnClick();

        /// <summary>
        /// 按钮产生时触发的方法 
        /// </summary>
        /// <param name="hook"></param>
        void OnCreate(NBGIS.PluginEngine.IApplication hook);
        
    }
}
