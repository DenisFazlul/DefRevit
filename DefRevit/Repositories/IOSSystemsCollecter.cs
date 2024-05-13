using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefRevit.Repositories
{
    public class IOSSystemsCollecter : BaseFilteredElementColecter
    {
        private string SysNameParam;
        private Element _param;
        public IOSSystemsCollecter(Document doc,string ParamNameOfSystem) : base(doc)
        {
            this.SysNameParam= ParamNameOfSystem;

            SheredParametersCollecter pc = new SheredParametersCollecter(doc);
            _param = pc.GetSharedParameter(this.SysNameParam);
            
        }
       
        public List<string> GetAllSystemsNames<T>()
        {
            var systems = new List<string>();
            FilteredElementCollector col = new FilteredElementCollector(Document);
            col.WhereElementIsNotElementType();
            col.OfClass(typeof(T));


            var elms = col.ToElements();
            foreach (Element element in elms)
            {
                var name =GetSystemName(element);
                if (systems.Contains(name) == false)
                {
                    systems.Add(name);
                }
            }
            return systems;
          
        }
        private string GetSystemName(Element e)
        {

           var p= e.LookupParameter(this.SysNameParam);
            if(p!= null)
            {
                return p.AsString();
            }
            return null;
        }
        public List<Element> GetAllElementsOfSystem<T>(string systemName)
        {
            FilteredElementCollector col = new FilteredElementCollector(Document)
                .WhereElementIsNotElementType();
            col.OfClass(typeof(T));


            ElementId id = _param.Id;
            ParameterValueProvider provider
              = new ParameterValueProvider(id);
            FilterStringRuleEvaluator evaluator
                = new FilterStringEquals();

            FilterRule rule = new FilterStringRule(
                provider, evaluator, systemName, false);

            ElementParameterFilter filter
              = new ElementParameterFilter(rule);
            col.WherePasses(filter);

            return col.ToElements().ToList();
        }
        public  FilteredElementCollector FilterBySystemName(FilteredElementCollector col,
            string systemName)
        {
            ElementId id = new ElementId(329039);
            ParameterValueProvider provider
              = new ParameterValueProvider(id);
            FilterStringRuleEvaluator evaluator
                = new FilterStringEquals();

            FilterRule rule = new FilterStringRule(
                provider, evaluator, systemName, false);

            ElementParameterFilter filter
              = new ElementParameterFilter(rule);
            col.WherePasses(filter);
            return col;
        }
    }
}
