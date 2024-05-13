using Autodesk.Revit.UI;
using DefRevit.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefRevit.Entities.Plugin
{
    public class PluginInstance
    {
        public RevitData RevitData { get; private set; }
        public ProjectInfo ProjectInfo { get; private set; }
        public LogService Logs { get; private set; } = new LogService(); 
        public PluginInstance(ExternalCommandData commandData)
        {
            RevitData = new RevitData(commandData);
            ProjectInfo = new ProjectInfo(RevitData.doc);
            Logs.Add(new Log("Init plugin instance", LogLevel.Info));
             
            
        }
    }
}
