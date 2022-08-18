using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudyCentreMasterSearchRequest : Request
    {
        public Int32 ID { get; set; }
        public string CentreCode { get; set; }
        public string CentreName { get; set; }
        public string HoCoRoScFlag { get; set; }
        public Int32 HoID { get; set; }
        public Int32 CoID { get; set; }
        public Int32 RoID { get; set; }
        public string CentreSpecialization { get; set; }
        public string CentreAddress { get; set; }
        public string PlotNo { get; set; }
        public string StreetName { get; set; }
        public string LastSyncDate { get; set; }
        public string DeviceCode { get; set; }
        
        public Int32 CityID { get; set; }
        public string Pincode { get; set; }
        public string EmailID { get; set; }
        public string Url { get; set; }
        public string CellPhone { get; set; }
        public string FaxNumber { get; set; }
        public string PhoneNumberOffice { get; set; }
        public string CentreEstablishmentDatetime { get; set; }
        public Int32 OrganisationID { get; set; }
        public Int32 CentreLoginNumber { get; set; }
        public string InstituteCode { get; set; }
        public string TimeZone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal CampusArea { get; set; }
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
