using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace DefRevit.DMU
{
    public class DmuService
    {
        public List<DmuBaseEvent> events = new List<DmuBaseEvent>();
        public DmuService()
        {
            
        }

        public void Add(DmuBaseEvent ev)
        {
            events.Add(ev);
        }

        public void AddAndUp(DmuBaseEvent ev)
        {
            events.Add(ev);
            try
            {
                foreach (var changeType in ev.ChangeType)
                {
                    UpdaterRegistry.AddTrigger(ev.GetUpdaterId(),ev.Filter,changeType);
                }
                 
            }
            catch (Exception e)
            {
                    
            }
           
        }
        public void Up()
        {
            foreach (var ev in events)
            {
                try
                {
                    foreach (var changeType in ev.ChangeType)
                    {
                        UpdaterRegistry.AddTrigger(ev.GetUpdaterId(),ev.Filter,changeType);
                    }
                   
                }
                catch (Exception e)
                {
                    
                }
                 
            }
            
        }

        public void Down()
        {
            foreach (var ev in events)
            {

                try
                {
                    UpdaterRegistry.UnregisterUpdater(ev.GetUpdaterId());
                }
                catch (Exception e)
                {
                    
                }
               
            }
            
        }
    }
}