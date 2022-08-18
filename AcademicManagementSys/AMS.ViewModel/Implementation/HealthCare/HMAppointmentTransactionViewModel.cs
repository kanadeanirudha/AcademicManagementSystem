using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class HMAppointmentTransactionViewModel : IHMAppointmentTransactionViewModel
    {

        public HMAppointmentTransactionViewModel()
        {
            HMAppointmentTransactionDTO = new HMAppointmentTransaction();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListHMAppointmentTransactionListForPatient = new List<HMAppointmentTransaction>();
            ListOfOPDNameMaster = new List<HMOPDHealthCentre>();
        }

        public List<HMOPDHealthCentre> ListOfOPDNameMaster { get; set; }
        public List<HMAppointmentTransaction> ListHMAppointmentTransactionListForPatient { get; set; }
        public Int64 ID
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.ID : new Int64();
            }
            set
            {
                HMAppointmentTransactionDTO.ID = value;
            }
        }
       public bool IsCaseClosed
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.IsCaseClosed : false;
            }
            set
            {
                HMAppointmentTransactionDTO.IsCaseClosed = value;
            }
        }
        [Display(Name="Date")]
        public string TransactionDate
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.TransactionDate : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.TransactionDate = value;
            }
        }
        public Int64 GeneralPatientMasterId
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.GeneralPatientMasterId : new Int64();
            }
            set
            {
                HMAppointmentTransactionDTO.GeneralPatientMasterId = value;
            }
        }
       
        public bool IsNewPatient
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.IsNewPatient : false;
            }
            set
            {
                HMAppointmentTransactionDTO.IsNewPatient = value;
            }
        }
        [Required(ErrorMessage = "Symtomp Should not be blank")]
        [Display(Name = "Symtoms")]
        public string Symtomp
        { get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.Symtomp : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.Symtomp = value;
            }
        }
        [Required(ErrorMessage = "Case History Number Should not be blank")]
        [Display(Name = "Case History Number")]
        public string CaseHistoryNumber
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.CaseHistoryNumber : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.CaseHistoryNumber = value;
            }
        }
       // [Display(Name="Doctor")]
        public string Name
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.Name : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.Name = value;
            }
        }
      
        public Int32 ConsultantID
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.ConsultantID : new Int32();
            }
            set
            {
                HMAppointmentTransactionDTO.ConsultantID = value;
            }
        }
        [Display(Name="Next Appointment Date")]
         public string NextAppointmentDate
             {
                 get
              {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.NextAppointmentDate : string.Empty;
              }
            set
            {
                HMAppointmentTransactionDTO.NextAppointmentDate = value;
            }
        }
        public byte Status
         {
             get
             {
                 return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.Status : new byte();
             }
             set
             {
                 HMAppointmentTransactionDTO.Status = value;
             }
         }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        [Display(Name = "Patient Name")]
        public String PatientName
        {
            get 
            { 
                return (HMAppointmentTransactionDTO != null && HMAppointmentTransactionDTO.PatientName != null) ? HMAppointmentTransactionDTO.PatientName : String.Empty; 
            }
            set  
            { 
                HMAppointmentTransactionDTO.PatientName = value; 
            }
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public string CentreCode
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.CentreCode : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string CentreName
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.CentreName : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.CentreName = value;
            }
        }
        public string Age
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.Age : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.Age = value;
            }
        
        }
         [Display(Name = "Last Appointment Date")]
        public string LastAppointmentDate
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.LastAppointmentDate : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.LastAppointmentDate = value;
            }
        }
        public string Gender
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.Gender : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.Gender = value;
            }
        }
        public string Date
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.Date : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.Date = value;
            }
        }

        [Display(Name = "OPD Name")]
        public string OPDName
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.OPDName : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.OPDName = value;
            }
        }
        public HMAppointmentTransaction HMAppointmentTransactionDTO
        {
            get;
            set;
        }
        public string EntityLevel
        {
            get;
            set;
        }
        public string TaskCode
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.TaskCode : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.TaskCode = value;
            }
        }
        public Int16 HMOPDHealthCentreID
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.HMOPDHealthCentreID : new Int16();

            }
            set { HMAppointmentTransactionDTO.HMOPDHealthCentreID = value; 
                
                }
        }
        public string SelectedCentreCode
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.SelectedCentreCode : string.Empty;

            }
            set
            {
                HMAppointmentTransactionDTO.SelectedCentreCode = value;

            }
        }
        public string SelectedHMOPDHealthCentreID
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.SelectedHMOPDHealthCentreID : string.Empty;

            }
            set
            {
                HMAppointmentTransactionDTO.SelectedHMOPDHealthCentreID = value;

            }
        }
        public IEnumerable<SelectListItem> GetListHMOPDHealthCentre
        {
            get
            {

                return new SelectList(ListOfOPDNameMaster, "OPDID", "OPDName");
            }

        }
        //for HMPatientCaseHistory
        [Required(ErrorMessage = "Treatment Name Should not be blank")]
        [Display(Name = "Treatment Name")]
        public string TreatmentName
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.TreatmentName : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.TreatmentName = value;
            }
        }
        [Required(ErrorMessage = "Treatment Description Name Should not be blank")]
        [Display(Name = "Treatment Description")]
        public string TreatmentDescription
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.TreatmentDescription : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.TreatmentDescription = value;
            }
        }
        //For HMPatientMedicine
        [Required(ErrorMessage = "Treatment Name Should not be blank")]
        [Display(Name = "Priscription")]
        public string DosesDescription
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.DosesDescription : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.DosesDescription = value;
            }
        }
      
        [Display(Name = "For Number Of Days")]
        public string ForNumberOfDays
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.ForNumberOfDays : string.Empty;
            }
            set
            {
                HMAppointmentTransactionDTO.ForNumberOfDays = value;
            }
        }
        //For Appointment Creation
        //[Display(Name = "Transaction Date")]
        //public string DateHMOPDHealthCentreID
        //{
        //    get
        //    {
        //        return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.TransactionDate : string.Empty;
        //    }
        //    set
        //    {
        //        HMAppointmentTransactionDTO.TransactionDate = value;
        //    }
        //}
        //public string TransactionDate
        //{
        //    get
        //    {
        //        return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.TransactionDate : string.Empty;
        //    }
        //    set
        //    {
        //        HMAppointmentTransactionDTO.TransactionDate = value;
        //    }
        //}
      
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.IsDeleted : false;
            }
            set
            {
                HMAppointmentTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (HMAppointmentTransactionDTO != null && HMAppointmentTransactionDTO.CreatedBy > 0) ? HMAppointmentTransactionDTO.CreatedBy : new int();
            }
            set
            {
                HMAppointmentTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                HMAppointmentTransactionDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                HMAppointmentTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                HMAppointmentTransactionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.DeletedBy : new int();
            }
            set
            {
                HMAppointmentTransactionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (HMAppointmentTransactionDTO != null) ? HMAppointmentTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                HMAppointmentTransactionDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

