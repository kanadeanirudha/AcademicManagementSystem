using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ICRMCallEnquiryDetailsViewModel
    {
        CRMCallEnquiryDetails CRMCallEnquiryDetailsDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        int CallEnquiryMasterID
        {
            get;
            set;
        }

        string CalleeFirstName
        {
            get;
            set;
        }
        string StudentFirstName
        {
            get;
            set;
        }
        string CalleeMiddelName
        {
            get;
            set;
        }
        string StudentMiddelName
        {
            get;
            set;
        }
        string CalleeLastName
        {
            get;
            set;
        }
        string StudentLastName
        {
            get;
            set;
        }
        string CalleeMobileNo
        {
            get;
            set;
        }
        string StudentMobileNo
        {
            get;
            set;
        }
        string CalleeEmailID
        {
            get;
            set;
        }
        string StudentEmailID
        {
            get;
            set;
        }
        int CalleePersonID
        {
            get;
            set;
        }
        string CalleePersonType
        {
            get;
            set;
        }
        string CalleeEntityType
        {
            get;
            set;
        }

        Int16 Status
        {
            get;
            set;
        }

        string Source
        {
            get;
            set;
        }
        string SourceContactPerson
        {
            get;
            set;
        }

        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
