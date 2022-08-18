using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryDailySaleReportViewModel: IInventoryDailySaleReportViewModel
    {
        public InventoryDailySaleReportViewModel()
        {
            InventoryDailySaleReportDTO = new InventoryDailySaleReport();
            ListInventoryDailySaleReport = new List<InventoryDailySaleReport>();
        }

        public InventoryDailySaleReport InventoryDailySaleReportDTO { get; set; }
        public List<InventoryDailySaleReport> ListInventoryDailySaleReport { get; set; }

        //For Html Report Header.
        public List<OrganisationStudyCentreMaster> ListInventoryReportHeader { get; set; }

        public Int64 ID
        {
            get
            {
                return (InventoryDailySaleReportDTO != null && InventoryDailySaleReportDTO.ID > 0) ? InventoryDailySaleReportDTO.ID : new Int64();
            }
            set
            {
                InventoryDailySaleReportDTO.ID = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.TransactionDate = value;
            }
        }
        public string BillNumber
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.BillNumber : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.BillNumber = value;
            }
        }
        public decimal BillAmount
        {
            get
            {
                return (InventoryDailySaleReportDTO != null && InventoryDailySaleReportDTO.BillAmount > 0) ? InventoryDailySaleReportDTO.BillAmount : new decimal();
            }
            set
            {
                InventoryDailySaleReportDTO.BillAmount = value;
            }
        }
        public decimal RoundUpAmount
        {
            get
            {
                return (InventoryDailySaleReportDTO != null && InventoryDailySaleReportDTO.RoundUpAmount > 0) ? InventoryDailySaleReportDTO.RoundUpAmount : new decimal();
            }
            set
            {
                InventoryDailySaleReportDTO.RoundUpAmount = value;
            }
        }
        public string CustomerName
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.CustomerName : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.CustomerName = value;
            }
        }
        public string CustomerType
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.CustomerType : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.CustomerType = value;
            }
        }
        public int BalanceSheetID
        {
            get
            {
                return (InventoryDailySaleReportDTO != null && InventoryDailySaleReportDTO.BalanceSheetID > 0) ? InventoryDailySaleReportDTO.BalanceSheetID : new int();
            }
            set
            {
                InventoryDailySaleReportDTO.BalanceSheetID = value;
            }
        }
        public int CounterLogId
        {
            get
            {
                return (InventoryDailySaleReportDTO != null && InventoryDailySaleReportDTO.CounterLogId > 0) ? InventoryDailySaleReportDTO.CounterLogId : new int();
            }
            set
            {
                InventoryDailySaleReportDTO.CounterLogId = value;
            }
        }
        public int LocationID
        {
            get
            {
                return (InventoryDailySaleReportDTO != null && InventoryDailySaleReportDTO.LocationID > 0) ? InventoryDailySaleReportDTO.LocationID : new int();
            }
            set
            {
                InventoryDailySaleReportDTO.LocationID = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.IsActive : false;
            }
            set
            {
                InventoryDailySaleReportDTO.IsActive = value;
            }
        }
        public string LocationName
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.LocationName : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.LocationName = value;
            }
        }
        public string AccBalsheetHeadDesc
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.AccBalsheetHeadDesc : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.AccBalsheetHeadDesc = value;
            }
        }
        public string AccBalsheetCode
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.AccBalsheetCode : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.AccBalsheetCode = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.FromDate : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.UptoDate : string.Empty;
            }
            set
            {
                InventoryDailySaleReportDTO.UptoDate = value;
            }
        }
        public bool IsPosted
        {
            get
            {
                return (InventoryDailySaleReportDTO != null) ? InventoryDailySaleReportDTO.IsPosted : false;
            }
            set
            {
                InventoryDailySaleReportDTO.IsPosted = value;
            }
        }
    }
}
