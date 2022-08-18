using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class UserMasterAPIViewModel : IUserMasterAPIViewModel
    {
        public UserMasterAPIViewModel()
        {
            UserMasterAPIDTO = new UserMasterAPI();
        }
        public UserMasterAPI UserMasterAPIDTO { get; set; }
        public Int32 ID
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.ID > 0) ? UserMasterAPIDTO.ID : new Int32(); }
            set { UserMasterAPIDTO.ID = value; }
        }
        public Int32 UserTypeID
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.UserTypeID > 0) ? UserMasterAPIDTO.UserTypeID : new Int32(); }
            set { UserMasterAPIDTO.UserTypeID = value; }
        }
    
        public Char UserType
        {
            get { return (UserMasterAPIDTO != null ) ? UserMasterAPIDTO.UserType : new char(); }
            set { UserMasterAPIDTO.UserType = value; }
        }
       
        public String EmailID
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.EmailID != null) ? UserMasterAPIDTO.EmailID : String.Empty; }
            set { UserMasterAPIDTO.EmailID = value; }
        }
      
        public String Password
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.Password != null) ? UserMasterAPIDTO.Password : String.Empty; }
            set { UserMasterAPIDTO.Password = value; }
        }
        public Int32 PersonID
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.PersonID > 0) ? UserMasterAPIDTO.PersonID : new Int32(); }
            set { UserMasterAPIDTO.PersonID = value; }
        }
        
        public String FirstName
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.FirstName != null) ? UserMasterAPIDTO.FirstName : String.Empty; }
            set { UserMasterAPIDTO.FirstName = value; }
        }
    
        public String MiddleName
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.MiddleName != null) ? UserMasterAPIDTO.MiddleName : String.Empty; }
            set { UserMasterAPIDTO.MiddleName = value; }
        }
    
        public String LastName
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.LastName != null) ? UserMasterAPIDTO.LastName : String.Empty; }
            set { UserMasterAPIDTO.LastName = value; }
        }
        public bool Gender
        {
            get { return (UserMasterAPIDTO != null) ? UserMasterAPIDTO.Gender : false; }
            set { UserMasterAPIDTO.Gender = value; }
        }
        public String DateOfBirth
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.DateOfBirth != null) ? UserMasterAPIDTO.DateOfBirth : String.Empty; }
            set { UserMasterAPIDTO.DateOfBirth = value; }
        }
       
        public String DeviceToken
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.DeviceToken != null) ? UserMasterAPIDTO.DeviceToken : String.Empty; }
            set { UserMasterAPIDTO.DeviceToken = value; }
        }
        public bool IsActive
        {
            get { return (UserMasterAPIDTO != null) ? UserMasterAPIDTO.IsActive : false; }
            set { UserMasterAPIDTO.IsActive = value; }
        }
        public bool IsDeleted
        {
            get { return (UserMasterAPIDTO != null) ? UserMasterAPIDTO.IsDeleted : false; }
            set { UserMasterAPIDTO.IsDeleted = value; }
        }
        public Int32 CreatedBy
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.CreatedBy > 0) ? UserMasterAPIDTO.CreatedBy : new Int32(); }
            set { UserMasterAPIDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.CreatedDate != null) ? UserMasterAPIDTO.CreatedDate : String.Empty; }
            set { UserMasterAPIDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.ModifiedBy > 0) ? UserMasterAPIDTO.ModifiedBy : new Int32(); }
            set { UserMasterAPIDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.ModifiedDate != null) ? UserMasterAPIDTO.ModifiedDate : String.Empty; }
            set { UserMasterAPIDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.DeletedBy > 0) ? UserMasterAPIDTO.DeletedBy : new Int32(); }
            set { UserMasterAPIDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.DeletedDate != null) ? UserMasterAPIDTO.DeletedDate : String.Empty; }
            set { UserMasterAPIDTO.DeletedDate = value; }
        }
        public String LastSyncDate
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.LastSyncDate != null) ? UserMasterAPIDTO.LastSyncDate : String.Empty; }
            set { UserMasterAPIDTO.LastSyncDate = value; }
        }
        public String DeviceCode
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.DeviceCode != null) ? UserMasterAPIDTO.DeviceCode : String.Empty; }
            set { UserMasterAPIDTO.DeviceCode = value; }
        }
        public string UserLogsXML
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.UserLogsXML != null) ? UserMasterAPIDTO.UserLogsXML : string.Empty; }
            set { UserMasterAPIDTO.UserLogsXML = value; }
        }
        public String UserLogXML
        {
            get { return (UserMasterAPIDTO != null && UserMasterAPIDTO.UserLogXML != null) ? UserMasterAPIDTO.UserLogXML : String.Empty; }
            set { UserMasterAPIDTO.UserLogXML = value; }
        }
    }
}
