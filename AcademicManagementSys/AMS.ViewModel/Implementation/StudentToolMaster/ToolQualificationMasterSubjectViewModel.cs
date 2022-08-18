using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class ToolQualificationMasterSubjectBaseViewModel : IToolQualificationMasterSubjectBaseViewModel
    {
        public ToolQualificationMasterSubjectBaseViewModel()
        {

        }

        public ToolQualificationMasterSubject ToolQualificationMasterSubjectDTO
        {
            get;
            set;
        }



    }
    public class ToolQualificationMasterSubjectViewModel : IToolQualificationMasterSubjectViewModel
    {

        public ToolQualificationMasterSubjectViewModel()
        {
            ToolQualificationMasterSubjectDTO = new ToolQualificationMasterSubject();
            ToolQualificationMasterSubjectList = new List<ToolQualificationMasterSubject>();
        }

        public ToolQualificationMasterSubject ToolQualificationMasterSubjectDTO { get; set; }

        public int ID
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null && ToolQualificationMasterSubjectDTO.ID > 0) ? ToolQualificationMasterSubjectDTO.ID : new int();
            }
            set
            {
                ToolQualificationMasterSubjectDTO.ID = value;
            }
        }

        public int QualificationMstID
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null) ? ToolQualificationMasterSubjectDTO.QualificationMstID : new int();
            }
            set
            {
                ToolQualificationMasterSubjectDTO.QualificationMstID = value;
            }
        }
        public string QualificationName
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null) ? ToolQualificationMasterSubjectDTO.QualificationName : string.Empty;
            }
            set
            {
                ToolQualificationMasterSubjectDTO.QualificationName = value;
            }
        }
        //[Display(Name = "Subject Name")]
        [Display(Name = "DisplayName_SubjectName", ResourceType = typeof(AMS.Common.Resources))]
        public string SubjectName
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null) ? ToolQualificationMasterSubjectDTO.SubjectName : string.Empty;
            }
            set
            {
                ToolQualificationMasterSubjectDTO.SubjectName = value;
            }
        }
         [Display(Name = "DisplayName_MarkOutOf", ResourceType = typeof(AMS.Common.Resources))]
        //[Display(Name = "Mark Out Of")]
        public int MarkOutOf
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null) ? ToolQualificationMasterSubjectDTO.MarkOutOf : new int();
            }
            set
            {
                ToolQualificationMasterSubjectDTO.MarkOutOf = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null) ? ToolQualificationMasterSubjectDTO.IsDeleted : false;
            }
            set
            {
                ToolQualificationMasterSubjectDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null && ToolQualificationMasterSubjectDTO.CreatedBy > 0) ? ToolQualificationMasterSubjectDTO.CreatedBy : new int();
            }
            set
            {
                ToolQualificationMasterSubjectDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null) ? ToolQualificationMasterSubjectDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationMasterSubjectDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null && ToolQualificationMasterSubjectDTO.ModifiedBy.HasValue) ? ToolQualificationMasterSubjectDTO.ModifiedBy : new int();
            }
            set
            {
                ToolQualificationMasterSubjectDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null && ToolQualificationMasterSubjectDTO.ModifiedDate.HasValue) ? ToolQualificationMasterSubjectDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationMasterSubjectDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null && ToolQualificationMasterSubjectDTO.DeletedBy.HasValue) ? ToolQualificationMasterSubjectDTO.DeletedBy : new int();
            }
            set
            {
                ToolQualificationMasterSubjectDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null && ToolQualificationMasterSubjectDTO.DeletedDate.HasValue) ? ToolQualificationMasterSubjectDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationMasterSubjectDTO.DeletedDate = value;
            }
        }

        public bool StatusFlag
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null) ? ToolQualificationMasterSubjectDTO.StatusFlag : false;
            }
            set
            {
                ToolQualificationMasterSubjectDTO.StatusFlag = value;
            }
        }
        public string SelectedIDs
        {
            get
            {
                return (ToolQualificationMasterSubjectDTO != null) ? ToolQualificationMasterSubjectDTO.SelectedIDs : string.Empty;
            }
            set
            {
                ToolQualificationMasterSubjectDTO.SelectedIDs = value;
            }
        }
        public List<ToolQualificationMasterSubject> ToolQualificationMasterSubjectList
        {
            get;
            set;
        }
    }
}
