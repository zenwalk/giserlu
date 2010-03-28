using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace winFrom_CADDataConvertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string pdwgPath = Application.StartupPath.ToString() + "\\TestData.dwg";
            ReadDWGFile(pdwgPath);
        }

        private void CreateGeoDatabase()
        {
            //为了正常调用 pWorkSpaceFactory.OpenFromFile(pDBPath, 0); 
            //先初始化License如下，否则出未知异常

            ESRI.ArcGIS.esriSystem.AoInitialize pLicenseInitialize = new ESRI.ArcGIS.esriSystem.AoInitialize();
            pLicenseInitialize.Initialize(ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeEngine);

            string pDBDirectory = "C:\\";
            string pDBName = "LG.gdb";
            string pDBPath = pDBDirectory + pDBName;

            ESRI.ArcGIS.Geodatabase.IWorkspaceFactory pWorkSpaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactoryClass();
            //ESRI.ArcGIS.Geodatabase.IWorkspaceName pWorkspaceName =  pWorkSpaceFactory.Create(pDBDirectory, pDBName, null, 0);

            if (pWorkSpaceFactory.IsWorkspace(pDBPath))
            {
                pWorkSpaceFactory.OpenFromFile(pDBPath, 0);
            }

           

        }

        private void ReadDWGFile(string dwgPath)
        {
            lib_ReadDwg.Class1 ff = new lib_ReadDwg.Class1();
            ff.ReadDWGFile(dwgPath);
        }
    }
}