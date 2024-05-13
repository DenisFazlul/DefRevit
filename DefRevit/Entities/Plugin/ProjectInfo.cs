using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefRevit.Entities.Plugin
{
    public class ProjectInfo
    {
        public string Title { get; set; }
        public string PathToFile { get; set; }
        public ProjectInfo(Document doc)
        {
            Title = doc.Title;
            PathToFile = ParceDocPath(doc);
        }
        private string ParceDocPath(Document doc)
        {
            string pathToFile = null;
            try
            {

                ModelPath t = doc.GetWorksharingCentralModelPath();
                pathToFile = ModelPathUtils.ConvertModelPathToUserVisiblePath(t);
            }
            catch
            {
                pathToFile = doc.PathName;
            }
            return pathToFile;
        }

    }
}
