using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innosoft_ph_api.ApiControllers
{
    [RoutePrefix("api/support")]
    public class TrnSupportController : ApiController
    {
        private Data.innosoftdbDataContext db = new Data.innosoftdbDataContext();

        [HttpGet, Route("list/{dateStart}/{dateEnd}")]
        public List<Entities.TrnSupport> ListSupport(String dateStart, String dateEnd)
        {
            var supports = from d in db.IS_TrnSupports.OrderByDescending(d => d.Id)
                           where d.SupportDate >= Convert.ToDateTime(dateStart)
                           && d.SupportDate <= Convert.ToDateTime(dateEnd)
                           select new Entities.TrnSupport
                           {
                               Id = d.Id,
                               SupportNumber = d.SupportNumber,
                               SupportDate = d.SupportDate.ToShortDateString(),
                               ContinuityId = d.ContinuityId,
                               IssueCategory = d.IssueCategory,
                               Issue = d.Issue,
                               CustomerId = d.CustomerId,
                               ProductId = d.ProductId,
                               Severity = d.Severity,
                               Caller = d.Caller,
                               Remarks = d.Remarks,
                               ScreenShotURL = d.ScreenShotURL,
                               SupportType = d.SupportType,
                               EncodedByUserId = d.EncodedByUserId,
                               AssignedToUserId = d.AssignedToUserId,
                               SupportStatus = d.SupportStatus
                           };

            return supports.ToList();
        }


        [HttpGet, Route("detail/{id}")]
        public Entities.TrnSupport DetailSupoort(String id)
        {
            var support = from d in db.IS_TrnSupports.OrderByDescending(d => d.Id)
                          where d.Id == Convert.ToInt32(id)
                          select new Entities.TrnSupport
                          {
                              Id = d.Id,
                              SupportNumber = d.SupportNumber,
                              SupportDate = d.SupportDate.ToShortDateString(),
                              ContinuityId = d.ContinuityId,
                              IssueCategory = d.IssueCategory,
                              Issue = d.Issue,
                              CustomerId = d.CustomerId,
                              ProductId = d.ProductId,
                              Severity = d.Severity,
                              Caller = d.Caller,
                              Remarks = d.Remarks,
                              ScreenShotURL = d.ScreenShotURL,
                              SupportType = d.SupportType,
                              EncodedByUserId = d.EncodedByUserId,
                              AssignedToUserId = d.AssignedToUserId,
                              SupportStatus = d.SupportStatus
                          };

            return support.FirstOrDefault();
        }

        [HttpPost, Route("add")]
        public HttpResponseMessage AddSupporty(Entities.TrnSupport objSupport)
        {
            try
            {
                Data.IS_TrnSupport newSupport = new Data.IS_TrnSupport
                {
                    Id = objSupport.Id,
                    SupportNumber = objSupport.SupportNumber,
                    SupportDate = Convert.ToDateTime(objSupport.SupportDate),
                    ContinuityId = objSupport.ContinuityId,
                    IssueCategory = objSupport.IssueCategory,
                    Issue = objSupport.Issue,
                    CustomerId = objSupport.CustomerId,
                    ProductId = objSupport.ProductId,
                    Severity = objSupport.Severity,
                    Caller = objSupport.Caller,
                    Remarks = objSupport.Remarks,
                    ScreenShotURL = objSupport.ScreenShotURL,
                    SupportType = objSupport.SupportType,
                    EncodedByUserId = objSupport.EncodedByUserId,
                    AssignedToUserId = objSupport.AssignedToUserId,
                    SupportStatus = objSupport.SupportStatus
                };

                db.IS_TrnSupports.InsertOnSubmit(newSupport);
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
        public HttpResponseMessage UpdateSupport(Entities.TrnSupport objSupport, String id)
        {
            try
            {
                var support = from d in db.IS_TrnSupports
                              where d.Id == Convert.ToInt32(id)
                              select d;

                if (support.Any())
                {
                    var updatesupport = support.FirstOrDefault();
                    updatesupport.SupportNumber = objSupport.SupportNumber;
                    updatesupport.SupportDate = Convert.ToDateTime(objSupport.SupportDate);
                    updatesupport.ContinuityId = objSupport.ContinuityId;
                    updatesupport.IssueCategory = objSupport.IssueCategory;
                    updatesupport.Issue = objSupport.Issue;
                    updatesupport.CustomerId = objSupport.CustomerId;
                    updatesupport.ProductId = objSupport.ProductId;
                    updatesupport.Severity = objSupport.Severity;
                    updatesupport.Caller = objSupport.Caller;
                    updatesupport.Remarks = objSupport.Remarks;
                    updatesupport.ScreenShotURL = objSupport.ScreenShotURL;
                    updatesupport.SupportType = objSupport.SupportType;
                    updatesupport.EncodedByUserId = objSupport.EncodedByUserId;
                    updatesupport.AssignedToUserId = objSupport.AssignedToUserId;
                    updatesupport.SupportStatus = objSupport.SupportStatus;
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
        public HttpResponseMessage DeleteSupport(String id)
        {
            try
            {
                var support = from d in db.IS_TrnSupports
                                 where d.Id == Convert.ToInt32(id)
                                 select d;

                if (support.Any())
                {
                    db.IS_TrnSupports.DeleteOnSubmit(support.First());
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
