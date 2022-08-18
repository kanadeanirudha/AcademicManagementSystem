using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IScholarShipMasterViewModel
    {
        ScholarShipMaster ScholarShipMasterDTO { get; set; }
        int ID
        {
            get;
            set;
        }
        string ScholarShipDescription
        {
            get;
            set;
        }
        string ScholarShipType
        {
            get;
            set;
        }
        string ScholarShipImplementType
        {
            get;
            set;
        }
        bool IsCalulatedAmountFix
        {
            get;
            set;
        }
        decimal FixAmount
        {
            get;
            set;
        }
        decimal Percentage
        {
            get;
            set;
        }
        bool IsActive
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


        //---------------------FeeAccountTypeMaster

        string FeeAccountTypeDesc
        {
            get;
            set;
        }
        Int16 FeeAccountTypeCode
        {
            get;
            set;
        }
        int ScholarShipMasterID
        {
            get;
            set;
        }

        //--------------------FeeAccountSubTypeMaster


        int FeeAccountTypeMasterID
        {
            get;
            set;
        }
        string FeeAccountSubTypeDesc
        {
            get;
            set;
        }
        string FeeAccountSubTypeCode
        {
            get;
            set;
        }

        Int16 AccountID
        {
            get;
            set;
        }
    }

}
