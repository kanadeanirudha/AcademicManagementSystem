using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class PurchaseGRNViewModel : IPurchaseGRNViewModel
    {
        public PurchaseGRNViewModel()
        {
            PurchaseGRNDTO = new PurchaseGRN();
        }
        public PurchaseGRN PurchaseGRNDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.ID > 0) ? PurchaseGRNDTO.ID : new int();
            }
            set
            {
                PurchaseGRNDTO.ID = value;
            }
        }
        public int PurchaseOrderMasterID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.PurchaseOrderMasterID > 0) ? PurchaseGRNDTO.PurchaseOrderMasterID : new int();
            }
            set
            {
                PurchaseGRNDTO.PurchaseOrderMasterID = value;
            }
        }
        public int PurchaseOrderDetailID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.PurchaseOrderDetailID > 0) ? PurchaseGRNDTO.PurchaseOrderDetailID : new int();
            }
            set
            {
                PurchaseGRNDTO.PurchaseOrderDetailID = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.ItemNumber > 0) ? PurchaseGRNDTO.ItemNumber : new int();
            }
            set
            {
                PurchaseGRNDTO.ItemNumber = value;
            }
        }
        public string GRNNumber
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.GRNNumber : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.GRNNumber = value;
            }
        }
        public int PurchaseGRNMasterID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.PurchaseGRNMasterID > 0) ? PurchaseGRNDTO.PurchaseGRNMasterID : new int();
            }
            set
            {
                PurchaseGRNDTO.PurchaseGRNMasterID = value;
            }
        }
        public int PurchaseGRNDetailsID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.PurchaseGRNDetailsID > 0) ? PurchaseGRNDTO.PurchaseGRNDetailsID : new int();
            }
            set
            {
                PurchaseGRNDTO.PurchaseGRNDetailsID = value;
            }
        }
        public string GRNTransDate
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.GRNTransDate : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.GRNTransDate = value;
            }
        }
        public bool IsLocked
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.IsLocked : false;
            }
            set
            {
                PurchaseGRNDTO.IsLocked = value;
            }
        }
      
        public int CreatedBy
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.CreatedBy > 0) ? PurchaseGRNDTO.CreatedBy : new short();
            }
            set
            {
                PurchaseGRNDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseGRNDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.ModifiedBy > 0) ? PurchaseGRNDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseGRNDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseGRNDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.IsDeleted : false;
            }
            set
            {
                PurchaseGRNDTO.IsDeleted = value;
            }
        }
        //public string errorMessage { get; set; }

        public string PurchaseOrderNumber
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.PurchaseOrderNumber : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.PurchaseOrderNumber = value;
            }
        }
        public string PurchaseOrderDate
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.PurchaseOrderDate : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.PurchaseOrderDate = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.Quantity > 0) ? PurchaseGRNDTO.Quantity : new decimal();
            }
            set
            {
                PurchaseGRNDTO.Quantity = value;
            }
        }
        public decimal ReceivedQuantity
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.ReceivedQuantity > 0) ? PurchaseGRNDTO.ReceivedQuantity : new decimal();
            }
            set
            {
                PurchaseGRNDTO.ReceivedQuantity = value;
            }
        }
        public decimal ReceivedQuantityPerItem
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.ReceivedQuantityPerItem > 0) ? PurchaseGRNDTO.ReceivedQuantityPerItem : new decimal();
            }
            set
            {
                PurchaseGRNDTO.ReceivedQuantityPerItem = value;
            }
        }
        public decimal RemainingQuantity
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.RemainingQuantity > 0) ? PurchaseGRNDTO.RemainingQuantity : new decimal();
            }
            set
            {
                PurchaseGRNDTO.RemainingQuantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.Rate > 0) ? PurchaseGRNDTO.Rate : new decimal();
            }
            set
            {
                PurchaseGRNDTO.Rate = value;
            }
        }
        public int ReceivingLocationID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.ReceivingLocationID > 0) ? PurchaseGRNDTO.ReceivingLocationID : new int();
            }
            set
            {
                PurchaseGRNDTO.ReceivingLocationID = value;
            }
        }
        public int StorageLocationID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.StorageLocationID > 0) ? PurchaseGRNDTO.StorageLocationID : new int();
            }
            set
            {
                PurchaseGRNDTO.StorageLocationID = value;
            }
        }
        public string ReceivingLocationName
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.ReceivingLocationName : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.ReceivingLocationName = value;
            }
        }
        public string StorageLocationName
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.StorageLocationName : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.StorageLocationName = value;
            }
        }
        public string ItemName
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.ItemName : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.ItemName = value;
            }
        }
      
        public string XMLstring
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.XMLstring : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.XMLstring = value;
            }
        }
       
        public string Remark
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.Remark : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.Remark = value;
            }
        }
       
        public int BatchID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.BatchID > 0) ? PurchaseGRNDTO.BatchID : new int();
            }
            set
            {
                PurchaseGRNDTO.BatchID = value;
            }
        }
        public decimal BatchQuantity
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.BatchQuantity > 0) ? PurchaseGRNDTO.BatchQuantity : new decimal();
            }
            set
            {
                PurchaseGRNDTO.BatchQuantity = value;
            }
        }
        public string BatchNumber
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.BatchNumber : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.BatchNumber = value;
            }
        }
        public string ExpiryDate
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.ExpiryDate : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.ExpiryDate = value;
            }
        }
        
        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                PurchaseGRNDTO.SerialAndBatchManagedBy = value;
            }
        }

        public bool GRNIsLockedStatusFlag
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.GRNIsLockedStatusFlag : false;
            }
            set
            {
                PurchaseGRNDTO.GRNIsLockedStatusFlag = value;
            }
        }
    
        public decimal TotalTaxAmount
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.TotalTaxAmount > 0) ? PurchaseGRNDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                PurchaseGRNDTO.TotalTaxAmount = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.Discount > 0) ? PurchaseGRNDTO.Discount : new decimal();
            }
            set
            {
                PurchaseGRNDTO.Discount = value;
            }
        }
        public decimal Freight
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.Freight > 0) ? PurchaseGRNDTO.Freight : new decimal();
            }
            set
            {
                PurchaseGRNDTO.Freight = value;
            }
        }
        public decimal ShippingHandling
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.ShippingHandling > 0) ? PurchaseGRNDTO.ShippingHandling : new decimal();
            }
            set
            {
                PurchaseGRNDTO.ShippingHandling = value;
            }
        }
       
        public string ShelfLife
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.ShelfLife : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.ShelfLife = value;
            }
        }
       
        public string RemainingShelfLife
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.RemainingShelfLife : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.RemainingShelfLife = value;
            }
        }
        public int VendorID
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.VendorID > 0) ? PurchaseGRNDTO.VendorID : new int();
            }
            set
            {
                PurchaseGRNDTO.VendorID = value;
            }
        }
        public bool ReturnGoods
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.ReturnGoods : false;
            }
            set
            {
                PurchaseGRNDTO.ReturnGoods = value;
            }
        }
        public string VendorName
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.VendorName : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.VendorName = value;
            }
        }
        public string SearchWord
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.SearchWord : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.SearchWord = value;
            }
        }
        public int VendorNumber
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.VendorNumber > 0) ? PurchaseGRNDTO.VendorID : new int();
            }
            set
            {
                PurchaseGRNDTO.VendorNumber = value;
            }
        }
        public byte POStatus
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.POStatus : new byte();
            }
            set
            {
                PurchaseGRNDTO.POStatus = value;
            }
        }
        public string PurchaseBillID
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.PurchaseBillID : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.PurchaseBillID = value;
            }
        }
        public string SaleDate
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.SaleDate : string.Empty;
            }
            set
            {
                PurchaseGRNDTO.SaleDate = value;
            }
        }
        public decimal SoldQuantity
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.SoldQuantity > 0) ? PurchaseGRNDTO.SoldQuantity : new decimal();
            }
            set
            {
                PurchaseGRNDTO.SoldQuantity = value;
            }
        }
        public bool IsBatchSold
        {
            get
            {
                return (PurchaseGRNDTO != null) ? PurchaseGRNDTO.IsBatchSold : false;
            }
            set
            {
                PurchaseGRNDTO.IsBatchSold = value;
            }
        }
        public int StartRow
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.StartRow > 0) ? PurchaseGRNDTO.StartRow : new int();
            }
            set
            {
                PurchaseGRNDTO.StartRow = value;
            }
        }
        public int EndRow
        {
            get
            {
                return (PurchaseGRNDTO != null && PurchaseGRNDTO.EndRow > 0) ? PurchaseGRNDTO.EndRow : new int();
            }
            set
            {
                PurchaseGRNDTO.EndRow = value;
            }
        }
    }
}
