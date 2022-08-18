using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class FeeAccountTypeMasterViewModel : IFeeAccountTypeMasterViewModel
    {

        public FeeAccountTypeMasterViewModel()
        {
            FeeAccountTypeMasterDTO = new FeeAccountTypeMaster();

        }



        public FeeAccountTypeMaster FeeAccountTypeMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null && FeeAccountTypeMasterDTO.ID > 0) ? FeeAccountTypeMasterDTO.ID : new Int16();
            }
            set
            {
                FeeAccountTypeMasterDTO.ID = value;
            }
        }


        [Required(ErrorMessage = "Fee Account Type Description should not be blank.")]
        [Display(Name = "Fee Account Type Description")]
        public string FeeAccountTypeDesc
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null) ? FeeAccountTypeMasterDTO.FeeAccountTypeDesc : string.Empty;
            }
            set
            {
                FeeAccountTypeMasterDTO.FeeAccountTypeDesc = value;
            }
        }

        [Required(ErrorMessage = "Fee Account Type Code should not be blank.")]
        [Display(Name = "Fee Account Type Code")]
        public byte FeeAccountTypeCode
        {
           get
            {
                return (FeeAccountTypeMasterDTO != null) ? FeeAccountTypeMasterDTO.FeeAccountTypeCode : new byte();
            }
            set
            {
                FeeAccountTypeMasterDTO.FeeAccountTypeCode = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null) ? FeeAccountTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                FeeAccountTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null && FeeAccountTypeMasterDTO.CreatedBy > 0) ? FeeAccountTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                FeeAccountTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null) ? FeeAccountTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeAccountTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null) ? FeeAccountTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                FeeAccountTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null) ? FeeAccountTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeAccountTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null) ? FeeAccountTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                FeeAccountTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (FeeAccountTypeMasterDTO != null) ? FeeAccountTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeAccountTypeMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        

    }
}

