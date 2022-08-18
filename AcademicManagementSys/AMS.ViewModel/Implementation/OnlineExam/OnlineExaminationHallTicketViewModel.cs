using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExaminationHallTicketViewModel : IOnlineExaminationHallTicketViewModel
    {

        public OnlineExaminationHallTicketViewModel()
        {
            OnlineExaminationHallTicketDTO = new OnlineExaminationHallTicket();
        }

        public OnlineExaminationHallTicket OnlineExaminationHallTicketDTO
        {
            get;
            set;
        } 

       
        public int ID
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null && OnlineExaminationHallTicketDTO.ID > 0) ? OnlineExaminationHallTicketDTO.ID : new int();
            }
            set
            {
                OnlineExaminationHallTicketDTO.ID = value;
            }
        }
        public int StudentRegistrationID
        {
            get;
            set;
        }
        [Display(Name = "Registration Number:")]
        public string RegistrationNumber
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.RegistrationNumber : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.RegistrationNumber = value;
            }
        }
        public int RollNumber
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null && OnlineExaminationHallTicketDTO.RollNumber > 0) ? OnlineExaminationHallTicketDTO.RollNumber : new int();
            }
            set
            {
                OnlineExaminationHallTicketDTO.RollNumber = value;
            }
        }
        [Display(Name = "Student Full Name :")]
        public string StudentFullName
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.StudentFullName : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.StudentFullName = value;
            }
        }
         [Display(Name = "Examination Name :")]
        public string ExaminationName
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.ExaminationName = value;
            }
        }

        

        [Display(Name = "Gender :")]
        public string Gender
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.Gender : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.Gender = value;
            }
        }
        [Display(Name = "Exam Date :")]
        public string ExamDate
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.ExamDate : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.ExamDate = value;
            }
        }

        [Display(Name = "Exam Time :")]
        public string ExamTime
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.ExamTime : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.ExamTime = value;
            }
        }
        [Display(Name = "Exam Center Address :")]
        public string Venue
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.Venue : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.Venue = value;
            }
        }
        public string Venue1
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.Venue1 : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.Venue1 = value;
            }
        }
        public byte[] StudentPhoto
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.StudentPhoto : new byte[1];         //review this       
            }
            set
            {
                OnlineExaminationHallTicketDTO.StudentPhoto = value;
            }
        }
        public byte[] StudentSignature
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.StudentSignature : new byte[1];         //review this       
            }
            set
            {
                OnlineExaminationHallTicketDTO.StudentSignature = value;
            }
        }
        public string StudentSignatureFilename
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.StudentSignatureFilename : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.StudentSignatureFilename = value;
            }
        }
        public string StudentPhotoFilename
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.StudentPhotoFilename : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.StudentPhotoFilename = value;
            }
        }
        public string StudentPhotoFileSize
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.StudentPhotoFileSize : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.StudentPhotoFileSize = value;
            }
        }
        public string StudentSignatureFileSize
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.StudentSignatureFileSize : string.Empty;
            }
            set
            {
                OnlineExaminationHallTicketDTO.StudentSignatureFileSize = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.IsDeleted : false;
            }
            set
            {
                OnlineExaminationHallTicketDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null && OnlineExaminationHallTicketDTO.CreatedBy > 0) ? OnlineExaminationHallTicketDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExaminationHallTicketDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExaminationHallTicketDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExaminationHallTicketDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExaminationHallTicketDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExaminationHallTicketDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExaminationHallTicketDTO != null) ? OnlineExaminationHallTicketDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExaminationHallTicketDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

   