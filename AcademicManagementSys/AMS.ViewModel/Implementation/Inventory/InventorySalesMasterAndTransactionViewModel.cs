using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventorySalesMasterAndTransactionViewModel : IInventorySalesMasterAndTransactionViewModel
    {
        public InventorySalesMasterAndTransactionViewModel()
        {
            InventorySalesMasterAndTransactionDTO = new InventorySalesMasterAndTransaction();
            LocationList = new List<InventoryLocationMaster>();
            InventoryCounterMasterList = new List<InventoryCounterMaster>();
            InventorySalesMasterAndTransactionBillPrintList = new List<InventorySalesMasterAndTransaction>();
            InventoryOperatorSaleReportList = new List<InventorySalesMasterAndTransaction>();
            systemseeting = new List<InventoryInWardMasterAndInWardDetails>();
            PolicyAnswerByPolicyStatus = new List<GeneralPolicyRules>();
        }
        public List<InventoryInWardMasterAndInWardDetails> systemseeting { get; set; }
        public List<GeneralPolicyRules> PolicyAnswerByPolicyStatus { get; set; } 
        public IEnumerable<SelectListItem> InventorySalesMasterAndTransactionBillPrintListItems
        {
            get
            {
                return new SelectList(InventorySalesMasterAndTransactionBillPrintList, "ID", "ItemName");
            }
        }

        public List<InventorySalesMasterAndTransaction> InventorySalesMasterAndTransactionBillPrintList
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> InventoryOperatorSaleReportListItems
        {
            get
            {
                return new SelectList(InventoryOperatorSaleReportList, "ID", "ItemName");
            }
        }

        public List<InventorySalesMasterAndTransaction> InventoryOperatorSaleReportList
        {
            get;
            set;
        }



        public List<InventoryLocationMaster> LocationList { get; set; }
        public List<InventoryCounterMaster> InventoryCounterMasterList { get; set; }
        public IEnumerable<SelectListItem> LocationListItems
        {
            get
            {
                return new SelectList(LocationList, "ID", "LocationName");
            }
        }
        public IEnumerable<SelectListItem> InventoryCounterMasterListItems
        {
            get
            {
                return new SelectList(InventoryCounterMasterList, "CounterIDAndCounterApplicableID", "CounterName");
            }
        }
        public InventorySalesMasterAndTransaction InventorySalesMasterAndTransactionDTO { get; set; }
        //---------------------------------------InventorySalesMaster-----------------------------
        public int ID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.ID > 0) ? InventorySalesMasterAndTransactionDTO.ID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.ID = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.TransactionDate = value;
            }
        }
        public string BillNumber
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.BillNumber : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.BillNumber = value;
            }
        }
        [Display(Name = "DisplayName_BillAmount", ResourceType = typeof(Resources))]
        public decimal BillAmount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.BillAmount > 0) ? InventorySalesMasterAndTransactionDTO.BillAmount : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.BillAmount = value;
            }
        }
        public decimal TotalBillAmount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TotalBillAmount > 0) ? InventorySalesMasterAndTransactionDTO.TotalBillAmount : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.TotalBillAmount = value;
            }
        }
        public decimal NetAmount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.NetAmount > 0) ? InventorySalesMasterAndTransactionDTO.NetAmount : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.NetAmount= value;
            }
        }
        public decimal DiscountInPercentage
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.DiscountInPercentage > 0) ? InventorySalesMasterAndTransactionDTO.DiscountInPercentage : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.DiscountInPercentage = value;
            }
        }
        public decimal TaxInPercentage
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TaxInPercentage > 0) ? InventorySalesMasterAndTransactionDTO.TaxInPercentage : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.TaxInPercentage = value;
            }
        }
        public int TotalItem
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.TotalItem : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.TotalItem = value;
            }
        }
        [Display(Name = "Discount(%)")]
        public decimal Discount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.Discount > 0) ? InventorySalesMasterAndTransactionDTO.Discount : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.Discount = value;
            }
        }

        public decimal TotalDiscount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TotalDiscount > 0) ? InventorySalesMasterAndTransactionDTO.TotalDiscount : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.TotalDiscount = value;
            }
        }
        public decimal DeliveryCharge
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.DeliveryCharge > 0) ? InventorySalesMasterAndTransactionDTO.DeliveryCharge : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.DeliveryCharge = value;
            }
        }
        public decimal TotalTaxAmount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TotalTaxAmount > 0) ? InventorySalesMasterAndTransactionDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.TotalTaxAmount = value;
            }
        }
        public decimal TotalGrossAmount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TotalGrossAmount > 0) ? InventorySalesMasterAndTransactionDTO.TotalGrossAmount : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.TotalGrossAmount = value;
            }
        }
        [Display(Name = "Tax(%)")]
        public decimal Tax
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.Tax > 0) ? InventorySalesMasterAndTransactionDTO.Tax : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.Tax = value;
            }
        }
        [Display(Name = "Batch No.")]
        public string BatchNumber
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.BatchNumber : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.BatchNumber = value;
            }
        }
        public int BatchID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.BatchID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.BatchID = value;
            }
        }
        public decimal BatchQuantity
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.BatchQuantity : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.BatchQuantity = value;
            }
        }
        public string ExpiryDate
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.ExpiryDate : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.ExpiryDate = value;
            }
        } 
        public int GeneralTaxGroupID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.GeneralTaxGroupID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.GeneralTaxGroupID = value;
            }
        }
        public string CustomerName
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CustomerName : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CustomerName = value;
            }
        }

        public int CustomerID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CustomerID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CustomerID = value;
            }
        }
        public string CustomerContactNo
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CustomerContactNo : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CustomerContactNo = value;
            }
        }
        public string CustomerAddress
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CustomerAddress : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CustomerAddress = value;
            }
        }

        public string CustomerType
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CustomerType : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CustomerType = value;
            }
        }

        public int BalanceSheetID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.BalanceSheetID > 0) ? InventorySalesMasterAndTransactionDTO.BalanceSheetID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.BalanceSheetID = value;
            }
        }
        public int CounterLogID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.CounterLogID > 0) ? InventorySalesMasterAndTransactionDTO.CounterLogID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CounterLogID = value;
            }
        }
        public decimal RoundUpAmount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.RoundUpAmount : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.RoundUpAmount = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.IsActive : false;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.CreatedBy > 0) ? InventorySalesMasterAndTransactionDTO.CreatedBy : new short();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.ModifiedBy > 0) ? InventorySalesMasterAndTransactionDTO.ModifiedBy : new short();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.DeletedBy > 0) ? InventorySalesMasterAndTransactionDTO.DeletedBy : new short();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.DeletedDate = value;
            }
        }
        //--------------------------------------InventorySalesTransaction------------------------------
        public int SalesTransactionID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.SalesTransactionID > 0) ? InventorySalesMasterAndTransactionDTO.SalesTransactionID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.SalesTransactionID = value;
            }
        }
        public int SaleMasterID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.SaleMasterID > 0) ? InventorySalesMasterAndTransactionDTO.SaleMasterID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.SaleMasterID = value;
            }
        }
        public int ItemID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.ItemID > 0) ? InventorySalesMasterAndTransactionDTO.ItemID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.ItemID = value;
            }
        }
        [Display(Name = "DisplayName_ItemName", ResourceType = typeof(Resources))]
        public string ItemName
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.ItemName : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.ItemName = value;
            }
        }
        [Display(Name = "DisplayName_Quantity", ResourceType = typeof(Resources))]
        public decimal Quantity
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.Quantity > 0) ? InventorySalesMasterAndTransactionDTO.Quantity : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.Quantity = value;
            }
        }
        [Display(Name = "DisplayName_Rate", ResourceType = typeof(Resources))]
        public decimal Rate
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.Rate > 0) ? InventorySalesMasterAndTransactionDTO.Rate : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.Rate = value;
            }
        }
        public int UnitID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.UnitID > 0) ? InventorySalesMasterAndTransactionDTO.UnitID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.UnitID = value;
            }
        }
        [Display(Name = "DisplayName_UnitCode", ResourceType = typeof(Resources))]
        public string UnitCode
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.UnitCode : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.UnitCode = value;
            }
        }
        public int LocationID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.LocationID > 0) ? InventorySalesMasterAndTransactionDTO.LocationID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.LocationID = value;
            }
        }
        public string Location
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.Location : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.Location = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.errorMessage : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.errorMessage = value;
            }
        }
        public string SelectedBalanceSheet
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.SelectedBalanceSheet : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.SelectedBalanceSheet = value;
            }
        }
        [AllowHtml]
        public string XMLstring
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.XMLstring : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.XMLstring = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CentreCode : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CentreCode = value;
            }
        }
        [Display(Name = "DisplayName_AvailableStock", ResourceType = typeof(Resources))]
        public string AvailableStock
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.AvailableStock : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.AvailableStock = value;
            }
        }
        public int AccountSessionID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.AccountSessionID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.AccountSessionID = value;
            }
        }
        [Display(Name = "Counter Name")]
        public string CounterName
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CounterName : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CounterName = value;
            }
        }
        [Display(Name = "Opening Counter Cash")]
        public string CounterOpeningCash
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CounterOpeningCash : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CounterOpeningCash = value;
            }
        }
        [Display(Name = "Counter Closing Cash")]
        public string CounterClosingCash
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CounterClosingCash : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CounterClosingCash = value;
            }
        }
        public int CounterLoginStatus
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CounterLoginStatus : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CounterLoginStatus = value;
            }
        }
        public int LoginUserCount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.LoginUserCount : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.LoginUserCount = value;
            }
        }
        public int CounterID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.CounterID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.CounterID = value;
            }
        }
        public int InvCounterApplicableDetailsID
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.InvCounterApplicableDetailsID : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.InvCounterApplicableDetailsID = value;
            }
        }
        public string SelectedCounterID
        {
            get;
            set;

        }
        public string EmployeeName
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.EmployeeName : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.EmployeeName = value;
            }
        }
        public bool IsExpiry
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.IsExpiry : false;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.IsExpiry = value;
            }
        }
        public decimal TodaySale
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TodaySale > 0) ? InventorySalesMasterAndTransactionDTO.TodaySale : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.TodaySale = value;
            }
        }
        public decimal LocationWiseSale
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.LocationWiseSale > 0) ? InventorySalesMasterAndTransactionDTO.LocationWiseSale : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.LocationWiseSale = value;
            }
        }
        public int OpenBillCount
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.OpenBillCount > 0) ? InventorySalesMasterAndTransactionDTO.OpenBillCount : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.OpenBillCount = value;
            }
        }
        [Display(Name="Hold Bill Reference")]
        [Required(ErrorMessage="Bill reference required")]
        public string HoldBillReference
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.HoldBillReference : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.HoldBillReference = value;
            }
        }
        
        [Required(ErrorMessage = "Payment amount required")]
        public decimal PaymentByCustomer
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.PaymentByCustomer> 0) ? InventorySalesMasterAndTransactionDTO.PaymentByCustomer: new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.PaymentByCustomer= value;
            }
        }
        public decimal ReturnChange
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.ReturnChange > 0) ? InventorySalesMasterAndTransactionDTO.ReturnChange : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.ReturnChange = value;
            }
        }
        public string FieldName
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.FieldName != "") ? InventorySalesMasterAndTransactionDTO.FieldName : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.FieldName = value;
            }
        }
        public int FieldValue
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.FieldValue > 0) ? InventorySalesMasterAndTransactionDTO.FieldValue : new int();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.FieldValue = value;
            }
        }

        public string PolicyApplicableStatus
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.PolicyApplicableStatus : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.PolicyApplicableStatus = value;
            }

        }
        public string PolicyDefaultAnswer
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.PolicyDefaultAnswer : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.PolicyDefaultAnswer = value;
            }

        }
        public string PolicyCode
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null) ? InventorySalesMasterAndTransactionDTO.PolicyCode : string.Empty;
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.PolicyCode = value;
            }

        }
         [Display(Name = "DisplayName_Rate", ResourceType = typeof(Resources))]
        public decimal RateIncludingtax
        {
            get
            {
                return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.RateIncludingtax > 0) ? InventorySalesMasterAndTransactionDTO.RateIncludingtax : new decimal();
            }
            set
            {
                InventorySalesMasterAndTransactionDTO.RateIncludingtax = value;
            }
        }
         public decimal TodaysTotalSale
         {
             get
             {
                 return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TodaysTotalSale > 0) ? InventorySalesMasterAndTransactionDTO.TodaysTotalSale : new decimal();
             }
             set
             {
                 InventorySalesMasterAndTransactionDTO.TodaysTotalSale = value;
             }
         }
         public decimal TotalSaleReturnAmount
         {
             get
             {
                 return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TotalSaleReturnAmount > 0) ? InventorySalesMasterAndTransactionDTO.TotalSaleReturnAmount : new decimal();
             }
             set
             {
                 InventorySalesMasterAndTransactionDTO.TotalSaleReturnAmount = value;
             }
         }
         public decimal TotalBillAmountIncludeTaxTemplate
         {
             get
             {
                 return (InventorySalesMasterAndTransactionDTO != null && InventorySalesMasterAndTransactionDTO.TotalBillAmountIncludeTaxTemplate > 0) ? InventorySalesMasterAndTransactionDTO.TotalBillAmountIncludeTaxTemplate : new decimal();
             }
             set
             {
                 InventorySalesMasterAndTransactionDTO.TotalBillAmountIncludeTaxTemplate = value;
             }
         }
        
    }

}
