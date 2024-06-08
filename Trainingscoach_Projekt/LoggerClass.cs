using Serilog.Core;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Trainingscoach_Projekt
{
    internal class LoggerClass
    {
        public static Logger logger { get; private set; } = new LoggerConfiguration().WriteTo.File("/src/logs/log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7).CreateLogger();
    }
}
