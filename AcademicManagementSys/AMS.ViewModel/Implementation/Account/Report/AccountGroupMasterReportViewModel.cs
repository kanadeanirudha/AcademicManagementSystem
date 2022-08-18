﻿using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class AccountGroupMasterReportViewModel : IAccountGroupMasterReportViewModel
    {

        public AccountGroupMasterReportViewModel()
        {
            AccountGroupMasterDTO = new AccountGroupMaster();
            ListAccountHeadMasterReport = new List<AccountHeadMasterReport>();
            ListAccountCategoryMasterReport = new List<AccountCategoryMasterReport>();
            ListAccountGroupMasterReport = new List<AccountGroupMasterReport>();
        }

        [Display(Name = "DisplayName_SelectedHeadID", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedHeadIDRequired")]
        public string SelectedHeadID { get; set; }

        [Display(Name = "DisplayName_SelectedCategoryID", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedCategoryIDRequired")]
        public string SelectedCategoryID { get; set; }

        [Display(Name = "DisplayName_SelectedGroupID", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedGroupIDRequired")]
        public string SelectedGroupID { get; set; }

        public List<AccountHeadMasterReport> ListAccountHeadMasterReport { get; set; }
        public List<AccountCategoryMasterReport> ListAccountCategoryMasterReport { get; set; }
        public List<AccountGroupMasterReport> ListAccountGroupMasterReport { get; set; }


        public IEnumerable<SelectListItem> AccountHeadMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountHeadMasterReport, "ID", "HeadName");
            }
        }

        public IEnumerable<SelectListItem> AccountCategoryMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountCategoryMasterReport, "ID", "CategoryDescription");
            }
        }

        public IEnumerable<SelectListItem> AccountGroupMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountGroupMasterReport, "ID", "GroupDescription");
            }
        }
        public AccountGroupMaster AccountGroupMasterDTO { get; set; }



        public Int16 ID
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.ID > 0) ? AccountGroupMasterDTO.ID : new Int16();
            }
            set
            {
                AccountGroupMasterDTO.ID = value;
            }
        }
          public int AccountBalsheetMstID
        {
            get
            {
                return (AccountGroupMasterDTO != null ) ? AccountGroupMasterDTO.AccountBalsheetMstID : new int();
            }
            set
            {
                AccountGroupMasterDTO.AccountBalsheetMstID = value;
            }
        }
          public bool IsPosted
          {
              get
              {
                  return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.IsPosted : false;
              }
              set
              {
                  AccountGroupMasterDTO.IsPosted = value;
              }
          }
        [Display(Name = "DisplayName_GroupCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GroupCodeRequired")]
        public string GroupCode
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.GroupCode : string.Empty;
            }
            set
            {
                AccountGroupMasterDTO.GroupCode = value;
            }
        }

        [Display(Name = "DisplayName_GroupDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GroupDescriptionRequired")]
        public string GroupDescription
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.GroupDescription : string.Empty;
            }
            set
            {
                AccountGroupMasterDTO.GroupDescription = value;
            }
        }

        public string GroupDescriptionCategory
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.GroupDescriptionCategory : string.Empty;
            }
            set
            {
                AccountGroupMasterDTO.GroupDescriptionCategory = value;
            }
        }

        [Display(Name = "DisplayName_CategoryID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryIDRequired")]
        public Nullable<Int16> CategoryID
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.CategoryID > 0) ? AccountGroupMasterDTO.CategoryID : new Int16();
            }
            set
            {
                AccountGroupMasterDTO.CategoryID = value;
            }
        }

        public string BackDatedEntriesFlag
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.BackDatedEntriesFlag : string.Empty;
            }
            set
            {
                AccountGroupMasterDTO.BackDatedEntriesFlag = value;
            }
        }

        [Display(Name = "DisplayName_PrintingSequence", ResourceType = typeof(AMS.Common.Resources))]
        public Nullable<Int16> PrintingSequence
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.PrintingSequence > 0) ? AccountGroupMasterDTO.PrintingSequence : new Int16();
            }
            set
            {
                AccountGroupMasterDTO.PrintingSequence = value;
            }
        }

        public Nullable<bool> IsActive
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.IsActive : false;
            }
            set
            {
                AccountGroupMasterDTO.IsActive = value;
            }
        }

        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.CreatedBy > 0) ? AccountGroupMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccountGroupMasterDTO.CreatedBy = value;
            }
        }


        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.CreatedDate : null;
            }
            set
            {
                AccountGroupMasterDTO.CreatedDate = value;
            }
        }


        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.ModifiedBy > 0) ? AccountGroupMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccountGroupMasterDTO.ModifiedBy = value;
            }
        }


        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.ModifiedDate : null;
            }
            set
            {
                AccountGroupMasterDTO.ModifiedDate = value;
            }
        }

        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.DeletedBy > 0) ? AccountGroupMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccountGroupMasterDTO.DeletedBy = value;
            }
        }


        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.DeletedDate : null;
            }
            set
            {
                AccountGroupMasterDTO.DeletedDate = value;
            }
        }

        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.IsDeleted : false;
            }
            set
            {
                AccountGroupMasterDTO.IsDeleted = value;
            }
        }
       



    }
}
