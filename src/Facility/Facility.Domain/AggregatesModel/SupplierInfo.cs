using Envision.MDM.Location.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.MDM.Location.Domain.AggregatesModel
{
    public class SupplierInfo : Entity, IAggregateRoot
    {
        public int partyId { get; set; }
        public string partyName { get; set; }
        //public string CAdd1 { get; set; }
        //public string CAdd2 { get; set; }
        //public string CCity { get; set; }
        //public string CPincode { get; set; }
        //public string CState { get; set; }
        //public string CCstNo { get; set; }
        //public string CGstNo { get; set; }
        //public string CTinNo { get; set; }
        //public string CPanNo { get; set; }
        //public string CPinNo { get; set; }

        public SupplierInfo() { }

        public SupplierInfo(int id) { base.Id = id; }

        public SupplierInfo(int id, string Name)
        {
            base.Id = id;
            partyId = id;
            partyName = Name;
        }
    }
}
