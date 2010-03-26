using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace NBGIS.MainGIS
{
    /// <summary>
    /// MapControl与PageLayoutControl视图同步
    /// </summary>
    //class ControlsSynchronizer
    //{
    //    private ESRI.ArcGIS.Controls.IMapControlDefault m_MapControl = null;
    //    private ESRI.ArcGIS.Controls.IPageLayoutControlDefault m_PageLayoutControl = null;
    //    //MapControl是否属于激活状态
    //    private bool m_IsMapControlActive = true;
    //    //存放与两个地图控件相关的Buddy控件
    //    private ArrayList m_FrameworkControls = null;

    //    public ControlsSynchronizer()
    //    {
    //        m_FrameworkControls = new ArrayList();
    //    }

    //    public ControlsSynchronizer(ESRI.ArcGIS.Controls.IMapControlDefault mapControl,
    //        ESRI.ArcGIS.Controls.IPageLayoutControlDefault pageLayoutControl)
    //        : this()
    //    {
    //        m_MapControl = mapControl;
    //        m_PageLayoutControl = pageLayoutControl;
    //    }
    //    public ESRI.ArcGIS.Controls.IMapControlDefault MapControl
    //    {
    //        get
    //        {
    //            return m_MapControl;
    //        }
    //        set
    //        {
    //            if (m_MapControl == value)
    //                return;
    //            m_MapControl = value;
    //        }
    //    }
    //    public ESRI.ArcGIS.Controls.IPageLayoutControlDefault PageLayoutControl
    //    {
    //        get
    //        {
    //            return m_PageLayoutControl;
    //        }
    //        set
    //        {
    //            if (m_PageLayoutControl == value)
    //                return;
    //            m_PageLayoutControl = value;
    //        }
    //    }

    //    /// <summary>
    //    /// 将Mapcontrl与PageLayoutControl通过一个焦点Map进行绑定
    //    /// </summary>
    //    /// <param name="activateMapControl">如果MapControl作为默认活动控件则设置为Trure</param>
    //    public void BindControls(bool isActivateMapControl)
    //    {
    //        if (m_PageLayoutControl == null || m_MapControl == null)
    //        {
    //            throw new Exception("ControlsSynchronizer::BindControls:\r\nMapcontrol或PageLayoutControl没有初始化");
    //        }

    //        ESRI.ArcGIS.Carto.IMap pMap = new ESRI.ArcGIS.Carto.MapClass();
    //        pMap.Name = "地图";

    //        //产生一个地图容器IMaps对象
    //        ESRI.ArcGIS.Carto.IMaps pMaps = new Maps();
    //        pMaps.Add(pMap);

    //        m_PageLayoutControl.PageLayout.ReplaceMaps(pMaps);
    //        m_MapControl.Map = pMap;

    //        if (isActivateMapControl)
    //        {
    //            this.ActivateMapControl();
    //           // m_MapControl.ActiveView.Refresh(); 
    //        }
    //        else
    //        {
    //            this.ActivatePageLayoutControl();
    //           // m_PageLayoutControl.ActiveView.Refresh();
    //        }
    //    }

    //    /// <summary>
    //    /// 激活PageLayoutContorl并使MapControl处于非活动状态
    //    /// </summary>
    //    public void ActivatePageLayoutControl()
    //    {
    //        try
    //        {
    //            if (m_MapControl == null || m_PageLayoutControl == null)
    //            {
    //                NBGIS.PluginEngine.Applog.log.Error("ControlsSynchronizer::ActivatePageLayoutControl\r\nMapcontrol或PageLayoutConrol没有初始化");

    //            }
    //            else
    //            {
    //                //使MapControl视图处于非活动状态
    //                m_MapControl.ActiveView.Deactivate();
    //                //使PageLayoutControl视图处于活动状态
    //                m_PageLayoutControl.ActiveView.Activate(m_PageLayoutControl.hWnd);
    //                m_IsMapControlActive = false;
    //                //将MapControl控件设置为TOCControl的Buddy控件
    //                this.SetBuddies(m_PageLayoutControl.Object);
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            NBGIS.PluginEngine.Applog.log.Error(ex.Message);
    //        }
    //    }

    //    /// <summary>
    //    /// 激活Mapcontorl并使PageLayoutControl处于非活动状态
    //    /// </summary>
    //    public void ActivateMapControl()
    //    {
    //        try
    //        {
    //           if (m_MapControl==null||m_PageLayoutControl==null)
    //           {
    //               NBGIS.PluginEngine.Applog.log.Error("ControlsSynchronizer::ActivateMapControl\r\nMapcontrol或PageLayoutConrol没有初始化");

    //           }
    //           else
    //           {
    //               //使PageLayoutControl视图处于非活动状态
    //               m_PageLayoutControl.ActiveView.Deactivate();
    //               //使MapControl视图处于活动状态
    //               m_MapControl.ActiveView.Activate(m_MapControl.hWnd);
    //               m_IsMapControlActive = true;
    //               //将MapControl控件设置为TOCControl的Buddy控件
    //               this.SetBuddies(m_MapControl.Object);
    //           }
                
    //        }
    //        catch (Exception ex)
    //        {
    //            NBGIS.PluginEngine.Applog.log.Error(ex.Message);
    //        }
    //    }

    //    /// <summary>
    //    /// Buddy控件的存放集合
    //    /// </summary>
    //    /// <param name="control"></param>
    //    public void AddFrameworkControl(object control)
    //    {
    //        if (control == null)
    //        {
    //            NBGIS.PluginEngine.Applog.log.Error("ControlsSynchronizer::AddFrameworkControl\r\n参数control为空");
    //        }
    //        m_FrameworkControls.Add(control);
    //    }

    //    /// <summary>
    //    /// 当活动控件改变时，将TOCControl的Buddy控件设置为当前活动控件
    //    /// </summary>
    //    /// <param name="buddy">当前活动控件</param>
    //    private void SetBuddies(object buddy)
    //    {
    //        try
    //        {
    //            if (buddy == null)
    //            {
    //                NBGIS.PluginEngine.Applog.log.Error("ControlsSynchronizer::SetBuddies\r\n目标Buddy控件没有初始化");
    //            }
    //            foreach (object obj in m_FrameworkControls)
    //            {
    //                if (obj is ESRI.ArcGIS.Controls.ITOCControl)
    //                {
    //                    ESRI.ArcGIS.Controls.ITOCControl pTOCControl = (ESRI.ArcGIS.Controls.ITOCControl)obj;
    //                    pTOCControl.SetBuddyControl(buddy);
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            NBGIS.PluginEngine.Applog.log.Error(ex.Message);
    //        }
    //    }

    //    /// <summary>
    //    /// 产生一个新Map，并使它成为PageLayoutControl和MapControl的焦点地图
    //    /// </summary>
    //    /// <param name="newMap"></param>
    //    public void ReplaceMap(ESRI.ArcGIS.Carto.IMap newMap)
    //    {
    //       if (newMap==null)
    //       {
    //           NBGIS.PluginEngine.Applog.log.Error("ControlsSynchronizer::ReplaceMap\r\n新Map没有初始化");
    //       }

    //        if (m_PageLayoutControl==null||m_MapControl==null)
    //        {
    //            NBGIS.PluginEngine.Applog.log.Error("ControlsSynchronizer::ReplaceMap\r\nMapControl或PageLayoutControl没有初始化");
    //        }

    //        //产生一个IMaps集合对象
    //        ESRI.ArcGIS.Carto.IMaps pMaps = new Maps();
    //        //将新Map添加到这pMaps集合
    //        pMaps.Add(newMap);

    //        bool pIsMapControlActived = m_IsMapControlActive;

    //        //使PageLayoutControl处于激活状态才能调用ReplaceMaps命令
    //        this.ActivatePageLayoutControl();
    //        m_PageLayoutControl.PageLayout.ReplaceMaps(pMaps);
          
            
    //        //将newMap传递给MapControl
    //        m_MapControl.Map = newMap;

    //        //保证一个活动控件处于激活状态
    //        if (pIsMapControlActived)
    //        {
    //            this.ActivateMapControl();
    //            m_MapControl.ActiveView.Refresh();
    //        }
    //        else
    //        {
    //            this.ActivatePageLayoutControl();
               
               
    //            m_PageLayoutControl.ActiveView.Refresh();
    //        }
           
    //    }


        
    //}


    public class ControlsSynchronizer
    {
        private ESRI.ArcGIS.Controls.IMapControlDefault m_mapControl = null;
        private ESRI.ArcGIS.Controls.IPageLayoutControlDefault m_pageLayoutControl = null;
        private ESRI.ArcGIS.SystemUI.ITool m_mapActiveTool = null;
        private ESRI.ArcGIS.SystemUI.ITool m_pageLayoutActiveTool = null;
        private bool m_IsMapControlActive = true;
        private ArrayList m_frameworkControls = null;


        public ControlsSynchronizer()
        {
            m_frameworkControls = new ArrayList();
        }

        public ControlsSynchronizer(ESRI.ArcGIS.Controls.IMapControlDefault mapControl, ESRI.ArcGIS.Controls.IPageLayoutControlDefault pageLayoutControl)
            : this()
        {
            m_mapControl = mapControl;
            m_pageLayoutControl = pageLayoutControl;
        }

        public ESRI.ArcGIS.Controls.IMapControlDefault MapControl
        {
            get { return m_mapControl; }
            set { m_mapControl = value; }
        }

        public ESRI.ArcGIS.Controls.IPageLayoutControlDefault PageLayoutControl
        {
            get { return m_pageLayoutControl; }
            set { m_pageLayoutControl = value; }
        }

        public string ActiveViewType
        {
            get
            {
                if (m_IsMapControlActive)
                {
                    return "MapControl";
                }
                else
                {
                    return "PageLayoutControl";
                }
            }
        }

        public ESRI.ArcGIS.SystemUI.ITool ActiveControlCurrentTool
        {
            set
            {
                if (ActiveControl == m_mapControl.Object)
                {
                    //   m_mapControl.CurrentTool = null;
                    m_mapControl.CurrentTool = value; ;
                }
                else
                {
                    m_pageLayoutControl.CurrentTool = null;
                    m_pageLayoutControl.CurrentTool = value;
                }
            }
        }

        public object ActiveControl
        {
            get
            {
                if (m_mapControl == null || m_pageLayoutControl == null)
                {
                    throw new Exception("ControlsSynchronzier::ActiveControl:\r\n MapControl or PageLayoutControl is not initialized");
                }
                if (m_IsMapControlActive)
                {
                    return m_mapControl.Object;
                }
                else
                {
                    return m_pageLayoutControl.Object;
                }
            }
        }

        public void ActivateMapControl()
        {
            try
            {
                if (m_mapControl == null || m_pageLayoutControl == null)
                {
                    throw new Exception("ControlsSynchronizer::ActivateMap:/n/r MapControl or PageLayoutControl is not initialized");
                }

                //保存PageLayoutControl最后使用的工具并停用
                if (m_pageLayoutControl.CurrentTool != null)
                {
                    m_pageLayoutActiveTool = m_pageLayoutControl.CurrentTool;
                }
                m_pageLayoutControl.ActiveView.Deactivate();

                //激活MapControl并分配预先保留的工具
                m_mapControl.ActiveView.Activate(m_mapControl.hWnd);

                if (m_mapActiveTool != null)
                {
                    m_mapControl.CurrentTool = m_mapActiveTool;
                }

                //指示器
                m_IsMapControlActive = true;

                //设置MapControl的Buddies
                this.SetBuddies(m_mapControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivateMap:/r/n", ex.Message));
            }

        }
        public void ActivatePageLayout()
        {
            try
            {
                if (m_mapControl == null || m_pageLayoutControl == null)
                {
                    throw new Exception("ControlsSynchronizer::ActivatePageLayout:/r/nMapControl or PageLayoutControl is not initialized");
                }

                if (m_mapControl.CurrentTool != null)
                {
                    m_mapActiveTool = m_mapControl.CurrentTool;

                }
                m_mapControl.ActiveView.Deactivate();


                m_pageLayoutControl.ActiveView.Activate(m_pageLayoutControl.hWnd);
                if (m_pageLayoutActiveTool != null)
                {
                    m_pageLayoutControl.CurrentTool = m_pageLayoutActiveTool;
                }


                m_IsMapControlActive = false;

                this.SetBuddies(m_pageLayoutControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivatePageLayout:/r/n", ex.Message));
            }
        }
        public void ReplaceMap(ESRI.ArcGIS.Carto.IMap newMap)
        {
            if (newMap == null)
            {
                throw new Exception("ControlsSynchronizer::ReplaceMap:/r/n New Map is not initialized");
            }

            if (m_mapControl == null || m_pageLayoutControl == null)
            {
                throw new Exception("ControlsSynchronzier::ReplaceMap:\r\n MapControl or PageLayoutControl is not initialized");
            }

            ESRI.ArcGIS.Carto.IMaps maps = new Maps();
            maps.Add(newMap);

            bool IsMapActive = m_IsMapControlActive;

            this.ActivatePageLayout();
            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);

            m_mapControl.Map = newMap;

            m_mapActiveTool = null;
            m_pageLayoutActiveTool = null;

            if (IsMapActive)
            {
                this.ActivateMapControl();
                m_mapControl.ActiveView.Refresh();
            }
            else
            {
                this.ActivatePageLayout();
                m_pageLayoutControl.ActiveView.Refresh();
            }

        }
        public void BindControls(ESRI.ArcGIS.Controls.IMapControlDefault mapControl, ESRI.ArcGIS.Controls.IPageLayoutControlDefault pageLayoutControl, bool activeMapFirst)
        {
            if (mapControl == null || pageLayoutControl == null)
            {
                throw new Exception("ControlsSynchronizer::BindControls:/r/nMapControl or PageLayoutControl is not initialized.");
            }

            m_mapControl = MapControl;
            m_pageLayoutControl = pageLayoutControl;

            this.BindControls(activeMapFirst);
        }
        public void BindControls(bool activeMapFirst)
        {
            if (m_mapControl == null || m_pageLayoutControl == null)
            {
                throw new Exception("ControlsSynchronizer::BindControls:/r/n MapControl or PageLayoutControl is not initialized.");
            }

            ESRI.ArcGIS.Carto.IMap newMap = new ESRI.ArcGIS.Carto.MapClass();
            newMap.Name = "地图";

            ESRI.ArcGIS.Carto.IMaps maps = new Maps();
            maps.Add(newMap);

            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);
            m_mapControl.Map = newMap;

            m_mapActiveTool = null;
            m_pageLayoutActiveTool = null;

            if (activeMapFirst)
            {
                this.ActivateMapControl();
            }
            else
            {
                this.ActivatePageLayout();
            }
        }
        public void AddFrameworkControl(object control)
        {
            if (control == null)
            {
                throw new Exception("ControlsSynchronizer::AddFrameworkControl:/r/n Added control is not initialized.");
            }
            else
            {
                m_frameworkControls.Add(control);
            }
        }
        public void RemoveFrameworkControl(object control)
        {
            if (control == null)
            {
                throw new Exception("ControlsSynchronizer::RemoveFrameworkControl:/r/n Control to be removed is not initialized.");
            }
            else
            {
                m_frameworkControls.Remove(control);
            }
        }
        public void RemoveFrameworkControlAt(int index)
        {
            if (index < 0 || index > m_frameworkControls.Count)
            {
                throw new Exception("ControlsSychronizer::RemoveFrameworkControlAt:/r/n Index is out of range.");
            }
            else
            {
                m_frameworkControls.RemoveAt(index);
            }
        }

        private void SetBuddies(object buddy)
        {
            try
            {
                if (buddy == null)
                {
                    throw new Exception("ControlsSynchronizer::SetBuddies:/r/n Target Buddy Control is not initialized");
                }
                else
                {
                    foreach (object obj in m_frameworkControls)
                    {
                        if (obj is ESRI.ArcGIS.Controls.IToolbarControl)
                        {
                            ((ESRI.ArcGIS.Controls.IToolbarControl)obj).SetBuddyControl(buddy);
                        }
                        else if (obj is ESRI.ArcGIS.Controls.ITOCControl)
                        {
                            ((ESRI.ArcGIS.Controls.ITOCControl)obj).SetBuddyControl(buddy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronzier::SetBuddies:/r/n", ex.Message));
            }
        }


    }
}
