using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///  �ýӿ���AO���е�ICommand�ӿ�
    /// Bitmap���Է��ص���Bitmap���������Դ��
    /// </summary>
   public interface ICommand:NBGIS.PluginEngine.IPlugin
    {
       /// <summary>
       /// ���ťͼ��
       /// </summary>
       Bitmap Bitmap { get;}

       /// <summary>
       /// ���ť������
       /// </summary>
       string Caption { get;}

       /// <summary>
       /// ���ť�������
       /// </summary>
       string Category { get;}

       /// <summary>
       /// ���ť�Ƿ�ѡ��
       /// </summary>
       bool Checked { get;}

       /// <summary>
       /// ���ť�Ƿ����
       /// </summary>
       bool Enabled { get;}

       /// <summary>
       /// ��ݰ���ID
       /// </summary>
       int HelpContexID { get;}

       /// <summary>
       /// �����ļ�·��
       /// </summary>
       string HelpFile { get;}

       /// <summary>
       /// ����Ƶ���ť��ʱ״̬����������
       /// </summary>
       string Message { get;}

       /// <summary>
       /// ��ť����
       /// </summary>
       string Name { get;}

       /// <summary>
       /// ��ť���ʱ��������
       /// </summary>
       void OnClick();

       /// <summary>
       /// ��ť����ʱ��������
       /// </summary>
       /// <param name="hook">�����������hook,���ܳ��������Ϣ����</param>
       void OnCreate(NBGIS.PluginEngine.IApplication hook);

       /// <summary>
       /// ����Ƶ���ť��ʱ��������
       /// </summary>
       string Tooltip { get;}
    }
}
