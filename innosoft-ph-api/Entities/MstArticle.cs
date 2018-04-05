using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innosoft_ph_api.Entities
{
    public class MstArticle
    {
        public Int32 Id { set; get; }
        public String ArticleCode { set; get; }
        public String ManualArticleCode { set; get; }
        public String Article { set; get; }
    }
}