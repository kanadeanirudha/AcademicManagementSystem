using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class RestaurantKOTOrderDetailsViewModel : IRestaurantKOTOrderDetailsViewModel
    {
        public RestaurantKOTOrderDetailsViewModel()
        {
            RestaurantKOTOrderDetailsDTO = new RestaurantKOTOrderDetails();
        }
        public RestaurantKOTOrderDetails RestaurantKOTOrderDetailsDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.ID > 0) ? RestaurantKOTOrderDetailsDTO.ID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.ID = value;
            }
        }

        public string TransactionDate
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.TransactionDate != string.Empty) ? RestaurantKOTOrderDetailsDTO.TransactionDate : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.TransactionDate = value;
            }
        }
        public string RestaurantKOTOrderDetailTransactionDate
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailTransactionDate != string.Empty) ? RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailTransactionDate : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailTransactionDate = value;
            }
        }
        public string ExpectedTimeForDelevery
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.ExpectedTimeForDelevery != string.Empty) ? RestaurantKOTOrderDetailsDTO.ExpectedTimeForDelevery : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.ExpectedTimeForDelevery = value;
            }
        }
        public int RestaurantKOTOrderID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderID > 0) ? RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderID = value;
            }
        }
        public int RestaurantTableOrdersID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.RestaurantTableOrdersID > 0) ? RestaurantKOTOrderDetailsDTO.RestaurantTableOrdersID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.RestaurantTableOrdersID = value;
            }
        }
        public int RestaurantKOTOrderDetailID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailID > 0) ? RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailID = value;
            }
        }
        public int RestaurantKOTOrderDetailRestaurantKOTOrderID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailRestaurantKOTOrderID > 0) ? RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailRestaurantKOTOrderID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailRestaurantKOTOrderID = value;
            }
        }
        public int RestaurantKOTOrderDetailJobStatus
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailJobStatus > 0) ? RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailJobStatus : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.RestaurantKOTOrderDetailJobStatus = value;
            }
        }
        public int JobStatus
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.JobStatus > 0) ? RestaurantKOTOrderDetailsDTO.JobStatus : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.JobStatus = value;
            }
        }

        public int CookById
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.CookById > 0) ? RestaurantKOTOrderDetailsDTO.CookById : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.CookById = value;
            }
        }
        public decimal Qty
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.Qty > 0) ? RestaurantKOTOrderDetailsDTO.Qty : new decimal();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.Qty = value;
            }
        }
        public string Remark
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.Remark != string.Empty) ? RestaurantKOTOrderDetailsDTO.Remark : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.Remark = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.CentreCode != string.Empty) ? RestaurantKOTOrderDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.CentreCode = value;
            }
        }
        public int GeneralUnitsId
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.GeneralUnitsId > 0) ? RestaurantKOTOrderDetailsDTO.GeneralUnitsId : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.GeneralUnitsId = value;
            }
        }
        public int GeneralItemMasterID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.GeneralItemMasterID > 0) ? RestaurantKOTOrderDetailsDTO.GeneralItemMasterID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.GeneralItemMasterID = value;
            }
        }
        public string UomCode
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.UomCode != string.Empty) ? RestaurantKOTOrderDetailsDTO.UomCode : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.UomCode = value;
            }
        }
        public int IsBOMRelevant
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.IsBOMRelevant > 0) ? RestaurantKOTOrderDetailsDTO.IsBOMRelevant : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.IsBOMRelevant = value;
            }
        }
        public string TableNumber
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.TableNumber != string.Empty) ? RestaurantKOTOrderDetailsDTO.TableNumber : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.TableNumber = value;
            }
        }
        public string KOTOrderXML
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.KOTOrderXML != string.Empty) ? RestaurantKOTOrderDetailsDTO.KOTOrderXML : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.KOTOrderXML = value;
            }
        }
        public short IsRelatedWithCafe
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.IsRelatedWithCafe > 0) ? RestaurantKOTOrderDetailsDTO.IsRelatedWithCafe : new short();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.IsRelatedWithCafe = value;
            }
        }

        public int InventoryVariationMasterID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.InventoryVariationMasterID > 0) ? RestaurantKOTOrderDetailsDTO.InventoryVariationMasterID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.InventoryVariationMasterID = value;
            }
        }

        public decimal Price
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.Price > 0) ? RestaurantKOTOrderDetailsDTO.Price : new decimal();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.Price = value;
            }
        }
        public short ResponseFlag
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.ResponseFlag > 0) ? RestaurantKOTOrderDetailsDTO.ResponseFlag : new short();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.ResponseFlag = value;
            }
        }
        
        public int InventoryLocationMasterID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.InventoryLocationMasterID > 0) ? RestaurantKOTOrderDetailsDTO.InventoryLocationMasterID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.InventoryLocationMasterID = value;
            }
        }
        public string MenuName
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.MenuName != string.Empty) ? RestaurantKOTOrderDetailsDTO.MenuName : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.MenuName = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.CreatedBy != string.Empty) ? RestaurantKOTOrderDetailsDTO.CreatedBy : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.CreatedBy = value;
            }
        }

        public string CreatedDate
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.CreatedDate != string.Empty) ? RestaurantKOTOrderDetailsDTO.CreatedDate : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.CreatedDate = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.ModifiedBy != string.Empty) ? RestaurantKOTOrderDetailsDTO.ModifiedBy : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.ModifiedBy = value;
            }
        }

        public string ModifiedDate
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.ModifiedDate != string.Empty) ? RestaurantKOTOrderDetailsDTO.ModifiedDate : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.ModifiedDate = value;
            }
        }

        public string DeletedBy
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.DeletedBy != string.Empty) ? RestaurantKOTOrderDetailsDTO.DeletedBy : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.DeletedBy = value;
            }
        }

        public string DeletedDate
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.DeletedDate != string.Empty) ? RestaurantKOTOrderDetailsDTO.DeletedDate : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null ? RestaurantKOTOrderDetailsDTO.IsDeleted : new bool());
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.IsDeleted = value;
            }
        }

        public bool IsTakeAway
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null ? RestaurantKOTOrderDetailsDTO.IsTakeAway : new bool());
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.IsTakeAway = value;
            }
        }
        public string ComplitedDateTime
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null) ? RestaurantKOTOrderDetailsDTO.ComplitedDateTime : String.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.ComplitedDateTime = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.FromDate != string.Empty) ? RestaurantKOTOrderDetailsDTO.FromDate : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.UptoDate != string.Empty) ? RestaurantKOTOrderDetailsDTO.UptoDate : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.UptoDate = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null ? RestaurantKOTOrderDetailsDTO.StatusFlag : new bool());
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.StatusFlag = value;
            }
        }
        public string LocalInvoiceNumber
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.LocalInvoiceNumber != string.Empty) ? RestaurantKOTOrderDetailsDTO.LocalInvoiceNumber : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.LocalInvoiceNumber = value;
            }
        }
        public int SaleMasterID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.SaleMasterID > 0) ? RestaurantKOTOrderDetailsDTO.SaleMasterID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.SaleMasterID = value;
            }
        }
        public int RestaurantBillOrderdetailsID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.RestaurantBillOrderdetailsID > 0) ? RestaurantKOTOrderDetailsDTO.RestaurantBillOrderdetailsID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.RestaurantBillOrderdetailsID = value;
            }
        }
        public string ItemName
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.ItemName != string.Empty) ? RestaurantKOTOrderDetailsDTO.ItemName : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.ItemName = value;
            }
        }
        public string ItemNumber
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.ItemNumber != string.Empty) ? RestaurantKOTOrderDetailsDTO.ItemNumber : string.Empty;
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.ItemNumber = value;
            }
        }
        public bool IsRestaurant
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null ? RestaurantKOTOrderDetailsDTO.IsRestaurant : new bool());
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.IsRestaurant = value;
            }
        }
        public int SalePromotionActivityDetailsID
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.SalePromotionActivityDetailsID > 0) ? RestaurantKOTOrderDetailsDTO.SalePromotionActivityDetailsID : new int();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.SalePromotionActivityDetailsID = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (RestaurantKOTOrderDetailsDTO != null && RestaurantKOTOrderDetailsDTO.Quantity > 0) ? RestaurantKOTOrderDetailsDTO.Quantity : new decimal();
            }
            set
            {
                RestaurantKOTOrderDetailsDTO.Quantity = value;
            }
        }
    }
    public class KotDetails
    {
        public KotDetails()
        {
            KotDetailsList = new List<RestaurantKOTOrderDetails>();
        }
        public int KotOrderID { get; set; }
        public string TableNumber { get; set; }
        public int RestaurantTableOrdersID { get; set; }
        public string LocalInvoiceNumber { get; set; }
        public List<RestaurantKOTOrderDetails> KotDetailsList { get; set; }
    }
}
