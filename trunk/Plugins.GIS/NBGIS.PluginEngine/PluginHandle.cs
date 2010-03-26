using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace NBGIS.PluginEngine
{
    public class PluginHandle
    {
        private static readonly string pluginFolder =
            System.Windows.Forms.Application.StartupPath + "\\plugin";

        public static PluginCollection GetPluginsFromDll()
        {
            //存储插件的容器
            PluginCollection pluginCol = new PluginCollection();
            //检测 插件文件夹是否存在，如果不存在则新建一个避免出现异常
            if (!Directory.Exists(pluginFolder))
            {
                Directory.CreateDirectory(pluginFolder);
                if (Applog.log.IsDebugEnabled)
                {
                    Applog.log.Debug("plugin文件夹不存在，系统自动建立一个");
                }
            }
            //获得插件文件夹中每一个dll文件
            string[] files = Directory.GetFiles(pluginFolder, "*.dll");
            foreach (string file in files)
            {
                //从Dll文件中加载程序集
                Assembly assembly = Assembly.LoadFrom(file);
                if (assembly != null)
                {
                    Type[] types = null;
                    try
                    {
                        //获取程序集中定义的类型
                        types = assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        if (Applog.log.IsErrorEnabled)
                        {
                            Applog.log.Error("反射类型加载异常");
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
                        foreach (Type type in types)
                        {
                            //获得一个类型所有实现的接口
                            Type[] interfaces = type.GetInterfaces();
                            //遍历接口类型
                            foreach(Type theInterface in interfaces)
                                {
                                	//如果满足某种类型，则添加到插件集合对象中
                                    switch (theInterface.FullName)
                                    {
                                        case "NBGIS.PluginEngine.ICommand":
                                        case "NBGIS.PluginEngine.ITool":
                                        case "NBGIS.PluginEngine.IMenuDef":
                                        case "NBGIS.PluginEngine.IToolBarDef":
                                        case "NBGIS.PluginEngine.IDockableWindowDef":
                                            GetPluginObject(pluginCol, type);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                        }
                     
                    }
                }
            }
            return pluginCol;
        }

        private static void GetPluginObject(PluginCollection pluginCol, Type type)
        {
            IPlugin plugin = null;
            try
            {
                plugin = Activator.CreateInstance(type) as NBGIS.PluginEngine.IPlugin;
            }
            catch (Exception ex)
            {
                if (Applog.log.IsErrorEnabled)
                {
                    Applog.log.Error(type.FullName + "反射生成对象时发生异常"+"Message"+ex.Message);
                }
            }
            finally
                {
                	if(plugin!=null)
                    {
                        if(!pluginCol.Contains(plugin))
                        {
                            pluginCol.Add(plugin);
                        }
                    }
                }
        }
    }
}
