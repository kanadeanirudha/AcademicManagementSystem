using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AMS.ViewModel
{
    public class EntranceExamPaymentDetailsViewModel : IEntranceExamPaymentDetailsViewModel
    {
        public EntranceExamPaymentDetailsViewModel()
        {
            EntranceExamPaymentDetailsDTO = new EntranceExamPaymentDetails();
        }
        public EntranceExamPaymentDetails EntranceExamPaymentDetailsDTO { get; set; }


        //-----------------------------------EntranceExamPaymentDetails Table Property-------------------------------//
        public int ID
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.ID > 0) ? EntranceExamPaymentDetailsDTO.ID : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.ID = value;
            }
        }


        public int EntranceExamValidationParameterApplicableID
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.EntranceExamValidationParameterApplicableID > 0) ? EntranceExamPaymentDetailsDTO.EntranceExamValidationParameterApplicableID : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.EntranceExamValidationParameterApplicableID = value;
            }
        }

        public int StudentRegistrationID
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.StudentRegistrationID > 0) ? EntranceExamPaymentDetailsDTO.StudentRegistrationID : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.StudentRegistrationID = value;
            }
        }

        [Display(Name = "Payment Amount :")]
        [Required(ErrorMessage = "Payment amount should not blank.")]
        public decimal PaymentAmount
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.PaymentAmount > 0) ? EntranceExamPaymentDetailsDTO.PaymentAmount : new decimal();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.PaymentAmount = value;
            }
        }

        [Display(Name="Payment Mode :")]
        [Required(ErrorMessage = "Payment mode should not blank.")]
        public int PaymentMode
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.PaymentMode > 0) ? EntranceExamPaymentDetailsDTO.PaymentMode : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.PaymentMode = value;
            }
        }
        
        [Display(Name = "Payment Through :")]
        [Required(ErrorMessage = "Payment through should not blank.")]
        public int PaymentThrough
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.PaymentThrough > 0) ? EntranceExamPaymentDetailsDTO.PaymentThrough : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.PaymentThrough = value;
            }
        }

        [Display(Name = "Chalan Number :")]
        [Required(ErrorMessage = "Chalan number should not blank.")]
        public string ChalanNo
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.ChalanNo != "") ? EntranceExamPaymentDetailsDTO.ChalanNo : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.ChalanNo = value;
            }
        }

        [Display(Name = "Chalan Date :")]
        [Required(ErrorMessage = "Chalan date should not blank.")]
        public string ChalanDate
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.ChalanDate != "") ? EntranceExamPaymentDetailsDTO.ChalanDate : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.ChalanDate = value;
            }
        }


        [Display(Name = "Bank Name :")]
        [Required(ErrorMessage = "Bank name should not blank.")]
        public string BankName
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.BankName != "") ? EntranceExamPaymentDetailsDTO.BankName : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.BankName = value;
            }
        }

        [Display(Name = "Bank Address :")]
        [Required(ErrorMessage = "Bank address should not blank.")]
        public string BankAddress
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.BankAddress != "") ? EntranceExamPaymentDetailsDTO.BankAddress : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.BankAddress = value;
            }
        }

        //To Upload File.
        [Display(Name = "Attach File :")]
        [Required(ErrorMessage = "Attach file should not blank.")]
        public byte[] AttachFile
        {
            get
            {
                return EntranceExamPaymentDetailsDTO != null ? EntranceExamPaymentDetailsDTO.AttachFile : new byte[1];
            }
            set
            {
                EntranceExamPaymentDetailsDTO.AttachFile = value;
            }
        }

        [Display(Name = "Payment ID :")]
        [Required(ErrorMessage = "Payment id should not blank.")]
        public string PaymentID
        {
            get
            {
                return EntranceExamPaymentDetailsDTO != null  ? EntranceExamPaymentDetailsDTO.PaymentID : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.PaymentID = value;
            }
        }

        [Required(ErrorMessage = "Status should not blank.")]
        public bool Status
        {
            get
            {
                return EntranceExamPaymentDetailsDTO != null ? EntranceExamPaymentDetailsDTO.Status : false;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.Status = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool? IsDeleted
        {
            get
            {
                return EntranceExamPaymentDetailsDTO.IsDeleted != null ? EntranceExamPaymentDetailsDTO.IsDeleted : false;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int? CreatedBy
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO.CreatedBy != null && EntranceExamPaymentDetailsDTO.CreatedBy > 0) ? EntranceExamPaymentDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO.CreatedDate != null) ? EntranceExamPaymentDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return EntranceExamPaymentDetailsDTO.ModifiedBy != null ? EntranceExamPaymentDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO.ModifiedDate != null && EntranceExamPaymentDetailsDTO.ModifiedDate.HasValue) ? EntranceExamPaymentDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.DeletedBy > 0) ? EntranceExamPaymentDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO.DeletedDate != null && EntranceExamPaymentDetailsDTO.DeletedDate.HasValue) ? EntranceExamPaymentDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.DeletedDate = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.ErrorMessage != "") ? EntranceExamPaymentDetailsDTO.ErrorMessage : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.ErrorMessage = value;
            }
        }

        ///-------------------------------------------Extra Property------------------------------------
        
        [Display(Name = "Student Name :")]
        [Required(ErrorMessage = "Student name should not blank.")]
        public string StudentName
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.StudentName != "") ? EntranceExamPaymentDetailsDTO.StudentName : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.StudentName = value;
            }
        }

        public int EntranceExamPaymenDetailsID
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.EntranceExamPaymenDetailsID > 0) ? EntranceExamPaymentDetailsDTO.EntranceExamPaymenDetailsID : new int();
            }
            set
            {
                EntranceExamPaymentDetailsDTO.EntranceExamPaymenDetailsID = value;
            }
        }

        public string EntranceExamPaymentDetailsSearchWord
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.EntranceExamPaymentDetailsSearchWord != "") ? EntranceExamPaymentDetailsDTO.EntranceExamPaymentDetailsSearchWord : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.EntranceExamPaymentDetailsSearchWord = value;
            }
        }

        //[Display(Name = "Payment by :")]
        //public string Paymentby
        //{
        //    get
        //    {
        //        return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.Paymentby != "") ? EntranceExamPaymentDetailsDTO.Paymentby : string.Empty;
        //    }
        //    set
        //    {
        //        EntranceExamPaymentDetailsDTO.Paymentby = value;
        //    }
        //}

        public string  PaymentModeValue
        {
            get
            {
                return (EntranceExamPaymentDetailsDTO != null && EntranceExamPaymentDetailsDTO.PaymentModeValue != "") ? EntranceExamPaymentDetailsDTO.PaymentModeValue : string.Empty;
            }
            set
            {
                EntranceExamPaymentDetailsDTO.PaymentModeValue = value;
            }
        }

        public HttpPostedFileBase AttachPaymentDetailFile { get; set; }

    }
}
