using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.MDM.Location.Infrastructure.Entity.POCO
{
    public class PFacility
    {
        public int FacilityID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public string FacilityLegalName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string FacilityEntityLegalName { get; set; }
    }
}
