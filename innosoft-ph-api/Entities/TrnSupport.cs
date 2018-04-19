using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innosoft_ph_api.Entities
{
    public class TrnSupport
    {
        public Int32 Id { set; get; }
        public String SupportNumber { set; get; }
        public String SupportDate { set; get; }
        public Int32 ContinuityId { set; get; }
        public String IssueCategory { set; get; }
        public String Issue { set; get; }
        public Int32 CustomerId { set; get; }
        public Int32 ProductId { set; get; }
        public String Severity { set; get; }
        public String Caller { set; get; }
        public String Remarks { set; get; }
        public String ScreenShotURL { set; get; }
        public String SupportType { set; get; }
        public Int32 EncodedByUserId { set; get; }
        public Int32? AssignedToUserId { set; get; }
        public String SupportStatus { set; get; }
    }
}