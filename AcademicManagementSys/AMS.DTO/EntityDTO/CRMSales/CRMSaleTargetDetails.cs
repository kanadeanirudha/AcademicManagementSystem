using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleTargetDetails : BaseDTO
    {
        //CRMSaleTargetGroupWise
        public Int16 CRMSaleTargetGroupWiseID
        {
            get;
            set;
        }
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
        public Int64 TargetValue
        {
            get;
            set;
        }
        public string FromDate
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
        public Int16 CRMSaleTargetTypeId
        {
            get;
            set;
        }
        public string TargetType
        {
            get;
            set;
        }
        
        //CRMSaleTargetException

        public Int16 CRMSaleTargetExceptionID
        {
            get;
            set;
        }
        public int EmployeeId
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
        public int GeneralPeriodTypeMasterID { get; set; }
    }
}
