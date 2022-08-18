using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleBillingTransaction : BaseDTO
    {
        public int ID { get; set; }
        public string InvoiceNumber { get;set; }
        public string InvoiceDate { get; set; }
        public int CRMSaleEnquiryAccountMasterID { get; set; }
        public int CallEnquiryMasterID { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string CurrencyCode { get; set; }
        
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string errorMessage { get; set; }

        public string EnquiryDesription { get; set; }
        public string AccountName { get; set; }
      

    }
}
