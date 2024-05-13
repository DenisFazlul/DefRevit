using System;
using System.Collections.Generic;
using System.Text;

namespace DefRevit.Logging
{
    public interface ILogSaverSrvice
    {
         void Save(LogSet set);
    }
}
