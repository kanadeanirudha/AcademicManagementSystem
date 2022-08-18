using AMS.Common;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class RestaurantSettleAndPrintBillViewModel : IRestaurantSettleAndPrintBillViewModel
    {
        public RestaurantSettleAndPrintBillViewModel()
        {
            RestaurantSettleAndPrintBillDTO = new RestaurantSettleAndPrintBill();
        }
        public RestaurantSettleAndPrintBill RestaurantSettleAndPrintBillDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.ID > 0) ? RestaurantSettleAndPrintBillDTO.ID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.ID = value;
            }
        }
        public int SaleTransactionID
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null) ? RestaurantSettleAndPrintBillDTO.SaleTransactionID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.SaleTransactionID = value;
            }
        }

        public int InventorySaleMasterID

        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.InventorySaleMasterID > 0) ? RestaurantSettleAndPrintBillDTO.InventorySaleMasterID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.InventorySaleMasterID = value;
            }
        }

        public int RestaurantTableOrderID

        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.RestaurantTableOrderID > 0) ? RestaurantSettleAndPrintBillDTO.RestaurantTableOrderID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.RestaurantTableOrderID = value;
            }
        }

        public string GlobalInvoiceNumber
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.GlobalInvoiceNumber != string.Empty) ? RestaurantSettleAndPrintBillDTO.GlobalInvoiceNumber : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.GlobalInvoiceNumber = value;
            }
        }
        public string TableNumber
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.TableNumber != string.Empty) ? RestaurantSettleAndPrintBillDTO.TableNumber : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.TableNumber = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.CentreCode != string.Empty) ? RestaurantSettleAndPrintBillDTO.CentreCode : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.CentreCode = value;
            }
        }
        
        public string TransactionDate
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.TransactionDate != string.Empty) ? RestaurantSettleAndPrintBillDTO.TransactionDate : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.TransactionDate = value;
            }
        }

        public decimal BillAmount
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.BillAmount > 0) ? RestaurantSettleAndPrintBillDTO.BillAmount : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.BillAmount = value;
            }
        }

        public decimal NetAmount
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.NetAmount > 0) ? RestaurantSettleAndPrintBillDTO.NetAmount : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.NetAmount = value;
            }
        }

        public string DeliveryCharge
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.DeliveryCharge != string.Empty) ? RestaurantSettleAndPrintBillDTO.DeliveryCharge : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.DeliveryCharge = value;
            }
        }

        public decimal TotalTaxAmount
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.TotalTaxAmount > 0) ? RestaurantSettleAndPrintBillDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.TotalTaxAmount = value;
            }
        }

        public decimal TotalDiscountAmount
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ? RestaurantSettleAndPrintBillDTO.TotalDiscountAmount : new decimal());
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.TotalDiscountAmount = value;
            }
        }

        public decimal PaymentByCustomer
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ) ? RestaurantSettleAndPrintBillDTO.PaymentByCustomer : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.PaymentByCustomer = value;
            }
        }

        public decimal ReturnChange
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null) ? RestaurantSettleAndPrintBillDTO.ReturnChange : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.ReturnChange = value;
            }
        }

        public string BillNumber
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.BillNumber != string.Empty) ? RestaurantSettleAndPrintBillDTO.BillNumber : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.BillNumber = value;
            }
        }
        
        public int CounterID
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.CounterID > 0) ? RestaurantSettleAndPrintBillDTO.CounterID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.CounterID = value;
            }
        }

        public decimal RoundUpAmount
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.RoundUpAmount > 0) ? RestaurantSettleAndPrintBillDTO.RoundUpAmount : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.RoundUpAmount = value;
            }
        }

        public decimal LocalInvoiceNumber
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.LocalInvoiceNumber > 0) ? RestaurantSettleAndPrintBillDTO.LocalInvoiceNumber : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.LocalInvoiceNumber = value;
            }
        }

        public string Customer
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.Customer != string.Empty) ? RestaurantSettleAndPrintBillDTO.Customer : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.Customer = value;
            }
        }

        public bool PaymentMode
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ) ? RestaurantSettleAndPrintBillDTO.PaymentMode :false;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.PaymentMode = value;
            }
        }

        public string BillRelevantTo
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.BillRelevantTo != string.Empty) ? RestaurantSettleAndPrintBillDTO.BillRelevantTo : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.BillRelevantTo = value;
            }
        }

        public string CustomerCode
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.CustomerCode != string.Empty) ? RestaurantSettleAndPrintBillDTO.CustomerCode : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.CustomerCode = value;
            }
        }

        public int InventoryCounterLogID
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.InventoryCounterLogID > 0) ? RestaurantSettleAndPrintBillDTO.InventoryCounterLogID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.InventoryCounterLogID = value;
            }
        }
        public int SalePromotionActivityDetailsID
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.SalePromotionActivityDetailsID > 0) ? RestaurantSettleAndPrintBillDTO.SalePromotionActivityDetailsID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.SalePromotionActivityDetailsID = value;
            }
        }
        
        public string ItemNumber
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.ItemNumber != string.Empty) ? RestaurantSettleAndPrintBillDTO.ItemNumber : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.ItemNumber = value;
            }
        }

        public string MenuName
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.MenuName != string.Empty) ? RestaurantSettleAndPrintBillDTO.MenuName : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.MenuName = value;
            }
        }

        public int GeneralItemCodeID
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.GeneralItemCodeID > 0) ? RestaurantSettleAndPrintBillDTO.GeneralItemCodeID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.GeneralItemCodeID = value;
            }
        }

        public decimal TaxAmount
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.TaxAmount > 0) ? RestaurantSettleAndPrintBillDTO.TaxAmount : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.TaxAmount = value;
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ? RestaurantSettleAndPrintBillDTO.DiscountAmount : new decimal());
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.DiscountAmount = value;
            }
        }
        public bool IsPaid
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ? RestaurantSettleAndPrintBillDTO.IsPaid : new bool());
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.IsPaid = value;
            }
        }

        public decimal DiscountInPercentage
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ? RestaurantSettleAndPrintBillDTO.DiscountInPercentage : new decimal());
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.DiscountInPercentage = value;
            }
        }

        public string TaxInPercentage
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.TaxInPercentage != string.Empty) ? RestaurantSettleAndPrintBillDTO.TaxInPercentage : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.TaxInPercentage = value;
            }
        }

        public string ItemName
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.ItemName != string.Empty) ? RestaurantSettleAndPrintBillDTO.ItemName : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.ItemName = value;
            }
        }
        public string Quantity
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.Quantity != string.Empty) ? RestaurantSettleAndPrintBillDTO.Quantity : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.Quantity = value;
            }
        }

        public int GenTaxGroupMasterID
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.GenTaxGroupMasterID > 0) ? RestaurantSettleAndPrintBillDTO.GenTaxGroupMasterID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.GenTaxGroupMasterID = value;
            }
        }

        public int VariationMasterId
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.VariationMasterId > 0) ? RestaurantSettleAndPrintBillDTO.VariationMasterId : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.VariationMasterId = value;
            }
        }

        public string Price
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.Price != string.Empty) ? RestaurantSettleAndPrintBillDTO.Price : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.Price = value;
            }
        }

        public string BatchNumber
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.BatchNumber != string.Empty) ? RestaurantSettleAndPrintBillDTO.BatchNumber : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.BatchNumber = value;
            }
        }


        public string ExpiryDate
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.ExpiryDate != string.Empty) ? RestaurantSettleAndPrintBillDTO.ExpiryDate : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.ExpiryDate = value;
            }
        }

        public string UOMCode
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.UOMCode != string.Empty) ? RestaurantSettleAndPrintBillDTO.UOMCode : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.UOMCode = value;
            }
        }

        public decimal ItemAmount
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.ItemAmount > 0) ? RestaurantSettleAndPrintBillDTO.ItemAmount : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.ItemAmount = value;
            }
        }

        public int GeneralUnitsID
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.GeneralUnitsID > 0) ? RestaurantSettleAndPrintBillDTO.GeneralUnitsID : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.GeneralUnitsID = value;
            }
        }
        public byte PaidUnpaidFlag
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null )? RestaurantSettleAndPrintBillDTO.PaidUnpaidFlag : new byte();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.PaidUnpaidFlag = value;
            }
        }
        public decimal DiscountInPercent
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.DiscountInPercent > 0) ? RestaurantSettleAndPrintBillDTO.DiscountInPercent : new decimal();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.DiscountInPercent = value;
            }
        }
        public bool PromotionActivityFlag
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ? RestaurantSettleAndPrintBillDTO.PromotionActivityFlag : new bool());
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.PromotionActivityFlag = value;
            }
        }
        public bool IsRestaurant
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ? RestaurantSettleAndPrintBillDTO.IsRestaurant : new bool());
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.IsRestaurant = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.CreatedBy > 0) ? RestaurantSettleAndPrintBillDTO.CreatedBy : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null) ? RestaurantSettleAndPrintBillDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.CreatedDate = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.ModifiedBy != string.Empty) ? RestaurantSettleAndPrintBillDTO.ModifiedBy : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.ModifiedBy = value;
            }
        }
        public string TransactionNumber
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.TransactionNumber != string.Empty) ? RestaurantSettleAndPrintBillDTO.TransactionNumber : string.Empty;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.TransactionNumber = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null) ? RestaurantSettleAndPrintBillDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null && RestaurantSettleAndPrintBillDTO.DeletedBy > 0) ? RestaurantSettleAndPrintBillDTO.DeletedBy : new int();
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null) ? RestaurantSettleAndPrintBillDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (RestaurantSettleAndPrintBillDTO != null ? RestaurantSettleAndPrintBillDTO.IsDeleted : new bool());
            }
            set
            {
                RestaurantSettleAndPrintBillDTO.IsDeleted = value;
            }
        }

    }
    public class BillDetails
    {
        public BillDetails()
        {
            BillDetailsList = new List<RestaurantSettleAndPrintBill>();
        }
        public int RestaurantTableOrderID { get; set; }
        public string BillNumber { get; set; }
        public string TableNumber { get; set; }
        public int InventorySaleMasterID { get; set; }
        public List<RestaurantSettleAndPrintBill> BillDetailsList { get; set; }
    }
}
