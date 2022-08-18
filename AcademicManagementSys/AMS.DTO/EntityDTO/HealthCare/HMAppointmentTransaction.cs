using AMS.Base.DTO;
using System;
namespace AMS.DTO
    {   public class HMAppointmentTransaction : BaseDTO
        {
                    public Int64  ID{get;set;}
                    public string TransactionDate { get; set; }
                    public Int64  GeneralPatientMasterId { get; set; }
                    public string symtoms { get; set; } 
                    public string Symtomp { get; set; }
                    public string PatientName { get; set; }
                    public Int32  ConsultantID { get; set; }
                    public string NextAppointmentDate { get; set; }
                    public byte Status { get; set; }
                    public bool IsCaseClosed { get; set; }
                    public bool   IsNewPatient { get; set; }
                    public string CentreName { get; set; }
                    public string CentreCode { get; set; }
                   // public string OPDID { get; set; }
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
                   public string Name
                    {
                        get;
                        set;

                    }
                   public string Age
                    {
                        get;
                        set;
                    }
                   public string LastAppointmentDate
                   {
                       get;
                       set;
                   }
                   public string Gender
                    {
                        get;
                        set;
                    }
                   public string Date
                    {
                        get;
                        set;
                    }
                   public string OPDName
                   {
                       get;
                       set;
                   }
                   public string TaskCode
                   {
                       get;
                       set;
                   }
                   public Int16 HMOPDHealthCentreID
                   {
                       get;
                       set;
                   }
                  
                   public string SelectedCentreCode { get; set; }
                   public string SelectedHMOPDHealthCentreID { get; set; }
                   public string errorMessage { get; set; }

                   //For HMPatientCaseHisgtory
                   public string CaseHistoryNumber { get; set; }
                   public Int64 AppointmentTransactionId { get; set; }
                   public string TreatmentName { get; set; }
                   public string TreatmentDescription { get; set; }
                   public string Doctor { get; set; }
                  // public byte IsCaseClosed { get; set; }
                   public byte IsReferIPD { get; set; }
                  //For HMPatientMedicine
                   public string DosesDescription { get; set; }
                   public string ForNumberOfDays { get; set; }
      }
}
