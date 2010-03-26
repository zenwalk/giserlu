using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NBGIS.PluginEngine;

namespace NBGIS.MainGIS
{
    public partial class MainGIS : Form
    {
        //Mapcontrol、PageLayoutContl、TOCControl对象
        private ESRI.ArcGIS.Controls.IMapControlDefault m_MapControl = null;
        private ESRI.ArcGIS.Controls.IPageLayoutControlDefault m_PageLayoutControl = null;
        private ESRI.ArcGIS.Controls.ITOCControlDefault m_TOCControl = null;
        //MapControl与PageLayoutControl同步类
        private ControlsSynchronizer m_ControlsSynchronizer = null;

        //宿主对象
        private NBGIS.PluginEngine.IApplication m_Application = null;

        //保存地图数据的DataSet
        private DataSet m_DataSet = null;

        //当前使用的Tool
        private NBGIS.PluginEngine.ITool m_CurrentTool = null;

        //插件对象集合
        private Dictionary<string, NBGIS.PluginEngine.ICommand> m_CommandCol = null;
        private Dictionary<string, NBGIS.PluginEngine.ITool> m_ToolCol = null;
        private Dictionary<string, NBGIS.PluginEngine.IMenuDef> m_MenuCol = null;
        private Dictionary<string, NBGIS.PluginEngine.IToolBarDef> m_ToolBarCol = null;
        //private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> m_DockableWindowCol = null;

        public MainGIS()
        {
            InitializeComponent();

            //为TOC设置伙伴控件，与MapControl关联
            this.axTOCControl.SetBuddyControl(this.axMapControl.Object);

            //从控件中得到相应接口的对象
            m_MapControl = axMapControl.Object as ESRI.ArcGIS.Controls.IMapControlDefault;
            m_PageLayoutControl = axPageLayoutControl.Object as ESRI.ArcGIS.Controls.IPageLayoutControlDefault;
            m_TOCControl = axTOCControl.Object as ESRI.ArcGIS.Controls.ITOCControlDefault;
            //初始化数据集对象
            m_DataSet = new DataSet();




            //初始化主框架对象
            m_Application = new NBGIS.PluginEngine.Application();
            m_Application.StatusBar = this.StatusBar;
            m_Application.MapControl = m_MapControl;
            m_Application.PageLayoutControl = m_PageLayoutControl;
            m_Application.MainPlatform = this;
            m_Application.Caption = this.Text;
            m_Application.Visible = this.Visible;
            m_Application.CurrentTool = null;
            m_Application.MainDataSet = this.m_DataSet;
            m_Application.Map = m_MapControl.Map;

            //让MapControl与PageLayoutControl保持同步
            m_ControlsSynchronizer = new ControlsSynchronizer(m_MapControl, m_PageLayoutControl);
            m_ControlsSynchronizer.BindControls(true);
           
            m_ControlsSynchronizer.AddFrameworkControl(axTOCControl.Object);
           
            

        }

        //主窗体Load事件
        private void MainGIS_Load(object sender, EventArgs e)
        {
            //从插件文件夹中获得实现了插件接口的对象
            NBGIS.PluginEngine.PluginCollection pluginCol =NBGIS.PluginEngine.PluginHandle.GetPluginsFromDll();
           
            
            //NBGIS.PluginEngine.ParsePluginCollection parsePluginCol = new NBGIS.PluginEngine.ParsePluginCollection();

           //解析这些插件对象，获得不同类型的插件集合
            //把插件集合解析成五种不同的类型存储在ParsePluginCollection对象属性中
            ParsePluginCollection.GetPluginArray(pluginCol);

            //从ParsePluginCollection提取出各种插件对象集合
            m_CommandCol = ParsePluginCollection.GetCommands;
            m_ToolCol = ParsePluginCollection.GetTools;
            m_ToolBarCol = ParsePluginCollection.GetToolBars;
            m_MenuCol = ParsePluginCollection.GetMenus;
            //m_DockableWindowCol = ParsePluginCollection.GetDockableWindows;

           //获得Command和Tool在UI层面上的Category属性
            foreach (string categoryName in ParsePluginCollection.GetCommandsCategorys)
            {
                this.uiCommandManager.Categories.Add(new Janus.Windows.UI.CommandBars.UICommandCategory(categoryName));

            }
            //创建插件的UI对象
            this.CreateUICommandAndTool(this.m_CommandCol, this.m_ToolCol);
            this.CreateUIToolBars(this.m_ToolBarCol);
            this.CreateUIMenus(this.m_MenuCol);


            // this.CreateUIDockableWindow(this.m_DockableWindowCol);

            //经过改进，动态创建DockableWindow
           //---------------------------------------------------------------
            NBGIS.PluginEngine.CreateUI.Application = m_Application;
            NBGIS.PluginEngine.CreateUI.UIPanelManager = uiPanelManager;
            //-------------------------------------------------------------------

            

            this.m_MapControl.CurrentTool = null;
            this.m_PageLayoutControl.CurrentTool = null;

        }

