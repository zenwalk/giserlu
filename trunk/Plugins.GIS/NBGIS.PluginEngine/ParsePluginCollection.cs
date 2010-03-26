using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 解析插件容器中插件对象，将其分别放置在不同的集合中
    /// </summary>
    public class ParsePluginCollection
    {
        //四种插件类型集合
        private static Dictionary<string, NBGIS.PluginEngine.ICommand> m_Commands = new Dictionary<string, ICommand>();
        private static Dictionary<string, NBGIS.PluginEngine.ITool> m_Tools = new Dictionary<string, ITool>();
        private static Dictionary<string, NBGIS.PluginEngine.IToolBarDef> m_ToolBars = new Dictionary<string, IToolBarDef>();
        private static Dictionary<string, NBGIS.PluginEngine.IMenuDef> m_Menus = new Dictionary<string, IMenuDef>();
        private static Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> m_DockableWindows = new Dictionary<string, IDockableWindowDef>();

        //命令类型集合
        private static ArrayList m_CommandCategory = new ArrayList();

        public ParsePluginCollection()
        {
            m_Commands = new Dictionary<string, ICommand>();
            m_ToolBars = new Dictionary<string, IToolBarDef>();
            m_Tools = new Dictionary<string, ITool>();
            m_Menus = new Dictionary<string, IMenuDef>();
            m_DockableWindows = new Dictionary<string, IDockableWindowDef>();

            m_CommandCategory = new ArrayList();
        }

        
        public static Dictionary<string,NBGIS.PluginEngine.ICommand> GetCommands
        {
            get { return m_Commands; }
            
        }
        public static Dictionary<string, NBGIS.PluginEngine.ITool> GetTools
        {
            get { return m_Tools; }
            
        }
        public static Dictionary<string, NBGIS.PluginEngine.IToolBarDef> GetToolBars
        {
            get { return m_ToolBars; }
            
        }
        public static Dictionary<string, NBGIS.PluginEngine.IMenuDef> GetMenus
        {
            get { return m_Menus; }
          
        }
        public static Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> GetDockableWindows
        {
            get { return m_DockableWindows; }
            
        }

        public static ArrayList GetCommandsCategorys
        {
            get
            {
                return m_CommandCategory;
            }
        }

        //解析插件集合中所有对象
        //将其分别装入ICommand、ITool、IToolBarDef、IMenuDef和IDockableWindows5个集合
        public static void  GetPluginArray(PluginCollection pluginCol)
        {
            foreach (NBGIS.PluginEngine.IPlugin plugin in pluginCol)
            {
                /////////////////
                NBGIS.PluginEngine.ICommand cmd = plugin as NBGIS.PluginEngine.ICommand;
                if (cmd != null)
                {
                   m_Commands.Add(cmd.ToString(), cmd);
                    //找出该Command的Category，如果它没有添加到Category中则添加 
                    if (cmd.Category != null && (!m_CommandCategory.Contains(cmd.Category)))
                    {
                        m_CommandCategory.Add(cmd.Category);
                    }
                    continue;
                }
                ////////////////
                NBGIS.PluginEngine.ITool tool = plugin as NBGIS.PluginEngine.ITool;
                if (tool != null)
                {
                    m_Tools.Add(tool.ToString(), tool);
                    if (tool.Category != null && (!m_CommandCategory.Contains(tool.Category)))
                    {
                        m_CommandCategory.Add(tool.Category);
                    }
                    continue;
                }

                ////////////////
                NBGIS.PluginEngine.IToolBarDef toolbar = plugin as NBGIS.PluginEngine.IToolBarDef;
                if (toolbar != null)
                {
                    m_ToolBars.Add(toolbar.ToString(), toolbar);
                    continue;
                }
                ////////////////
                NBGIS.PluginEngine.IMenuDef menu = plugin as NBGIS.PluginEngine.IMenuDef;
                if(menu!=null)
                {
                    m_Menus.Add(menu.ToString(), menu);
                    continue;
                }
                ////////////////
                NBGIS.PluginEngine.IDockableWindowDef dockableWindow = plugin as NBGIS.PluginEngine.IDockableWindowDef;
                if(dockableWindow!=null)
                {
                   m_DockableWindows.Add(dockableWindow.ToString(), dockableWindow);
                    continue;
                }
            }
        }
    }
}
