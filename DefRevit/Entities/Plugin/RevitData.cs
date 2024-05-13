using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefRevit.Entities.Plugin
{
    public class RevitData
    {
        public UIApplication uiapp { get; private set; }
        public UIDocument uidoc { get; private set; }
        public Application app { get; private set; }
        public Document doc;
        public RevitData(ExternalCommandData externalCommandData)
        {
            uiapp = externalCommandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;
        }





    }
}
