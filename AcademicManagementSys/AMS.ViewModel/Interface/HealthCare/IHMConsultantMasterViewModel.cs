using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IHMConsultantMasterViewModel
    {
       HMConsultantMaster HMConsultantMasterDTO
        {
            get;
            set;
        }

       Int32 ID
        {
            get;
            set;
        }
       Int16 ConsultantTypeMasterID
        {
            get;
            set;
        }

        Int32 EmployeeID
       {
           get;
           set;
       }
        string CentreCode
        {
            get;
            set;
        }
        string CentreName
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        string ConsultantType
        {
            get;
            set;
        }
        string EntityLevel
        {
            get;
            set;
        }
        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
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

        List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster { get; set; }

        string SelectedCentreCode { get; set; }

        string SelectedDepartmentID { get; set; }
    }
}
