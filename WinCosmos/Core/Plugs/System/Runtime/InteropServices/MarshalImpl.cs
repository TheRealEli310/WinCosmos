using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Core_Plugs.System.Runtime.InteropServices
{
    //[Plug(Target = typeof(global::System.Runtime.InteropServices.Marshal))]
    public static class MarshalImpl
    {
        public static void CCtor()
        {
        }

        public static int GetLastWin32Error()
        {
            return 0;
        }
    }

}