        #region 创建插件的UI对象
        private void CreateUICommandAndTool(Dictionary<string, NBGIS.PluginEngine.ICommand> Cmds, Dictionary<string, NBGIS.PluginEngine.ITool> Tools)
        {
            //遍历ICommand对象集合
            foreach (KeyValuePair<string, NBGIS.PluginEngine.ICommand> cmd in Cmds)
            {
                //获得一个ICommand对象
                NBGIS.PluginEngine.ICommand nbCmd = cmd.Value;

                //产生一个UICommand对象
                Janus.Windows.UI.CommandBars.UICommand uiCmd = new Janus.Windows.UI.CommandBars.UICommand();
                
                //根据ICommand的信息设置UICommand的属性
                uiCmd.ToolTipText = nbCmd.Tooltip;
                uiCmd.CategoryName = nbCmd.Category;
                uiCmd.Text = nbCmd.Caption;
                uiCmd.Image = nbCmd.Bitmap;
                uiCmd.Key = nbCmd.ToString();

                //UICommand的Enabled属性默认为true
                if (!nbCmd.Enabled)
                {
                    uiCmd.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }

                //UICommand的Checked属性默认为false
                if (nbCmd.Checked)
                {
                    uiCmd.Checked = Janus.Windows.UI.InheritableBoolean.True;
                }

                //产生UICommand时调用OnCreate方法，将主框架对象传递给插件对象
                nbCmd.OnCreate(this.m_Application);

                //使用委托机制处理Command的事件
                //所有的UICommand对象的Click事件均使用this.Command_Click方法处理
                uiCmd.Click+=new Janus.Windows.UI.CommandBars.CommandEventHandler(uiCmd_Click);
               
                //将生成的UICommand添加到CommandManager中
                this.uiCommandManager.Commands.Add(uiCmd);
            }

            //遍历ITool对象集合
            foreach (KeyValuePair<string, NBGIS.PluginEngine.ITool> tool in Tools)
            {
                NBGIS.PluginEngine.ITool nbTool = tool.Value;
               
                Janus.Windows.UI.CommandBars.UICommand uiTool = new Janus.Windows.UI.CommandBars.UICommand();
                
                uiTool.CategoryName = nbTool.Category;
                uiTool.Text = nbTool.Caption;
                uiTool.ToolTipText = nbTool.Tooltip;
                uiTool.Image = nbTool.Bitmap;
                uiTool.Key = nbTool.ToString();

                if (!nbTool.Enabled)
                {
                    uiTool.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                if (nbTool.Checked)
                {
                    uiTool.Checked = Janus.Windows.UI.InheritableBoolean.True;
                }

                nbTool.OnCreate(this.m_Application);

                uiTool.Click+=new Janus.Windows.UI.CommandBars.CommandEventHandler(uiTool_Click);
                
                this.uiCommandManager.Commands.Add(uiTool);
            }
        }

        private void CreateUIToolBars(Dictionary<string, NBGIS.PluginEngine.IToolBarDef> Toolbars)
        {
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IToolBarDef> toolbar in Toolbars)
            {
                NBGIS.PluginEngine.IToolBarDef nbToolbar = toolbar.Value;

                Janus.Windows.UI.CommandBars.UICommandBar uiToolbar = new Janus.Windows.UI.CommandBars.UICommandBar();

                uiToolbar.CommandManager = this.uiCommandManager;
                
                uiToolbar.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
                
                uiToolbar.Name = nbToolbar.Name;
                uiToolbar.Text = nbToolbar.Caption;
                //Tag=nbToolbar?
                uiToolbar.Tag = nbToolbar;
                uiToolbar.Key = nbToolbar.ToString();
                uiToolbar.Visible = nbToolbar.IsVisible;

                //将Command和Tool插入到Toolbar中
                NBGIS.PluginEngine.IItemDef itemDef = new NBGIS.PluginEngine.ItemDef();
                for (int i = 0; i < nbToolbar.ItemCount; i++)
                {
                    nbToolbar.GetItemInfo(i, itemDef);
                    Janus.Windows.UI.CommandBars.UICommand uiCmd = null;

                    //如果一个ICommand对象由于某些原因并没有正确产生，
                    //而在Toolbar或Menu中又存在它的名称
                    //获取该ICommand对象就会出现异常
                    try
                    {
                       //uiCmd = this.uiCommandManager.Commands[itemDef.ID];
                        uiCmd = this.uiCommandManager.Commands[i];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( itemDef.ID +" Plugin" + " didn't load.\n" + " Message: " + ex.Message);
                        
                    }
                    if (uiCmd != null)
                    {
                        if (itemDef.Group)
                        {
                            uiToolbar.Commands.AddSeparator();
                        }
                        uiToolbar.Commands.Add(uiCmd);
                    }
                }
            }
        }

