using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public class StudyCentreMasterViewModel : IStudyCentreMasterViewModel
    {
        public StudyCentreMasterViewModel()
        {
            StudyCentreMasterDTO = new StudyCentreMaster();
        }
        public StudyCentreMaster StudyCentreMasterDTO { get; set; }
        public Int32 ID
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.ID > 0) ? StudyCentreMasterDTO.ID : new Int32(); }
            set { StudyCentreMasterDTO.ID = value; }
        }
        
        public String CentreCode
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CentreCode != null) ? StudyCentreMasterDTO.CentreCode : String.Empty; }
            set { StudyCentreMasterDTO.CentreCode = value; }
        }
        
        public String CentreName
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CentreName != null) ? StudyCentreMasterDTO.CentreName : String.Empty; }
            set { StudyCentreMasterDTO.CentreName = value; }
        }
      
        public String HoCoRoScFlag
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.HoCoRoScFlag != null) ? StudyCentreMasterDTO.HoCoRoScFlag : String.Empty; }
            set { StudyCentreMasterDTO.HoCoRoScFlag = value; }
        }
        public Int32 HoID
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.HoID > 0) ? StudyCentreMasterDTO.HoID : new Int32(); }
            set { StudyCentreMasterDTO.HoID = value; }
        }
        public Int32 CoID
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CoID > 0) ? StudyCentreMasterDTO.CoID : new Int32(); }
            set { StudyCentreMasterDTO.CoID = value; }
        }
        public Int32 RoID
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.RoID > 0) ? StudyCentreMasterDTO.RoID : new Int32(); }
            set { StudyCentreMasterDTO.RoID = value; }
        }
    
        public String CentreSpecialization
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CentreSpecialization != null) ? StudyCentreMasterDTO.CentreSpecialization : String.Empty; }
            set { StudyCentreMasterDTO.CentreSpecialization = value; }
        }
      
        public String CentreAddress
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CentreAddress != null) ? StudyCentreMasterDTO.CentreAddress : String.Empty; }
            set { StudyCentreMasterDTO.CentreAddress = value; }
        }
      
        public String PlotNo
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.PlotNo != null) ? StudyCentreMasterDTO.PlotNo : String.Empty; }
            set { StudyCentreMasterDTO.PlotNo = value; }
        }
     
        public String StreetName
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.StreetName != null) ? StudyCentreMasterDTO.StreetName : String.Empty; }
            set { StudyCentreMasterDTO.StreetName = value; }
        }
        public Int32 CityID
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CityID > 0) ? StudyCentreMasterDTO.CityID : new Int32(); }
            set { StudyCentreMasterDTO.CityID = value; }
        }
      
        public String Pincode
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.Pincode != null) ? StudyCentreMasterDTO.Pincode : String.Empty; }
            set { StudyCentreMasterDTO.Pincode = value; }
        }
     
        public String EmailID
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.EmailID != null) ? StudyCentreMasterDTO.EmailID : String.Empty; }
            set { StudyCentreMasterDTO.EmailID = value; }
        }
    
        public String Url
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.Url != null) ? StudyCentreMasterDTO.Url : String.Empty; }
            set { StudyCentreMasterDTO.Url = value; }
        }
    
        public String CellPhone
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CellPhone != null) ? StudyCentreMasterDTO.CellPhone : String.Empty; }
            set { StudyCentreMasterDTO.CellPhone = value; }
        }
      
        public String FaxNumber
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.FaxNumber != null) ? StudyCentreMasterDTO.FaxNumber : String.Empty; }
            set { StudyCentreMasterDTO.FaxNumber = value; }
        }
      
        public String PhoneNumberOffice
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.PhoneNumberOffice != null) ? StudyCentreMasterDTO.PhoneNumberOffice : String.Empty; }
            set { StudyCentreMasterDTO.PhoneNumberOffice = value; }
        }
        public String CentreEstablishmentDatetime
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CentreEstablishmentDatetime != null) ? StudyCentreMasterDTO.CentreEstablishmentDatetime : String.Empty; }
            set { StudyCentreMasterDTO.CentreEstablishmentDatetime = value; }
        }
        public Int32 OrganisationID
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.OrganisationID > 0) ? StudyCentreMasterDTO.OrganisationID : new Int32(); }
            set { StudyCentreMasterDTO.OrganisationID = value; }
        }
        public Int32 CentreLoginNumber
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CentreLoginNumber > 0) ? StudyCentreMasterDTO.CentreLoginNumber : new Int32(); }
            set { StudyCentreMasterDTO.CentreLoginNumber = value; }
        }
  
        public String InstituteCode
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.InstituteCode != null) ? StudyCentreMasterDTO.InstituteCode : String.Empty; }
            set { StudyCentreMasterDTO.InstituteCode = value; }
        }
  
        public String TimeZone
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.TimeZone != null) ? StudyCentreMasterDTO.TimeZone : String.Empty; }
            set { StudyCentreMasterDTO.TimeZone = value; }
        }
        public Decimal Latitude
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.Latitude > 0) ? StudyCentreMasterDTO.Latitude : new Decimal(); }
            set { StudyCentreMasterDTO.Latitude = value; }
        }
        public Decimal Longitude
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.Longitude > 0) ? StudyCentreMasterDTO.Longitude : new Decimal(); }
            set { StudyCentreMasterDTO.Longitude = value; }
        }
        public bool IsDeleted
        {
            get { return (StudyCentreMasterDTO != null) ? StudyCentreMasterDTO.IsDeleted : false; }
            set { StudyCentreMasterDTO.IsDeleted = value; }
        }
        public Int32 CreatedBy
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CreatedBy > 0) ? StudyCentreMasterDTO.CreatedBy : new Int32(); }
            set { StudyCentreMasterDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CreatedDate != null) ? StudyCentreMasterDTO.CreatedDate : String.Empty; }
            set { StudyCentreMasterDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.ModifiedBy > 0) ? StudyCentreMasterDTO.ModifiedBy : new Int32(); }
            set { StudyCentreMasterDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.ModifiedDate != null) ? StudyCentreMasterDTO.ModifiedDate : String.Empty; }
            set { StudyCentreMasterDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.DeletedBy > 0) ? StudyCentreMasterDTO.DeletedBy : new Int32(); }
            set { StudyCentreMasterDTO.DeletedBy = value; }
        }
        public decimal CampusArea
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.CampusArea > 0) ? StudyCentreMasterDTO.CampusArea : new decimal(); }
            set { StudyCentreMasterDTO.CampusArea = value; }
        }
        
        public String DeletedDate
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.DeletedDate != null) ? StudyCentreMasterDTO.DeletedDate : String.Empty; }
            set { StudyCentreMasterDTO.DeletedDate = value; }
        }
        public string LastSyncDate
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.LastSyncDate != null) ? StudyCentreMasterDTO.LastSyncDate : string.Empty; }
            set { StudyCentreMasterDTO.LastSyncDate = value; }
        }
        public string DeviceCode
        {
            get { return (StudyCentreMasterDTO != null && StudyCentreMasterDTO.DeviceCode != null) ? StudyCentreMasterDTO.DeviceCode : string.Empty; }
            set { StudyCentreMasterDTO.DeviceCode = value; }
        }
        
    }
}
