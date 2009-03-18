using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace NBGIS.PluginEngine
{
   /// <summary>
   /// 根据反射机制产生插件对象并将其装入插件容器
   /// </summary>
   public class PluginHandle
    {
       private static readonly string pluginFolder = System.Windows.Forms.Application.StartupPath + "\\plugin";

       public static PluginCollection GetPluginsFormDll()
       {
           //存储插件的容器
           PluginCollection _PluginCol = new PluginCollection();

           if (!Directory.Exists(pluginFolder))
           {
               Directory.CreateDirectory(pluginFolder);
               if (Applog.log.IsDebugEnabled)
               {
                   Applog.log.Debug("plugin文件夹不存在，系统自动建立一个");
               }
           }


           string[] _files = Directory.GetFiles(pluginFolder, "*.dll");
           foreach (string _file in _files)
           {
               Assembly _assembly = Assembly.LoadFrom(_file);
               if (_assembly != null)
               {
                   Type[] _types = null;
                   try
                   {
                       //获取程序集中定义的类型
                       _types = _assembly.GetTypes();
                   }
                   catch (ReflectionTypeLoadException ex)
                   {
                       if (Applog.log.IsErrorEnabled)
                       {
                           Applog.log.Error("反射类型加载异常" + ex.Message);
                       }
                   }
                   catch (Exception ex)
                   {
                       if (Applog.log.IsErrorEnabled)
                       {
                           Applog.log.Error(ex.Message);
                       }
                   }
                   finally
                   {
                       foreach (Type _type in _types)
                       {
                           //获得一个类型所有实现接口
                           Type[] _interfaces = _type.GetInterfaces();
                           foreach (Type theInterface in _interfaces)
                           {
                               //如果满足某种类型，则添加到插件集合对象中
                               switch (theInterface.FullName)
                               {
                                   case "NBGIS.PluginEngine.ICommand":
                                   case "NBGIS.PluginEngine.ITool":
                                   case "NBGIS.PluginEngine.IMenuDef":
                                   case "NBGIS.PluginEngine.IToolBarDef":
                                   case "NBGIS.PluginEngine.IDockableWindowDef":

                                       GetPluginObject(_PluginCol, _type);
                                       break;

                                   default:
                                       break;
                               }
                           }
                       }
                   }
               }
              
           }
           return _PluginCol;
       }

       private static void GetPluginObject(PluginCollection PluginCol, Type _type)
       {
           IPlugin plugin = null;
           try
           {
               plugin = Activator.CreateInstance(_type) as NBGIS.PluginEngine.IPlugin;
           }
           catch (Exception ex)
           {
               if (Applog.log.IsErrorEnabled)
               {
                   Applog.log.Error(_type.FullName + "反射生成对象时发生异常"+"\n"+ex.Message);
               }
           }

           finally
           {
               if (plugin != null)
               {
                   if (!PluginCol.Contains(plugin))
                   {
                       PluginCol.Add(plugin);
                   }
               }
           }
       }
    }
}
