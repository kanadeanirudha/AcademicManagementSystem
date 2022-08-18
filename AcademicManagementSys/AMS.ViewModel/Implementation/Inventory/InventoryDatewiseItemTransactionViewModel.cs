using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryDatewiseItemTransactionViewModel : IInventoryDatewiseItemTransactionViewModel
    {
        public InventoryDatewiseItemTransactionViewModel()
        {
            InventoryDatewiseItemTransactionDTO = new InventoryDatewiseItemTransaction();
            ListGetCategoryCode = new List<InventoryItemCategoryMaster>();
          
        }
        public InventoryDatewiseItemTransaction InventoryDatewiseItemTransactionDTO { get; set; }

        public Int64 ID
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null && InventoryDatewiseItemTransactionDTO.ID > 0) ? InventoryDatewiseItemTransactionDTO.ID : new Int64();
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.ID = value;
            }
        }
        public int ItemID
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null && InventoryDatewiseItemTransactionDTO.ItemID > 0) ? InventoryDatewiseItemTransactionDTO.ItemID : new short();
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.ItemID = value;
            }
        }
        public string ItemName
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null) ? InventoryDatewiseItemTransactionDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.ItemName = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null && InventoryDatewiseItemTransactionDTO.Quantity > 0) ? InventoryDatewiseItemTransactionDTO.Quantity : new decimal();
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.Quantity = value;
            }
        }
        public decimal PurchaseRate
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null && InventoryDatewiseItemTransactionDTO.PurchaseRate > 0) ? InventoryDatewiseItemTransactionDTO.PurchaseRate : new decimal();
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.PurchaseRate = value;
            }
        }
        public decimal RetailRate
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null && InventoryDatewiseItemTransactionDTO.RetailRate > 0) ? InventoryDatewiseItemTransactionDTO.RetailRate : new decimal();
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.RetailRate = value;
            }
        }
        public DateTime TransactionDate
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null) ? InventoryDatewiseItemTransactionDTO.TransactionDate : DateTime.Now;
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.TransactionDate = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null) ? InventoryDatewiseItemTransactionDTO.IsActive : false;
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.IsActive = value;
            }
        }
        public string CategoryDescription
        {
            get;
            set;
        }
        public string CategoryCode
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetCategoryCodeItems
        {
            get
            {
                return new SelectList(ListGetCategoryCode, "CategoryCode", "CategoryDescription");
            }
        }
        public List<InventoryItemCategoryMaster> ListGetCategoryCode
        {
            get;
            set;
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
                return (InventoryDatewiseItemTransactionDTO != null && InventoryDatewiseItemTransactionDTO.CreatedBy > 0) ? InventoryDatewiseItemTransactionDTO.CreatedBy : new short();
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null) ? InventoryDatewiseItemTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null && InventoryDatewiseItemTransactionDTO.ModifiedBy > 0) ? InventoryDatewiseItemTransactionDTO.ModifiedBy : new short();
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null) ? InventoryDatewiseItemTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null && InventoryDatewiseItemTransactionDTO.DeletedBy > 0) ? InventoryDatewiseItemTransactionDTO.DeletedBy : new short();
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null) ? InventoryDatewiseItemTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string SelectedXml
        {
            get
            {
                return (InventoryDatewiseItemTransactionDTO != null) ? InventoryDatewiseItemTransactionDTO.SelectedXml : string.Empty;
            }
            set
            {
                InventoryDatewiseItemTransactionDTO.SelectedXml = value;
            }
        }
    }
}