        private void CreateUIMenus(Dictionary<string,NBGIS.PluginEngine.IMenuDef> Menus)
        {
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IMenuDef> menu in Menus)
            {
                NBGIS.PluginEngine.IMenuDef nbMenu = menu.Value;

                Janus.Windows.UI.CommandBars.UICommand uiMenu = new Janus.Windows.UI.CommandBars.UICommand();


                this.uiMainMenu.Commands.Add(uiMenu);

                uiMenu.Text = nbMenu.Caption;
                uiMenu.Name = nbMenu.Name;
                uiMenu.Tag = nbMenu;
                uiMenu.Key = nbMenu.ToString();
                uiMenu.Visible = nbMenu.IsVisible;

                //将Command和Tool插入到menu中
                //遍历每一个菜单item
                NBGIS.PluginEngine.IItemDef itemDef = new NBGIS.PluginEngine.ItemDef();
                for (int i = 0; i < nbMenu.ItemCount; i++)
                {
                    //寻找该菜单对象的信息，如该菜单上所有的Item数量，是否为Group
                    nbMenu.GetItemInfo(i, itemDef);
                    Janus.Windows.UI.CommandBars.UICommand uiCmd = null;
                    try
                    {
                        uiCmd = this.uiCommandManager.Commands[i];
                    }
                    catch(Exception ex)
                    {}
                    //如果该uiCommand存在，则添加
                    if(uiCmd!=null)
                        {
                        	//暂时不考虑Subtype的情况
                            if(itemDef.Group)
                            {
                                uiMenu.Commands.AddSeparator();
                            }
                            uiMenu.Commands.Add(uiCmd);
                        }
                }
            }

        }

        //private void CreateUIDockableWindow(Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> DockableWindows)
        //{
        //    foreach (KeyValuePair<string, NBGIS.PluginEngine.IDockableWindowDef> dockWindowsItem in DockableWindows)
        //    {
        //        NBGIS.PluginEngine.IDockableWindowDef nbDockWindowItem = dockWindowsItem.Value;

        //        nbDockWindowItem.OnCreate(this.m_Application);

