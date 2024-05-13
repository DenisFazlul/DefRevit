using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefRevit.ButtonServices
{
    public class ButtonConfig
    {
        public string Name { get; set; }=Guid.NewGuid().ToString();
        public string DisplayName { get; set; } = "NewButton";

        
        public Type ClassName { get; set; }

         
        public string Description { get; set; }
        public string TabName { get; set; } = "DefRevit";
        public string PanelName { get; set; } = "Main";
        public string ContextHelp { get; set; }
        
        public string ToolTip { get; set; }
        public Bitmap Icon { get; set; }

        public ButtonConfig(Type commandClass)
        {
            ClassName = commandClass;
        }
        

        
    }
}
