using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefRevit.Repositories
{
    public class BaseFilteredElementColecter
    {
        public FilteredElementCollector col;
        public Document Document { get; set; }
        public BaseFilteredElementColecter(Document doc) 
        {
            Document = doc;
            col = new FilteredElementCollector(Document);
        }

    }
}
