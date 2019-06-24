using Envision.MDM.Location.Domain.Common;
using System;

namespace Envision.MDM.Location.Domain.AggregatesModel
{
    /// <summary>
    /// Author:         Johng
    /// Created Date:   03/01/2019
    /// Description:    This class represent the Facility Domain agregate root for a given facility
    /// </summary>
    public class Facility
        : Entity, IAggregateRoot
    {
        public int FacilityID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public Address Address { get; set; }
        public Nullable<int> PageIndex { get; set; }
        public Nullable<int> PageSize { get; set; }
        public string SortDirection { get; set; }
        public string SortbyColumn { get; set; }
        public Facility()
        {
        }
        public Facility (int id)
        {
            base.Id = id;
            Address = new Address();
        }

        public Facility(int id, string name)
        {
            base.Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = new Address();
        }

        public Facility(int id,  string name, string code, string legalName, string facilityLegalName)
        {
            base.Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            LegalName = legalName ?? throw new ArgumentNullException(nameof(legalName));
            Address = new Address();
        }

        /// <summary>
        /// This method will add an address to the facility 
        /// </summary>
        public void AddNewAddess(Address address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
        } 
        
    }

    public class RequestFacility : IAggregateRoot
    {
        public RequestFacility() { }

        public Nullable<int> PageIndex { get; set; }
        public Nullable<int> PageSize { get; set; }
        public string SortDirection { get; set; }
        public string SortbyColumn { get; set; }
    }

    public class ResponseFacility : IAggregateRoot
    {
        public ResponseFacility() { }
        public int FacilityID { get; set; }
        public string Name { get; set; }
        public ResponseFacility(int FacilityId, string FacilityName)
        {
            FacilityID = FacilityId;
            Name = FacilityName;
        }
        public ResponseFacility(int FacilityId)
        {
            FacilityID = FacilityId;
        }
    }
}
