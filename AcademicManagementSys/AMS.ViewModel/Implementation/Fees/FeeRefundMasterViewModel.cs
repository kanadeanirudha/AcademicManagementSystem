using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FeeRefundMasterViewModel : IFeeRefundMasterViewModel
    {
        public FeeRefundMasterViewModel()
        {
            FeeRefundMasterDTO = new FeeRefundMaster();
            StructureApplicableStudentList = new List<FeeRefundMaster>();
            StudentPaymentDetails = new List<FeeRefundMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            AccountList = new List<FeeRefundMaster>();
        }
        public List<FeeRefundMaster> StructureApplicableStudentList
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<FeeRefundMaster> AccountList
        {
            get;
            set;
        }
        public List<FeeRefundMaster> StudentPaymentDetails { get; set; }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public IEnumerable<SelectListItem> AccountListItems
        {
            get { return new SelectList(AccountList, "AccountID", "AccountName"); }
        }
        public string SelectedFeeCriteriaMasterID { get; set; }
        public FeeRefundMaster FeeRefundMasterDTO { get; set; }

        public int ID
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.ID > 0) ? FeeRefundMasterDTO.ID : new int();
            }
            set
            {
                FeeRefundMasterDTO.ID = value;
            }
        }

        public Int16 AccSessionID
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AccSessionID > 0) ? FeeRefundMasterDTO.AccSessionID : new Int16();
            }
            set
            {
                FeeRefundMasterDTO.AccSessionID = value;
            }
        }
        public Int16 AccBalsheetID
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AccBalsheetID > 0) ? FeeRefundMasterDTO.AccBalsheetID : new Int16();
            }
            set
            {
                FeeRefundMasterDTO.AccBalsheetID = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.CentreCode != string.Empty) ? FeeRefundMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.CentreCode = value;
            }
        }

        public string CentreName
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.CentreName != string.Empty) ? FeeRefundMasterDTO.CentreName : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.CentreName = value;
            }
        }

        public int AcademicYearID
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AcademicYearID > 0) ? FeeRefundMasterDTO.AcademicYearID : new int();
            }
            set
            {
                FeeRefundMasterDTO.AcademicYearID = value;
            }
        }

        public string PersonType
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.PersonType != string.Empty) ? FeeRefundMasterDTO.PersonType : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.PersonType = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.PersonID > 0) ? FeeRefundMasterDTO.PersonID : new int();
            }
            set
            {
                FeeRefundMasterDTO.PersonID = value;
            }
        }

        public bool IsRefundByCashOrBank
        {
            get
            {
                return (FeeRefundMasterDTO != null ? FeeRefundMasterDTO.IsRefundByCashOrBank : new bool());
            }
            set
            {
                FeeRefundMasterDTO.IsRefundByCashOrBank = value;
            }
        }

        [Required(ErrorMessage="Remark should not be blank")]
        public string Remark
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.Remark != string.Empty) ? FeeRefundMasterDTO.Remark : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.Remark = value;
            }
        }

        public decimal RefundAmount
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.RefundAmount > 0) ? FeeRefundMasterDTO.RefundAmount : new decimal();
            }
            set
            {
                FeeRefundMasterDTO.RefundAmount = value;
            }
        }

        public string RefundDate
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.RefundDate != string.Empty) ? FeeRefundMasterDTO.RefundDate : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.RefundDate = value;
            }
        }

        [Display(Name="Cheque Number")]
        public string ChequeNumber
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.ChequeNumber != string.Empty) ? FeeRefundMasterDTO.ChequeNumber : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.ChequeNumber = value;
            }
        }

        [Display(Name = "Cheque Date")]
        public string ChequeDate
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.ChequeDate != string.Empty) ? FeeRefundMasterDTO.ChequeDate : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.ChequeDate = value;
            }
        }

        public bool IsRefundGiven
        {
            get
            {
                return (FeeRefundMasterDTO != null ? FeeRefundMasterDTO.IsRefundGiven : new bool());
            }
            set
            {
                FeeRefundMasterDTO.IsRefundGiven = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (FeeRefundMasterDTO != null ? FeeRefundMasterDTO.IsActive : new bool());
            }
            set
            {
                FeeRefundMasterDTO.IsActive = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (FeeRefundMasterDTO != null ? FeeRefundMasterDTO.IsDeleted : new bool());
            }
            set
            {
                FeeRefundMasterDTO.IsDeleted = value;
            }
        }

        public string errorMessage
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.errorMessage != string.Empty) ? FeeRefundMasterDTO.errorMessage : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.errorMessage = value;
            }
        }

        public string SelectedXml
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.SelectedXml != string.Empty) ? FeeRefundMasterDTO.SelectedXml : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.SelectedXml = value;
            }
        }
        public string EntityLevel
        {
            get
            {
                return (FeeRefundMasterDTO != null) ? FeeRefundMasterDTO.EntityLevel : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.EntityLevel = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.CreatedBy > 0) ? FeeRefundMasterDTO.CreatedBy : new int();
            }
            set
            {
                FeeRefundMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (FeeRefundMasterDTO != null) ? FeeRefundMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeRefundMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.ModifiedBy > 0) ? FeeRefundMasterDTO.ModifiedBy : new int();
            }
            set
            {
                FeeRefundMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (FeeRefundMasterDTO != null) ? FeeRefundMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeRefundMasterDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.DeletedBy > 0) ? FeeRefundMasterDTO.DeletedBy : new int();
            }
            set
            {
                FeeRefundMasterDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (FeeRefundMasterDTO != null) ? FeeRefundMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeRefundMasterDTO.DeletedDate = value;
            }
        }

        public int StudentID
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.StudentID > 0) ? FeeRefundMasterDTO.StudentID : new int();
            }
            set
            {
                FeeRefundMasterDTO.StudentID = value;
            }
        }
        public string StudentName
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.StudentName != string.Empty) ? FeeRefundMasterDTO.StudentName : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.StudentName = value;
            }
        }
        public string BranchDescription
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.BranchDescription != string.Empty) ? FeeRefundMasterDTO.BranchDescription : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.BranchDescription = value;
            }
        }
        public string BranchShortCode
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.BranchShortCode != string.Empty) ? FeeRefundMasterDTO.BranchShortCode : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.BranchShortCode = value;
            }
        }
        public string SessionName
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.SessionName != string.Empty) ? FeeRefundMasterDTO.SessionName : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.SessionName = value;
            }
        }

        public string AccountName
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AccountName != string.Empty) ? FeeRefundMasterDTO.AccountName : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.AccountName = value;
            }
        }
        public int AccountID
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AccountID > 0) ? FeeRefundMasterDTO.AccountID : new int();
            }
            set
            {
                FeeRefundMasterDTO.AccountID = value;
            }
        }

        public string AcademicYear
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AcademicYear != string.Empty) ? FeeRefundMasterDTO.AcademicYear : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.AcademicYear = value;
            }
        }

        public string EmailID
        {
            get
            {
                return (FeeRefundMasterDTO != null) ? FeeRefundMasterDTO.EmailID : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.EmailID = value;
            }
        }

        public string Course
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.Course != string.Empty) ? FeeRefundMasterDTO.Course : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.Course = value;
            }
        }

        public string Section
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.Section != string.Empty) ? FeeRefundMasterDTO.Section : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.Section = value;
            }
        }

        public string AdmissionPattern
        {
            get
            {
                return (FeeRefundMasterDTO != null) ? FeeRefundMasterDTO.AdmissionPattern : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.AdmissionPattern = value;
            }
        }

        public string EnrollmentNumber
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.EnrollmentNumber != string.Empty) ? FeeRefundMasterDTO.EnrollmentNumber : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.EnrollmentNumber = value;
            }
        }

        public string StandardNumber
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.StandardNumber != string.Empty) ? FeeRefundMasterDTO.StandardNumber : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.StandardNumber = value;
            }
        }

        public string AdmitAcademicYear
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AdmitAcademicYear != string.Empty) ? FeeRefundMasterDTO.AdmitAcademicYear : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.AdmitAcademicYear = value;
            }
        }

        public string Gender
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.Gender != string.Empty) ? FeeRefundMasterDTO.Gender : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.Gender = value;
            }
        }

        public byte[] StudentPhoto
        {
            get
            {
                return (FeeRefundMasterDTO != null) ? FeeRefundMasterDTO.StudentPhoto : new byte[1];         //review this       
            }
            set
            {
                FeeRefundMasterDTO.StudentPhoto = value;
            }
        }

        public string StudentPhotoFileHeight
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.StudentPhotoFileHeight != "") ? FeeRefundMasterDTO.StudentPhotoFileHeight : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.StudentPhotoFileHeight = value;
            }
        }
        public string StudentPhotoFilename
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.StudentPhotoFilename != "") ? FeeRefundMasterDTO.StudentPhotoFilename : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.StudentPhotoFilename = value;
            }
        }
        public string StudentPhotoFileSize
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.StudentPhotoFileSize != "") ? FeeRefundMasterDTO.StudentPhotoFileSize : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.StudentPhotoFileSize = value;
            }
        }
        public string StudentPhotoFileWidth
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.StudentPhotoFileWidth != "") ? FeeRefundMasterDTO.StudentPhotoFileWidth : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.StudentPhotoFileWidth = value;
            }
        }
        public string StudentPhotoType
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.StudentPhotoType != "") ? FeeRefundMasterDTO.StudentPhotoType : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.StudentPhotoType = value;
            }
        }
        public string AccountType
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AccountType != string.Empty) ? FeeRefundMasterDTO.AccountType : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.AccountType = value;
            }
        }
        public string SectionDetailsDesc
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.SectionDetailsDesc != string.Empty) ? FeeRefundMasterDTO.SectionDetailsDesc : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.SectionDetailsDesc = value;
            }
        }
        public int AccountIDForStudentOutStanding
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.AccountIDForStudentOutStanding > 0) ? FeeRefundMasterDTO.AccountIDForStudentOutStanding : new int();
            }
            set
            {
                FeeRefundMasterDTO.AccountIDForStudentOutStanding = value;
            }
        }
        public string XmlString
        {
            get
            {
                return (FeeRefundMasterDTO != null && FeeRefundMasterDTO.XmlString != string.Empty) ? FeeRefundMasterDTO.XmlString : string.Empty;
            }
            set
            {
                FeeRefundMasterDTO.XmlString = value;
            }
        }
    }
}
