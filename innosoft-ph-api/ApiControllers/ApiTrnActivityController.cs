using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innosoft_ph_api.ApiControllers
{
    [RoutePrefix("api/activity")]
    public class ApiTrnActivityController : ApiController
    {
        private Data.innosoftdbDataContext db = new Data.innosoftdbDataContext();

        [HttpGet, Route("list/{dateStart}/{dateEnd}")]
        public List<Entities.TrnActivity> ListActivity(String dateStart, String dateEnd)
        {
            var activities = from d in db.IS_TrnActivities.OrderByDescending(d => d.Id)
                             where d.ActivityDate >= Convert.ToDateTime(dateStart)
                             && d.ActivityDate <= Convert.ToDateTime(dateEnd)
                             select new Entities.TrnActivity
                             {
                                 Id = d.Id,
                                 ActivityNumber = d.ActivityNumber,
                                 ActivityDate = d.ActivityDate.ToShortDateString(),
                                 StaffUserId = d.StaffUserId,
                                 CustomerId = d.CustomerId,
                                 ProductId = d.ProductId,
                                 ParticularCategory = d.ParticularCategory,
                                 Particulars = d.Particulars,
                                 Location = d.Location,
                                 NumberOfHours = d.NumberOfHours,
                                 ActivityAmount = d.ActivityAmount,
                                 ActivityStatus = d.ActivityStatus,
                                 LeadId = d.LeadId,
                                 QuotationId = d.QuotationId,
                                 DeliveryId = d.DeliveryId,
                                 SupportId = d.SupportId,
                                 SoftwareDevelopmentId = d.SoftwareDevelopmentId
                             };

            return activities.ToList();
        }

        [HttpGet, Route("detail/{id}")]
        public Entities.TrnActivity DetailActivity(String id)
        {
            var activity = from d in db.IS_TrnActivities
                           where d.Id == Convert.ToInt32(id)
                           select new Entities.TrnActivity
                           {
                               Id = d.Id,
                               ActivityNumber = d.ActivityNumber,
                               ActivityDate = d.ActivityDate.ToShortDateString(),
                               StaffUserId = d.StaffUserId,
                               CustomerId = d.CustomerId,
                               ProductId = d.ProductId,
                               ParticularCategory = d.ParticularCategory,
                               Particulars = d.Particulars,
                               Location = d.Location,
                               NumberOfHours = d.NumberOfHours,
                               ActivityAmount = d.ActivityAmount,
                               ActivityStatus = d.ActivityStatus,
                               LeadId = d.LeadId,
                               QuotationId = d.QuotationId,
                               DeliveryId = d.DeliveryId,
                               SupportId = d.SupportId,
                               SoftwareDevelopmentId = d.SoftwareDevelopmentId
                           };

            return activity.FirstOrDefault();
        }

        [HttpPost, Route("add")]
        public HttpResponseMessage AddActivity(Entities.TrnActivity objActivity)
        {
            try
            {
                Data.IS_TrnActivity newActivity = new Data.IS_TrnActivity
                {
                    Id = objActivity.Id,
                    ActivityNumber = objActivity.ActivityNumber,
                    ActivityDate = Convert.ToDateTime(objActivity.ActivityDate),
                    StaffUserId = objActivity.StaffUserId,
                    CustomerId = objActivity.CustomerId,
                    ProductId = objActivity.ProductId,
                    ParticularCategory = objActivity.ParticularCategory,
                    Particulars = objActivity.Particulars,
                    Location = objActivity.Location,
                    NumberOfHours = objActivity.NumberOfHours,
                    ActivityAmount = objActivity.ActivityAmount,
                    ActivityStatus = objActivity.ActivityStatus,
                    LeadId = objActivity.LeadId,
                    QuotationId = objActivity.QuotationId,
                    DeliveryId = objActivity.DeliveryId,
                    SupportId = objActivity.SupportId,
                    SoftwareDevelopmentId = objActivity.SoftwareDevelopmentId
                };

                db.IS_TrnActivities.InsertOnSubmit(newActivity);
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
        public HttpResponseMessage UpdateActivity(Entities.TrnActivity objActivity, String id)
        {
            try
            {
                var activity = from d in db.IS_TrnActivities
                               where d.Id == Convert.ToInt32(id)
                               select d;

                if (activity.Any())
                {
                    var updateActivity = activity.FirstOrDefault();
                    updateActivity.ActivityNumber = objActivity.ActivityNumber;
                    updateActivity.ActivityDate = Convert.ToDateTime(objActivity.ActivityDate);
                    updateActivity.StaffUserId = objActivity.StaffUserId;
                    updateActivity.CustomerId = objActivity.CustomerId;
                    updateActivity.ProductId = objActivity.ProductId;
                    updateActivity.ParticularCategory = objActivity.ParticularCategory;
                    updateActivity.Particulars = objActivity.Particulars;
                    updateActivity.Location = objActivity.Location;
                    updateActivity.NumberOfHours = objActivity.NumberOfHours;
                    updateActivity.ActivityAmount = objActivity.ActivityAmount;
                    updateActivity.ActivityStatus = objActivity.ActivityStatus;
                    updateActivity.LeadId = objActivity.LeadId;
                    updateActivity.QuotationId = objActivity.QuotationId;
                    updateActivity.DeliveryId = objActivity.DeliveryId;
                    updateActivity.SupportId = objActivity.SupportId;
                    updateActivity.SoftwareDevelopmentId = objActivity.SoftwareDevelopmentId;
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
        public HttpResponseMessage DeleteActivity(String id)
        {
            try
            {
                var activity = from d in db.IS_TrnActivities
                                where d.Id == Convert.ToInt32(id)
                                select d;

                if (activity.Any())
                {
                    db.IS_TrnActivities.DeleteOnSubmit(activity.First());
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
