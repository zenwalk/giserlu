using System;
using System.Collections.Generic;
using System.Text;
using log4net;
//����Log4Net������
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ʹ��Log4net�����Log��־����
    /// </summary>
   public class Applog
    {
       /// <summary>
       /// Log4net��־��̬��
       /// </summary>
       public static readonly log4net.ILog log = log4net.LogManager.GetLogger("NBGIS");
    }
}
