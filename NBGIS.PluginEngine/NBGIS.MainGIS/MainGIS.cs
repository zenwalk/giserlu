using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NBGIS.PluginEngine;

namespace NBGIS.MainGIS
{
    public partial class MainGIS : Form
    {
        private ESRI.ArcGIS.Controls.IMapControlDefault _MapControl = null;
        private ESRI.ArcGIS.Controls.IPageLayoutControlDefault _PageLayoutControl = null;
        private ESRI.ArcGIS.Controls.ITOCControlDefault _TocControl = null;

        //��������
        private NBGIS.PluginEngine.IApplication _Application = null;
        //�����ͼ���ݵ�Dataset
        private DataSet _DataSet = null;
        //��ǰʹ�õĹ���
        private NBGIS.PluginEngine.ITool _Tool = null;


        private Dictionary<string, NBGIS.PluginEngine.ICommand> _CommandCol = null;
        private Dictionary<string, NBGIS.PluginEngine.ITool> _ToolCol = null;
        private Dictionary<string, NBGIS.PluginEngine.IToolBarDef> _ToolBarCol = null;
        private Dictionary<string, NBGIS.PluginEngine.IMenuDef> _MenuItmeCol = null;
        private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> _DockableWindowCol = null;

        public MainGIS()
        {
            InitializeComponent();
            this.axTOCControl1.SetBuddyControl(this.axMapControl.Object);
            _MapControl = axMapControl.Object as ESRI.ArcGIS.Controls.IMapControlDefault;
            _PageLayoutControl = axPageLayoutControl.Object as ESRI.ArcGIS.Controls.IPageLayoutControlDefault;
            _TocControl = axTOCControl1 as ESRI.ArcGIS.Controls.ITOCControlDefault;
            this._DataSet = new DataSet();

            //��ʼ������ܶ���
            this._Application = new NBGIS.PluginEngine.Application();
            this._Application.StatusBar = this.uiStatusBar;
            this._Application.MapControl = this._MapControl;
            this._Application.PageLayoutControl = this._PageLayoutControl;
            this._Application.MainPlatForm = this;
            this._Application.Caption = this.Text;
            this._Application.Visible = this.Visible;
            this._Application.CurrentTool = null;
            this._Application.MainDataSet = this._DataSet;
        }

        private void MainGIS_Load(object sender, EventArgs e)
        {
           //�Ӳ���ļ����л��ʵ���˲���ӿڵĶ���
            PluginCollection pluginCol = PluginHandle.GetPluginsFormDll();
           //������Щ������󣬻�ò�ͬ���͵Ĳ������
            ParsePluginCollection parsePluginCol = new ParsePluginCollection();
            parsePluginCol.GetPluginArray(pluginCol);
            this._CommandCol = parsePluginCol.GetCommands;
            this._ToolCol = parsePluginCol.GetTools;
            this._ToolBarCol = parsePluginCol.GetToolBars;
            this._MenuItmeCol = parsePluginCol.GetMenus;
            this._DockableWindowCol = parsePluginCol.GetDockableWindows;

            //���Command��Tool��UI���ϵ�Category����
            foreach (string categoryName in parsePluginCol.GetCommandCategory)
            {
                this.uiCommandManager1.Categories.Add(new Janus.Windows.UI.CommandBars.UICommandCategory(categoryName));
            }
        }
    }
}