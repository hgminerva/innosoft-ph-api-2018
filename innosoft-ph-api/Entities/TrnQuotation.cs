using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innosoft_ph_api.Entities
{
    public class TrnQuotation
    {
        public Int32 Id { set; get; }
        public String QuotationNumber { set; get; }
        public String QuotationDate { set; get; }
        public Int32 LeadId { set; get; }
        public Int32 CustomerId { set; get; }
        public Int32 ProductId { set; get; }
        public String Remarks { set; get; }
        public Int32 EncodedByUserId { set; get; }
        public String QuotationStatus { set; get; }
    }
}