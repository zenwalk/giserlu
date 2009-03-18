using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ITool�ӿڷ�AO�������AO�е�ICommand�ӿں�ITool�ӿ�
    /// </summary>
    interface ITool:NBGIS.PluginEngine.IPlugin
    {
        /// <summary>
        /// ���߰�ťͼ��
        /// </summary>
        Bitmap Bitmap { get;}

        /// <summary>
        /// ���߰�ť������
        /// </summary>
        string Caption { get;}

        /// <summary>
        /// ���߰�ť�������
        /// </summary>
        string Category { get;}

        /// <summary>
        /// ���߰�ť�Ƿ�ѡ��
        /// </summary>
        bool Checked { get;}

        /// <summary>
        /// ���߰�ť�Ƿ����
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

        /// <summary>
        /// ����ڵ�ͼ�ϵ���ʽ
        /// </summary>
        int Cursor { get;}

        /// <summary>
        /// ���ߵļ���״̬����
        /// </summary>
        /// <returns></returns>
        bool Deactivate();

        /// <summary>
        /// ���˫����ͼʱ�������¼�
        /// </summary>
        void OnDblClick();

        /// <summary>
        /// ����ڵ���Ҽ���ݲ˵�ʱ�������¼�
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool OnContextMenu(int x, int y);

        /// <summary>
        /// ����ڵ�ͼ���ƶ�ʱ�������¼�
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseMove(int button, int shift, int x, int y);

        /// <summary>
        /// �������ͼ���������¼�
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseDown(int button, int shift, int x, int y);

        /// <summary>
        /// ����ڵ�ͼ�ϵ���ʱ�������¼�
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseUp(int button, int shift, int x, int y);

        /// <summary>
        /// ��ͼˢ��ʱ�������¼�
        /// </summary>
        /// <param name="hDC"></param>
        void Refresh(int hDC);

        /// <summary>
        /// ����ĳ���������ʱ�������¼�
        /// </summary>
        /// <param name="KeyCode"></param>
        /// <param name="shift"></param>
        void OnKeyDown(int KeyCode, int shift);

        /// <summary>
        /// ����ĳ�������������ʱ�������¼�
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="shift"></param>
        void OnKeyUp(int keyCode, int shift);
    }
}
