﻿using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IAccountTransactionMasterViewModel
    {
         AccountTransactionMaster AccountTransactionMasterDTO
        {
            get;
            set;
        }

        /// <summary>
        /// Properties for table AccTransactionMaster
        /// </summary>

         Int64 ID { get; set; }
         char TransactionType { get; set; }
         string TransactionDate { get; set; }
         string NarrationDescription { get; set; }
         string ModeCode { get; set; }
         Int16 AccSessionID { get; set; }
         Int64 VoucherNumber { get; set; }
         Int16 AccBalsheetMstID { get; set; }
         string AccBalsheetName { get; set; }
         Int16 IsPosted { get; set; }
         int PostedBy { get; set; }
         string PostedDate { get; set; }
         bool IsActive { get; set; }
         int CreatedBy { get; set; }
         DateTime CreatedDate { get; set; }
         int ModifiedBy { get; set; }
         DateTime ModifiedDate { get; set; }
         int DeletedBy { get; set; }
         DateTime DeletedDate { get; set; }
         bool IsDeleted { get; set; }

         string SelectedXmlData { get; set; }

        /// <summary>
        /// Properties for table AccTransactionDetails
        /// </summary>

         Int64 AccTransDetailsID { get; set; }
         Int64 TransactionMainID { get; set; }
         Int16 AccountID { get; set; }
         string AccountName { get; set; }
         decimal TransactionAmount { get; set; }
         string DebitCreditFlag { get; set; }
         string ChequeNo { get; set; }
         string ChequeDatetime { get; set; }
        // string NarrationDescription { get; set; }
         string BankName { get; set; }
         string BranchName { get; set; }
         string BankClearingDatetime { get; set; }
         int PersonID { get; set; }
        // string ModeCode { get; set; }
         string PersonType { get; set; }
        // int AccSessionID { get; set; }
        // int VoucherNumber { get; set; }
         string SubmitSlipNo { get; set; }
         string SubmitDatetime { get; set; }
         string ReconcilationDatetime { get; set; }
        // int AccBalsheetMstID { get; set; }
         string BankTransferFlag { get; set; }
         string ChqDepositSlipNo { get; set; }
         string ChqDepositDatetime { get; set; }


        /// <summary>
        /// Properties for AccTransactionTypeMaster
        /// </summary>

         int AccTransTypeID { get; set; }
         string TransactionTypeCode { get; set; }
         string TransactionTypeName { get; set; }
    }

    public  interface IAccountTransactionMasterBaseViewModel
    {
         List<AccountTransactionTypeMaster> ListAccountTransactionTypeMaster
        {
            get;
            set;
        }
    }

}
