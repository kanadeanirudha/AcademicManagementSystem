using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class GeneralTimeZoneMasterViewModel : IGeneralTimeZoneMasterViewModel
    {
        public GeneralTimeZoneMasterViewModel()
        {
            GeneralTimeZoneMasterDTO = new GeneralTimeZoneMaster();
        }
        public GeneralTimeZoneMaster GeneralTimeZoneMasterDTO { get; set; }
        public Int32 ID
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.ID > 0) ? GeneralTimeZoneMasterDTO.ID : new Int32(); }
            set { GeneralTimeZoneMasterDTO.ID = value; }
        }
        
        public String TimeZone
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.TimeZone != null) ? GeneralTimeZoneMasterDTO.TimeZone : String.Empty; }
            set { GeneralTimeZoneMasterDTO.TimeZone = value; }
        }
      
        public String Coordinates
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.Coordinates != null) ? GeneralTimeZoneMasterDTO.Coordinates : String.Empty; }
            set { GeneralTimeZoneMasterDTO.Coordinates = value; }
        }
    
        public String CountryCode
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.CountryCode != null) ? GeneralTimeZoneMasterDTO.CountryCode : String.Empty; }
            set { GeneralTimeZoneMasterDTO.CountryCode = value; }
        }
     
        public String Comments
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.Comments != null) ? GeneralTimeZoneMasterDTO.Comments : String.Empty; }
            set { GeneralTimeZoneMasterDTO.Comments = value; }
        }
   
        public String UTCoffset
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.UTCoffset != null) ? GeneralTimeZoneMasterDTO.UTCoffset : String.Empty; }
            set { GeneralTimeZoneMasterDTO.UTCoffset = value; }
        }
    
        public String UTCDSToffset
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.UTCDSToffset != null) ? GeneralTimeZoneMasterDTO.UTCDSToffset : String.Empty; }
            set { GeneralTimeZoneMasterDTO.UTCDSToffset = value; }
        }
     
        public String Notes
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.Notes != null) ? GeneralTimeZoneMasterDTO.Notes : String.Empty; }
            set { GeneralTimeZoneMasterDTO.Notes = value; }
        }
        public Int32 CreatedBy
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.CreatedBy > 0) ? GeneralTimeZoneMasterDTO.CreatedBy : new Int32(); }
            set { GeneralTimeZoneMasterDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.CreatedDate != null) ? GeneralTimeZoneMasterDTO.CreatedDate : String.Empty; }
            set { GeneralTimeZoneMasterDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.ModifiedBy > 0) ? GeneralTimeZoneMasterDTO.ModifiedBy : new Int32(); }
            set { GeneralTimeZoneMasterDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.ModifiedDate != null) ? GeneralTimeZoneMasterDTO.ModifiedDate : String.Empty; }
            set { GeneralTimeZoneMasterDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.DeletedBy > 0) ? GeneralTimeZoneMasterDTO.DeletedBy : new Int32(); }
            set { GeneralTimeZoneMasterDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.DeletedDate != null) ? GeneralTimeZoneMasterDTO.DeletedDate : String.Empty; }
            set { GeneralTimeZoneMasterDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (GeneralTimeZoneMasterDTO != null) ? GeneralTimeZoneMasterDTO.IsDeleted : false; }
            set { GeneralTimeZoneMasterDTO.IsDeleted = value; }
        }
        public string LastSyncDate
        {
            get { return (GeneralTimeZoneMasterDTO != null && GeneralTimeZoneMasterDTO.LastSyncDate != null) ? GeneralTimeZoneMasterDTO.LastSyncDate : string.Empty; }
            set { GeneralTimeZoneMasterDTO.LastSyncDate = value; }
        }
        
    }
}
