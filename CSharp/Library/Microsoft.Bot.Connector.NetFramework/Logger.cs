using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.TraceSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Microsoft.Bot.Connector
{
    public class Logger : TraceSourceLogger
    {
        public Logger() : base(new TraceSource("botTrace"))
        {
        }
    }
}