        //        Janus.Windows.UI.Dock.UIPanel panel = new Janus.Windows.UI.Dock.UIPanel();

        //        panel.FloatingLocation = new System.Drawing.Point(120, 180);
        //        panel.FloatingSize = new System.Drawing.Size(188, 188);
        //        panel.Name = nbDockWindowItem.Name;
        //        panel.Text = nbDockWindowItem.Caption;
                
        //        panel.DockState = Janus.Windows.UI.Dock.PanelDockState.Floating;

        //        ((System.ComponentModel.ISupportInitialize)(panel)).BeginInit();
        //        panel.SuspendLayout();
        //        panel.Id = Guid.NewGuid();
        //        this.uiPanelManager.Panels.Add(panel);

        //        Janus.Windows.UI.Dock.UIPanelInnerContainer panelContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
        //        panel.InnerContainer = panelContainer;
               

        //        try
        //        {
        //            //这个地方易发生异常，插件必须保证ChildHWND完全正确
        //            panelContainer.Controls.Add(nbDockWindowItem.ChildHWND);
        //            panelContainer.Location = new System.Drawing.Point(1, 27);
        //            panelContainer.Name = nbDockWindowItem.Name + "Container";
        //            panelContainer.Size = new System.Drawing.Size(188, 188);
        //            panelContainer.TabIndex = 0;
                 
        //        }
        //        catch (Exception ex)
        //        {
        //            if (Applog.log.IsErrorEnabled)
        //            {
        //                Applog.log.Error("浮动窗体插件的子控件没有正确加载:" + ex.Message);
        //            }
        //        }
        //    }
        //}

        #endregion

        #region ITool与ICommand的Click事件方法
        private void uiCmd_Click(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //当Command被按下时，CurrentTool设置为Null
            this.m_Application.CurrentTool = null;
            this.m_Application.MapControl.CurrentTool = null;
            this.m_Application.PageLayoutControl.CurrentTool = null;
            //一切在Command被 按下前未完成的Tool操作都可能使Tool的Checked为True
            //此项必须设置为False
            foreach (Janus.Windows.UI.CommandBars.UICommand uiCmd in this.uiCommandManager.Commands)
            {
                uiCmd.Checked = Janus.Windows.UI.InheritableBoolean.False;
            }

           
            
            Janus.Windows.UI.CommandBars.UICommand cmd = (Janus.Windows.UI.CommandBars.UICommand)sender;
            cmd.Checked = Janus.Windows.UI.InheritableBoolean.True;
             this.axMapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
           
            NBGIS.PluginEngine.ICommand nbCmd = this.m_CommandCol[e.Command.Key];
            
            //状态栏显示插件信息
            this.StatusBar.Panels[0].Text = nbCmd.Message;
            nbCmd.OnClick();
            
            cmd.Checked = Janus.Windows.UI.InheritableBoolean.False;
        }

