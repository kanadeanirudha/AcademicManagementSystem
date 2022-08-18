using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryDailySaleReportViewModel
    {
        InventoryDailySaleReport InventoryDailySaleReportDTO { get; set; }
        Int64 ID
        {
            get;
            set;
        }
        string TransactionDate
        {
            get;
            set;
        }
        string BillNumber
        {
            get;
            set;
        }
        decimal BillAmount
        {
            get;
            set;
        }
        decimal RoundUpAmount
        {
            get;
            set;
        }
        string CustomerName
        {
            get;
            set;
        }
        string CustomerType
        {
            get;
            set;
        }
        int BalanceSheetID
        {
            get;
            set;
        }
        int CounterLogId
        {
            get;
            set;
        }
        int LocationID
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        string LocationName
        {
            get;
            set;
        }
        string AccBalsheetHeadDesc
        {
            get;
            set;
        }
        string AccBalsheetCode
        {
            get;
            set;
        }
        string FromDate { get; set; }
        string UptoDate { get; set; }
        bool IsPosted
        {
            get;
            set;
        }
   }
}
