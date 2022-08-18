using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IHMPatientMasterViewModel
     {
            HMPatientMaster HMPatientMasterDTO {get;set;}
            Int64 ID{get;set;}
            string PatientCode{get;set;}
            string FirstName{get;set;}
            string MiddleName{get;set;}
            string LastName{get;set;}
            string Age{get;set;}
            string Gender{get;set;}
            string DOB{get;set;}
            string Address{get;set;}
            string City{get;set;}
            string PinCode{get;set;}
            string NextAppointmentDate{get;set;}
            Int64 LastAppointmentTransactionID{get;set;}
            //string Note{get;set;}
            string IdentityNumber{get;set;}
            string Note { get; set; }
            string FamilyMobileNumber { get; set; }
            int CreatedBy
            {
                get;
                set;
            }
            DateTime CreatedDate
            {
                get;
                set;
            }
            int ModifiedBy
            {
                get;
                set;
            }
            DateTime ModifiedDate
            {
                get;
                set;
            }
            int DeletedBy
            {
                get;
                set;
            }
            DateTime DeletedDate
            {
                get;
                set;
            }
            string PatientName
            { get; set; }
            string errorMessage { get; set; }
   }
}
