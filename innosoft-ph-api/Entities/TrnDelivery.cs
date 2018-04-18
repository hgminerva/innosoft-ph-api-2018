using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innosoft_ph_api.Entities
{
    public class TrnDelivery
    {
        public Int32 Id { set; get; }
        public String DeliveryNumber { set; get; }
        public String DeliveryDate { set; get; }
        public Int32 QuotationId { set; get; }
        public Int32 CustomerId { set; get; }
        public Int32 ProductId { set; get; }
        public String MeetingDate { set; get; }
        public String Remarks { set; get; }
        public Int32 SalesUserId { set; get; }
        public Int32 TechnicalUserId { set; get; }
        public Int32 FunctionalUserId { set; get; }
        public String DeliveryStatus { set; get; }
    }
}