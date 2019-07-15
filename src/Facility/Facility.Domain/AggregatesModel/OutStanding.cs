using Envision.MDM.Location.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.MDM.Location.Domain.AggregatesModel
{
    public class OutStandingSummary : Entity, IAggregateRoot
    {
        public int companyId { get; set; }
        public string partyName { get; set; }
        public int partyId { get; set; }
        public int agentId { get; set; }
        public double BillAmount { get; set; }
        public double PaidAmount { get; set; }
        public double Balance { get; set; }
        public int TotalRowCount { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public OutStandingSummary()
        {
        }

        public OutStandingSummary(int id)
        {
            base.Id = Id;
        }
    }

    public class OutStandingDetail : Entity, IAggregateRoot
    {

        public int companyId { get; set; }
        public string companyName { get; set; }
        public string partyName { get; set; }
        public int partyId { get; set; }
        public int agentId { get; set; }
        public string agentName { get; set; }
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public double BillAmount { get; set; }
        public double PaidAmount { get; set; }
        public double Balance { get; set; }



        public OutStandingDetail()
        {
        }

        public OutStandingDetail(int id)
        {
            base.Id = Id;
        }
    }

    public class RequestOutStandingSummary : IAggregateRoot
    {
        public RequestOutStandingSummary() { }

        public int companyId { get; set; }
        public int partyId { get; set; }
        public int agentId { get; set; }
        public DateTime date1 { get; set; }
        public DateTime date2 { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string SortDirection { get; set; }
        public string SortbyColumn { get; set; }
    }

    public class RequestOutStandingDetail : IAggregateRoot
    {
        public RequestOutStandingDetail() { }

        public int? companyId { get; set; }
        public int? partyId { get; set; }
        public int? agentId { get; set; }
        public DateTime? date1 { get; set; }
        public DateTime? date2 { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string SortDirection { get; set; }
        public string SortbyColumn { get; set; }
    }

    public class FinancialYear
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
