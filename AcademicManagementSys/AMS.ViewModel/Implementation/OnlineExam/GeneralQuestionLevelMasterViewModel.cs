
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralQuestionLevelMasterViewModel : IGeneralQuestionLevelMasterViewModel
    {

        public GeneralQuestionLevelMasterViewModel()
        {
            GeneralQuestionLevelMasterDTO = new GeneralQuestionLevelMaster();

        }



        public GeneralQuestionLevelMaster GeneralQuestionLevelMasterDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null && GeneralQuestionLevelMasterDTO.ID > 0) ? GeneralQuestionLevelMasterDTO.ID : new Int32();
            }
            set
            {
                GeneralQuestionLevelMasterDTO.ID = value;
            }
        }


        [Required(ErrorMessage = "Level Description should not be blank.")]
        [Display(Name = "Level Description")]
        public string LevelDescription
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.LevelDescription : string.Empty;
            }
            set
            {
                GeneralQuestionLevelMasterDTO.LevelDescription = value;
            }
        }

        [Required(ErrorMessage = "Level Code should not be blank.")]
        [Display(Name = "Level Code")]
        public string LevelCode
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.LevelCode : string.Empty;
            }
            set
            {
                GeneralQuestionLevelMasterDTO.LevelCode = value;
            }
        }
          [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.IsActive : false;
            }
            set
            {
                GeneralQuestionLevelMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralQuestionLevelMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null && GeneralQuestionLevelMasterDTO.CreatedBy > 0) ? GeneralQuestionLevelMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralQuestionLevelMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralQuestionLevelMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralQuestionLevelMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralQuestionLevelMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralQuestionLevelMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralQuestionLevelMasterDTO != null) ? GeneralQuestionLevelMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralQuestionLevelMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

