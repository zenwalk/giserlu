using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ��������ӿڶ���
    /// </summary>
    public interface IDockableWindowDef:IPlugin
    {
        /// <summary>
        /// �����������
        /// </summary>
        string Caption { get;}

        /// <summary>
        /// ����������ͣ�����ӿؼ�
        /// </summary>
        System.Windows.Forms.Control ChildHWND { get;}

        /// <summary>
        /// ������������
        /// </summary>
        string Name { get;}

        /// <summary>
        /// �������崴��ʱ�����ķ���
        /// </summary>
        /// <param name="hook"></param>
        void OnCreate(NBGIS.PluginEngine.IApplication hook);

        /// <summary>
        /// ��������ر�ʱ�����ķ���
        /// </summary>
        void OnDestroy();

        /// <summary>
        /// ���������������֮��ʤ�ڽ����Ķ��⸨�����ݶ���
        /// </summary>
        object UserData { get;}
    }
}
