using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generalsolution
{
    internal class method
    {
        private Document doc;
        public method(Document document)
        {
           doc= document;
        }
      
        public void showtask(string name)
        {
            TaskDialog.Show("title", name);
        }
        public double Round(double Number )
        {
            return Math.Round(Number, 5);
        }
    }
}
