using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class RestaurantTableOrderViewModel : IRestaurantTableOrderViewModel
    {
        public RestaurantTableOrderViewModel()
        {
            RestaurantTableOrderDTO = new RestaurantTableOrder();
        }
        public RestaurantTableOrder RestaurantTableOrderDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.ID > 0) ? RestaurantTableOrderDTO.ID : new int();
            }
            set
            {
                RestaurantTableOrderDTO.ID = value;
            }
        }

        public string TransacationDate
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.TransacationDate != string.Empty) ? RestaurantTableOrderDTO.TransacationDate : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.TransacationDate = value;
            }
        }

        public string TransactionUpToDate
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.TransactionUpToDate != string.Empty) ? RestaurantTableOrderDTO.TransactionUpToDate : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.TransactionUpToDate = value;
            }
        }

        public string TableNumber
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.TableNumber != string.Empty) ? RestaurantTableOrderDTO.TableNumber : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.TableNumber = value;
            }
        }

        public string TableVariant
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.TableVariant != string.Empty) ? RestaurantTableOrderDTO.TableVariant : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.TableVariant = value;
            }
        }

        public string TotalMembers
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.TotalMembers != string.Empty) ? RestaurantTableOrderDTO.TotalMembers : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.TotalMembers = value;
            }
        }

        public int OrderByID
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.OrderByID > 0) ? RestaurantTableOrderDTO.OrderByID : new int();
            }
            set
            {
                RestaurantTableOrderDTO.OrderByID = value;
            }
        }

        public string OrderStatus
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.OrderStatus != string.Empty) ? RestaurantTableOrderDTO.OrderStatus : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.OrderStatus = value;
            }
        }

        public string KOTStatus
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.KOTStatus != string.Empty) ? RestaurantTableOrderDTO.KOTStatus : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.KOTStatus = value;
            }
        }

        public int BillPaidStatus
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.BillPaidStatus > 0) ? RestaurantTableOrderDTO.BillPaidStatus : new int();
            }
            set
            {
                RestaurantTableOrderDTO.BillPaidStatus = value;
            }
        }

        public decimal TotalBillAmt
        {
            get
            {
                return (RestaurantTableOrderDTO != null) ? RestaurantTableOrderDTO.TotalBillAmt :new decimal();
            }
            set
            {
                RestaurantTableOrderDTO.TotalBillAmt = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.CentreCode != string.Empty) ? RestaurantTableOrderDTO.CentreCode : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.CentreCode = value;
            }
        }

        public int GeneralUnitsId
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.GeneralUnitsId > 0) ? RestaurantTableOrderDTO.GeneralUnitsId : new int();
            }
            set
            {
                RestaurantTableOrderDTO.GeneralUnitsId = value;
            }
        }
        public short IsRelatedWithCafe
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.IsRelatedWithCafe > 0) ? RestaurantTableOrderDTO.IsRelatedWithCafe : new short();
            }
            set
            {
                RestaurantTableOrderDTO.IsRelatedWithCafe = value;
            }
        }
        public string PaidBillNumber
        {
            get
            {
                return (RestaurantTableOrderDTO != null) ? RestaurantTableOrderDTO.PaidBillNumber : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.PaidBillNumber = value;
            }
        }

        public int RestaurantTableOrdersID
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.RestaurantTableOrdersID > 0) ? RestaurantTableOrderDTO.RestaurantTableOrdersID : new int();
            }
            set
            {
                RestaurantTableOrderDTO.RestaurantTableOrdersID = value;
            }
        }

        public string OrderDateTime
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.OrderDateTime != string.Empty) ? RestaurantTableOrderDTO.OrderDateTime : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.OrderDateTime = value;
            }
        }

        public string ExpectedTimeGivenForOrder
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.ExpectedTimeGivenForOrder != string.Empty) ? RestaurantTableOrderDTO.ExpectedTimeGivenForOrder : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.ExpectedTimeGivenForOrder = value;
            }
        }

        public string KOTNumbe
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.KOTNumbe != string.Empty) ? RestaurantTableOrderDTO.KOTNumbe : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.KOTNumbe = value;
            }
        }

        public string OrderReceiveDateTime
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.OrderReceiveDateTime != string.Empty) ? RestaurantTableOrderDTO.OrderReceiveDateTime : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.OrderReceiveDateTime = value;
            }
        }

        public bool IsOrderPostedInBill
        {
            get
            {
                return (RestaurantTableOrderDTO != null ? RestaurantTableOrderDTO.IsOrderPostedInBill : new bool());
            }
            set
            {
                RestaurantTableOrderDTO.IsOrderPostedInBill = value;
            }
        }

        public int RestaurantTableOrdersDetailID
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.RestaurantTableOrdersDetailID > 0) ? RestaurantTableOrderDTO.RestaurantTableOrdersDetailID : new int();
            }
            set
            {
                RestaurantTableOrderDTO.RestaurantTableOrdersDetailID = value;
            }
        }


        public int ItemID
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.ItemID > 0) ? RestaurantTableOrderDTO.ItemID : new int();
            }
            set
            {
                RestaurantTableOrderDTO.ItemID = value;
            }
        }

        public string Qty
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.Qty != string.Empty) ? RestaurantTableOrderDTO.Qty : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.Qty = value;
            }
        }

        public string OrderXML
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.OrderXML != string.Empty) ? RestaurantTableOrderDTO.OrderXML : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.OrderXML = value;
            }
        }
        public int GeneralItemMasterID
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.GeneralItemMasterID > 0) ? RestaurantTableOrderDTO.GeneralItemMasterID : new int();
            }
            set
            {
                RestaurantTableOrderDTO.GeneralItemMasterID = value;
            }
        }

        public string UomCode
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.UomCode != string.Empty) ? RestaurantTableOrderDTO.UomCode : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.UomCode = value;
            }
        }

        public string IsBOMRelevant
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.IsBOMRelevant != string.Empty) ? RestaurantTableOrderDTO.IsBOMRelevant : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.IsBOMRelevant = value;
            }
        }

        public int InventoryVariationMasterID
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.InventoryVariationMasterID > 0) ? RestaurantTableOrderDTO.InventoryVariationMasterID : new int();
            }
            set
            {
                RestaurantTableOrderDTO.InventoryVariationMasterID = value;
            }
        }

        public int Price
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.Price > 0) ? RestaurantTableOrderDTO.Price : new int();
            }
            set
            {
                RestaurantTableOrderDTO.Price = value;
            }
        }

        public int InventoryLocationMasterID
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.InventoryLocationMasterID > 0) ? RestaurantTableOrderDTO.InventoryLocationMasterID : new int();
            }
            set
            {
                RestaurantTableOrderDTO.InventoryLocationMasterID = value;
            }
        }
        public string MenuName
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.MenuName != string.Empty) ? RestaurantTableOrderDTO.MenuName : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.MenuName = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.CreatedBy != string.Empty) ? RestaurantTableOrderDTO.CreatedBy : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.CreatedBy = value;
            }
        }

        public string CreatedDate
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.CreatedDate != string.Empty) ? RestaurantTableOrderDTO.CreatedDate : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.CreatedDate = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.ModifiedBy != string.Empty) ? RestaurantTableOrderDTO.ModifiedBy : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.ModifiedBy = value;
            }
        }

        public string ModifiedDate
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.ModifiedDate != string.Empty) ? RestaurantTableOrderDTO.ModifiedDate : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.ModifiedDate = value;
            }
        }

        public string DeletedBy
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.DeletedBy != string.Empty) ? RestaurantTableOrderDTO.DeletedBy : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.DeletedBy = value;
            }
        }

        public string DeletedDate
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.DeletedDate != string.Empty) ? RestaurantTableOrderDTO.DeletedDate : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (RestaurantTableOrderDTO != null ? RestaurantTableOrderDTO.IsDeleted : new bool());
            }
            set
            {
                RestaurantTableOrderDTO.IsDeleted = value;
            }
        }

        public short IsOrderServed
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.IsOrderServed > 0) ? RestaurantTableOrderDTO.IsOrderServed : new short();
            }
            set
            {
                RestaurantTableOrderDTO.IsOrderServed = value;
            }
        }

        public string PaymentReferenceCode
        {
            get
            {
                return (RestaurantTableOrderDTO != null && RestaurantTableOrderDTO.PaymentReferenceCode != string.Empty) ? RestaurantTableOrderDTO.PaymentReferenceCode : string.Empty;
            }
            set
            {
                RestaurantTableOrderDTO.PaymentReferenceCode = value;
            }
        }
        public bool IsTakeAway
        {
            get
            {
                return (RestaurantTableOrderDTO != null ? RestaurantTableOrderDTO.IsTakeAway : new bool());
            }
            set
            {
                RestaurantTableOrderDTO.IsTakeAway = value;
            }
        }
        
    }
}
