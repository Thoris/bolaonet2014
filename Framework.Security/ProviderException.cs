using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Framework.Security
{
    [Serializable]
    public class ProviderException : Exception 
    {
        public ProviderException(string message) : base(message) { }
        protected ProviderException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
