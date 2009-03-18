using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 浮动窗体接口定义
    /// </summary>
    public interface IDockableWindowDef:IPlugin
    {
        /// <summary>
        /// 浮动窗体标题
        /// </summary>
        string Caption { get;}

        /// <summary>
        /// 浮动窗体上停靠的子控件
        /// </summary>
        System.Windows.Forms.Control ChildHWND { get;}

        /// <summary>
        /// 浮动窗体名称
        /// </summary>
        string Name { get;}

        /// <summary>
        /// 浮动窗体创建时触发的方法
        /// </summary>
        /// <param name="hook"></param>
        void OnCreate(NBGIS.PluginEngine.IApplication hook);

        /// <summary>
        /// 浮动窗体关闭时触发的方法
        /// </summary>
        void OnDestroy();

        /// <summary>
        /// 浮动窗体与主框架之间胜于交互的额外辅助数据对象
        /// </summary>
        object UserData { get;}
    }
}