        private void uiTool_Click(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            NBGIS.PluginEngine.ITool tool = this.m_ToolCol[e.Command.Key];
            //Tool第一次按下
            if (this.m_Application.CurrentTool == null
                && this.m_MapControl.CurrentTool == null
                && this.m_PageLayoutControl.CurrentTool == null)
            {
                this.StatusBar.Panels[0].Text = tool.Message;
                Janus.Windows.UI.CommandBars.UICommand cmd = (Janus.Windows.UI.CommandBars.UICommand)sender;
                cmd.Checked = Janus.Windows.UI.InheritableBoolean.True;
                this.axMapControl.MousePointer = (ESRI.ArcGIS.Controls.esriControlsMousePointer)(tool.Cursor);
                this.axPageLayoutControl.MousePointer = (ESRI.ArcGIS.Controls.esriControlsMousePointer)(tool.Cursor);
                tool.OnClick();
                this.m_Application.CurrentTool = tool.ToString();
            }
            else
            {
                if (this.m_Application.CurrentTool == e.Command.Key)
                {
                    //如果是连续第二次按下，则这个Tool完成操作后处于关闭状态
                    Janus.Windows.UI.CommandBars.UICommand cmd = (Janus.Windows.UI.CommandBars.UICommand)sender;
                    cmd.Checked = Janus.Windows.UI.InheritableBoolean.False;
                    this.axMapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
                    this.axPageLayoutControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
                    this.m_Application.CurrentTool = null;
                    this.m_Application.MapControl.CurrentTool = null;
                    this.m_Application.PageLayoutControl.CurrentTool = null;
                }
                else
                {
                    //按下一个Tool后没有关闭接着按另一个Tool，则关闭前一个Tool
                    Janus.Windows.UI.CommandBars.UICommand lastTool 
                        = this.uiCommandManager.Commands[this.m_Application.CurrentTool];
                    if (lastTool != null)
                    {
                        lastTool.Checked = Janus.Windows.UI.InheritableBoolean.False;
                    }
                    this.m_Application.MapControl.CurrentTool = null;
                    this.m_Application.PageLayoutControl.CurrentTool = null;

                    //设置后一个Tool的状态
                    this.StatusBar.Panels[0].Text = tool.Message;
                    Janus.Windows.UI.CommandBars.UICommand cmd = (Janus.Windows.UI.CommandBars.UICommand)sender;
                    cmd.Checked = Janus.Windows.UI.InheritableBoolean.True;
                    this.axMapControl.MousePointer = (ESRI.ArcGIS.Controls.esriControlsMousePointer)(tool.Cursor);
                    this.axPageLayoutControl.MousePointer = (ESRI.ArcGIS.Controls.esriControlsMousePointer)(tool.Cursor);
                    tool.OnClick();
                    this.m_Application.CurrentTool = tool.ToString();

                }
            }
        }
#endregion]

