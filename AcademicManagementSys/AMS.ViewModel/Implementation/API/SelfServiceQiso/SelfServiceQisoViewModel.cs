using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class SelfServiceQisoViewModel : ISelfServiceQisoViewModel
    {
        public SelfServiceQisoViewModel()
        {
            SelfServiceQisoDTO = new SelfServiceQiso();
        }
        public SelfServiceQiso SelfServiceQisoDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.ID > 0) ? SelfServiceQisoDTO.ID : new int();
            }
            set
            {
                SelfServiceQisoDTO.ID = value;
            }
        }

        public string TransacationDate
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TransacationDate != string.Empty) ? SelfServiceQisoDTO.TransacationDate : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.TransacationDate = value;
            }
        }

        public string TransactionUpToDate
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TransactionUpToDate != string.Empty) ? SelfServiceQisoDTO.TransactionUpToDate : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.TransactionUpToDate = value;
            }
        }

        public string TableNumber
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TableNumber != string.Empty) ? SelfServiceQisoDTO.TableNumber : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.TableNumber = value;
            }
        }

        public string TableVariant
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TableVariant != string.Empty) ? SelfServiceQisoDTO.TableVariant : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.TableVariant = value;
            }
        }

        public string TotalMembers
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TotalMembers != string.Empty) ? SelfServiceQisoDTO.TotalMembers : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.TotalMembers = value;
            }
        }

        public int OrderByID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.OrderByID > 0) ? SelfServiceQisoDTO.OrderByID : new int();
            }
            set
            {
                SelfServiceQisoDTO.OrderByID = value;
            }
        }

        public string OrderStatus
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.OrderStatus != string.Empty) ? SelfServiceQisoDTO.OrderStatus : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.OrderStatus = value;
            }
        }

        public string KOTStatus
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.KOTStatus != string.Empty) ? SelfServiceQisoDTO.KOTStatus : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.KOTStatus = value;
            }
        }

        public int BillPaidStatus
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.BillPaidStatus > 0) ? SelfServiceQisoDTO.BillPaidStatus : new int();
            }
            set
            {
                SelfServiceQisoDTO.BillPaidStatus = value;
            }
        }

        public string TotalBillAmt
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TotalBillAmt != string.Empty) ? SelfServiceQisoDTO.TotalBillAmt : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.TotalBillAmt = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.CentreCode != string.Empty) ? SelfServiceQisoDTO.CentreCode : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.CentreCode = value;
            }
        }

        public int GeneralUnitsId
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.GeneralUnitsId > 0) ? SelfServiceQisoDTO.GeneralUnitsId : new int();
            }
            set
            {
                SelfServiceQisoDTO.GeneralUnitsId = value;
            }
        }
        public short IsRelatedWithCafe
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.IsRelatedWithCafe > 0) ? SelfServiceQisoDTO.IsRelatedWithCafe : new short();
            }
            set
            {
                SelfServiceQisoDTO.IsRelatedWithCafe = value;
            }
        }
        public string PaidBillNumber
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.PaidBillNumber != string.Empty) ? SelfServiceQisoDTO.PaidBillNumber : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.PaidBillNumber = value;
            }
        }

        public int RestaurantTableOrdersID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.RestaurantTableOrdersID > 0) ? SelfServiceQisoDTO.RestaurantTableOrdersID : new int();
            }
            set
            {
                SelfServiceQisoDTO.RestaurantTableOrdersID = value;
            }
        }

        public string OrderDateTime
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.OrderDateTime != string.Empty) ? SelfServiceQisoDTO.OrderDateTime : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.OrderDateTime = value;
            }
        }

        public string ExpectedTimeGivenForOrder
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.ExpectedTimeGivenForOrder != string.Empty) ? SelfServiceQisoDTO.ExpectedTimeGivenForOrder : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.ExpectedTimeGivenForOrder = value;
            }
        }

        public string KOTNumbe
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.KOTNumbe != string.Empty) ? SelfServiceQisoDTO.KOTNumbe : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.KOTNumbe = value;
            }
        }

        public string OrderReceiveDateTime
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.OrderReceiveDateTime != string.Empty) ? SelfServiceQisoDTO.OrderReceiveDateTime : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.OrderReceiveDateTime = value;
            }
        }

        public bool IsOrderPostedInBill
        {
            get
            {
                return (SelfServiceQisoDTO != null ? SelfServiceQisoDTO.IsOrderPostedInBill : new bool());
            }
            set
            {
                SelfServiceQisoDTO.IsOrderPostedInBill = value;
            }
        }

        public int RestaurantTableOrdersDetailID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.RestaurantTableOrdersDetailID > 0) ? SelfServiceQisoDTO.RestaurantTableOrdersDetailID : new int();
            }
            set
            {
                SelfServiceQisoDTO.RestaurantTableOrdersDetailID = value;
            }
        }


        public int ItemID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.ItemID > 0) ? SelfServiceQisoDTO.ItemID : new int();
            }
            set
            {
                SelfServiceQisoDTO.ItemID = value;
            }
        }

        public string Qty
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.Qty != string.Empty) ? SelfServiceQisoDTO.Qty : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.Qty = value;
            }
        }

        public string OrderXML
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.OrderXML != string.Empty) ? SelfServiceQisoDTO.OrderXML : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.OrderXML = value;
            }
        }
        public int GeneralItemMasterID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.GeneralItemMasterID > 0) ? SelfServiceQisoDTO.GeneralItemMasterID : new int();
            }
            set
            {
                SelfServiceQisoDTO.GeneralItemMasterID = value;
            }
        }

        public string UomCode
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.UomCode != string.Empty) ? SelfServiceQisoDTO.UomCode : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.UomCode = value;
            }
        }

        public string IsBOMRelevant
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.IsBOMRelevant != string.Empty) ? SelfServiceQisoDTO.IsBOMRelevant : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.IsBOMRelevant = value;
            }
        }

        public int InventoryVariationMasterID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.InventoryVariationMasterID > 0) ? SelfServiceQisoDTO.InventoryVariationMasterID : new int();
            }
            set
            {
                SelfServiceQisoDTO.InventoryVariationMasterID = value;
            }
        }

        public int Price
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.Price > 0) ? SelfServiceQisoDTO.Price : new int();
            }
            set
            {
                SelfServiceQisoDTO.Price = value;
            }
        }

        public int InventoryLocationMasterID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.InventoryLocationMasterID > 0) ? SelfServiceQisoDTO.InventoryLocationMasterID : new int();
            }
            set
            {
                SelfServiceQisoDTO.InventoryLocationMasterID = value;
            }
        }
        public string MenuName
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.MenuName != string.Empty) ? SelfServiceQisoDTO.MenuName : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.MenuName = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.CreatedBy != string.Empty) ? SelfServiceQisoDTO.CreatedBy : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.CreatedBy = value;
            }
        }

        public string CreatedDate
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.CreatedDate != string.Empty) ? SelfServiceQisoDTO.CreatedDate : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.CreatedDate = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.ModifiedBy != string.Empty) ? SelfServiceQisoDTO.ModifiedBy : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.ModifiedBy = value;
            }
        }

        public string ModifiedDate
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.ModifiedDate != string.Empty) ? SelfServiceQisoDTO.ModifiedDate : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.ModifiedDate = value;
            }
        }

        public string DeletedBy
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.DeletedBy != string.Empty) ? SelfServiceQisoDTO.DeletedBy : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.DeletedBy = value;
            }
        }

        public string DeletedDate
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.DeletedDate != string.Empty) ? SelfServiceQisoDTO.DeletedDate : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (SelfServiceQisoDTO != null ? SelfServiceQisoDTO.IsDeleted : new bool());
            }
            set
            {
                SelfServiceQisoDTO.IsDeleted = value;
            }
        }

        public short IsOrderServed
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.IsOrderServed > 0) ? SelfServiceQisoDTO.IsOrderServed : new short();
            }
            set
            {
                SelfServiceQisoDTO.IsOrderServed = value;
            }
        }

        public string PaymentReferenceCode
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.PaymentReferenceCode != string.Empty) ? SelfServiceQisoDTO.PaymentReferenceCode : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.PaymentReferenceCode = value;
            }
        }
        public bool IsTakeAway
        {
            get
            {
                return (SelfServiceQisoDTO != null ? SelfServiceQisoDTO.IsTakeAway : new bool());
            }
            set
            {
                SelfServiceQisoDTO.IsTakeAway = value;
            }
        }
        public int InventorySaleMasterID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.InventorySaleMasterID > 0) ? SelfServiceQisoDTO.InventorySaleMasterID : new int();
            }
            set
            {
                SelfServiceQisoDTO.InventorySaleMasterID = value;
            }
        }
        public bool IsBillPaid
        {
            get
            {
                return (SelfServiceQisoDTO != null ? SelfServiceQisoDTO.IsBillPaid : new bool());
            }
            set
            {
                SelfServiceQisoDTO.IsBillPaid = value;
            }
        }
        
        public int RestaurantTableOrderID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.RestaurantTableOrderID > 0) ? SelfServiceQisoDTO.RestaurantTableOrderID : new int();
            }
            set
            {
                SelfServiceQisoDTO.RestaurantTableOrderID = value;
            }
        }

        public string GlobalInvoiceNumber
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.GlobalInvoiceNumber != string.Empty) ? SelfServiceQisoDTO.GlobalInvoiceNumber : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.GlobalInvoiceNumber = value;
            }
        }

        public string TransactionDate
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TransactionDate != string.Empty) ? SelfServiceQisoDTO.TransactionDate : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.TransactionDate = value;
            }
        }

        public decimal BillAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.BillAmount > 0) ? SelfServiceQisoDTO.BillAmount : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.BillAmount = value;
            }
        }
        public decimal TotalBillAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.BillAmount > 0) ? SelfServiceQisoDTO.TotalBillAmount : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.TotalBillAmount = value;
            }
        }
        public decimal NetAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.NetAmount > 0) ? SelfServiceQisoDTO.NetAmount : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.NetAmount = value;
            }
        }

        public string DeliveryCharge
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.DeliveryCharge != string.Empty) ? SelfServiceQisoDTO.DeliveryCharge : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.DeliveryCharge = value;
            }
        }

        public decimal TotalTaxAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TotalTaxAmount > 0) ? SelfServiceQisoDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.TotalTaxAmount = value;
            }
        }

        public decimal TotalDiscountAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null ? SelfServiceQisoDTO.TotalDiscountAmount : new decimal());
            }
            set
            {
                SelfServiceQisoDTO.TotalDiscountAmount = value;
            }
        }

        public decimal PaymentByCustomer
        {
            get
            {
                return (SelfServiceQisoDTO != null) ? SelfServiceQisoDTO.PaymentByCustomer : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.PaymentByCustomer = value;
            }
        }

        public decimal ReturnChange
        {
            get
            {
                return (SelfServiceQisoDTO != null) ? SelfServiceQisoDTO.ReturnChange : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.ReturnChange = value;
            }
        }

        public string BillNumber
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.BillNumber != string.Empty) ? SelfServiceQisoDTO.BillNumber : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.BillNumber = value;
            }
        }

        public int CounterID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.CounterID > 0) ? SelfServiceQisoDTO.CounterID : new int();
            }
            set
            {
                SelfServiceQisoDTO.CounterID = value;
            }
        }

        public decimal RoundUpAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.RoundUpAmount > 0) ? SelfServiceQisoDTO.RoundUpAmount : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.RoundUpAmount = value;
            }
        }

        public string Customer
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.Customer != string.Empty) ? SelfServiceQisoDTO.Customer : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.Customer = value;
            }
        }

        public bool PaymentMode
        {
            get
            {
                return (SelfServiceQisoDTO != null) ? SelfServiceQisoDTO.PaymentMode : false;
            }
            set
            {
                SelfServiceQisoDTO.PaymentMode = value;
            }
        }

        public bool IsAvailableForPOS
        {
            get
            {
                return (SelfServiceQisoDTO != null) ? SelfServiceQisoDTO.IsAvailableForPOS : false;
            }
            set
            {
                SelfServiceQisoDTO.IsAvailableForPOS = value;
            }
        }

        public string BillRelevantTo
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.BillRelevantTo != string.Empty) ? SelfServiceQisoDTO.BillRelevantTo : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.BillRelevantTo = value;
            }
        }

        public string CustomerCode
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.CustomerCode != string.Empty) ? SelfServiceQisoDTO.CustomerCode : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.CustomerCode = value;
            }
        }

        public int InventoryCounterLogID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.InventoryCounterLogID > 0) ? SelfServiceQisoDTO.InventoryCounterLogID : new int();
            }
            set
            {
                SelfServiceQisoDTO.InventoryCounterLogID = value;
            }
        }

        public string ItemNumber
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.ItemNumber != string.Empty) ? SelfServiceQisoDTO.ItemNumber : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.ItemNumber = value;
            }
        }


        public int GeneralItemCodeID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.GeneralItemCodeID > 0) ? SelfServiceQisoDTO.GeneralItemCodeID : new int();
            }
            set
            {
                SelfServiceQisoDTO.GeneralItemCodeID = value;
            }
        }

        public decimal TaxAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TaxAmount > 0) ? SelfServiceQisoDTO.TaxAmount : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.TaxAmount = value;
            }
        }

        public bool DiscountAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null ? SelfServiceQisoDTO.DiscountAmount : new bool());
            }
            set
            {
                SelfServiceQisoDTO.DiscountAmount = value;
            }
        }

        public bool DiscountInPercentage
        {
            get
            {
                return (SelfServiceQisoDTO != null ? SelfServiceQisoDTO.DiscountInPercentage : new bool());
            }
            set
            {
                SelfServiceQisoDTO.DiscountInPercentage = value;
            }
        }

        public string TaxInPercentage
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.TaxInPercentage != string.Empty) ? SelfServiceQisoDTO.TaxInPercentage : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.TaxInPercentage = value;
            }
        }

        public string Quantity
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.Quantity != string.Empty) ? SelfServiceQisoDTO.Quantity : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.Quantity = value;
            }
        }

        public int GenTaxGroupMasterID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.GenTaxGroupMasterID > 0) ? SelfServiceQisoDTO.GenTaxGroupMasterID : new int();
            }
            set
            {
                SelfServiceQisoDTO.GenTaxGroupMasterID = value;
            }
        }
        
        public string BatchNumber
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.BatchNumber != string.Empty) ? SelfServiceQisoDTO.BatchNumber : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.BatchNumber = value;
            }
        }

        public string ExpiryDate
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.ExpiryDate != string.Empty) ? SelfServiceQisoDTO.ExpiryDate : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.ExpiryDate = value;
            }
        }

        public string UOMCode
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.UOMCode != string.Empty) ? SelfServiceQisoDTO.UOMCode : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.UOMCode = value;
            }
        }

        public decimal ItemAmount
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.ItemAmount > 0) ? SelfServiceQisoDTO.ItemAmount : new decimal();
            }
            set
            {
                SelfServiceQisoDTO.ItemAmount = value;
            }
        }

        public int GeneralUnitsID
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.GeneralUnitsID > 0) ? SelfServiceQisoDTO.GeneralUnitsID : new int();
            }
            set
            {
                SelfServiceQisoDTO.GeneralUnitsID = value;
            }
        }

        public string SaleTransactionXML
        {
            get
            {
                return (SelfServiceQisoDTO != null && SelfServiceQisoDTO.SaleTransactionXML != string.Empty) ? SelfServiceQisoDTO.SaleTransactionXML : string.Empty;
            }
            set
            {
                SelfServiceQisoDTO.SaleTransactionXML = value;
            }
        }
    }
}
