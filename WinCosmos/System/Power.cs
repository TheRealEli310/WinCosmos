using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Cosmos.System
{
    public static class Power
    {
        public static void Reboot()
        {
            Process.Start(Environment.CommandLine);
            Environment.Exit(0);
        }
        public static void Shutdown()
        {
            Environment.Exit(0);
        }
    }
}
