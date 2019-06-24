using Envision.MDM.Location.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.MDM.Location.Domain.AggregatesModel
{
    public class OutStanding : Entity, IAggregateRoot
    {
        public int Id { get; set; }
        public int CCOde { get; set; }
        public int FYear { get; set; }

        public OutStanding()
        {
        }

        public OutStanding(int id)
        {
            base.Id = Id;
        }
    }
}
