using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.MDM.Location.Infrastructure.POCO
{
    public class POutStandingSummary
    {
        public int CompanyId { get; set; }
        public string PartyName { get; set; }
        public int PartyId { get; set; }
        public int AgentId { get; set; }
        public double BillAmount { get; set; }
        public double PaidAmount { get; set; }
        public double Balance { get; set; }
        public int TotalRowCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class POutStandingDetail
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string PartyName { get; set; }
        public int PartyId { get; set; }
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public double BillAmount { get; set; }
        public double PaidAmount { get; set; }
        public double Balance { get; set; }
    }

    public class PFinancialYear
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
