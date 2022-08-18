using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ScholarShipMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string ScholarShipDescription
        {
            get;
            set;
        }
        public string ScholarShipType
        {
            get;
            set;
        }
        public string ScholarShipImplementType
        {
            get;
            set;
        }
        public bool IsCalulatedAmountFix
        {
            get;
            set;
        }
        public decimal FixAmount
        {
            get;
            set;
        }
        public decimal Percentage
        {
            get;
            set;
        }
        public bool IsActive
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

        //---------------------FeeAccountTypeMaster
       
        public string FeeAccountTypeDesc
        {
            get;
            set;
        }
        public Int16 FeeAccountTypeCode
        {
            get;
            set;
        }
        public int ScholarShipMasterID
        {
            get;
            set;
        }

        //--------------------FeeAccountSubTypeMaster

       
        public int FeeAccountTypeMasterID
        {
            get;
            set;
        }
        public int FeeAccountTypeMasterIDForStudentReceivable
        {
            get;
            set;
        }
        public string FeeAccountSubTypeDesc
        {
            get;
            set;
        }
        public string FeeAccountSubTypeCode
        {
            get;
            set;
        }
      
        public Int16 AccountID
        {
            get;
            set;
        }


        public Int16 AccountIDForStudentReceivable
        {
            get;
            set;
        }
        public string FeeAccountSubTypeDescForStudentReceivable { get; set; }
        public string FeeAccountSubTypeCodeForStudentReceivable { get; set; }
        public string errorMessage { get; set; }
    }
}


	
