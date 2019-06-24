using Envision.MDM.Location.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;


namespace Envision.MDM.Location.Domain.AggregatesModel
{
    /// <summary>
    /// Address value object for Facility Domain
    /// </summary>
    public class Address : ValueObject
    {
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String ZipCode { get; set; }

        public Address()
        {
        }

        public Address(string street, string city, string state, string country, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;

        }
    }
}
