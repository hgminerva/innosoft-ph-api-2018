using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innosoft_ph_api.ApiControllers
{
    [RoutePrefix("api/leads")]
    public class ApiTrnLeadController : ApiController
    {
        private Data.innosoftdbDataContext db = new Data.innosoftdbDataContext();

        [HttpGet, Route("list/{dateStart}/{dateEnd}")]
        public List<Entities.TrnLeads> ListLead(String dateStart, String dateEnd)
        {
            var leads = from d in db.IS_TrnLeads.OrderByDescending(d => d.Id)
                        where d.LeadDate >= Convert.ToDateTime(dateStart)
                        && d.LeadDate <= Convert.ToDateTime(dateEnd)
                        select new Entities.TrnLeads
                        {
                            Id = d.Id,
                            LeadNumber = d.LeadNumber,
                            LeadDate = d.LeadDate.ToShortDateString(),
                            LeadName = d.LeadName,
                            Address = d.Address,
                            ContactPerson = d.ContactPerson,
                            ContactPosition = d.ContactPosition,
                            ContactEmail = d.ContactEmail,
                            ContactPhoneNo = d.ContactPhoneNo,
                            ReferredBy = d.ReferredBy,
                            Remarks = d.Remarks,
                            EncodedByUserId = d.EncodedByUserId,
                            AssignedToUserId = d.AssignedToUserId,
                            LeadStatus = d.LeadStatus
                        };

            return leads.ToList();
        }

        [HttpGet, Route("detail/{id}")]
        public Entities.TrnLeads DetailLead(String id)
        {
            var leads = from d in db.IS_TrnLeads.OrderByDescending(d => d.Id)
                        where d.Id == Convert.ToInt32(id)
                        select new Entities.TrnLeads
                        {
                            Id = d.Id,
                            LeadNumber = d.LeadNumber,
                            LeadDate = d.LeadDate.ToShortDateString(),
                            LeadName = d.LeadName,
                            Address = d.Address,
                            ContactPerson = d.ContactPerson,
                            ContactPosition = d.ContactPosition,
                            ContactEmail = d.ContactEmail,
                            ContactPhoneNo = d.ContactPhoneNo,
                            ReferredBy = d.ReferredBy,
                            Remarks = d.Remarks,
                            EncodedByUserId = d.EncodedByUserId,
                            AssignedToUserId = d.AssignedToUserId,
                            LeadStatus = d.LeadStatus
                        };

            return leads.FirstOrDefault();
        }

        [HttpPost, Route("add")]
        public HttpResponseMessage AddLead(Entities.TrnLeads objLead)
        {
            try
            {
                Data.IS_TrnLead newLead = new Data.IS_TrnLead
                {
                    Id = objLead.Id,
                    LeadNumber = objLead.LeadNumber,
                    LeadDate = Convert.ToDateTime(objLead.LeadDate),
                    LeadName = objLead.LeadName,
                    Address = objLead.Address,
                    ContactPerson = objLead.ContactPerson,
                    ContactPosition = objLead.ContactPosition,
                    ContactEmail = objLead.ContactEmail,
                    ContactPhoneNo = objLead.ContactPhoneNo,
                    ReferredBy = objLead.ReferredBy,
                    Remarks = objLead.Remarks,
                    EncodedByUserId = objLead.EncodedByUserId,
                    AssignedToUserId = objLead.AssignedToUserId,
                    LeadStatus = objLead.LeadStatus
                };

                db.IS_TrnLeads.InsertOnSubmit(newLead);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Added!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something's went wrong!");
            }
        }

        [HttpPut, Route("update/{id}")]
        public HttpResponseMessage UpdateLead(Entities.TrnLeads objLead, String id)
        {
            try
            {
                var lead = from d in db.IS_TrnLeads
                           where d.Id == Convert.ToInt32(id)
                           select d;

                if (lead.Any())
                {
                    var updateLead = lead.FirstOrDefault();
                    updateLead.LeadNumber = objLead.LeadNumber;
                    updateLead.LeadDate = Convert.ToDateTime(objLead.LeadDate);
                    updateLead.LeadName = objLead.LeadName;
                    updateLead.Address = objLead.Address;
                    updateLead.ContactPerson = objLead.ContactPerson;
                    updateLead.ContactPosition = objLead.ContactPosition;
                    updateLead.ContactEmail = objLead.ContactEmail;
                    updateLead.ContactPhoneNo = objLead.ContactPhoneNo;
                    updateLead.ReferredBy = objLead.ReferredBy;
                    updateLead.Remarks = objLead.Remarks;
                    updateLead.AssignedToUserId = objLead.AssignedToUserId;
                    updateLead.LeadStatus = objLead.LeadStatus;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Data Not Exist!");
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something's went wrong!");
            }
        }

        [HttpDelete, Route("delete/{id}")]
        public HttpResponseMessage DeleteLead(String id)
        {
            try
            {
                var lead = from d in db.IS_TrnLeads
                           where d.Id == Convert.ToInt32(id)
                           select d;

                if (lead.Any())
                {
                    db.IS_TrnLeads.DeleteOnSubmit(lead.First());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Data Not Exist!");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something's went wrong!");
            }
        }
    }
}
