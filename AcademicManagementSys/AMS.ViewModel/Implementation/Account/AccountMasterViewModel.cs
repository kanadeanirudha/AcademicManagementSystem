using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{

    public class AccountMasterBaseViewModel : IAccountMasterBaseViewModel
    {
        public AccountMasterBaseViewModel()
        {
            ListAccountGroupMaster = new List<AccountGroupMaster>();
            ListAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
          
        }
       

        public List<AccountGroupMaster> ListAccountGroupMaster
        {
            get;
            set;
        }
        public List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }
        public string SelectedGroupID
        {
            get;
            set;
        }
        public string SelectedBalanceSheet
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListAccountGroupMasterItems
        {
            get
            {
                return new SelectList(ListAccountGroupMaster, "GroupID", "GroupName");
            }
        }
        public IEnumerable<SelectListItem> ListAccountBalancesheetMasterItems
        {
            get
            {
                return new SelectList(ListAccountBalancesheetMaster, "ID", "AccBalsheetHeadDesc");
            }
        }
    }

    public class AccountMasterViewModel: IAccountMasterViewModel
    {
        public AccountMasterViewModel()
        {
            AccountMasterDTO = new AccountMaster();
            UserTypeList = new List<UserMaster>();
        }
        public AccountMaster AccountMasterDTO { get; set; }

        public List<UserMaster> UserTypeList { get; set; }
        public IEnumerable<SelectListItem> UserTypeListItems
        {
            get
            {
                return new SelectList(UserTypeList, "UserType", "UserDescription");
            }
        }

        /// <summary>
        /// properties of AccAccountMaster
        /// </summary>
        public Int16 ID 
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.ID > 0) ? AccountMasterDTO.ID : new Int16();
            }
            set
            {
                AccountMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_AccountCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AccountCodeRequired")]
        public string AccountCode 
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.AccountCode : string.Empty;
            }
            set
            {
                AccountMasterDTO.AccountCode = value;
            }
        }

        [Display(Name = "DisplayName_AccountName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AccountNameRequired")]
        public string AccountName 
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.AccountName : string.Empty;
            }
            set
            {
                AccountMasterDTO.AccountName = value;
            } 
        }

      
        public Int16 GroupID
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.GroupID > 0) ? AccountMasterDTO.GroupID : new Int16();
            }
            set
            {
                AccountMasterDTO.GroupID = value;
            }
        }

        [Display(Name = "DisplayName_DebitCreditFlag", ResourceType = typeof(AMS.Common.Resources))]
        public string DebitCreditFlag
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.DebitCreditFlag :string.Empty;
            }
            set
            {
                AccountMasterDTO.DebitCreditFlag = value;
            }
        }

        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CashBankFlagRequired")]
        public string CashBankFlag
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.CashBankFlag : string.Empty;
            }
            set
            {
                AccountMasterDTO.CashBankFlag = value;
            }
        }

        [Display(Name = "DisplayName_BackDatetimedEntries", ResourceType = typeof(AMS.Common.Resources))]
        public bool BackDatetimedEntries
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.BackDatetimedEntries : false;
            }
            set
            {
                AccountMasterDTO.BackDatetimedEntries = value;
            }
        }
        public Int16 PrintingSequence
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.PrintingSequence > 0) ? AccountMasterDTO.PrintingSequence : new Int16();
            }
            set
            {
                AccountMasterDTO.PrintingSequence = value;
            }
        }
        public string PersonType
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.PersonType : string.Empty;
            }
            set
            {
                AccountMasterDTO.PersonType = value;
            }
        }
        public bool OpBalRequired
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.OpBalRequired : false;
            }
            set
            {
                AccountMasterDTO.OpBalRequired = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.IsActive : false;
            }
            set
            {
                AccountMasterDTO.IsActive = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.CreatedBy > 0) ? AccountMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccountMasterDTO.CreatedBy = value;
            }
        }
        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.CreatedDate : null;
            }
            set
            {
                AccountMasterDTO.CreatedDate = value;
            }
        }
        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.ModifiedBy > 0) ? AccountMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccountMasterDTO.ModifiedBy = value;
            }
        }
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.ModifiedDate : null;
            }
            set
            {
                AccountMasterDTO.ModifiedDate = value;
            }
        }
        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.DeletedBy > 0) ? AccountMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccountMasterDTO.DeletedBy = value;
            }
        }
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.DeletedDate : null;
            }
            set
            {
                AccountMasterDTO.DeletedDate = value;
            }
        }
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.IsDeleted : false;
            }
            set
            {
                AccountMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "DisplayName_ExclusivelyForBalancesheet", ResourceType = typeof(AMS.Common.Resources))]
        public bool ExclusivelyForCentre
        {
            get
            {
                return (AccountMasterDTO != null) ? Convert.ToBoolean(AccountMasterDTO.ExclusivelyForCentre) : false;
            }
            set
            {
                AccountMasterDTO.ExclusivelyForCentre = value;
            }
        }
        public string IgnoreChequeNo
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.IgnoreChequeNo : string.Empty;
            }
            set
            {
                AccountMasterDTO.IgnoreChequeNo = value;
            }
        }
        [Display(Name = "DisplayName_AltGroupID", ResourceType = typeof(AMS.Common.Resources))]
        public Int16 AltGroupID
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.AltGroupID > 0) ? AccountMasterDTO.AltGroupID : new Int16();
            }
            set
            {
                AccountMasterDTO.AltGroupID = value;
            }
        }
        public bool TrialBalSubledger
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.TrialBalSubledger : false;
            }
            set
            {
                AccountMasterDTO.TrialBalSubledger = value;
            }
        }

        [Display(Name = "DisplayName_SurpDifiFlag", ResourceType = typeof(AMS.Common.Resources))]
        public string SurpDifiFlag
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.SurpDifiFlag : string.Empty;
            }
            set
            {
                AccountMasterDTO.SurpDifiFlag = value;
            }
        }
        public string SelectedBalanceSheet
        {
            get;
            set;
        }
        public string SelectedXml
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.SelectedXml : string.Empty;
            }
            set
            {
                AccountMasterDTO.SelectedXml = value;
            }
        }

        public List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }
        public List<AccountMaster> ListAccountMaster
        {
            get;
            set;
        }
        public List<AccountMaster> ListAlternateGroupList
        {
            get;
            set;
        }
        /// <summary>
        /// properties of AccAccountCentrewise
        /// </summary>  
        public Int16 AccAccountCentreID 
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.AccAccountCentreID > 0) ? AccountMasterDTO.AccAccountCentreID : new Int16();
            }
            set
            {
                AccountMasterDTO.AccAccountCentreID = value;
            }
        }
        public Int16 AccBalsheetMstID
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.AccBalsheetMstID > 0) ? AccountMasterDTO.AccBalsheetMstID : new Int16();
            }
            set
            {
                AccountMasterDTO.AccBalsheetMstID = value;
            }
        }

        public int AccCenterwiseID
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.AccCenterwiseID > 0) ? AccountMasterDTO.AccCenterwiseID : new int();
            }
            set
            {
                AccountMasterDTO.AccCenterwiseID = value;
            }
        }
        public int BankDetailsID
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.BankDetailsID > 0) ? AccountMasterDTO.BankDetailsID : new int();
            }
            set
            {
                AccountMasterDTO.BankDetailsID = value;
            }
        }
        public string GroupDescription
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.GroupDescription : string.Empty;
            }
            set
            {
                AccountMasterDTO.GroupDescription = value;
            }
        }


        /// <summary>
        /// properties of AccBankDetails
        /// </summary>
        public Int16 AccBankDetailsID
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.AccBankDetailsID > 0) ? AccountMasterDTO.AccBankDetailsID : new Int16();
            }
            set
            {
                AccountMasterDTO.AccBankDetailsID = value;
            }
        }

        [Display(Name = "DisplayName_BankAccountNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BankAccountNumberRequired")]
        public string BankAccountNumber
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.BankAccountNumber : string.Empty;
            }
            set
            {
                AccountMasterDTO.BankAccountNumber = value;
            }
        }

        [Display(Name = "DisplayName_AccountInNameOf", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AccountInNameOfRequired")]
        public string AccountInNameOf
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.AccountInNameOf : string.Empty;
            }
            set
            {
                AccountMasterDTO.AccountInNameOf = value;
            }
        }

        [Display(Name = "DisplayName_BankBranchName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BankBranchNameRequired")]
        public string BankBranchName
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.BankBranchName : string.Empty;
            }
            set
            {
                AccountMasterDTO.BankBranchName = value;
            }
        }

        [Display(Name = "DisplayName_BankLimitAmount", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BankLimitAmountRequired")]
        public decimal BankLimitAmount
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.BankLimitAmount > 0) ? AccountMasterDTO.BankLimitAmount : new decimal();
            }
            set
            {
                AccountMasterDTO.BankLimitAmount = value;
            }
        }

        [Display(Name = "DisplayName_RateOfInterest", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RateOfInterestRequired")]
        public decimal RateOfInterest
        {
            get
            {
                return (AccountMasterDTO != null && AccountMasterDTO.RateOfInterest > 0) ? AccountMasterDTO.RateOfInterest : new decimal();
            }
            set
            {
                AccountMasterDTO.RateOfInterest = value;
            }
        }

        [Display(Name = "DisplayName_InterestMode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_InterestModeRequired")]
        public string InterestMode
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.InterestMode : string.Empty;
            }
            set
            {
                AccountMasterDTO.InterestMode = value;
            }
        }

        [Display(Name = "DisplayName_InterestType", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_InterestTypeRequired")]
        public string InterestType
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.InterestType : string.Empty;
            }
            set
            {
                AccountMasterDTO.InterestType = value;
            }
        }

        [Display(Name = "DisplayName_OpenDatetime", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OpenDatetimeRequired")]
        public string OpenDatetime
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.OpenDatetime : string.Empty;
            }
            set
            {
                AccountMasterDTO.OpenDatetime = value;
            }
        }

        [Display(Name = "DisplayName_DueDatetime", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DueDatetimeRequired")]
        public string DueDatetime
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.DueDatetime :string.Empty;
            }
            set
            {
                AccountMasterDTO.DueDatetime = value;
            }
        }

        [Display(Name = "DisplayName_AccountType", ResourceType = typeof(AMS.Common.Resources))]
        public string AccountType
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.AccountType : string.Empty;
            }
            set
            {
                AccountMasterDTO.AccountType = value;
            }
        }

        [Display(Name = "DisplayName_ControlHead", ResourceType = typeof(AMS.Common.Resources))]
        public string ControlHead
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.ControlHead : string.Empty;
            }
            set
            {
                AccountMasterDTO.ControlHead = value;
            }
        }

        [Display(Name = "DisplayName_Credit", ResourceType = typeof(AMS.Common.Resources))]
        public string Credit
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.Credit : string.Empty;
            }
            set
            {
                AccountMasterDTO.Credit = value;
            }
        }

        [Display(Name = "DisplayName_Debit", ResourceType = typeof(AMS.Common.Resources))]
        public string Debit
        {
            get
            {
                return (AccountMasterDTO != null) ? AccountMasterDTO.Debit : string.Empty;
            }
            set
            {
                AccountMasterDTO.Debit = value;
            }
        }
    }
}
