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
        public String Category { set; get; }
        public Int32 ArticleTypeId { set; get; }
        public Int32 ArticleGroupId { set; get; }
        public Int32 AccountId { set; get; }
        public Int32 SalesAccountId { set; get; }
        public Int32 CostAccountId { set; get; }
        public Int32 AssetAccountId { set; get; }
        public Int32 ExpenseAccountId { set; get; }
        public Int32 UnitId { set; get; }
        public Int32 OutputTaxId { set; get; }
        public Int32 InputTaxId { set; get; }
        public Int32 WTaxTypeId { set; get; }
        public Decimal Price { set; get; }
        public Decimal Cost { set; get; }
        public Boolean IsInventory { set; get; }
        public String Particulars { set; get; }
        public String Address { set; get; }
        public Int32 TermId { set; get; }
        public String ContactNumber { set; get; }
        public String ContactPerson { set; get; }
        public String EmailAddress { set; get; }
        public String TaxNumber { set; get; }
        public Decimal CreditLimit { set; get; }
        public String DateAcquired { set; get; }
        public Decimal UsefulLife { set; get; }
        public Decimal SalvageValue { set; get; }
        public String ManualArticleOldCode { set; get; }
        public Int32 Kitting { set; get; }
        public Boolean IsLocked { set; get; }
        public Int32 CreatedById { set; get; }
        public String CreatedDateTime { set; get; }
        public Int32 UpdatedById { set; get; }
        public String UpdatedDateTime { set; get; }
    }   
}