using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IUserMasterAPIViewModel
    {
        UserMasterAPI UserMasterAPIDTO { get; set; }
        Int32 ID { get; set; }
        Int32 UserTypeID { get; set; }
        char UserType { get; set; }
        string EmailID { get; set; }
        string Password { get; set; }
        Int32 PersonID { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        bool Gender { get; set; }
        string DateOfBirth { get; set; }
        string DeviceToken { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
    }
}
