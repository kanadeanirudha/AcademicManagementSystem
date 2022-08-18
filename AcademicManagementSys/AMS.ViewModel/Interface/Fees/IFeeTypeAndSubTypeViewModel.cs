using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IFeeTypeAndSubTypeViewModel
    {
        FeeTypeAndSubType FeeTypeAndSubTypeDTO { get; set; }
        //-------------------------------FeeType ------------------------------------
        short ID { get; set; }
        string FeeTypeDesc { get; set; }
        string FeeTypeCode { get; set; }
        bool IsActive { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        int DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }
        bool IsDeleted { get; set; }

        //-------------------------------Fee Sub Type---------------------------------
        short FeeSubTypeID { get; set; }
        string FeeSubTypeDesc { get; set; }
        string FeeSubShortDesc { get; set; }
        int AccountID { get; set; }
        string SubTypeIdentification { get; set; }
        int ConsiderFeeTypeID { get; set; }
        string CarryForwardFeeSubtypeID { get; set; }
        string CarryForwardAcctEffects { get; set; }
        string FeeSource { get; set; }
    }
}