        #region uiTabe 选项卡选择改变事件方法 
        private void uiTab_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (m_ControlsSynchronizer != null)
            {
                if (e.Page.Name == "mapTab")
                {
                   m_ControlsSynchronizer.ActivateMapControl();
                   m_ControlsSynchronizer.ReplaceMap(m_Application.Map);
                   axMapControl.Focus();
                }
                else if (e.Page.Name == "pageTab")
                {

                    m_ControlsSynchronizer.ActivatePageLayout();
                    m_ControlsSynchronizer.ReplaceMap(m_Application.Map);
                    axPageLayoutControl.Focus();
                }
            }
        }
        #endregion
        #region MapControl事件

        private void axMapControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];
                if (e.button == 1)
                {
                    this.m_CurrentTool.OnMouseDown(e.button, e.shift, (int)e.mapX, (int)e.mapY);
                }
                else if(e.button ==2)
                {
                    this.m_CurrentTool.OnContextMenu(e.x, e.y);
                }
                this.StatusBar.Panels[2].Text = "X:" + e.mapX.ToString() + "  Y:" + e.mapY.ToString();
            }
        }

        private void axMapControl_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.OnMouseMove(e.button, e.shift, (int)e.mapX, (int)e.mapY);

                this.StatusBar.Panels[2].Text = "X:" + e.mapX.ToString() + "  Y:" + e.mapY.ToString();
            }
        }

        private void axMapControl_OnMouseUp(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseUpEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.OnMouseUp(e.button, e.shift, (int)e.mapX, (int)e.mapY);

                this.StatusBar.Panels[2].Text = "X:" + e.mapX.ToString() + "  Y:" + e.mapY.ToString();
            }
        }

        private void axMapControl_OnKeyDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnKeyDownEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.OnKeyDown(e.keyCode,e.shift);
            }
        }

        private void axMapControl_OnKeyUp(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnKeyUpEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.OnKeyUp(e.keyCode, e.shift);
            }
        }

        private void axMapControl_OnViewRefreshed(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnViewRefreshedEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.Refresh(0);
            }
        }

        private void axMapControl_OnDoubleClick(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnDoubleClickEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];
                this.m_CurrentTool.OnDblClick();
               
            }
        }

        private void axMapControl_OnFullExtentUpdated(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnFullExtentUpdatedEvent e)
        {
            m_Application.Map = m_MapControl.Map;
        }

        #endregion

        #region PageLayoutControl事件方法
        private void axPageLayoutControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];
                if (e.button == 1)
                {
                    this.m_CurrentTool.OnMouseDown(e.button, e.shift, (int)e.pageX, (int)e.pageY);
                }
                else if (e.button == 2)
                {
                    this.m_CurrentTool.OnContextMenu(e.x, e.y);
                }
              
            }
        }

        private void axPageLayoutControl_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.OnMouseMove(e.button, e.shift, (int)e.pageX, (int)e.pageY);

                
            }
        }

        private void axPageLayoutControl_OnMouseUp(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnMouseUpEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.OnMouseUp(e.button, e.shift, (int)e.pageX, (int)e.pageY);


            }
        }

        private void axPageLayoutControl_OnKeyDown(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnKeyDownEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.OnKeyDown(e.keyCode, e.shift);
            }
        }

        private void axPageLayoutControl_OnKeyUp(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnKeyUpEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];

                this.m_CurrentTool.OnKeyUp(e.keyCode, e.shift);
            }
        }

        private void axPageLayoutControl_OnViewRefreshed(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnViewRefreshedEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];
                this.m_CurrentTool.Refresh(0);

            }
        }

        private void axPageLayoutControl_OnDoubleClick(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnDoubleClickEvent e)
        {
            if (this.m_Application.CurrentTool != null)
            {
                this.m_CurrentTool = this.m_ToolCol[this.m_Application.CurrentTool];
                this.m_CurrentTool.OnDblClick();

            }
        }

        #endregion


        #region MinGIS Form 事件方法
        private void MainGIS_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void MainGIS_FormClosed(object sender, FormClosedEventArgs e)
        {
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();
           // System.Windows.Forms.Application.Exit();
        }

        #endregion


        #region TOCControl事件方法

        private void axTOCControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {
            ESRI.ArcGIS.Controls.esriTOCControlItem pTOCControlItem = ESRI.ArcGIS.Controls.esriTOCControlItem.esriTOCControlItemNone;

            //HitTest引用参数定义
            ESRI.ArcGIS.Carto.IBasicMap pBasicMap = null;
            ESRI.ArcGIS.Carto.ILayer  pLayer = null;
            object pObjectOther = null;
            object pObjectIndex = null;

            m_TOCControl.HitTest(e.x, e.y, ref pTOCControlItem, ref pBasicMap, ref pLayer, ref pObjectOther, ref pObjectIndex);

            //确保有项目被选中
            if (pTOCControlItem == ESRI.ArcGIS.Controls.esriTOCControlItem.esriTOCControlItemMap)
            {
                m_TOCControl.SelectItem(pBasicMap, null);
            }
            else
            {
                m_TOCControl.SelectItem(pLayer, null);
            }

            //对选中的item进行处理
            //选中的是Map
            if (pTOCControlItem == ESRI.ArcGIS.Controls.esriTOCControlItem.esriTOCControlItemMap)
            {
                
                MapInfo pMapInfo = new MapInfo(m_MapControl.Map);
                propertyGrid1.SelectedObject = pMapInfo;
            }
            //layer
            if (pTOCControlItem == ESRI.ArcGIS.Controls.esriTOCControlItem.esriTOCControlItemLayer)
            {
                LayerInfo pLayerInfo = new LayerInfo(pLayer);
                propertyGrid1.SelectedObject = pLayerInfo;
               
            }
            //Heading
            if (pTOCControlItem == ESRI.ArcGIS.Controls.esriTOCControlItem.esriTOCControlItemHeading)
            {
                MessageBox.Show("Selected Heading");
            }
            //LegendClass
            if (pTOCControlItem == ESRI.ArcGIS.Controls.esriTOCControlItem.esriTOCControlItemLegendClass)
            {
                MessageBox.Show("Selected LegendClass");
            }
        }

        #endregion





    }
    
}
