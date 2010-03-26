using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NBGIS.PluginEngine
{
    public class CreateUI
    {
        private static NBGIS.PluginEngine.IApplication m_Application;
        
        private static Janus.Windows.UI.Dock.UIPanelManager m_UIPanelManager;

        public static NBGIS.PluginEngine.IApplication Application
        {
           
            set
            {
                if (m_Application == value)
                {
                    return;
                }
                else
                {
                    m_Application = value;
                
                }

            }
        }

        public static Janus.Windows.UI.Dock.UIPanelManager UIPanelManager
        {
         
            set
            {
                if (m_UIPanelManager == value)
                    return;
                m_UIPanelManager = value;
            }
        }

       public static void CreateUIDockableWindow(NBGIS.PluginEngine.IDockableWindowDef nbDockWindowItem)
         {

             nbDockWindowItem.OnCreate(m_Application);

             Janus.Windows.UI.Dock.UIPanel panel = new Janus.Windows.UI.Dock.UIPanel();

             panel.FloatingLocation = new System.Drawing.Point(120, 180);
             panel.FloatingSize = new System.Drawing.Size(188, 188);
             panel.Name = nbDockWindowItem.Name;
             panel.Text = nbDockWindowItem.Caption;
             panel.DockState = Janus.Windows.UI.Dock.PanelDockState.Floating;

             ((System.ComponentModel.ISupportInitialize)(panel)).BeginInit();
             panel.SuspendLayout();
             panel.Id = Guid.NewGuid();
             m_UIPanelManager.Panels.Add(panel);

             Janus.Windows.UI.Dock.UIPanelInnerContainer panelContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
             panel.InnerContainer = panelContainer;

             try
             {
                 //这个地方易发生异常，插件必须保证ChildHWND完全正确
                 panelContainer.Controls.Add(nbDockWindowItem.ChildHWND);
                 panelContainer.Location = new System.Drawing.Point(1, 27);
                 panelContainer.Name = nbDockWindowItem.Name + "Container";
                 panelContainer.Size = new System.Drawing.Size(188, 188);
                 panelContainer.TabIndex = 0;

             }
             catch (Exception ex)
             {
                 if (Applog.log.IsErrorEnabled)
                 {
                     Applog.log.Error("浮动窗体插件的子控件没有正确加载:" + ex.Message);
                 }
             }

         }
        
    
    }
}
