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
            var info = new ProcessStartInfo(Environment.GetCommandLineArgs()[0]);
            Process.Start(info);
            Environment.Exit(0);
        }
        public static void Shutdown()
        {
            Environment.Exit(0);
        }
    }
}
