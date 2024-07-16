using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics.CodeAnalysis;
using Autodesk.Revit.DB.Visual;
using Autodesk.Revit.DB.Plumbing;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;
using Autodesk.Revit.DB.Structure.StructuralSections;
using System.Security.Cryptography;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB.Mechanical;
using System.Windows.Documents;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.DB;
using Grid = Autodesk.Revit.DB.Grid;

namespace generalsolution
{

    [Transaction(TransactionMode.Manual)]
    public class revitplugin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region generalmethod
            UIApplication uiapp = commandData.Application;
            Autodesk.Revit.ApplicationServices.Application app = commandData.Application.Application;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = commandData.Application.ActiveUIDocument.Document;
            method m = new method(doc);

            #endregion
            TransactionGroup tg = new TransactionGroup(doc, "tg");
            tg.Start();

            Transaction tlevel = new Transaction(doc, "tlevel");
            tlevel.Start();
            int N = 0;
            var floortype = new FilteredElementCollector(doc).OfClass(typeof(FloorType)).First() as FloorType;
            List<MessageBoxResult> result = new List<MessageBoxResult>();
            for (int i = 0; i < 101; i++)
            {
                double lvl = 0 + (i * UnitUtils.Convert(3000, UnitTypeId.Millimeters, UnitTypeId.Feet));

                CurveArray curve = new CurveArray();
                var level = Level.Create(doc, lvl);
                N = i;
                level.Name = $"KAITECH - Level {N}";
                var z = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).First() as ViewFamilyType;
                var x = level.Id;
                ViewPlan.Create(doc, z.Id, x);
            }
            tlevel.Commit();
            string messagess = $"There ({N}) Levels are already Created :\n";
            for (int i = 1; i <= N; i++)
            {
                messagess += $" KAITECH - Level {i}\n";
            }
            TaskDialog.Show("Levels Creator Add-in", messagess);
            tg.Assimilate();
            return Result.Succeeded;

        }

    }
}



