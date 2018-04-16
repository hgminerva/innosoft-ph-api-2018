using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innosoft_ph_api.Entities
{
    public class TrnLeads
    {
        public Int32 Id { set; get; }
        public String LeadNumber { set; get; }
        public String LeadDate { set; get; }
        public String LeadName { set; get; }
        public String Address { set; get; }
        public String ContactPerson { set; get; }
        public String ContactPosition { set; get; }
        public String ContactEmail { set; get; }
        public String ContactPhoneNo { set; get; }
        public String ReferredBy { set; get; }
        public String Remarks { set; get; }
        public Int32 EncodedByUserId { set; get; }
        public Int32? AssignedToUserId { set; get; }
        public String LeadStatus { set; get; }
    }
}