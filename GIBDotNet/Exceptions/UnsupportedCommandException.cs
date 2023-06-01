using System;

namespace GIBDotNet.Exceptions
{
    public class UnsupportedCommandException : Exception
    {
        public UnsupportedCommandException(Type type) : base ($"{type.Name} Unsupported command")
        {
                
        }
    }
}
