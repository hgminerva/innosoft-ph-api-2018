using System;
using System.Collections.Generic;
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
            var articles = from d in db.MstArticles
                           where d.ArticleTypeId == Convert.ToInt32(articleTypeId)
                           select new Entities.MstArticle
                           {
                               Id = d.Id,
                               ArticleCode = d.ArticleCode,
                               ManualArticleCode = d.ManualArticleCode,
                               Article = d.Article
                           };

            return articles.ToList();
        }
    }
}
