
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralPaperSetMasterViewModel : IGeneralPaperSetMasterViewModel
    {

        public GeneralPaperSetMasterViewModel()
        {
            GeneralPaperSetMasterDTO = new GeneralPaperSetMaster();

        }



        public GeneralPaperSetMaster GeneralPaperSetMasterDTO
        {
            get;
            set;
        }

        public Byte ID
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null && GeneralPaperSetMasterDTO.ID > 0) ? GeneralPaperSetMasterDTO.ID : new byte();
            }
            set
            {
                GeneralPaperSetMasterDTO.ID = value;
            }
        }


        [Required(ErrorMessage = "Paper Set Code should not be blank.")]
        [Display(Name = "Paper Set Code")]
        public string PaperSetCode
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null) ? GeneralPaperSetMasterDTO.PaperSetCode : string.Empty;
            }
            set
            {
                GeneralPaperSetMasterDTO.PaperSetCode = value;
            }
        }

        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null) ? GeneralPaperSetMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralPaperSetMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null && GeneralPaperSetMasterDTO.CreatedBy > 0) ? GeneralPaperSetMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPaperSetMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null) ? GeneralPaperSetMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPaperSetMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null) ? GeneralPaperSetMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPaperSetMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null) ? GeneralPaperSetMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPaperSetMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null) ? GeneralPaperSetMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPaperSetMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralPaperSetMasterDTO != null) ? GeneralPaperSetMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPaperSetMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

