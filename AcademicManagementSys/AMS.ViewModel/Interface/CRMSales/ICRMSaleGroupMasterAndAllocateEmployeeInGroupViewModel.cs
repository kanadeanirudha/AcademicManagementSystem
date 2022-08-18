using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ICRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel
    {
        CRMSaleGroupMasterAndAllocateEmployeeInGroup CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO
        {
            get;
            set;
        }

        //CRMSaleGroupMaster
        int CRMSaleGroupMasterID
        {
            get;
            set;
        }
        string GroupName
        {
            get;
            set;
        }
        //CRMSaleAllocateEmployeeInGroup

        int CRMSaleAllocateEmployeeInGroupID
        {
            get;
            set;
        }
        int EmployeeId
        {
            get;
            set;
        }
        string TransactionDate
        {
            get;
            set;
        }
        string UptoDate
        {
            get;
            set;
        }
        bool IsCurrent
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
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
