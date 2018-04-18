using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innosoft_ph_api.ApiControllers
{
    [RoutePrefix("api/quotations")]
    public class ApiTrnQuotationController : ApiController
    {
        private Data.innosoftdbDataContext db = new Data.innosoftdbDataContext();

        [HttpGet, Route("list/{dateStart}/{dateEnd}")]
        public List<Entities.TrnQuotation> ListQuotation(String dateStart, String dateEnd)
        {
            var quotations = from d in db.IS_TrnQuotations.OrderByDescending(d => d.Id)
                             where d.QuotationDate >= Convert.ToDateTime(dateStart)
                             && d.QuotationDate <= Convert.ToDateTime(dateEnd)
                             select new Entities.TrnQuotation
                             {
                                 Id = d.Id,
                                 QuotationNumber = d.QuotationNumber,
                                 QuotationDate = d.QuotationDate.ToShortDateString(),
                                 LeadId = d.LeadId,
                                 CustomerId = d.CustomerId,
                                 ProductId = d.ProductId,
                                 Remarks = d.Remarks,
                                 EncodedByUserId = d.EncodedByUserId,
                                 QuotationStatus = d.QuotationStatus
                             };

            return quotations.ToList();
        }

        [HttpGet, Route("detail/{id}")]
        public Entities.TrnQuotation DetailQuotation(String id)
        {
            var quotation = from d in db.IS_TrnQuotations
                            where d.Id == Convert.ToInt32(id)
                            select new Entities.TrnQuotation
                            {
                                Id = d.Id,
                                QuotationNumber = d.QuotationNumber,
                                QuotationDate = d.QuotationDate.ToShortDateString(),
                                LeadId = d.LeadId,
                                CustomerId = d.CustomerId,
                                ProductId = d.ProductId,
                                Remarks = d.Remarks,
                                EncodedByUserId = d.EncodedByUserId,
                                QuotationStatus = d.QuotationStatus
                            };

            return quotation.FirstOrDefault();
        }

        [HttpPost, Route("add")]
        public HttpResponseMessage AddQuotation(Entities.TrnQuotation objQuotation)
        {
            try
            {
                Data.IS_TrnQuotation newQuotation = new Data.IS_TrnQuotation
                {
                    Id = objQuotation.Id,
                    QuotationNumber = objQuotation.QuotationNumber,
                    QuotationDate = Convert.ToDateTime(objQuotation.QuotationDate),
                    LeadId = objQuotation.LeadId,
                    CustomerId = objQuotation.CustomerId,
                    ProductId = objQuotation.ProductId,
                    Remarks = objQuotation.Remarks,
                    EncodedByUserId = objQuotation.EncodedByUserId,
                    QuotationStatus = objQuotation.QuotationStatus
                };

                db.IS_TrnQuotations.InsertOnSubmit(newQuotation);
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
        public HttpResponseMessage UpdateQuotation(Entities.TrnQuotation objQuotation, String id)
        {
            try
            {
                var quotaion = from d in db.IS_TrnQuotations
                               where d.Id == Convert.ToInt32(id)
                               select d;

                if (quotaion.Any())
                {
                    var updateQuotaion = quotaion.FirstOrDefault();
                    updateQuotaion.QuotationNumber = objQuotation.QuotationNumber;
                    updateQuotaion.QuotationDate = Convert.ToDateTime(objQuotation.QuotationDate);
                    updateQuotaion.LeadId = objQuotation.LeadId;
                    updateQuotaion.CustomerId = objQuotation.CustomerId;
                    updateQuotaion.ProductId = objQuotation.ProductId;
                    updateQuotaion.Remarks = objQuotation.Remarks;
                    updateQuotaion.QuotationStatus = objQuotation.QuotationStatus;
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
                var quotation = from d in db.IS_TrnQuotations
                                where d.Id == Convert.ToInt32(id)
                                select d;

                if (quotation.Any())
                {
                    db.IS_TrnQuotations.DeleteOnSubmit(quotation.First());
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



