using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmos.Core_Plugs.System
{
    //[Plug(Target = typeof(global::System.Globalization.CharUnicodeInfo))]
    public static class CharUnicodeInfoImpl
    {
        public static void Cctor()
        {

        }

        public static bool InitTable()
        {
            return false;
        }
    }
}
