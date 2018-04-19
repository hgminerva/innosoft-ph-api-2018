using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innosoft_ph_api.Entities
{
    public class TrnContinuity
    {
        public Int32 Id { set; get; }
        public String ContinuityNumber { set; get; }
        public String ContinuityDate { set; get; }
        public Int32 DeliveryId { set; get; }
        public Int32 CustomerId { set; get; }
        public Int32 ProductId { set; get; }
        public String ExpiryDate { set; get; }
        public String Remarks { set; get; }
        public Decimal ContinuityAmount { set; get; }
        public Int32 StaffUserId { set; get; }
        public String ContinuityStatus { set; get; }
    }
}