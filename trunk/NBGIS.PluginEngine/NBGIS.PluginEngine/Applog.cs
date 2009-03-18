using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// 使用Log4net插件的Log日志对象
    /// </summary>
   public class Applog
    {
       /// <summary>
       /// Log4net日志静态类
       /// </summary>
       public static readonly log4net.ILog log = log4net.LogManager.GetLogger("NBGIS");
    }
}
