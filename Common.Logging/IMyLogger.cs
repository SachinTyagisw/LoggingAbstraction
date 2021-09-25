using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Logging
{
    //This interface shall be exposed to the outer world and consumer will call AddLog method to log the exception. Caller will not be
    //aware of the implementation of any third party logging library (serilog, NLog etc).
    public interface IMyLogger
    {
        void AddLog(LogEvent logEvent);
    }
}
