using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace NBGIS.PluginEngine
{
   /// <summary>
   /// ���ݷ�����Ʋ���������󲢽���װ��������
   /// </summary>
   public class PluginHandle
    {
       private static readonly string pluginFolder = System.Windows.Forms.Application.StartupPath + "\\plugin";

       public static PluginCollection GetPluginsFormDll()
       {
           //�洢���������
           PluginCollection _PluginCol = new PluginCollection();

           if (!Directory.Exists(pluginFolder))
           {
               Directory.CreateDirectory(pluginFolder);
               if (Applog.log.IsDebugEnabled)
               {
                   Applog.log.Debug("plugin�ļ��в����ڣ�ϵͳ�Զ�����һ��");
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
                       //��ȡ�����ж��������
                       _types = _assembly.GetTypes();
                   }
                   catch (ReflectionTypeLoadException ex)
                   {
                       if (Applog.log.IsErrorEnabled)
                       {
                           Applog.log.Error("�������ͼ����쳣" + ex.Message);
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
                           //���һ����������ʵ�ֽӿ�
                           Type[] _interfaces = _type.GetInterfaces();
                           foreach (Type theInterface in _interfaces)
                           {
                               //�������ĳ�����ͣ�����ӵ�������϶�����
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
                   Applog.log.Error(_type.FullName + "�������ɶ���ʱ�����쳣"+"\n"+ex.Message);
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
