using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ITool接口仿AO并混合了AO中的ICommand接口和ITool接口
    /// </summary>
    interface ITool:NBGIS.PluginEngine.IPlugin
    {
        /// <summary>
        /// 工具按钮图标
        /// </summary>
        Bitmap Bitmap { get;}

        /// <summary>
        /// 工具按钮的文字
        /// </summary>
        string Caption { get;}

        /// <summary>
        /// 工具按钮所属类别
        /// </summary>
        string Category { get;}

        /// <summary>
        /// 工具按钮是否被选中
        /// </summary>
        bool Checked { get;}

        /// <summary>
        /// 工具按钮是否可用
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

        /// <summary>
        /// 鼠标在地图上的样式
        /// </summary>
        int Cursor { get;}

        /// <summary>
        /// 工具的激活状态设置
        /// </summary>
        /// <returns></returns>
        bool Deactivate();

        /// <summary>
        /// 鼠标双击地图时触发的事件
        /// </summary>
        void OnDblClick();

        /// <summary>
        /// 鼠标在点击右键快捷菜单时触发的事件
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool OnContextMenu(int x, int y);

        /// <summary>
        /// 鼠标在地图上移动时触发的事件
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseMove(int button, int shift, int x, int y);

        /// <summary>
        /// 鼠标点击地图进触发的事件
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseDown(int button, int shift, int x, int y);

        /// <summary>
        /// 鼠标在地图上弹起时触发的事件
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseUp(int button, int shift, int x, int y);

        /// <summary>
        /// 地图刷新时触发的事件
        /// </summary>
        /// <param name="hDC"></param>
        void Refresh(int hDC);

        /// <summary>
        /// 键盘某个按键点击时触发的事件
        /// </summary>
        /// <param name="KeyCode"></param>
        /// <param name="shift"></param>
        void OnKeyDown(int KeyCode, int shift);

        /// <summary>
        /// 键盘某个按键点击后弹起时触发的事件
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="shift"></param>
        void OnKeyUp(int keyCode, int shift);
    }
}
