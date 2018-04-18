using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innosoft_ph_api.ApiControllers
{
    [RoutePrefix("api/delivery")]
    public class ApiTrnDeliveryController : ApiController
    {
        private Data.innosoftdbDataContext db = new Data.innosoftdbDataContext();

        [HttpGet, Route("list/{dateStart}/{dateEnd}")]
        public List<Entities.TrnDelivery> ListDelivery(String dateStart, String dateEnd)
        {
            var deliveries = from d in db.IS_TrnDeliveries.OrderByDescending(d => d.Id)
                             where d.DeliveryDate >= Convert.ToDateTime(dateStart)
                             && d.DeliveryDate <= Convert.ToDateTime(dateEnd)
                             select new Entities.TrnDelivery
                             {
                                 Id = d.Id,
                                 DeliveryNumber = d.DeliveryNumber,
                                 DeliveryDate = d.DeliveryDate.ToShortDateString(),
                                 QuotationId = d.QuotationId,
                                 CustomerId = d.CustomerId,
                                 ProductId = d.ProductId,
                                 MeetingDate = d.MeetingDate.ToShortDateString(),
                                 Remarks = d.Remarks,
                                 SalesUserId = d.SalesUserId,
                                 TechnicalUserId = d.TechnicalUserId,
                                 FunctionalUserId = d.FunctionalUserId,
                                 DeliveryStatus = d.DeliveryStatus
                             };

            return deliveries.ToList();

        }

        [HttpGet, Route("detail/{id}")]
        public Entities.TrnDelivery DetailDelivery(String id)
        {
            var delivery = from d in db.IS_TrnDeliveries
                           where d.Id == Convert.ToInt32(id)
                           select new Entities.TrnDelivery
                           {
                               Id = d.Id,
                               DeliveryNumber = d.DeliveryNumber,
                               DeliveryDate = d.DeliveryDate.ToShortDateString(),
                               QuotationId = d.QuotationId,
                               CustomerId = d.CustomerId,
                               ProductId = d.ProductId,
                               MeetingDate = d.MeetingDate.ToShortDateString(),
                               Remarks = d.Remarks,
                               SalesUserId = d.SalesUserId,
                               TechnicalUserId = d.TechnicalUserId,
                               FunctionalUserId = d.FunctionalUserId,
                               DeliveryStatus = d.DeliveryStatus
                           };

            return delivery.FirstOrDefault();
        }

        [HttpPost, Route("add")]
        public HttpResponseMessage AddDelivery(Entities.TrnDelivery objDelivery)
        {
            try
            {
                Data.IS_TrnDelivery newDelivery = new Data.IS_TrnDelivery
                {
                    Id = objDelivery.Id,
                    DeliveryNumber = objDelivery.DeliveryNumber,
                    DeliveryDate = Convert.ToDateTime(objDelivery.DeliveryDate),
                    QuotationId = objDelivery.QuotationId,
                    CustomerId = objDelivery.CustomerId,
                    ProductId = objDelivery.ProductId,
                    MeetingDate = Convert.ToDateTime(objDelivery.MeetingDate),
                    Remarks = objDelivery.Remarks,
                    SalesUserId = objDelivery.SalesUserId,
                    TechnicalUserId = objDelivery.TechnicalUserId,
                    FunctionalUserId = objDelivery.FunctionalUserId,
                    DeliveryStatus = objDelivery.DeliveryStatus
                };

                db.IS_TrnDeliveries.InsertOnSubmit(newDelivery);
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
        public HttpResponseMessage UpdateDelivery(Entities.TrnDelivery objDelivery, String id)
        {
            try
            {
                var delivery = from d in db.IS_TrnDeliveries
                               where d.Id == Convert.ToInt32(id)
                               select d;

                if (delivery.Any())
                {
                    var updateDelivery = delivery.FirstOrDefault();
                    updateDelivery.DeliveryNumber = objDelivery.DeliveryNumber;
                    updateDelivery.DeliveryDate = Convert.ToDateTime(objDelivery.DeliveryDate);
                    updateDelivery.QuotationId = objDelivery.QuotationId;
                    updateDelivery.CustomerId = objDelivery.CustomerId;
                    updateDelivery.ProductId = objDelivery.ProductId;
                    updateDelivery.MeetingDate = Convert.ToDateTime(objDelivery.MeetingDate);
                    updateDelivery.Remarks = objDelivery.Remarks;
                    updateDelivery.SalesUserId = objDelivery.SalesUserId;
                    updateDelivery.TechnicalUserId = objDelivery.TechnicalUserId;
                    updateDelivery.FunctionalUserId = objDelivery.FunctionalUserId;
                    updateDelivery.DeliveryStatus = objDelivery.DeliveryStatus;
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
        public HttpResponseMessage DeleteQuation(String id)
        {
            try
            {
                var delivery = from d in db.IS_TrnDeliveries
                               where d.Id == Convert.ToInt32(id)
                               select d;

                if (delivery.Any())
                {
                    db.IS_TrnDeliveries.DeleteOnSubmit(delivery.First());
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
