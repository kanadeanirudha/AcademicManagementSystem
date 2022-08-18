using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class HMPatientMasterViewModel : IHMPatientMasterViewModel
    {

        public HMPatientMasterViewModel()
        {
            HMPatientMasterDTO = new HMPatientMaster();

        }

        public HMPatientMaster HMPatientMasterDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.ID : new Int64();
            }
            set
            {
                HMPatientMasterDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Patient Code should not be blank.")]
        [Display(Name = "Patient Code")]
       public string PatientCode 

        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.PatientCode : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.PatientCode = value;
            }
        }
        [Required(ErrorMessage = "Patient Name should not be blank.")]
        [Display(Name = "Patient Name")]
        public string PatientName
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.PatientName : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.PatientName = value;
            }
        }
       [Required(ErrorMessage = "First Name should not be blank.")]
       [Display(Name = "First Name")]
       public string FirstName
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.FirstName : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.FirstName = value;
            }
        }

       [Required(ErrorMessage = "Middle Name should not be blank.")]
       [Display(Name = "Middle Name")]
       public string MiddleName
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.MiddleName = value;
            }
        }
       [Required(ErrorMessage = "Last Name should not be blank.")]
       [Display(Name = "Last Name")]
       public string LastName
       {
           get
           {
               return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.LastName : string.Empty;
           }
           set
           {
               HMPatientMasterDTO.LastName = value;
           }
       }
       [Required(ErrorMessage = "Age should not be blank.")]
       [Display(Name = "Age")]
        public string Age
       {
           get
           {
               return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.Age : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.Age = value;
            }
       }
       [Required(ErrorMessage = "Gender should not be blank.")]
       [Display(Name = "Gender")]
        public string Gender
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.Gender : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.Gender = value;
            }
        }
       [Required(ErrorMessage = "DOB should not be blank.")]
       [Display(Name = "DOB")]
        public string DOB
        { 
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.DOB : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.DOB = value;
            }
        }
       [Required(ErrorMessage = "Address should not be blank.")]
       [Display(Name = "Address")]
        public string Address
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.Address : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.Address = value;
            }
        }
       [Required(ErrorMessage = "City should not be blank.")]
       [Display(Name = "City")]
        public string City
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.City : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.City = value;
            }
        }
       [Required(ErrorMessage = "Pin Code should not be blank.")]
       [Display(Name = "Pin Code")]
       public string PinCode
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.PinCode : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.PinCode = value;
            }
        }
       [Required(ErrorMessage = "Identity Number should not be blank.")]
       [Display(Name = "Identity Number")]
        public string IdentityNumber
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.IdentityNumber : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.IdentityNumber = value;
            }
        }
       [Required(ErrorMessage = "Note should not be blank.")]
       [Display(Name = "Note")]
        public string Note
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.Note : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.Note = value;
            }
        }
       [Required(ErrorMessage = "Family Mobile Number should not be blank.")]
       [Display(Name = "Family Mobile Number")]
        public String FamilyMobileNumber
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.FamilyMobileNumber : string.Empty;
            }
            set
            {
                HMPatientMasterDTO.FamilyMobileNumber = value;
            }
        }
       [Required(ErrorMessage = "Next Appointment Date should not be blank.")]
       [Display(Name = "Next Appointment Date")]
       public string NextAppointmentDate
       {
           get
           {
               return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.NextAppointmentDate : string.Empty;
           }
           set
           {
               HMPatientMasterDTO.NextAppointmentDate = value;
           }
       }
       public Int64 LastAppointmentTransactionID
       {
           get
           {
               return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.LastAppointmentTransactionID : new Int64();
           }
           set
           {
               HMPatientMasterDTO.LastAppointmentTransactionID = value;
           }
       }
       [Display(Name = "IsIPDPatient")]
       public bool IsIPDPatient
       {
           get
           {
               return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.IsIPDPatient : false;
           }
           set
           {
               HMPatientMasterDTO.IsIPDPatient = value;
           }
       }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.IsDeleted : false;
            }
            set
            {
                HMPatientMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (HMPatientMasterDTO != null && HMPatientMasterDTO.CreatedBy > 0) ? HMPatientMasterDTO.CreatedBy : new int();
            }
            set
            {
                HMPatientMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                HMPatientMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.ModifiedBy : new int();
            }
            set
            {
                HMPatientMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                HMPatientMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.DeletedBy : new int();
            }
            set
            {
                HMPatientMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (HMPatientMasterDTO != null) ? HMPatientMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                HMPatientMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

