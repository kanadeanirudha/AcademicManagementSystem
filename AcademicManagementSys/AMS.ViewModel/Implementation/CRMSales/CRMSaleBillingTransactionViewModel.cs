using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AMS.ViewModel
{
    public class CRMSaleBillingTransactionViewModel : ICRMSaleBillingTransactionViewModel
    {
        public CRMSaleBillingTransactionViewModel()
        {
            CRMSaleBillingTransactionDTO = new CRMSaleBillingTransaction();
            GetCRMSaleEnquiryAccountMasterList = new List<CRMSaleEnquiryMasterAndAccountDetails>();
            GetGeneralCurrencyMasterList = new List<GeneralCurrencyMaster>();
        }

        //CRMSaleBillingTransaction
        public CRMSaleBillingTransaction CRMSaleBillingTransactionDTO { get; set; }
        public List<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountMasterList { get; set; }
        public List<GeneralCurrencyMaster> GetGeneralCurrencyMasterList { get; set; }

        public IEnumerable<SelectListItem> ListCRMSaleEnquiryAccountMasterItems
        {
            get
            {
                return new SelectList(GetCRMSaleEnquiryAccountMasterList, "CRMSaleEnquiryAccountMasterID", "AccountName");
            }
        }

        public int ID
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null && CRMSaleBillingTransactionDTO.ID > 0) ? CRMSaleBillingTransactionDTO.ID : new int();
            }
            set
            {
                CRMSaleBillingTransactionDTO.ID = value;
            }
        }

        [Display(Name = "Invoice Number")]
        //[Required(ErrorMessage = "Invoice number should not be blank")]
        public string InvoiceNumber
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.InvoiceNumber : String.Empty;
            }
            set
            {
                CRMSaleBillingTransactionDTO.InvoiceNumber = value;
            }
        }

        [Display(Name = "Invoice Date")]
        [Required(ErrorMessage = "Invoice date should not be blank")]
        public string InvoiceDate
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.InvoiceDate : String.Empty;
            }
            set
            {
                CRMSaleBillingTransactionDTO.InvoiceDate = value;
            }
        }
        public int CRMSaleEnquiryAccountMasterID 
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null && CRMSaleBillingTransactionDTO.CRMSaleEnquiryAccountMasterID > 0) ? CRMSaleBillingTransactionDTO.CRMSaleEnquiryAccountMasterID : new int();
            }
            set
            {
                CRMSaleBillingTransactionDTO.CRMSaleEnquiryAccountMasterID = value;
            }
        }
        public int CallEnquiryMasterID
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null && CRMSaleBillingTransactionDTO.CallEnquiryMasterID > 0) ? CRMSaleBillingTransactionDTO.CallEnquiryMasterID : new int();
            }
            set
            {
                CRMSaleBillingTransactionDTO.CallEnquiryMasterID = value;
            }
        }

        [Display(Name = "Invoice Amount")]
        //[Required(ErrorMessage = "Invoice amount should not be blank")]
        public decimal InvoiceAmount
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null && CRMSaleBillingTransactionDTO.InvoiceAmount > 0) ? CRMSaleBillingTransactionDTO.InvoiceAmount : new decimal();
            }
            set
            {
                CRMSaleBillingTransactionDTO.InvoiceAmount = value;
            }
        }
        [Display(Name = "Currency Code")]
        //[Required(ErrorMessage = "Currency code should not be blank")]
        public string CurrencyCode
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.CurrencyCode : String.Empty;
            }
            set
            {
                CRMSaleBillingTransactionDTO.CurrencyCode = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.IsDeleted : false;
            }
            set
            {
                CRMSaleBillingTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null && CRMSaleBillingTransactionDTO.CreatedBy > 0) ? CRMSaleBillingTransactionDTO.CreatedBy : new int();
            }
            set
            {
                CRMSaleBillingTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMSaleBillingTransactionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null && CRMSaleBillingTransactionDTO.ModifiedBy.HasValue) ? CRMSaleBillingTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                CRMSaleBillingTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null && CRMSaleBillingTransactionDTO.ModifiedDate.HasValue) ? CRMSaleBillingTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMSaleBillingTransactionDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.DeletedBy : new int();
            }
            set
            {
                CRMSaleBillingTransactionDTO.DeletedBy = value;
            }
        }


        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMSaleBillingTransactionDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.errorMessage : String.Empty;
            }
            set
            {
                CRMSaleBillingTransactionDTO.errorMessage = value;
            }
        }

        [Display(Name = "Enquiry Desription")]
        [Required(ErrorMessage = "Enquiry desription should not be blank")]
        public string EnquiryDesription
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.EnquiryDesription : String.Empty;
            }
            set
            {
                CRMSaleBillingTransactionDTO.EnquiryDesription = value;
            }
        }

        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "Account name should not be blank")]
        public string AccountName
        {
            get
            {
                return (CRMSaleBillingTransactionDTO != null) ? CRMSaleBillingTransactionDTO.AccountName : String.Empty;
            }
            set
            {
                CRMSaleBillingTransactionDTO.AccountName = value;
            }
        }
        
    }
}
