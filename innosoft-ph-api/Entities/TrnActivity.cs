using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innosoft_ph_api.Entities
{
    public class TrnActivity
    {
        public Int32 Id { set; get; } 
        public String ActivityNumber { set; get; }
        public String ActivityDate { set; get; }
        public Int32 StaffUserId { set; get; }
        public Int32? CustomerId { set; get; }
        public Int32? ProductId { set; get; }
        public String ParticularCategory { set; get; }
        public String Particulars { set; get; }
        public String Location { set; get; }
        public Decimal NumberOfHours { set; get; }
        public Decimal ActivityAmount { set; get; }
        public String ActivityStatus { set; get; }
        public Int32? LeadId { set; get; }
        public Int32? QuotationId { set; get; }
        public Int32? DeliveryId { set; get; }
        public Int32? SupportId { set; get; }
        public Int32? SoftwareDevelopmentId { set; get; }
    }
}