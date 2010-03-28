using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib_ReadDwg
{
    public class Class1
    {
        public  string ReadDWGFile(string dwgPath)
        {
            string pResult = string.Empty;
            //打开
            Autodesk.AutoCAD.DatabaseServices.Database pDwgDB = new Autodesk.AutoCAD.DatabaseServices.Database(false, true);
            pDwgDB.ReadDwgFile(dwgPath, System.IO.FileShare.ReadWrite, true, null);

            //为了让插入块的函数在多个图形文件打开的情况下起作用，你必须使用下面的函数把Dwg文件关闭
            pDwgDB.CloseInput(true);

            Autodesk.AutoCAD.DatabaseServices.Transaction pTransaction = pDwgDB.TransactionManager.StartTransaction();
            
                //打开源的块表
                Autodesk.AutoCAD.DatabaseServices.BlockTable pBlockTable =
                    (Autodesk.AutoCAD.DatabaseServices.BlockTable)pTransaction.GetObject(
                    pDwgDB.BlockTableId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead);

                //打开模型空间块表记录
                Autodesk.AutoCAD.DatabaseServices.BlockTableRecord pBlockTableRecord =
                    (Autodesk.AutoCAD.DatabaseServices.BlockTableRecord)pTransaction.GetObject(
                    pBlockTable[Autodesk.AutoCAD.DatabaseServices.BlockTableRecord.ModelSpace], Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead);



                foreach (Autodesk.AutoCAD.DatabaseServices.ObjectId pObjID in pBlockTableRecord)
                {
                    Autodesk.AutoCAD.DatabaseServices.DBObject pDBObject =
                       (Autodesk.AutoCAD.DatabaseServices.DBObject)pTransaction.GetObject(pObjID, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead, false, true);

                    if (pDBObject.GetRXClass().DxfName.ToUpper() == "INSERT")
                    {
                        Autodesk.AutoCAD.DatabaseServices.BlockReference pBlockReference = (Autodesk.AutoCAD.DatabaseServices.BlockReference)pDBObject;
                        if (pBlockReference.AttributeCollection.Count != 0)
                        {
                            System.Collections.IEnumerator pEnumerator = pBlockReference.AttributeCollection.GetEnumerator();
                            while (pEnumerator.MoveNext())
                            {
                                Autodesk.AutoCAD.DatabaseServices.ObjectId pObjectID = (Autodesk.AutoCAD.DatabaseServices.ObjectId)pEnumerator.Current;

                                Autodesk.AutoCAD.DatabaseServices.AttributeReference pAttributeReference =
                                    (Autodesk.AutoCAD.DatabaseServices.AttributeReference)pTransaction.GetObject(
                                    pObjectID, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead, false, true);

                                pResult += pAttributeReference.TextString;
                            }
                        }
                    }
                

                pTransaction.Commit();
                pBlockTableRecord.Dispose();
                pBlockTable.Dispose();
                pDwgDB.Dispose();

            }

            return pResult;
        }
    }
}
