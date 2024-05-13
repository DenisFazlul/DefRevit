using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
 

namespace DefRevit.ButtonServices
{
    public  class ButtonBuilder
    {
        private UIControlledApplication _a;
        public ButtonBuilder(UIControlledApplication a) 
        { 
            _a = a;
        }
        public PushButton CreateButton(ButtonConfig config)
        {
           var panel= CreateRibon(config.TabName, config.PanelName);
            var btn = CreateButton(panel, config);
            return btn;

        }
        private PushButton CreateButton( RibbonPanel panel,ButtonConfig config)
         
        {

             
            string dirToClass=config.ClassName.ToString();
            string thisAssemblyPath = config.ClassName.Assembly.Location;
            PushButton button = panel.AddItem(new PushButtonData(config.Name, config.DisplayName,
                thisAssemblyPath, dirToClass)) as PushButton;

 

            
           // button.LargeImage = ImgToSource(imageFromResource);

            if(string.IsNullOrEmpty(config.ToolTip) == false)
            {
                button.ToolTip = config.ToolTip;
            }
           
            if(config.Icon!=null)
            {

            }

 
            //справка из веб страницы
            if(string.IsNullOrEmpty(config.ContextHelp)==false)
            {
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.ChmFile, config.ContextHelp);
                button.SetContextualHelp(contextHelp);

            }
            

            return button;
        }
        private RibbonPanel CreateRibon(string TabName, string PanelName)
        {
             
            RibbonPanel ribbonPanel = null;
            // Try to create ribbon tab. 
            try
            {
                _a.CreateRibbonTab(TabName);
            }
            catch { }
            // Try to create ribbon panel.
            try
            {
                RibbonPanel panel = _a.CreateRibbonPanel(TabName,PanelName);
            }
            catch { }
            // Search existing tab for your panel.
            List<RibbonPanel> panels = _a.GetRibbonPanels(TabName);
            foreach (RibbonPanel p in panels)
            {
                if (p.Name == PanelName)
                {
                    ribbonPanel = p;
                }
            }
            //return panel 
            return ribbonPanel;
        }

        

    }
}
