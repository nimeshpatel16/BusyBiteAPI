using System;

namespace Envision.MDM.Location.Domain.Exceptions
{
    /// <summary>
    /// Exception type for facility domain exceptions
    /// </summary>
    public class FacilityDomainException : Exception
    {
        public FacilityDomainException()
        {}

        public FacilityDomainException(string message) 
            : base(message)
        {}

        public FacilityDomainException(string message, Exception innerException) 
            : base(message, innerException)
        {}
    }
}
