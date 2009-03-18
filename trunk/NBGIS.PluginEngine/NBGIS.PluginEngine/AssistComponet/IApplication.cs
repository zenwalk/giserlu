using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
//using ESRI.ArcGIS.esriSystem; �Ҳ���������� 
using Janus.Windows.UI.StatusBar;//Janus�ؼ�
using System.Data;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// IApplication�ӿڶ������������������
    /// </summary>
   public interface IApplication
    {
       /// <summary>
       /// ���������
       /// </summary>
       string Caption { get; set;}

       /// <summary>
       /// ������ǰʹ�ù�������
       /// </summary>
       string CurrentTool { get;set;}

       /// <summary>
       /// ������洢GIS���ݵ����ݼ�
       /// </summary>
       DataSet MainDataSet { get;set;}

       /// <summary>
       /// ����������ĵ�ͼ�ĵ�����
       /// </summary>
       IMapDocument Document { get;set;}


       /// <summary>
       /// �������е�MapControl����
       /// </summary>
       IMapControlDefault MapControl { get;set;}
        
       /// <summary>
       /// �������е�PageLayoutControl����
       /// </summary>
       IPageLayoutControlDefault PageLayoutControl { get;set;}

       /// <summary>
       /// ����������
       /// </summary>
       string Name { get;}

       /// <summary>
       /// �����������
       /// </summary>
       Form MainPlatForm { get; set;}

       /// <summary>
       /// ���������е�״̬��
       /// </summary>
       UIStatusBar StatusBar { get;set;}

       /// <summary>
       /// ������UI�����Visible����
       /// </summary>
       bool Visible { get;set;}
    }
}
