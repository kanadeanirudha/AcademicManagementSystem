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
    public class CRMCallEnquiryDetailsViewModel : ICRMCallEnquiryDetailsViewModel
    {

        public CRMCallEnquiryDetailsViewModel()
        {
            CRMCallEnquiryDetailsDTO = new CRMCallEnquiryDetails();
            ListCRMCallType = new List<CRMCallType>();
            CRMCallEnquiryDetailsList = new List<CRMCallEnquiryDetails>();
           
        }
        [Required(ErrorMessage = "Designation is required")]
        public List<CRMCallType> ListCRMCallType
        {
            get;
            set;
        }
       
        public CRMCallEnquiryDetails CRMCallEnquiryDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.ID > 0) ? CRMCallEnquiryDetailsDTO.ID : new int();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.ID = value;
            }
        }
        public int CallEnquiryMasterID
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.CallEnquiryMasterID > 0) ? CRMCallEnquiryDetailsDTO.CallEnquiryMasterID : new int();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CallEnquiryMasterID = value;
            }
        }

        [Required(ErrorMessage = "Callee First Nameshould not be blank.")]
        [Display(Name = "Callee First Name")]
        public string CalleeFirstName
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CalleeFirstName : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CalleeFirstName = value;
            }
        }

        [Required(ErrorMessage = "Callee Middel Name should not be blank.")]
        [Display(Name = "Callee Middel Name")]
        public string CalleeMiddelName
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CalleeMiddelName : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CalleeMiddelName = value;
            }
        }


        [Required(ErrorMessage = "Callee LastName should not be blank.")]
        [Display(Name = "Callee Last Name")]
        public string CalleeLastName
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CalleeLastName : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CalleeLastName = value;
            }
        }
        [Display(Name = "Callee Mobile No")]
        public string CalleeMobileNo
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CalleeMobileNo : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CalleeMobileNo = value;
            }
        }
        [Display(Name = "Callee Email ID")]
        public string CalleeEmailID
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CalleeEmailID : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CalleeEmailID = value;
            }
        }
        public int CalleePersonID
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.CalleePersonID > 0) ? CRMCallEnquiryDetailsDTO.CalleePersonID : new int();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CalleePersonID = value;
            }
        }
        [Display(Name = "Status")]
        public Int16 Status
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.Status > 0) ? CRMCallEnquiryDetailsDTO.Status : new Int16();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.Status = value;
            }
        }
         [Display(Name = "Person Type")]
        public string CalleePersonType
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CalleePersonType : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CalleePersonType = value;
            }
        }
        [Display(Name = "Entity Type")]
        public string CalleeEntityType
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CalleeEntityType : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CalleeEntityType = value;
            }
        }
        [Display(Name = "Source")]
        public string Source
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.Source : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.Source = value;
            }
        }
        [Display(Name = "Source Contact Person")]
        public string SourceContactPerson
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.SourceContactPerson : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.SourceContactPerson = value;
            }
        }
         [Display(Name = "Upload Date")]
        public string UploadDate
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.UploadDate : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.UploadDate = value;
            }
        }
        [Display(Name = "Upload Excel")]
        public int UploadExcelID
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.UploadExcelID > 0) ? CRMCallEnquiryDetailsDTO.UploadExcelID : new int();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.UploadExcelID = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.IsDeleted : false;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.CreatedBy > 0) ? CRMCallEnquiryDetailsDTO.CreatedBy : new int();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.DeletedBy : new int();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.DeletedDate = value;
            }
        }

        [Required(ErrorMessage = "Select Call Type")]
        public string CallType
        {
            get;
            set;
        }
         [Display(Name = "Call Type")]
        public Int16 CallTypeID
        {
            get;
            set;
        }

        public string errorMessage { get; set; }
        public HttpPostedFileBase MyFile { get; set; }
        public string XMLstring
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.XMLstring : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.XMLstring = value;
            }
        }
         [Display(Name = "Forward To")]
        public string CallForwardTo
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.CallForwardTo : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CallForwardTo = value;
            }
        }
        public IEnumerable<SelectListItem> CRMCallEnquiryDetailsListItems
        {
            get
            {
                return new SelectList(CRMCallEnquiryDetailsList, "ID", "ItemName");
            }
        }
        public List<CRMCallEnquiryDetails> CRMCallEnquiryDetailsList
        {
            get;
            set;
        }
        public Int16 CallStatus
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.CallStatus > 0) ? CRMCallEnquiryDetailsDTO.CallStatus : new Int16();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CallStatus = value;
            }
        }
        public Int16 CallerJobStatus
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.CallerJobStatus > 0) ? CRMCallEnquiryDetailsDTO.CallerJobStatus : new Int16();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CallerJobStatus = value;
            }
        }
        public bool IsButtonShow
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.IsButtonShow : false;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.IsButtonShow = value;
            }
        }

        public string StartDate
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.StartDate : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.StartDate = value;
            }
        }

        public string EndDate
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.EndDate : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.EndDate = value;
            }
        }
        public Int32 UnallocatedCalls
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null ) ? CRMCallEnquiryDetailsDTO.UnallocatedCalls : new Int32();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.UnallocatedCalls = value;
            }
        }
        public Int32 AllocatedCalls
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.AllocatedCalls : new Int32();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.AllocatedCalls = value;
            }
        }
        public int CRMCallTypeID
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null && CRMCallEnquiryDetailsDTO.CRMCallTypeID > 0) ? CRMCallEnquiryDetailsDTO.CRMCallTypeID : new int();
            }
            set
            {
                CRMCallEnquiryDetailsDTO.CRMCallTypeID = value;
            }
        }
       
        [Required(ErrorMessage = " First Name should not be blank.")]
        [Display(Name = "First Name")]
        public string StudentFirstName
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.StudentFirstName : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.StudentFirstName = value;
            }
        }
        [Required(ErrorMessage = " Middel Name should not be blank.")]
        [Display(Name = "Middle Name")]
        public string StudentMiddelName
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.StudentMiddelName : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.StudentMiddelName = value;
            }
        }
        [Required(ErrorMessage = " Last Name should not be blank.")]
        [Display(Name = "Last Name")]
        public string StudentLastName
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.StudentLastName : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.StudentLastName = value;
            }
        }
        [Required(ErrorMessage = "MobileNo should not be blank.")]
        [Display(Name = "Mobile No ")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)] 
        public string StudentMobileNo
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.StudentMobileNo : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.StudentMobileNo = value;
            }
        }
        [Required(ErrorMessage = "Email ID  is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email ID")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
      
        public string StudentEmailID
        {
            get
            {
                return (CRMCallEnquiryDetailsDTO != null) ? CRMCallEnquiryDetailsDTO.StudentEmailID : string.Empty;
            }
            set
            {
                CRMCallEnquiryDetailsDTO.StudentEmailID = value;
            }
        }
       
    }
    
}

