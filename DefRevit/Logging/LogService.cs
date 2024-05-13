using System;
using System.Collections.Generic;
using System.Text;

namespace DefRevit.Logging
{
    public class LogService
    {
        private LogSet _logSet;
        private ILogSaverSrvice _logSaveSrvice;
        public LogService()
        {
            _logSet = new LogSet();
        }
        public void Add(Log log)
        {
            _logSet.Add(log);
        }
        public LogSet GetLogs()
        {
            return _logSet;
        }
        public void SaveLogs()
        {
            if(_logSaveSrvice!= null )
            {
                this._logSaveSrvice.Save(this._logSet);
            }
            
        }
        public void UseLogSaver(ILogSaverSrvice srv)
        {
            this._logSaveSrvice = srv;
        }
        public void UseFileLog(string pathToFile)
        {
            this._logSaveSrvice=new LogSaverToFile(pathToFile);

        }
        
    }
}
