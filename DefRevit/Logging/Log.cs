using System;
using System.Collections.Generic;
using System.Text;

namespace DefRevit.Logging
{
    public class Log
    {
        public string Message { get;private set; }
        public LogLevel LogLevel { get; private set; }
        public Log(string message,LogLevel Level)
        {
            Message = message;
            LogLevel = Level;
        }
    }
}
