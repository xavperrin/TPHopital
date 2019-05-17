using System;
using System.Runtime.Serialization;

namespace TPHopital.Classes.DAO
{
    [Serializable]
    internal class InsertPatientException : Exception
    {
        public InsertPatientException()
        {
        }

        public InsertPatientException(string message) : base(message)
        {
        }

        public InsertPatientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsertPatientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}