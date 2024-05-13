using Autodesk.Revit.DB;
using DefRevit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefRevit.Repositories
{
    public class SheredParametersCollecter : BaseFilteredElementColecter
    {
        public SheredParametersCollecter(Document doc) : base(doc)
        {
        }
        public Element GetSharedParameter(string parameterName)
        {
            List<Element> sharedParams = new List<Element>();
            
              col.WhereElementIsNotElementType();
            // Filter elements for shared parameters only
            col.OfClass(typeof(SharedParameterElement));
            sharedParams = col.ToElements().ToList();
            var cur = sharedParams.Where(i => i.Name == parameterName).FirstOrDefault();
            if(cur==null)
            {
                throw new ElementNotFoundException();
            }    
            return cur;
        }
        public List<Element> GetParamtersWithPrefix(string prefix)
        {
            List<Element> sharedParams = new List<Element>();
            col.WhereElementIsNotElementType();
            // Filter elements for shared parameters only
            col.OfClass(typeof(SharedParameterElement));
            sharedParams = col.ToElements().ToList();
            sharedParams = sharedParams.Where(i => i.Name.StartsWith(prefix)).ToList();
            
            return sharedParams;
        }
    }
}
