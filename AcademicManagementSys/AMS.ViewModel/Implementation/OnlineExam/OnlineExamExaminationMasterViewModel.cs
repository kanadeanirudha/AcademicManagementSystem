using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamExaminationMasterViewModel : IOnlineExamExaminationMasterViewModel
    {

        public OnlineExamExaminationMasterViewModel()
        {
            OnlineExamExaminationMasterDTO = new OnlineExamExaminationMaster();
            SessionNameList = new List<GeneralSessionMaster>();

        }
        public List<GeneralSessionMaster> SessionNameList { get; set; }
        public IEnumerable<SelectListItem> SessionNameListItems { get { return new SelectList(SessionNameList, "SessionName", "SessionName"); } }



        public OnlineExamExaminationMaster OnlineExamExaminationMasterDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null && OnlineExamExaminationMasterDTO.ID > 0) ? OnlineExamExaminationMasterDTO.ID : new Int32();
            }
            set
            {
                OnlineExamExaminationMasterDTO.ID = value;
            }
        }


        [Required(ErrorMessage = "Examination Name should not be blank.")]
        [Display(Name = "Examination Name")]
        public string ExaminationName
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExamExaminationMasterDTO.ExaminationName = value;
            }
        }

        [Required(ErrorMessage = "Purpose should not be blank.")]
        [Display(Name = "Purpose")]
        public string Purpose
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.Purpose : string.Empty;
            }
            set
            {
                OnlineExamExaminationMasterDTO.Purpose = value;
            }
        }
        [Required(ErrorMessage = "AcadSessionId should not be blank.")]
        [Display(Name = "Academic Session")]
        public Int32 AcadSessionId
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.AcadSessionId : new Int32();
            }
            set
            {
                OnlineExamExaminationMasterDTO.AcadSessionId = value;
            }
        }
        [Required(ErrorMessage = "ExaminationFor should not be blank.")]
        [Display(Name = "Examination For")]
        public String ExaminationFor
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.ExaminationFor : string.Empty;
            }
            set
            {
                OnlineExamExaminationMasterDTO.ExaminationFor = value;
            }
        }
        [Required(ErrorMessage = "SessionNameList should not be blank.")]
        [Display(Name = "Session Name List")]
        public String SessionName
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.SessionName : string.Empty;
            }
            set
            {
                OnlineExamExaminationMasterDTO.SessionName = value;
            }
        }
           

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamExaminationMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null && OnlineExamExaminationMasterDTO.CreatedBy > 0) ? OnlineExamExaminationMasterDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamExaminationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamExaminationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamExaminationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamExaminationMasterDTO != null) ? OnlineExamExaminationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

