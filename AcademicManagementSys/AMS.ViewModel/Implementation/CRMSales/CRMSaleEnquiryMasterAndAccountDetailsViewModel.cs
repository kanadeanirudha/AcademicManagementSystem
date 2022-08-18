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
    public class CRMSaleEnquiryMasterAndAccountDetailsViewModel : ICRMSaleEnquiryMasterAndAccountDetailsViewModel
    {

        public CRMSaleEnquiryMasterAndAccountDetailsViewModel()
        {
            CRMSaleEnquiryMasterAndAccountDetailsDTO = new CRMSaleEnquiryMasterAndAccountDetails();
            GeneralServiceSelected = new List<GeneralServiceMaster>();
        }
        //CRMSaleTargetGroupWise
        public CRMSaleEnquiryMasterAndAccountDetails CRMSaleEnquiryMasterAndAccountDetailsDTO
        {
            get;
            set;
        }
        public List<GeneralServiceMaster> GeneralServiceSelected
        {
            get;
            set;
        }
        //CRMSaleEnquiryMaster
        public Int64 CRMSaleEnquiryMasterID
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryMasterID : new Int64();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryMasterID = value;
            }
        }
        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "Please select group")]
        public string TransactionDate
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.TransactionDate : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.TransactionDate = value;
            }
        }
        public Int16 EnquiryAccountStatus
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountStatus : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountStatus = value;
            }
        }


        public Int32 EnquiryHandledById
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryHandledById : new Int32();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryHandledById = value;
            }
        }
        [Display(Name = "Expected Billing Amount")]
        [Required(ErrorMessage = "Expected billing amount should not be blank")]
        public string ExpectedBillingAmount
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.ExpectedBillingAmount : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.ExpectedBillingAmount = value;
            }
        }

        [Display(Name = "Enquiry Type")]
        [Required(ErrorMessage = "Enquiry type should not be blank")]
        public Int16 EnquiryAccountType
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountType : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountType = value;
            }
        }
        [Display(Name = "Enquiry Source")]
        [Required(ErrorMessage = "Enquiry source should not be blank")]
        public Int16 EnquirySource
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquirySource : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquirySource = value;
            }
        }
        [Display(Name = "Enquiry Description")]
        [Required(ErrorMessage = "Enquiry desription should not be blank")]
        public string EnquiryDesription
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryDesription : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryDesription = value;
            }
        }
        public decimal EnquiryMasterLatitude
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterLatitude : new decimal();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterLatitude = value;
            }
        }
        public decimal EnquiryMasterLongitude
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterLongitude : new decimal();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterLongitude = value;
            }
        }
        public string EnquiryMasterLocation
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterLocation : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterLocation = value;
            }
        }
        [Display(Name = "Enquiry City")]
        [Required(ErrorMessage = "Enquiry city should not be blank")]
        public string EnquiryMasterCity
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterCity : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterCity = value;
            }
        }

        [Display(Name = "Enquiry Address")]
        [Required(ErrorMessage = "Enquiry address should not be blank")]
        public string EnquiryMasterAddress
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterAddress : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterAddress = value;
            }
        }
        [Display(Name = "Search Nearest Location")]
        public string NearestLocationSearch
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.NearestLocationSearch : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.NearestLocationSearch = value;
            }
        }

        public Int16 EnquiryProgressStatus
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryProgressStatus : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryProgressStatus = value;
            }
        }
        [Display(Name = "Service Required")]
        [Required(ErrorMessage = "Please select service required")]
        public Int16 GenServiceRequiredID
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.GenServiceRequiredID : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.GenServiceRequiredID = value;
            }
        }
        public string GenServiceRequiredName
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.GenServiceRequiredName : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.GenServiceRequiredName = value;
            }
        }
        public Int16 InternalSatus
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.InternalSatus : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.InternalSatus = value;
            }
        }
        [Display(Name = "Account Progress Type")]
        [Required(ErrorMessage = "Please select Account Progress Type")]
        public Int16 CRMAccountProgressTypeID
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMAccountProgressTypeID : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMAccountProgressTypeID = value;
            }
        }
        public bool IsSelfAssign
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.IsSelfAssign : false;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.IsSelfAssign = value;
            }
        }


        //CRMSaleEnquiryAccountMaster
        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "Please select Account")]
        public Int32 CRMSaleEnquiryAccountMasterID
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountMasterID : new Int32();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountMasterID = value;
            }
        }
        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "Please select Account")]
        public string AccountName
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountName : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountName = value;
            }
        }
        public string EnquiryAccountMasterLocation
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterLocation : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterLocation = value;
            }
        }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address should not be blank")]
        public string EnquiryAccountMasterAddress
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterAddress : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterAddress = value;
            }
        }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City should not be blank")]
        public string EnquiryAccountMasterCity
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCity : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCity = value;
            }
        }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country should not be blank")]
        public string EnquiryAccountMasterCountry
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCountry : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCountry = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.IsActive : false;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.IsActive = value;
            }
        }
        public Int32 LastSalesMenId
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.LastSalesMenId : new Int32();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.LastSalesMenId = value;
            }
        }
        public decimal EnquiryAccountMasterLatitude
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterLatitude : new decimal();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterLatitude = value;
            }
        }
        public decimal EnquiryAccountMasterLongitude
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterLongitude : new decimal();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterLongitude = value;
            }
        }
        [Display(Name = "Approx Annual Income")]
        [Required(ErrorMessage = "Approx annual income should not be blank")]
        public string ApproxAnnualAmount
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.ApproxAnnualAmount : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.ApproxAnnualAmount = value;
            }
        }
        [Display(Name = "Industry")]
        [Required(ErrorMessage = "Please select Industry")]
        public Int16 GeneralIndustryMasterID
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.GeneralIndustryMasterID : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.GeneralIndustryMasterID = value;
            }
        }
        public Int16 CRMSaleAccountProgressTypeID
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleAccountProgressTypeID : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleAccountProgressTypeID = value;
            }
        }
        public string AccountCreatedDate
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountCreatedDate : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountCreatedDate = value;
            }
        }
        //CRMSaleEnquiryAccountContactPerson


        public Int32 CRMSaleEnquiryAccountContactPersonID
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountContactPersonID : new Int32();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountContactPersonID = value;
            }
        }
        [Display(Name = "Enquiry Contact Person")]
        [Required(ErrorMessage = "Please select Enquiry Contact Person")]
        public string EnquiryContactPerson
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryContactPerson : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryContactPerson = value;
            }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name should not be blank.")]
        public string FirstName
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.FirstName : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.FirstName = value;
            }
        }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name should not be blank.")]
        public string LastName
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.LastName : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.LastName = value;
            }
        }

        [Required(ErrorMessage = "Designation should not blank")]
        public string Designation
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.Designation : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.Designation = value;
            }
        }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile number should not blank.")]
        public string MobileNumber
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.MobileNumber : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.MobileNumber = value;
            }
        }


        [Required(ErrorMessage = "Email address should not be blank.")]
        [Display(Name = "Email Id")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
        public string EmailId
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EmailId : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EmailId = value;
            }
        }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address should not blank.")]
        public string EnquiryAccountContactPersonAddress
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonAddress : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonAddress = value;
            }
        }

        [Display(Name = "Pin Number")]
        [Required(ErrorMessage = "Pin number should not blank.")]
        public string Pin
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.Pin : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.Pin = value;
            }
        }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location should not blank.")]
        public string EnquiryAccountContactPersonLocation
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonLocation : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonLocation = value;
            }
        }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City should not blank.")]
        public string EnquiryAccountContactPersonCity
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCity : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCity = value;
            }
        }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country should not blank.")]
        public string EnquiryAccountContactPersonCountry
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCountry : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCountry = value;
            }
        }
        public string VisitingCardPath
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.VisitingCardPath : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.VisitingCardPath = value;
            }
        }
        public decimal EnquiryAccountContactPersonLatitude
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonLatitude : new decimal();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonLatitude = value;
            }
        }
        public decimal EnquiryAccountContactPersonLongitude
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonLongitude : new decimal();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonLongitude = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.IsDeleted : false;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null && CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedBy > 0) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedBy : new int();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null && CRMSaleEnquiryMasterAndAccountDetailsDTO.ModifiedBy.HasValue) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null && CRMSaleEnquiryMasterAndAccountDetailsDTO.ModifiedDate.HasValue) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.DeletedBy : new int();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }


        public string SelectedEnquiryAccountType
        {
            get;
            set;
        }

        public Int16 AccountType
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountType : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountType = value;
            }
        }

        [Display(Name = "Industry Name")]
        public string IndustryName
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.IndustryName : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.IndustryName = value;
            }
        }

        [Display(Name = "Progress Type")]
        public string ProgressType
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.ProgressType : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.ProgressType = value;
            }
        }

        public string EmployeeName
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.EmployeeName : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.EmployeeName = value;
            }
        }

        public HttpPostedFileBase VisitingCard { get; set; }
        public string VisitingCardName { get; set; }

        [Required(ErrorMessage = "Reason should not blank.")]
        [Display(Name = "Reason for Account Transfer Request")]
        public string AccountTransferRequestReason
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountTransferRequestReason : String.Empty;
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountTransferRequestReason = value;
            }
        }
        public Int16 OwnAccountStatus
        {
            get
            {
                return (CRMSaleEnquiryMasterAndAccountDetailsDTO != null) ? CRMSaleEnquiryMasterAndAccountDetailsDTO.OwnAccountStatus : new Int16();
            }
            set
            {
                CRMSaleEnquiryMasterAndAccountDetailsDTO.OwnAccountStatus = value;
            }
        }
    }
}

