using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class ToolQualifyingExamSubjectBaseViewModel : IToolQualifyingExamSubjectBaseViewModel
    {
        public ToolQualifyingExamSubjectBaseViewModel()
        {

        }

        public ToolQualifyingExamSubject ToolQualifyingExamSubjectDTO
        {
            get;
            set;
        }



    }
    public class ToolQualifyingExamSubjectViewModel : IToolQualifyingExamSubjectViewModel
    {

        public ToolQualifyingExamSubjectViewModel()
        {
            ToolQualifyingExamSubjectDTO = new ToolQualifyingExamSubject();
            ToolQualifyingExamSubjectList = new List<ToolQualifyingExamSubject>(); 
        }

        public ToolQualifyingExamSubject ToolQualifyingExamSubjectDTO { get; set; }

        public int ID
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null && ToolQualifyingExamSubjectDTO.ID > 0) ? ToolQualifyingExamSubjectDTO.ID : new int();
            }
            set
            {
                ToolQualifyingExamSubjectDTO.ID = value;
            }
        }

        public int QualifyingExamMstID
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null ) ? ToolQualifyingExamSubjectDTO.QualifyingExamMstID : new int();
            }
            set
            {
                ToolQualifyingExamSubjectDTO.QualifyingExamMstID = value;
            }
        }
        public string ExamName
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null) ? ToolQualifyingExamSubjectDTO.ExamName : string.Empty;
            }
            set
            {
                ToolQualifyingExamSubjectDTO.ExamName = value;
            }
        }

        //[Display(Name = "Subject Name")]
        [Display(Name = "DisplayName_SubjectName", ResourceType = typeof(AMS.Common.Resources))]
        public string SubjectName
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null) ? ToolQualifyingExamSubjectDTO.SubjectName : string.Empty;
            }
            set
            {
                ToolQualifyingExamSubjectDTO.SubjectName = value;
            }
        }

       // [Display(Name = "Mark Out Of")]
        [Display(Name = "DisplayName_MarkOutOf", ResourceType = typeof(AMS.Common.Resources))]
        public int MarkOutOf
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null) ? ToolQualifyingExamSubjectDTO.MarkOutOf : new int();
            }
            set
            {
                ToolQualifyingExamSubjectDTO.MarkOutOf = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null) ? ToolQualifyingExamSubjectDTO.IsDeleted : false;
            }
            set
            {
                ToolQualifyingExamSubjectDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null && ToolQualifyingExamSubjectDTO.CreatedBy > 0) ? ToolQualifyingExamSubjectDTO.CreatedBy : new int();
            }
            set
            {
                ToolQualifyingExamSubjectDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null) ? ToolQualifyingExamSubjectDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamSubjectDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null && ToolQualifyingExamSubjectDTO.ModifiedBy.HasValue) ? ToolQualifyingExamSubjectDTO.ModifiedBy : new int();
            }
            set
            {
                ToolQualifyingExamSubjectDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null && ToolQualifyingExamSubjectDTO.ModifiedDate.HasValue) ? ToolQualifyingExamSubjectDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamSubjectDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null && ToolQualifyingExamSubjectDTO.DeletedBy.HasValue) ? ToolQualifyingExamSubjectDTO.DeletedBy : new int();
            }
            set
            {
                ToolQualifyingExamSubjectDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null && ToolQualifyingExamSubjectDTO.DeletedDate.HasValue) ? ToolQualifyingExamSubjectDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamSubjectDTO.DeletedDate = value;
            }
        }

        public bool StatusFlag
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null) ? ToolQualifyingExamSubjectDTO.StatusFlag : false;
            }
            set
            {
                ToolQualifyingExamSubjectDTO.StatusFlag = value;
            }
        }
        public string SelectedIDs
        {
            get
            {
                return (ToolQualifyingExamSubjectDTO != null) ? ToolQualifyingExamSubjectDTO.SelectedIDs : string.Empty;
            }
            set
            {
                ToolQualifyingExamSubjectDTO.SelectedIDs = value;
            }
        }
        public List<ToolQualifyingExamSubject> ToolQualifyingExamSubjectList
        {
            get;
            set;
        }
    }
}
