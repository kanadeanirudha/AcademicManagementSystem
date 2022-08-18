using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class UserMasterAPISearchRequest : Request
    {
        public Int32 ID { get; set; }
        public Int32 UserTypeID { get; set; }
        public char UserType { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public Int32 PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastSyncDate { get; set; }
        public string DeviceCode { get; set; }
        
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string DeviceToken { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
    }
}
