using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefRevit.Repositories
{
   public class LevelsCollecter : BaseFilteredElementColecter
    {
        public LevelsCollecter(Document doc) : base(doc)
        {
        }
        public List<Element> GetAllLevels()
        {  
            col.OfClass(typeof(Level));
            col.WhereElementIsNotElementType();
            return col.ToElements().ToList();
        }
    }
}
