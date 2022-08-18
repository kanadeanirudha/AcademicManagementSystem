using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleEnquiryMasterAndAccountDetails : BaseDTO
    {
        //CRMSaleEnquiryMaster
        public Int64 CRMSaleEnquiryMasterID { get; set; }
        public string TransactionDate { get; set; }
        public Int16 EnquiryAccountStatus { get; set; }      
        public Int32 EnquiryHandledById { get; set; }
        public string ExpectedBillingAmount { get; set; }
        public Int16 EnquiryAccountType { get; set; }
        public Int16 EnquirySource { get; set; }
        public string EnquiryDesription { get; set; }
        public decimal EnquiryMasterLatitude { get; set; }
        public decimal EnquiryMasterLongitude { get; set; }
        public string EnquiryMasterLocation { get; set; }
        public string EnquiryMasterCity { get; set; }
        public string EnquiryMasterAddress { get; set; }
        public Int16 EnquiryProgressStatus { get; set; }
        public Int16 GenServiceRequiredID { get; set; }
        public string GenServiceRequiredName { get; set; }
        public string NearestLocationSearch { get; set; }
        public Int16 InternalSatus { get; set; }
        public Int16 CRMAccountProgressTypeID { get; set; }
        public bool IsSelfAssign { get; set; }
        public Int32 EmployeeID { get; set; }
        
        //CRMSaleEnquiryAccountMaster
        public Int32 CRMSaleEnquiryAccountMasterID { get; set; }
        public string AccountName { get; set; }
        public Int16 AccountType { get; set; }
        public string EnquiryAccountMasterLocation { get; set; }
        public string EnquiryAccountMasterAddress { get; set; }
        public string EnquiryAccountMasterCity { get; set; }
        public string EnquiryAccountMasterCountry { get; set; }
        public bool IsActive { get; set; }
        public Int32 LastSalesMenId { get; set; }
        public decimal EnquiryAccountMasterLatitude { get; set; }
        public decimal EnquiryAccountMasterLongitude { get; set; }
        public string ApproxAnnualAmount { get; set; }
        public Int16 GeneralIndustryMasterID { get; set; } 
        public Int16 CRMSaleAccountProgressTypeID { get; set; }
        public string AccountCreatedDate { get; set; }

        //CRMSaleEnquiryTransfer
        public Int32 RequestedSalesMenId { get; set; }
        public string AccountTransferRequestReason { get; set; }
        public Int16 OwnAccountStatus { get; set; }

        //CRMSaleEnquiryAccountContactPerson
        public Int32 CRMSaleEnquiryAccountContactPersonID { get; set; }
        public string EnquiryContactPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; } 
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string EnquiryAccountContactPersonAddress { get; set; }
        public string Pin { get; set; }
        public string EnquiryAccountContactPersonLocation { get; set; }
        public string EnquiryAccountContactPersonCity { get; set; }
        public string EnquiryAccountContactPersonCountry { get; set; }
        public string VisitingCardPath { get; set; }
        public decimal EnquiryAccountContactPersonLatitude { get; set; }
        public decimal EnquiryAccountContactPersonLongitude { get; set; }

        //CRMSaleEmployee
        public string EmployeeName { get; set; }
        
        //Other
        public string VisitingCardName { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string errorMessage { get; set; }

        public string IndustryName { get; set; }
        public string ProgressType { get; set; }
    }
}
