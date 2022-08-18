using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeAccountTypeMaster : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public int FeeAccountTypeMasterID
        {
            get;
            set;
        }


        public string FeeAccountTypeDesc
        {
            get;
            set;
        }

        public byte FeeAccountTypeCode
        {
            get;
            set;
        }




        //Feilds from GeneralUnitType//



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
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
