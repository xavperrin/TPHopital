using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TPHopital.Classes.Exceptions
{
    public class MedecinNotFoundException : Exception
    {
        public MedecinNotFoundException()
        {
        }

        public MedecinNotFoundException(string message) : base(message)
        {
        }

        public MedecinNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MedecinNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
