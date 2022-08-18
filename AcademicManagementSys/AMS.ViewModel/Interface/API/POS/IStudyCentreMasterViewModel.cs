using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IStudyCentreMasterViewModel
    {
        StudyCentreMaster StudyCentreMasterDTO { get; set; }
        Int32 ID { get; set; }
        string CentreCode { get; set; }
        string CentreName { get; set; }
        string HoCoRoScFlag { get; set; }
        Int32 HoID { get; set; }
        Int32 CoID { get; set; }
        Int32 RoID { get; set; }
        string CentreSpecialization { get; set; }
        string CentreAddress { get; set; }
        string PlotNo { get; set; }
        string StreetName { get; set; }
        Int32 CityID { get; set; }
        string Pincode { get; set; }
        string EmailID { get; set; }
        string Url { get; set; }
        string CellPhone { get; set; }
        string FaxNumber { get; set; }
        string PhoneNumberOffice { get; set; }
        string CentreEstablishmentDatetime { get; set; }
        Int32 OrganisationID { get; set; }
        Int32 CentreLoginNumber { get; set; }
        string InstituteCode { get; set; }
        string TimeZone { get; set; }
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
        decimal CampusArea { get; set; }
        bool IsDeleted { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
    }
}
