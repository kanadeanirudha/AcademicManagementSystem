using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class UserMasterAPI : BaseDTO
    {
        public Int32 ID { get; set; }
        public Int32 UserTypeID { get; set; }
        public char UserType { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public Int32 PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string DeviceToken { get; set; }
        public string LastSyncDate { get; set; }
        public string DeviceCode { get; set; }
        
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool Flag { get; set; }
        public string UserLogXML { get; set;}
        public string UserLogsXML { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }

        //Account session

        public Int32 AccountsessionMasterID { get; set; }
        public string SessionStartDatetime { get; set; }
        public string SessionEndDatetime { get; set; }
        public bool DefaultFlag { get; set; }
        public string Account_System { get; set; }
        public bool IsBalanceCarryForward { get; set; }
        public Nullable<int> OldSessionID { get; set; }
        public bool IsSessionClosed { get; set; }
    }
}
