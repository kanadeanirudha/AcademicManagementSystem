using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IHMConsultantTypeMasterViewModel
    {
        HMConsultantTypeMaster HMConsultantTypeMasterDTO
        {
            get;
            set;
        }

       Int16 ID
        {
            get;
            set;
        }
       string Name
        {
            get;
            set;
        }

      
       Int32 DepartmentID
       {
           get;
           set;
       }
        bool IsDeleted
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

     
        string SelectedDepartmentID { get; set; }
    }
}
