using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innosoft_ph_api.ApiControllers
{
    [RoutePrefix("api/continuity")]
    public class ApiTrnContinuityController : ApiController
    {
        private Data.innosoftdbDataContext db = new Data.innosoftdbDataContext();

        [HttpGet, Route("list/{dateStart}/{dateEnd}")]
        public List<Entities.TrnContinuity> ListContinuity(String dateStart, String dateEnd)
        {
            var continuities = from d in db.IS_TrnContinuities.OrderByDescending(d => d.Id)
                               where d.ContinuityDate >= Convert.ToDateTime(dateStart)
                               && d.ContinuityDate <= Convert.ToDateTime(dateEnd)
                               select new Entities.TrnContinuity
                               {
                                   Id = d.Id,
                                   ContinuityNumber = d.ContinuityNumber,
                                   ContinuityDate = d.ContinuityDate.ToShortDateString(),
                                   DeliveryId = d.DeliveryId,
                                   CustomerId = d.CustomerId,
                                   ProductId = d.ProductId,
                                   ExpiryDate = d.ExpiryDate.ToShortDateString(),
                                   Remarks = d.Remarks,
                                   ContinuityAmount = d.ContinuityAmount,
                                   StaffUserId = d.StaffUserId,
                                   ContinuityStatus = d.ContinuityStatus
                               };

            return continuities.ToList();
        }

        [HttpGet, Route("detail/{id}")]
        public Entities.TrnContinuity DetailContinuity(String id)
        {
            var continuity = from d in db.IS_TrnContinuities.OrderByDescending(d => d.Id)
                             where d.Id == Convert.ToInt32(id)
                             select new Entities.TrnContinuity
                             {
                                 Id = d.Id,
                                 ContinuityNumber = d.ContinuityNumber,
                                 ContinuityDate = d.ContinuityDate.ToShortDateString(),
                                 DeliveryId = d.DeliveryId,
                                 CustomerId = d.CustomerId,
                                 ProductId = d.ProductId,
                                 ExpiryDate = d.ExpiryDate.ToShortDateString(),
                                 Remarks = d.Remarks,
                                 ContinuityAmount = d.ContinuityAmount,
                                 StaffUserId = d.StaffUserId,
                                 ContinuityStatus = d.ContinuityStatus
                             };

            return continuity.FirstOrDefault();
        }

        [HttpPost, Route("add")]
        public HttpResponseMessage AddContinuity(Entities.TrnContinuity objContinuity)
        {
            try
            {
                Data.IS_TrnContinuity newContinuity = new Data.IS_TrnContinuity
                {
                    Id = objContinuity.Id,
                    ContinuityNumber = objContinuity.ContinuityNumber,
                    ContinuityDate = Convert.ToDateTime(objContinuity.ContinuityDate),
                    DeliveryId = objContinuity.DeliveryId,
                    CustomerId = objContinuity.CustomerId,
                    ProductId = objContinuity.ProductId,
                    ExpiryDate = Convert.ToDateTime(objContinuity.ExpiryDate),
                    Remarks = objContinuity.Remarks,
                    ContinuityAmount = objContinuity.ContinuityAmount,
                    StaffUserId = objContinuity.StaffUserId,
                    ContinuityStatus = objContinuity.ContinuityStatus
                };

                db.IS_TrnContinuities.InsertOnSubmit(newContinuity);
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
        public HttpResponseMessage UpdateContinuity(Entities.TrnContinuity objContinuity, String id)
        {
            try
            {
                var continuity = from d in db.IS_TrnContinuities
                           where d.Id == Convert.ToInt32(id)
                           select d;

                if (continuity.Any())
                {
                    var updateContinuity = continuity.FirstOrDefault();
                    updateContinuity.ContinuityNumber = objContinuity.ContinuityNumber;
                    updateContinuity.ContinuityDate = Convert.ToDateTime(objContinuity.ContinuityDate);
                    updateContinuity.DeliveryId = objContinuity.DeliveryId;
                    updateContinuity.CustomerId = objContinuity.CustomerId;
                    updateContinuity.ProductId = objContinuity.ProductId;
                    updateContinuity.ExpiryDate = Convert.ToDateTime(objContinuity.ExpiryDate);
                    updateContinuity.Remarks = objContinuity.Remarks;
                    updateContinuity.ContinuityAmount = objContinuity.ContinuityAmount;
                    updateContinuity.StaffUserId = objContinuity.StaffUserId;
                    updateContinuity.ContinuityStatus = objContinuity.ContinuityStatus;
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
        public HttpResponseMessage DeleteContinuity(String id)
        {
            try
            {
                var continuity = from d in db.IS_TrnContinuities
                           where d.Id == Convert.ToInt32(id)
                           select d;

                if (continuity.Any())
                {
                    db.IS_TrnContinuities.DeleteOnSubmit(continuity.First());
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
