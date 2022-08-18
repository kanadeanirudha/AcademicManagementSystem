using AMS.Base.DTO;
using System;
namespace AMS.DTO
    {   public class HMPatientMaster : BaseDTO
        {
                    public Int64 ID{get;set;}
                    public string PatientCode{get;set;}
                    public string FirstName{get;set;}
                    public string MiddleName{get;set;}
                    public string LastName{get;set;}
                    public string Age{get;set;}
                    public string PatientName { get; set; }
                    public string Gender{get;set;}
                    public string symtoms { get; set; } 
                    public string DOB{get;set;}
                    public string Address{get;set;}
                    public string City{get;set;}
                    public string PinCode{get;set;}
                    public string NextAppointmentDate{get;set;}
                    public string TransactionDate { get; set; }
                    public bool IsCaseClosed { get; set; }
                    public Int64 LastAppointmentTransactionID{get;set;}
                    public string Note{get;set;}
                    public string OPDName { get; set; }
                    public string IdentityNumber{get;set;}
                    public string FamilyMobileNumber { get; set; }
                    public byte Status { get; set; }
                    public Int16 HMOPDHealthCentreID { get; set; } 
                    public int CreatedBy
                    {
                        get;
                        set;
                    }
                    public DateTime CreatedDate
                    {
                        get;
                        set;
                    }
                    public int ModifiedBy
                    {
                        get;
                        set;
                    }
                    public DateTime ModifiedDate
                    {
                        get;
                        set;
                    }
                    public int DeletedBy
                    {
                        get;
                        set;
                    }
                    public DateTime DeletedDate
                    {
                        get;
                        set;
                    }
                    public bool IsDeleted
                    {
                        get;
                        set;
                    }
                    public bool IsIPDPatient { get; set; }
                    //public Int32 CreatedBy{get;set;}
                    //public DateTime CreatedDate{get;set;}
                    //public Int32 ModifiedBy{get;set;}
                    //public DateTime ModifiedDate{get;set;}
                    //public Int32 DeletedBy{get;set;}
                    //public DateTime DeletedDate{get;set;}
      }
}
