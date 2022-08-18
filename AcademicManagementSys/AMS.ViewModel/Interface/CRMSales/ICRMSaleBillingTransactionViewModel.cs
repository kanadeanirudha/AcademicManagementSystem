using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ICRMSaleBillingTransactionViewModel
    {
        CRMSaleBillingTransaction CRMSaleBillingTransactionDTO { get; set; }

        int ID { get; set; }
        string InvoiceNumber { get; set; }
        string InvoiceDate { get; set; }
        int CRMSaleEnquiryAccountMasterID { get; set; }
        int CallEnquiryMasterID { get; set; }
        decimal InvoiceAmount { get; set; }
        string CurrencyCode { get; set; }

        string EnquiryDesription { get; set; }
        string AccountName { get; set; }

        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        string errorMessage { get; set; }
    }
}
