using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class PhysicalInventoryViewModel : IPhysicalInventoryViewModel
    {
        public PhysicalInventoryViewModel()
        {
            PhysicalInventoryDTO = new PhysicalInventory();
        }
        public PhysicalInventory PhysicalInventoryDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.ID > 0) ? PhysicalInventoryDTO.ID : new int();
            }
            set
            {
                PhysicalInventoryDTO.ID = value;
            }
        }

        public string TransactionDate
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.TransactionDate != string.Empty) ? PhysicalInventoryDTO.TransactionDate : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.TransactionDate = value;
            }
        }

        public int InventoryPhysicalStockAdjustmentID
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.InventoryPhysicalStockAdjustmentID > 0) ? PhysicalInventoryDTO.InventoryPhysicalStockAdjustmentID : new int();
            }
            set
            {
                PhysicalInventoryDTO.InventoryPhysicalStockAdjustmentID = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.ItemNumber > 0) ? PhysicalInventoryDTO.ItemNumber : new int();
            }
            set
            {
                PhysicalInventoryDTO.ItemNumber = value;
            }
        }
        public string ItemBarCode
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.ItemBarCode != string.Empty) ? PhysicalInventoryDTO.ItemBarCode : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.ItemBarCode = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.Rate > 0) ? PhysicalInventoryDTO.Rate : new decimal();
            }
            set
            {
                PhysicalInventoryDTO.Rate = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.Quantity > 0) ? PhysicalInventoryDTO.Quantity : new decimal();
            }
            set
            {
                PhysicalInventoryDTO.Quantity = value;
            }
        }
        public short Action
        {
            get
            {
                return (PhysicalInventoryDTO != null) ? PhysicalInventoryDTO.Action : new short();
            }
            set
            {
                PhysicalInventoryDTO.Action = value;
            }
        }
        public short ActionStatus
        {
            get
            {
                return (PhysicalInventoryDTO != null) ? PhysicalInventoryDTO.ActionStatus : new short();
            }
            set
            {
                PhysicalInventoryDTO.ActionStatus = value;
            }
        }

        public int FromLocation
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.FromLocation > 0) ? PhysicalInventoryDTO.FromLocation : new int();
            }
            set
            {
                PhysicalInventoryDTO.FromLocation = value;
            }
        }

        public Int16 GeneralUnitsID
        {
            get
            {
                return (PhysicalInventoryDTO != null ) ? PhysicalInventoryDTO.GeneralUnitsID : new Int16();
            }
            set
            {
                PhysicalInventoryDTO.GeneralUnitsID = value;
            }
        }

        public decimal CurrentStockQty
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.CurrentStockQty > 0) ? PhysicalInventoryDTO.CurrentStockQty : new decimal();
            }
            set
            {
                PhysicalInventoryDTO.CurrentStockQty = value;
            }
        }

        public string SaleUOM
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.SaleUOM != string.Empty) ? PhysicalInventoryDTO.SaleUOM : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.SaleUOM = value;
            }
        }
        public string BaseUOM
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.BaseUOM != string.Empty) ? PhysicalInventoryDTO.BaseUOM : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.BaseUOM = value;
            }
        }
        public string PhysicalInventoryStockDetails
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.PhysicalInventoryStockDetails != string.Empty) ? PhysicalInventoryDTO.PhysicalInventoryStockDetails : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.PhysicalInventoryStockDetails = value;
            }
        }
        public string PhysicalInventoryVoucherXml
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.PhysicalInventoryVoucherXml != string.Empty) ? PhysicalInventoryDTO.PhysicalInventoryVoucherXml : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.PhysicalInventoryVoucherXml = value;
            }
        }
        public decimal ConversionFactor
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.ConversionFactor > 0) ? PhysicalInventoryDTO.ConversionFactor : new decimal();
            }
            set
            {
                PhysicalInventoryDTO.ConversionFactor = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.CreatedBy != string.Empty) ? PhysicalInventoryDTO.CreatedBy : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.CreatedBy = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.ItemDescription != string.Empty) ? PhysicalInventoryDTO.ItemDescription : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.ItemDescription = value;
            }
        }
        public string CreatedDate
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.CreatedDate != string.Empty) ? PhysicalInventoryDTO.CreatedDate : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.CreatedDate = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.ModifiedBy != string.Empty) ? PhysicalInventoryDTO.ModifiedBy : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.ModifiedBy = value;
            }
        }

        public string ModifiedDate
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.ModifiedDate != string.Empty) ? PhysicalInventoryDTO.ModifiedDate : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.ModifiedDate = value;
            }
        }

        public string DeletedBy
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.DeletedBy != string.Empty) ? PhysicalInventoryDTO.DeletedBy : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.DeletedBy = value;
            }
        }

        public string DeletedDate
        {
            get
            {
                return (PhysicalInventoryDTO != null && PhysicalInventoryDTO.DeletedDate != string.Empty) ? PhysicalInventoryDTO.DeletedDate : string.Empty;
            }
            set
            {
                PhysicalInventoryDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (PhysicalInventoryDTO != null ? PhysicalInventoryDTO.IsDeleted : new bool());
            }
            set
            {
                PhysicalInventoryDTO.IsDeleted = value;
            }
        }

       


    }
   
}
