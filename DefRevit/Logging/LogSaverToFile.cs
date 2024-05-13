using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DefRevit.Logging
{
    public class LogSaverToFile : ILogSaverSrvice
    {
        private string _path;
        public LogSaverToFile(string pathToSave)
        {
            _path = pathToSave; 
        }
        public void Save(LogSet set)
        {
            StringBuilder st = new StringBuilder();
            foreach (Log item in set)
            {
                st.Append(item.Message);
                st.Append('|');
                st.Append(item.LogLevel);
                st.Append('|');
                st.AppendLine();
            }

            File.WriteAllText(st.ToString(), _path);
        }
    }
}
