using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ������������еĲ�����󣬽���ֱ�����ڲ�ͬ�ļ�����
    /// </summary>
  public  class ParsePluginCollection
    {
       //Command����
      private Dictionary<string, NBGIS.PluginEngine.ICommand> _Commands;
      //Tools����
      private Dictionary<string, NBGIS.PluginEngine.ITool> _Tools;
      //ToolBar����
      private Dictionary<string,NBGIS.PluginEngine.IToolBarDef> _ToolBars;
      //Menu����
      private Dictionary<string, NBGIS.PluginEngine.IMenuDef> _Menus;
      //DockableWindow����
      private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> _DockableWindows;
      //�������ͼ���
      private ArrayList _CommandCategory;

      public ParsePluginCollection()
      {
          //��ʼ�����еļ�������
          this._Commands = new Dictionary<string, ICommand>();
          this._Tools = new Dictionary<string, ITool>();
          this._ToolBars = new Dictionary<string, IToolBarDef>();
          this._Menus = new Dictionary<string, IMenuDef>();
          this._DockableWindows = new Dictionary<string, IDockableWindowDef>();
          this._CommandCategory = new ArrayList();
      }

      public Dictionary<string, NBGIS.PluginEngine.ICommand> GetCommands
      {
          get { return this._Commands; }
      }
      public Dictionary<string, NBGIS.PluginEngine.ITool> GetTools
      {
          get { return this._Tools; }
      }

      public Dictionary<string,NBGIS.PluginEngine.IToolBarDef> GetToolBars
      {
          get { return this._ToolBars; }
      }

      public Dictionary<string, NBGIS.PluginEngine.IMenuDef> GetMenus
      {
          get { return this._Menus; }
      }

      public Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> GetDockableWindows
      {
          get { return this._DockableWindows; }
      }

      public ArrayList GetCommandCategory
      {
          get { return this._CommandCategory; }
      }

      //����������������ж���
      //����ֱ�װ��ICommand��ITool��IToolBarDef��IMenuDef 4������
      public void GetPluginArray(PluginCollection pluginCol)
      {
          foreach(NBGIS.PluginEngine.IPlugin plugin in pluginCol)
          {
              NBGIS.PluginEngine.ICommand cmd = plugin as NBGIS.PluginEngine.ICommand;
              if (cmd != null)
              {
                  this._Commands.Add(cmd.ToString(), cmd);

                  //�ҳ���Command��Category,�����û����ӵ�Category�������
                  if (cmd.Category != null && _CommandCategory.Contains(cmd.Category) == false)
                  {
                      _CommandCategory.Add(cmd.Category);
                  }
                  continue;
              }

              NBGIS.PluginEngine.ITool tool = plugin as NBGIS.PluginEngine.ITool;
              if (tool != null)
              {
                  this._Tools.Add(tool.ToString(), tool);

                  if (tool.Category != null && _CommandCategory.Contains(tool.Category) == false)
                  {
                      _CommandCategory.Add(tool.Category);
                  }
                  continue;
              }

              NBGIS.PluginEngine.IToolBarDef toolbardef = plugin as NBGIS.PluginEngine.IToolBarDef;
              if (toolbardef != null)
              {
                  this._ToolBars.Add(toolbardef.ToString(), toolbardef);
                  continue;
              }


              NBGIS.PluginEngine.IMenuDef menudef = plugin as NBGIS.PluginEngine.IMenuDef;
              if (menudef != null)
              {
                  this._Menus.Add(menudef.ToString(), menudef);
                  continue;
              }

              NBGIS.PluginEngine.IDockableWindowDef dockablewindowdef = plugin as NBGIS.PluginEngine.IDockableWindowDef;
              if (dockablewindowdef != null)
              {
                  this._DockableWindows.Add(dockablewindowdef.ToString(), dockablewindowdef);
                  continue;
              }
             
          }

         
      }
    }
}
