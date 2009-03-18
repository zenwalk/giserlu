namespace NBGIS.MainGIS
{
    partial class MainGIS
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel5 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel6 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel7 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel8 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGIS));
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.MainMenu = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.uiStatusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.TOCPanel = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.LayerPanel = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.PropertyPanel = new Janus.Windows.UI.Dock.UIPanel();
            this.PropertyPanelContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.DataPanel = new Janus.Windows.UI.Dock.UIPanel();
            this.DataPanelContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiPanelGroup1 = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.MapContainer = new Janus.Windows.UI.Dock.UIPanel();
            this.MapContainerContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.maptab = new Janus.Windows.UI.Tab.UITabPage();
            this.pageTab = new Janus.Windows.UI.Tab.UITabPage();
            this.axMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axPageLayoutControl = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOCPanel)).BeginInit();
            this.TOCPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayerPanel)).BeginInit();
            this.LayerPanel.SuspendLayout();
            this.uiPanel1Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyPanel)).BeginInit();
            this.PropertyPanel.SuspendLayout();
            this.PropertyPanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataPanel)).BeginInit();
            this.DataPanel.SuspendLayout();
            this.DataPanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelGroup1)).BeginInit();
            this.uiPanelGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapContainer)).BeginInit();
            this.MapContainer.SuspendLayout();
            this.MapContainerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.maptab.SuspendLayout();
            this.pageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.MainMenu});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.Id = new System.Guid("88ea022e-b03e-4bd8-99e6-6fea49275ab5");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.MainMenu});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.MainMenu);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(861, 26);
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 26);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 608);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(861, 26);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 608);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 611);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(861, 0);
            // 
            // MainMenu
            // 
            this.MainMenu.CommandManager = this.uiCommandManager1;
            this.MainMenu.Key = "CommandBar1";
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RowIndex = 0;
            this.MainMenu.Size = new System.Drawing.Size(49, 26);
            this.MainMenu.Text = "MainMeun";
            this.MainMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // uiStatusBar
            // 
            this.uiStatusBar.Location = new System.Drawing.Point(0, 611);
            this.uiStatusBar.Name = "uiStatusBar";
            uiStatusBarPanel5.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel5.Key = "";
            uiStatusBarPanel5.ProgressBarValue = 0;
            uiStatusBarPanel6.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel6.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel6.Key = "";
            uiStatusBarPanel6.ProgressBarValue = 0;
            uiStatusBarPanel6.Width = 534;
            uiStatusBarPanel7.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel7.Key = "";
            uiStatusBarPanel7.ProgressBarValue = 0;
            uiStatusBarPanel8.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel8.Key = "";
            uiStatusBarPanel8.ProgressBarValue = 0;
            this.uiStatusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel5,
            uiStatusBarPanel6,
            uiStatusBarPanel7,
            uiStatusBarPanel8});
            this.uiStatusBar.Size = new System.Drawing.Size(861, 23);
            this.uiStatusBar.TabIndex = 4;
            this.uiStatusBar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            this.uiPanelGroup1.Id = new System.Guid("d01c7d79-83c1-4077-b42a-546b18610d07");
            this.TOCPanel.Id = new System.Guid("597af2bf-1b51-4800-be50-28e6a99209e7");
            this.TOCPanel.StaticGroup = true;
            this.LayerPanel.Id = new System.Guid("44368b77-c199-4a25-9190-149c2f1e9e64");
            this.TOCPanel.Panels.Add(this.LayerPanel);
            this.PropertyPanel.Id = new System.Guid("ce5cd3d2-076a-4324-bda6-302020887921");
            this.TOCPanel.Panels.Add(this.PropertyPanel);
            this.uiPanelGroup1.Panels.Add(this.TOCPanel);
            this.DataPanel.Id = new System.Guid("bc680536-61db-4561-a394-7f916c3772da");
            this.uiPanelGroup1.Panels.Add(this.DataPanel);
            this.uiPanelManager1.Panels.Add(this.uiPanelGroup1);
            this.MapContainer.Id = new System.Guid("41cc8056-c683-4965-8261-d2c366ead63e");
            this.uiPanelManager1.Panels.Add(this.MapContainer);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("d01c7d79-83c1-4077-b42a-546b18610d07"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Left, false, new System.Drawing.Size(200, 579), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("597af2bf-1b51-4800-be50-28e6a99209e7"), new System.Guid("d01c7d79-83c1-4077-b42a-546b18610d07"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, 251, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("44368b77-c199-4a25-9190-149c2f1e9e64"), new System.Guid("597af2bf-1b51-4800-be50-28e6a99209e7"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ce5cd3d2-076a-4324-bda6-302020887921"), new System.Guid("597af2bf-1b51-4800-be50-28e6a99209e7"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("bc680536-61db-4561-a394-7f916c3772da"), new System.Guid("d01c7d79-83c1-4077-b42a-546b18610d07"), 251, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("41cc8056-c683-4965-8261-d2c366ead63e"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(655, 579), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("bc680536-61db-4561-a394-7f916c3772da"), new System.Drawing.Point(281, 465), new System.Drawing.Size(200, 200), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // TOCPanel
            // 
            this.TOCPanel.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            this.TOCPanel.Location = new System.Drawing.Point(0, 0);
            this.TOCPanel.Name = "TOCPanel";
            this.TOCPanel.SelectedPanel = this.PropertyPanel;
            this.TOCPanel.Size = new System.Drawing.Size(196, 288);
            this.TOCPanel.TabIndex = 4;
            this.TOCPanel.Text = "地图信息";
            // 
            // LayerPanel
            // 
            this.LayerPanel.InnerContainer = this.uiPanel1Container;
            this.LayerPanel.Location = new System.Drawing.Point(0, 0);
            this.LayerPanel.Name = "LayerPanel";
            this.LayerPanel.Size = new System.Drawing.Size(196, 270);
            this.LayerPanel.TabIndex = 4;
            this.LayerPanel.Text = "图层";
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Controls.Add(this.axTOCControl1);
            this.uiPanel1Container.Location = new System.Drawing.Point(1, 24);
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.uiPanel1Container.Size = new System.Drawing.Size(194, 246);
            this.uiPanel1Container.TabIndex = 0;
            // 
            // PropertyPanel
            // 
            this.PropertyPanel.InnerContainer = this.PropertyPanelContainer;
            this.PropertyPanel.Location = new System.Drawing.Point(0, 0);
            this.PropertyPanel.Name = "PropertyPanel";
            this.PropertyPanel.Size = new System.Drawing.Size(196, 270);
            this.PropertyPanel.TabIndex = 4;
            this.PropertyPanel.Text = "属性";
            // 
            // PropertyPanelContainer
            // 
            this.PropertyPanelContainer.Controls.Add(this.propertyGrid1);
            this.PropertyPanelContainer.Location = new System.Drawing.Point(1, 24);
            this.PropertyPanelContainer.Name = "PropertyPanelContainer";
            this.PropertyPanelContainer.Size = new System.Drawing.Size(194, 246);
            this.PropertyPanelContainer.TabIndex = 0;
            // 
            // DataPanel
            // 
            this.DataPanel.FloatingLocation = new System.Drawing.Point(281, 465);
            this.DataPanel.InnerContainer = this.DataPanelContainer;
            this.DataPanel.Location = new System.Drawing.Point(0, 292);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(196, 287);
            this.DataPanel.TabIndex = 4;
            this.DataPanel.Text = "数据";
            // 
            // DataPanelContainer
            // 
            this.DataPanelContainer.Controls.Add(this.dataGridView1);
            this.DataPanelContainer.Location = new System.Drawing.Point(1, 23);
            this.DataPanelContainer.Name = "DataPanelContainer";
            this.DataPanelContainer.Size = new System.Drawing.Size(194, 263);
            this.DataPanelContainer.TabIndex = 0;
            // 
            // uiPanelGroup1
            // 
            this.uiPanelGroup1.Location = new System.Drawing.Point(3, 29);
            this.uiPanelGroup1.Name = "uiPanelGroup1";
            this.uiPanelGroup1.Size = new System.Drawing.Size(200, 579);
            this.uiPanelGroup1.TabIndex = 9;
            // 
            // MapContainer
            // 
            this.MapContainer.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.MapContainer.InnerContainer = this.MapContainerContainer;
            this.MapContainer.Location = new System.Drawing.Point(203, 29);
            this.MapContainer.Name = "MapContainer";
            this.MapContainer.Size = new System.Drawing.Size(655, 579);
            this.MapContainer.TabIndex = 4;
            this.MapContainer.Text = "地图容器";
            // 
            // MapContainerContainer
            // 
            this.MapContainerContainer.Controls.Add(this.uiTab1);
            this.MapContainerContainer.Location = new System.Drawing.Point(1, 1);
            this.MapContainerContainer.Name = "MapContainerContainer";
            this.MapContainerContainer.Size = new System.Drawing.Size(653, 577);
            this.MapContainerContainer.TabIndex = 0;
            // 
            // uiTab1
            // 
            this.uiTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTab1.Location = new System.Drawing.Point(0, 0);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(653, 577);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.maptab,
            this.pageTab});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007;
            // 
            // maptab
            // 
            this.maptab.Controls.Add(this.axLicenseControl1);
            this.maptab.Controls.Add(this.axMapControl);
            this.maptab.Location = new System.Drawing.Point(1, 20);
            this.maptab.Name = "maptab";
            this.maptab.Size = new System.Drawing.Size(651, 556);
            this.maptab.TabStop = true;
            this.maptab.Text = "地图";
            // 
            // pageTab
            // 
            this.pageTab.Controls.Add(this.axPageLayoutControl);
            this.pageTab.Location = new System.Drawing.Point(1, 20);
            this.pageTab.Name = "pageTab";
            this.pageTab.Size = new System.Drawing.Size(651, 556);
            this.pageTab.TabStop = true;
            this.pageTab.Text = "制版";
            // 
            // axMapControl
            // 
            this.axMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl.Location = new System.Drawing.Point(0, 0);
            this.axMapControl.Name = "axMapControl";
            this.axMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl.OcxState")));
            this.axMapControl.Size = new System.Drawing.Size(651, 556);
            this.axMapControl.TabIndex = 0;
            // 
            // axPageLayoutControl
            // 
            this.axPageLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.axPageLayoutControl.Name = "axPageLayoutControl";
            this.axPageLayoutControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl.OcxState")));
            this.axPageLayoutControl.Size = new System.Drawing.Size(651, 556);
            this.axPageLayoutControl.TabIndex = 0;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(194, 246);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(17, 499);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(194, 263);
            this.dataGridView1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(194, 246);
            this.propertyGrid1.TabIndex = 0;
            // 
            // MainGIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 634);
            this.Controls.Add(this.MapContainer);
            this.Controls.Add(this.uiPanelGroup1);
            this.Controls.Add(this.BottomRebar1);
            this.Controls.Add(this.uiStatusBar);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Name = "MainGIS";
            this.Text = "MainGIS";
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOCPanel)).EndInit();
            this.TOCPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayerPanel)).EndInit();
            this.LayerPanel.ResumeLayout(false);
            this.uiPanel1Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PropertyPanel)).EndInit();
            this.PropertyPanel.ResumeLayout(false);
            this.PropertyPanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataPanel)).EndInit();
            this.DataPanel.ResumeLayout(false);
            this.DataPanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelGroup1)).EndInit();
            this.uiPanelGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapContainer)).EndInit();
            this.MapContainer.ResumeLayout(false);
            this.MapContainerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.maptab.ResumeLayout(false);
            this.pageTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar MainMenu;
        private Janus.Windows.UI.Dock.UIPanelGroup TOCPanel;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanelGroup uiPanelGroup1;
        private Janus.Windows.UI.Dock.UIPanel LayerPanel;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        private Janus.Windows.UI.Dock.UIPanel PropertyPanel;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer PropertyPanelContainer;
        private Janus.Windows.UI.Dock.UIPanel DataPanel;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer DataPanelContainer;
        private Janus.Windows.UI.Dock.UIPanel MapContainer;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer MapContainerContainer;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage maptab;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl;
        private Janus.Windows.UI.Tab.UITabPage pageTab;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}