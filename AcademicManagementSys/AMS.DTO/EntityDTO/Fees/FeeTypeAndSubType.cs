using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeTypeAndSubType : BaseDTO
    {
        //-------------------------------FeeType ------------------------------------
        public short ID { get; set; }
        public string FeeTypeDesc { get; set; }
        public string FeeTypeCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        //-------------------------------Fee Sub Type---------------------------------
        public short FeeSubTypeID { get; set; }
        public string FeeSubTypeDesc { get; set; }
        public string FeeSubShortDesc { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string SubTypeIdentification { get; set; }
        public int ConsiderFeeTypeID { get; set; }
        public string CarryForwardFeeSubtypeID { get; set; }
        public string CarryForwardAcctEffects { get; set; }
        public string FeeSource { get; set; }

        public string errorMessage { get; set; }
        public bool IsFeeTypeTransaction { get; set; }
        public string SelectedBalanceSheet { get; set; }
        public int SelectedBalanceSheetID { get; set; }
    }
}
