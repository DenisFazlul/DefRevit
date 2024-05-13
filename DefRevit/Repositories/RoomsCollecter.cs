using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefRevit.Repositories
{
    public class RoomsCollecter : BaseFilteredElementColecter
    {
        public RoomsCollecter(Document doc) : base(doc)
        {
        }
        public List<Room> GetRooms()
        {

            col.OfCategory(BuiltInCategory.OST_Rooms);
            col.WhereElementIsNotElementType();
            var rooms= col.ToElements();
            var result=  rooms.Select(i => i as Room).ToList();
            return result;
        }
    }
}
