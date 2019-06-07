using System;
using System.Runtime.Serialization;

namespace TPHopitalWpf.Classes.DAO
{
    [Serializable]
    internal class HospitalisationCreateException : Exception
    {
        public HospitalisationCreateException()
        {
        }

        public HospitalisationCreateException(string message) : base(message)
        {
        }

        public HospitalisationCreateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HospitalisationCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}