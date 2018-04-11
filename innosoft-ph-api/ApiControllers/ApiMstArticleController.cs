using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innosoft_ph_api.ApiControllers
{
    [RoutePrefix("api/article")]
    public class ApiMstArticleController : ApiController
    {
        private Data.innosoftdbDataContext db = new Data.innosoftdbDataContext();

        [HttpGet, Route("list/{articleTypeId}")]
        public List<Entities.MstArticle> ListArticle(String articleTypeId)
        {
            var articles = from d in db.MstArticles.OrderByDescending(d => d.Id)
                           where d.ArticleTypeId == Convert.ToInt32(articleTypeId)
                           select new Entities.MstArticle
                           {
                               Id = d.Id,
                               ArticleCode = d.ArticleCode,
                               ManualArticleCode = d.ManualArticleCode,
                               Article = d.Article,
                               Category = d.Category,
                               ArticleTypeId = d.ArticleTypeId,
                               ArticleGroupId = d.ArticleGroupId,
                               AccountId = d.AccountId,
                               SalesAccountId = d.SalesAccountId,
                               CostAccountId = d.CostAccountId,

                           };

            return articles.ToList();
        }

        [HttpGet, Route("detail/{id}")]
        public Entities.MstArticle DetailArticle(String id)
        {
            var article = from d in db.MstArticles.OrderByDescending(d => d.Id)
                          where d.Id == Convert.ToInt32(id)
                          select new Entities.MstArticle
                          {
                              Id = d.Id,
                              ArticleCode = d.ArticleCode,
                              ManualArticleCode = d.ManualArticleCode,
                              Article = d.Article,
                              Category = d.Category
                          };

            return article.FirstOrDefault();
        }

        [HttpPost, Route("add")]
        public HttpResponseMessage AddArticle(Entities.MstArticle objArticle)
        {
            try
            {
                Data.MstArticle newArticle = new Data.MstArticle
                {
                    ArticleCode = objArticle.ArticleCode,
                    ManualArticleCode = objArticle.ManualArticleCode,
                    Article = objArticle.Article,
                    Category = objArticle.Category,
                    ArticleTypeId = objArticle.ArticleTypeId,
                    ArticleGroupId = objArticle.ArticleGroupId,
                    AccountId = objArticle.AccountId,
                    SalesAccountId = objArticle.SalesAccountId,
                    CostAccountId = objArticle.CostAccountId,
                    AssetAccountId = objArticle.AssetAccountId,
                    ExpenseAccountId = objArticle.ExpenseAccountId,
                    UnitId = objArticle.UnitId,
                    OutputTaxId = objArticle.OutputTaxId,
                    InputTaxId = objArticle.InputTaxId,
                    WTaxTypeId = objArticle.WTaxTypeId,
                    Price = objArticle.Price,
                    Cost = objArticle.Cost,
                    IsInventory = objArticle.IsInventory,
                    Particulars = objArticle.Particulars,
                    Address = objArticle.Address,
                    TermId = objArticle.TermId,
                    ContactNumber = objArticle.ContactNumber,
                    ContactPerson = objArticle.ContactPerson,
                    EmailAddress = objArticle.EmailAddress,
                    TaxNumber = objArticle.TaxNumber,
                    CreditLimit = objArticle.CreditLimit,
                    DateAcquired = Convert.ToDateTime(objArticle.DateAcquired),
                    UsefulLife = objArticle.UsefulLife,
                    SalvageValue = objArticle.SalvageValue,
                    ManualArticleOldCode = objArticle.ManualArticleOldCode,
                    Kitting = objArticle.Kitting,
                    IsLocked = objArticle.IsLocked,
                    CreatedById = objArticle.CreatedById,
                    CreatedDateTime = Convert.ToDateTime(objArticle.CreatedDateTime),
                    UpdatedById = objArticle.UpdatedById,
                    UpdatedDateTime = Convert.ToDateTime(objArticle.UpdatedDateTime),
                };

                db.MstArticles.InsertOnSubmit(newArticle);
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
        public HttpResponseMessage UpdateArticle(Entities.MstArticle objArticle, String id)
        {
            try
            {
                var article = from d in db.MstArticles
                              where d.Id == Convert.ToInt32(id)
                              select d;

                if (article.Any())
                {
                    var updateArticle = article.FirstOrDefault();
                    updateArticle.Article = objArticle.Article;
                    updateArticle.Category = objArticle.Category;

                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated!");
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

        [HttpDelete, Route("delete/{id}")]
        public HttpResponseMessage DeleteArticle(String id)
        {
            try
            {
                var article = from d in db.MstArticles
                              where d.Id == Convert.ToInt32(id)
                              select d;

                if (article.Any())
                {
                    db.MstArticles.DeleteOnSubmit(article.First());
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
