using System;
using System.Globalization;

namespace Cosmos.Core_Plugs.System.Globalization
{
    //[Plug(Target = typeof(NumberFormatInfo))]
    public static class NumberFormatInfoImpl
    {
        public static NumberFormatInfo GetInstance(IFormatProvider aProvider)
        {
            return null;
        }


        public static NumberFormatInfo get_CurrentInfo()
        {
            return null;
        }
    }
}
