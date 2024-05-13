using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DefRevit.Logging
{
    public class LogSet:IEnumerable
    {
        private List<Log> logList = new List<Log>();
        public LogSet()
        {

        }
        public void Add(Log log)
        {
            logList.Add(log);
        }

        public IEnumerator GetEnumerator()
        {
           return logList.GetEnumerator();
        }
    }
}
