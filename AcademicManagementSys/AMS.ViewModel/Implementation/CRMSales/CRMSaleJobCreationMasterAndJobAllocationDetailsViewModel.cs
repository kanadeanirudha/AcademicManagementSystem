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
    public class CRMSaleJobCreationMasterAndJobAllocationDetailsViewModel : ICRMSaleJobCreationMasterAndJobAllocationDetailsViewModel
    {
        public CRMSaleJobCreationMasterAndJobAllocationDetailsViewModel()
        {
            CRMSaleJobCreationMasterAndAllocationDetailsDTO = new CRMSaleJobCreationMasterAndJobAllocationDetails();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleJobCreationMaster Table ~~~~~~~~~~~~~~~~~~~~~~
        public CRMSaleJobCreationMasterAndJobAllocationDetails CRMSaleJobCreationMasterAndAllocationDetailsDTO { get; set; }

        public int CRMSaleJobCreationMasterID
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleJobCreationMasterID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleJobCreationMasterID : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleJobCreationMasterID = value;
            }
        }
        public string JobName
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobName != "") ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobName : string.Empty;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobName = value;
            }
        }
        public string JobCode
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobCode != "") ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobCode : string.Empty;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobCode = value;
            }
        }
        public string JobStartDate
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobStartDate != "") ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobStartDate : string.Empty;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobStartDate = value;
            }
        }
        public string JobEndDate
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobEndDate != "") ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobEndDate : string.Empty;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobEndDate = value;
            }
        }
        public Int16 CallTypeID
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallTypeID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallTypeID : new Int16();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallTypeID = value;
            }
        }
        public Int16 JobAllocationStatus
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallTypeID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallTypeID : new Int16();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallTypeID = value;
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleJobCreationAllocation Table~~~~~~~~~~~~~~~~~~~~~~~
        public int CRMSaleJobCreationAllocationID
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleJobCreationAllocationID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleJobCreationAllocationID : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleJobCreationAllocationID = value;
            }
        }
        public int CallEnquiryMasterID
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallEnquiryMasterID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallEnquiryMasterID : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallEnquiryMasterID = value;
            }
        }
        public int AdminRoleMasterID
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.AdminRoleMasterID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.AdminRoleMasterID : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.AdminRoleMasterID = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.EmployeeID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.EmployeeID : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.EmployeeID = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.TransactionDate != "") ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.TransactionDate : string.Empty;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.TransactionDate = value;
            }
        }
        public Int16 CallerJobStatus
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallerJobStatus > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallerJobStatus : new Int16();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallerJobStatus = value;
            }
        }
        public Int64 JobAllocationOldID
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobAllocationOldID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobAllocationOldID : new Int64();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.JobAllocationOldID = value;
            }
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleCallMaster Table~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int CRMSaleCallMasterID
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleCallMasterID > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleCallMasterID : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CRMSaleCallMasterID = value;
            }
        }
        public Int16 CallStatus
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallStatus > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallStatus : new Int16();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallStatus = value;
            }
        }
        public string CallAnswerXML
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallAnswerXML != "") ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallAnswerXML : string.Empty;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CallAnswerXML = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.IsDeleted : false;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.CreatedBy > 0) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CreatedBy : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.ModifiedBy.HasValue) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null && CRMSaleJobCreationMasterAndAllocationDetailsDTO.ModifiedDate.HasValue) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.DeletedBy : new int();
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMSaleJobCreationMasterAndAllocationDetailsDTO != null) ? CRMSaleJobCreationMasterAndAllocationDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMSaleJobCreationMasterAndAllocationDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}
