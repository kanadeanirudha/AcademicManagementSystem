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
    public class ScholarShipMasterViewModel : IScholarShipMasterViewModel
    {
        public ScholarShipMasterViewModel()
        {
            ScholarShipMasterDTO = new ScholarShipMaster();
            AccountMasterList = new List<AccountMaster>();
            AccountTypeList = new List<ScholarShipMaster>();
        }
        public List<AccountMaster> AccountMasterList { get; set; }
        public List<ScholarShipMaster> AccountTypeList { get; set; }
        public IEnumerable<SelectListItem> AccountTypeListItems
        {
            get
            {
                return new SelectList(AccountTypeList, "FeeAccountTypeCode", "FeeAccountTypeDesc");
            }
        }
        public IEnumerable<SelectListItem> AccountMasterListItems
        {
            get
            {
                return new SelectList(AccountMasterList, "ID", "AccountName");
            }
        }
        public ScholarShipMaster ScholarShipMasterDTO { get; set; }

        public int ID
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.ID > 0) ? ScholarShipMasterDTO.ID : new int();
            }
            set
            {
                ScholarShipMasterDTO.ID = value;
            }
        }
        [Display(Name = "ScholarShip Description")]
        [Required(ErrorMessage= "ScholarShip Description should not be blank")]
        public string ScholarShipDescription
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.ScholarShipDescription : string.Empty;
            }
            set
            {
                ScholarShipMasterDTO.ScholarShipDescription = value;
            }
        }

        [Display(Name = "ScholarShip Type")]
        [Required(ErrorMessage = "ScholarShip Type must be selected")]
        public string ScholarShipType
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.ScholarShipType : string.Empty;
            }
            set
            {
                ScholarShipMasterDTO.ScholarShipType = value;
            }
        }
          [Display(Name = "Implementation Type")]
          [Required(ErrorMessage = "Implementation Type must be selected")]
        public string ScholarShipImplementType
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.ScholarShipImplementType : string.Empty;
            }
            set
            {
                ScholarShipMasterDTO.ScholarShipImplementType = value;
            }
        }
          [Display(Name = "Is Amount Fixed ?")]
        public bool IsCalulatedAmountFix
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.IsCalulatedAmountFix : false;
            }
            set
            {
                ScholarShipMasterDTO.IsCalulatedAmountFix = value;
            }
        }
        [Display(Name = "Fix Amount")]
        public decimal FixAmount
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.FixAmount > 0) ? ScholarShipMasterDTO.FixAmount : new decimal();
            }
            set
            {
                ScholarShipMasterDTO.FixAmount = value;
            }
        }
        [Display(Name = "Percentage")]
        public decimal Percentage
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.Percentage > 0) ? ScholarShipMasterDTO.Percentage : new decimal();
            }
            set
            {
                ScholarShipMasterDTO.Percentage = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.IsActive : false;
            }
            set
            {
                ScholarShipMasterDTO.IsActive = value;
            }
        }
        
        public int CreatedBy
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.CreatedBy > 0) ? ScholarShipMasterDTO.CreatedBy : new int();
            }
            set
            {
                ScholarShipMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ScholarShipMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.ModifiedBy > 0) ? ScholarShipMasterDTO.ModifiedBy : new int();
            }
            set
            {
                ScholarShipMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ScholarShipMasterDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.IsDeleted : false;
            }
            set
            {
                ScholarShipMasterDTO.IsDeleted = value;
            }
        }
        public string errorMessage { get; set; }

        //---------------------FeeAccountTypeMaster

        public string FeeAccountTypeDesc
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.FeeAccountTypeDesc : string.Empty;
            }
            set
            {
                ScholarShipMasterDTO.FeeAccountTypeDesc = value;
            }
        }
        public Int16 FeeAccountTypeCode
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.FeeAccountTypeCode > 0) ? ScholarShipMasterDTO.FeeAccountTypeCode : new Int16();
            }
            set
            {
                ScholarShipMasterDTO.FeeAccountTypeCode = value;
            }
        }
        public int ScholarShipMasterID
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.ScholarShipMasterID > 0) ? ScholarShipMasterDTO.ScholarShipMasterID : new int();
            }
            set
            {
                ScholarShipMasterDTO.ScholarShipMasterID = value;
            }
        }

        //--------------------FeeAccountSubTypeMaster


        public int FeeAccountTypeMasterID
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.FeeAccountTypeMasterID > 0) ? ScholarShipMasterDTO.FeeAccountTypeMasterID : new int();
            }
            set
            {
                ScholarShipMasterDTO.FeeAccountTypeMasterID = value;
            }
        }
        public int FeeAccountTypeMasterIDForStudentReceivable
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.FeeAccountTypeMasterIDForStudentReceivable > 0) ? ScholarShipMasterDTO.FeeAccountTypeMasterIDForStudentReceivable : new int();
            }
            set
            {
                ScholarShipMasterDTO.FeeAccountTypeMasterIDForStudentReceivable = value;
            }
        }
        [Display(Name = "Account Type Description")]
        [Required(ErrorMessage = "Account Type Description should not be blank")]
        public string FeeAccountSubTypeDesc
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.FeeAccountSubTypeDesc : string.Empty;
            }
            set
            {
                ScholarShipMasterDTO.FeeAccountSubTypeDesc = value;
            }
        }
        [Display(Name = "Account Type Code")]
        [Required(ErrorMessage = "Account Type Code should not be blank")]
        public string FeeAccountSubTypeCode
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.FeeAccountSubTypeCode : string.Empty;
            }
            set
            {
                ScholarShipMasterDTO.FeeAccountSubTypeCode = value;
            }
        }
        [Display(Name = "Account")]
        public Int16 AccountID
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.AccountID > 0) ? ScholarShipMasterDTO.AccountID : new Int16();
            }
            set
            {
                ScholarShipMasterDTO.AccountID = value;
            }
        }
        [Display(Name="Account")]
        public Int16 AccountIDForStudentReceivable
        {
            get
            {
                return (ScholarShipMasterDTO != null && ScholarShipMasterDTO.AccountID > 0) ? ScholarShipMasterDTO.AccountIDForStudentReceivable : new Int16();
            }
            set
            {
                ScholarShipMasterDTO.AccountIDForStudentReceivable = value;
            }
        }

        [Display(Name = "Account Type Description")]
        [Required(ErrorMessage = "Account Type Description should not be blank")]
        public string FeeAccountSubTypeDescForStudentReceivable
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.FeeAccountSubTypeDescForStudentReceivable : string.Empty;
            }
            set
            {
                ScholarShipMasterDTO.FeeAccountSubTypeDescForStudentReceivable = value;
            }
        }
        [Display(Name = "Account Type Code")]
        [Required(ErrorMessage = "Account Type Code should not be blank")]
        public string FeeAccountSubTypeCodeForStudentReceivable
        {
            get
            {
                return (ScholarShipMasterDTO != null) ? ScholarShipMasterDTO.FeeAccountSubTypeCodeForStudentReceivable : string.Empty;
            }
            set
            {
                ScholarShipMasterDTO.FeeAccountSubTypeCodeForStudentReceivable = value;
            }
        }
    
    }

}
