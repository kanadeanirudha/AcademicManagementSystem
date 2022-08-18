using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class POSCounter : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public int POSMasterID
        {
            get;
            set;
        }

        public int GeneralUnitsID
        {
            get;
            set;
        }

        public int CounterMstID
        {
            get;
            set;
        }
        
        public string DeviceToken
        {
            get;
            set;
        }
        public int CounterPOSApplicableID
        {
            get;
            set;
        }
        public int GeneralWeavingMachineMasterID
        {
            get;
            set;
        }
        public string DateFrom
        {
            get;
            set;
        }
        public string DateUpto
        {
            get;
            set;
        }
        public bool IsCurrent
        {
            get;
            set;
        }
        public Int16 UserTypeID
        {
            get;
            set;
        }
        public string UserType
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public string DateOfBirth
        {
            get;
            set;
        }
        public string CreatedDate
        {
            get;
            set;
        }
        public string ModifiedDate
        {
            get;
            set;
        }
        public string DeletedDate
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public bool Flag
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public string InventoryPOSSelfAssignXML
        {
            get;
            set;
        }
        public string InventoryCounterLogXML
        {
            get;
            set;
        }
        public string UserLogsXML
        {
            get;
            set;
        }
        public string UserLogXML
        {
            get;
            set;
        }
    }
}
