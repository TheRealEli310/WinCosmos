using System;
using System.Resources;

namespace Cosmos.Core_Plugs.System.Resources
{
    //[Plug(typeof(ResourceManager))]
    public static class ResourceManagerImpl
    {
        public static void CCtor()
        {
        }


        public static void Ctor(Type aResourceSource)
        {
        }

        public static string GetString(string aString)
        {
            return SRImpl.InternalGetResourceString(aString);
        }
    }
}
