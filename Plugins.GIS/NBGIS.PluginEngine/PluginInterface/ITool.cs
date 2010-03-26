using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ITool接口中混合了AO中的ICommand接口和ITool接口
    /// </summary>
    public interface ITool:NBGIS.PluginEngine.IPlugin
    {
        Bitmap Bitmap { get; }
        string Caption { get; }
        string  Category { get; }
        bool Checked { get;  }
        bool Enabled { get; }
         int  HelpContextID { get;  }
         string HelpFile { get; }
         string Message { get;  }
         string Name { get; }
         void OnClick();
         void OnCreate(NBGIS.PluginEngine.IApplication hook);
         string Tooltip { get; }
        /// <summary>
        /// 鼠标在地图上样式
        /// </summary>
         int  Cursor { get; }

        /// <summary>
        /// Tool的激活状态设置
        /// </summary>
        /// <returns></returns>
         bool Deactivate();

        /// <summary>
        /// 鼠标点右键弹出快捷菜单时触发的事件
        /// </summary>
        /// <param name="x"></param>
        /// <param name="?"></param>
         bool OnContextMenu(int x,int y);

         void OnDblClick();
        void OnMouseMove(int button , int shift,int x,int y);
        void OnMouseDown(int button,int shift,int x,int y);
        void OnMouseUp(int button ,int shift,int x,int y);

        /// <summary>
        /// 地图刷新时触发的事件
        /// </summary>
        /// <param name="hDC"></param>
        void Refresh(int hDC);


        void OnKeyDown(int keyCode, int shift);
        void OnKeyUp(int keyCode,int shift);

    }
}
