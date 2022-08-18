using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleGroupMasterAndAllocateEmployeeInGroup : BaseDTO
    {
        //CRMSaleGroupMaster
        public int CRMSaleGroupMasterID
        {
            get;
            set;
        }
        public string GroupName
        {
            get;
            set;
        }
        //CRMSaleAllocateEmployeeInGroup

        public int CRMSaleAllocateEmployeeInGroupID
        {
            get;
            set;
        }
        public int EmployeeId
        {
            get;
            set;
        }
        public int GeneralGroupTypeAttributesId
        {
            get;
            set;
        }
        public int AuthorRoleID
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public string EmployeeDesignation
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public bool IsCurrent
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
