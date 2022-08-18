using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class APIInventoryViewModel : IAPIInventoryViewModel
    {
        public APIInventoryViewModel()
        {
            APIInventoryDTO = new APIInventory();
        }

        public APIInventory APIInventoryDTO
        {
            get;
            set;
        }

        public int POSMasterID
        {
            get
            {
                return (APIInventoryDTO != null && APIInventoryDTO.POSMasterID > 0) ? APIInventoryDTO.POSMasterID : new int();
            }
            set
            {
                APIInventoryDTO.POSMasterID = value;
            }
        }
        public int InventoryLocationMasterID
        {
            get
            {
                return (APIInventoryDTO != null && APIInventoryDTO.InventoryLocationMasterID > 0) ? APIInventoryDTO.InventoryLocationMasterID : new int();
            }
            set
            {
                APIInventoryDTO.InventoryLocationMasterID = value;
            }
        }

        public int UserID
        {
            get
            {
                return (APIInventoryDTO != null) ? APIInventoryDTO.UserID : new int();
            }
            set
            {
                APIInventoryDTO.UserID = value;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return APIInventoryDTO.ErrorMessage;
            }
            set
            {
                APIInventoryDTO.ErrorMessage = value;
            }
        }

        public string TimeZone
        {
            get
            {
                return APIInventoryDTO.TimeZone;
            }
            set
            {
                APIInventoryDTO.TimeZone = value;
            }
        }
        public int CounterMstID
        {
            get
            {
                return (APIInventoryDTO != null) ? APIInventoryDTO.CounterMstID : new int();
            }
            set
            {
                APIInventoryDTO.CounterMstID = value;
            }
        }
    
        public string DeviceToken
        {
            get
            {
                return APIInventoryDTO.DeviceToken;
            }
            set
            {
                APIInventoryDTO.DeviceToken = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (APIInventoryDTO != null) ? APIInventoryDTO.CreatedBy : new int();
            }
            set
            {
                APIInventoryDTO.CreatedBy = value;
            }
        }
        public int Status
        {
            get
            {
                return (APIInventoryDTO != null) ? APIInventoryDTO.Status : new int();
            }
            set
            {
                APIInventoryDTO.Status = value;
            }
        }
        public bool IsRestaurant
        {
            get
            {
                return (APIInventoryDTO != null) ? APIInventoryDTO.IsRestaurant : false;
            }
            set
            {
                APIInventoryDTO.IsRestaurant = value;
            }
        }

        public string InvSaleMasterXML
        {
            get;
            set;
        }
        public string InvSaleTransactionXML
        {
            get;
            set;
        }
        public string InvSaleVoucherXML
        {
            get;
            set;
        }
        public int StorageLocationID
        {
            get;
            set;
        }
        public string LastSyncDate
        {
            get;
            set;
        }
        public string KeyField
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get
            {
                return (APIInventoryDTO != null) ? APIInventoryDTO.GeneralUnitsID : new int();
            }
            set
            {
                APIInventoryDTO.GeneralUnitsID = value;
            }
        }

        public string InvSaleReturnMasterXML
        {
            get;
            set;
        }

        public string InvSaleReturnTransactionXML
        {
            get;
            set;
        }
        public string InvSaleReturnVoucherXML
        {
            get;
            set;
        }
    }
}
