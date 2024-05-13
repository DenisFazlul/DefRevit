using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefRevit.Repositories
{
    public class TitleBlockCollecter : BaseFilteredElementColecter
    {
        public TitleBlockCollecter(Document doc) : base(doc)
        {
        }
        public List<Element>GetTitleBlockTypes()
        {
         
            col.OfCategory(BuiltInCategory.OST_TitleBlocks);
            col.WhereElementIsElementType();
            return col.ToElements().ToList();
        }
    }
}
