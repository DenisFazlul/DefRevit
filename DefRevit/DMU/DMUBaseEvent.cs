using System;
using System.Collections.Generic;
using System.ComponentModel;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace DefRevit.DMU
{
     
    public class DmuBaseEvent:IUpdater
    {
        private AddInId _addInId;
        
        private UpdaterId _uid;
        private Guid _guid;
        public ElementFilter Filter;
        public List<ChangeType> ChangeType;
        public bool IsRunning = true;
        public DmuBaseEvent(UIControlledApplication a,List<Type> types,List<ChangeType> changeType)
        {
            ChangeType = changeType;
           _addInId= a.ActiveAddInId;
            
           _guid = Guid.NewGuid();
           _uid = new UpdaterId(_addInId,_guid);
            Filter = new ElementMulticlassFilter(types);
        }
        public void Execute(UpdaterData data)
        {
            if (IsRunning == false)
            {
                return;
            }
            
        }

        public UpdaterId GetUpdaterId()
        {
            return _uid;
        }

        public ChangePriority GetChangePriority()
        {
            return ChangePriority.MEPSystems;
        }

        public string GetUpdaterName()
        {
            return this._guid.ToString();
        }

        public string GetAdditionalInformation()
        {
            return "info";
        }
    }
}