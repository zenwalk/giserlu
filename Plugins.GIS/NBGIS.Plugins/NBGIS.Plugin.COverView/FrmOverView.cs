using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NBGIS.Plugin.COverView
{
    public partial class FrmOverView : Form
    {
        private NBGIS.PluginEngine.IApplication m_Application;
        private ESRI.ArcGIS.Carto.IMap m_OverMap = null;
        private ESRI.ArcGIS.Carto.IGraphicsContainer m_GraphContainer = null;
        private ESRI.ArcGIS.Carto.IActiveView m_ActiveView = null;
        private ESRI.ArcGIS.Carto.IElement m_Element = null;

        public FrmOverView()
        {
            InitializeComponent();
            m_OverMap = this.axMapControl.Map;

            m_GraphContainer = (ESRI.ArcGIS.Carto.IGraphicsContainer)m_OverMap;
            m_ActiveView = (ESRI.ArcGIS.Carto.IActiveView)m_OverMap;

        }

        public NBGIS.PluginEngine.IApplication Hook
        {
            set
            {
                //将hook设置给插件对象
                this.m_Application = value;

                if (this.m_Application != null)
                {
                    //设置事件，这是主控件与OverView控件互动的关键
                    ((ESRI.ArcGIS.Controls.IMapControlEvents2_Event)this.m_Application.MapControl).OnExtentUpdated +=
                        new ESRI.ArcGIS.Controls.IMapControlEvents2_OnExtentUpdatedEventHandler(FrmOverViewMapControl_OnExtentUpdated);
                    ((ESRI.ArcGIS.Carto.IActiveViewEvents_Event)this.m_Application.MapControl.ActiveView).ItemAdded +=
                        new ESRI.ArcGIS.Carto.IActiveViewEvents_ItemAddedEventHandler(AddItemToFrmOverView);

                    ((ESRI.ArcGIS.Carto.IActiveViewEvents_Event)this.m_Application.MapControl.ActiveView).ContentsCleared +=
                        new ESRI.ArcGIS.Carto.IActiveViewEvents_ContentsClearedEventHandler(ClearFrmOverViewContents);

                    //在OverView上显示一个全范围的红色框
                    this.m_ActiveView.Extent = this.m_Application.MapControl.ActiveView.FullExtent;
                    ESRI.ArcGIS.Geometry.IEnvelope pEnvelope = this.m_ActiveView.Extent;
                    ESRI.ArcGIS.Carto.IRectangleElement pRectangleElement = new ESRI.ArcGIS.Carto.RectangleElementClass();
                    m_Element = pRectangleElement as ESRI.ArcGIS.Carto.IElement;
                    m_Element.Geometry = pEnvelope;

                    ESRI.ArcGIS.Carto.IFillShapeElement pFillShapeEle = (ESRI.ArcGIS.Carto.IFillShapeElement)m_Element;
                    pFillShapeEle.Symbol = this.CreateFillSymbol();
                    m_GraphContainer.AddElement((ESRI.ArcGIS.Carto.IElement)pFillShapeEle, 0);
                    //this.axMapControl.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGraphics, null, null);
                    m_ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGraphics, null, null);
                }
            }
        }
        /// <summary>
        /// 宿主地图的图层全部删除后，OverView地图也删除所有数据
        /// </summary>
        private void ClearFrmOverViewContents()
        {
            m_OverMap.ClearLayers();
            m_ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
        }

        /// <summary>
        /// 宿主地图添加数据后，OverView地图选择一个图层作为背景图层
        /// </summary>
        /// <param name="item"></param>
        private void AddItemToFrmOverView(object item)
        {
            if (this.m_OverMap.LayerCount == 0)
            {
                this.m_OverMap.AddLayer(this.GetBackgroundLayer(this.m_Application.MapControl.Map));
                this.m_ActiveView.Extent = this.m_Application.MapControl.FullExtent;
                this.m_ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                this.m_ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGraphics, null, null);

            }
        }

        /// <summary>
        /// 宿主地图视图改变后，OverView地图的红框发生改变
        /// </summary>
        /// <param name="displayTransformation"></param>
        /// <param name="sizeChanged"></param>
        /// <param name="newEnvelop"></param>
        private void FrmOverViewMapControl_OnExtentUpdated(object displayTransformation, bool sizeChanged, object newEnvelop)
        {
            this.m_ActiveView.Extent = this.m_Application.MapControl.ActiveView.FullExtent;
            m_Element.Geometry = (ESRI.ArcGIS.Geometry.IGeometry)newEnvelop;
            this.m_GraphContainer.UpdateElement(m_Element);
            this.m_ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGraphics, null, null);
            AddItemToFrmOverView(displayTransformation);
        }

        /// <summary>
        /// OverView地图的红框移动后，宿主地图视图发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMapControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            ESRI.ArcGIS.Geometry.IPoint centerPoint = new ESRI.ArcGIS.Geometry.PointClass();
            centerPoint.PutCoords(e.mapX, e.mapY);
            ESRI.ArcGIS.Geometry.IEnvelope eleEnvelope = m_Element.Geometry.Envelope;
            eleEnvelope.CenterAt(centerPoint);
            m_Element.Geometry = (ESRI.ArcGIS.Geometry.IGeometry)eleEnvelope;

            this.m_Application.MapControl.Extent = eleEnvelope;
            this.m_Application.MapControl.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private ESRI.ArcGIS.Display.IFillSymbol CreateFillSymbol()
        {
            ESRI.ArcGIS.Display.IRgbColor color = new ESRI.ArcGIS.Display.RgbColorClass();
            color.Red = 255;
            color.Transparency = 255;

            ESRI.ArcGIS.Display.ILineSymbol outLine = new ESRI.ArcGIS.Display.SimpleLineSymbolClass();
            outLine.Width = 1;
            outLine.Color = color;
            color.Transparency = 0;

            ESRI.ArcGIS.Display.IFillSymbol fillSymbol = new ESRI.ArcGIS.Display.SimpleFillSymbolClass();
            fillSymbol.Color = color;
            fillSymbol.Outline = outLine;

            ESRI.ArcGIS.Display.ISimpleFillSymbol simpleFillSymbol = (ESRI.ArcGIS.Display.ISimpleFillSymbol)fillSymbol;
            simpleFillSymbol.Style = ESRI.ArcGIS.Display.esriSimpleFillStyle.esriSFSCross;

            return fillSymbol;
        }
  
        private ESRI.ArcGIS.Carto.ILayer GetBackgroundLayer(ESRI.ArcGIS.Carto.IMap map)
        {
            ESRI.ArcGIS.Carto.ILayer pLayer = map.get_Layer(0);
            ESRI.ArcGIS.Carto.ILayer pTempLayer = null;
            for (int i = 1; i < map.LayerCount; i++)
            {
                pTempLayer = map.get_Layer(i);
                if (pLayer.AreaOfInterest.Width < pTempLayer.AreaOfInterest.Width)
                {
                    pLayer = pTempLayer;
                }
            }
            return pLayer;
        }
    }
}
