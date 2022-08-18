using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class RegisterPOSAPIViewModel : IRegisterPOSAPIViewModel
    {
        public RegisterPOSAPIViewModel()
        {
            RegisterPOSAPIDTO = new RegisterPOSAPI();
        }

        public RegisterPOSAPI RegisterPOSAPIDTO
        {
            get;
            set;
        }

        public int POSMasterID
        {
            get
            {
                return (RegisterPOSAPIDTO != null && RegisterPOSAPIDTO.POSMasterID > 0) ? RegisterPOSAPIDTO.POSMasterID : new int();
            }
            set
            {
                RegisterPOSAPIDTO.POSMasterID = value;
            }
        }

        public int UserID
        {
            get
            {
                return (RegisterPOSAPIDTO != null) ? RegisterPOSAPIDTO.UserID : new int();
            }
            set
            {
                RegisterPOSAPIDTO.UserID = value;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return RegisterPOSAPIDTO.ErrorMessage;
            }
            set
            {
                RegisterPOSAPIDTO.ErrorMessage = value;
            }
        }

        public string TimeZone
        {
            get
            {
                return RegisterPOSAPIDTO.TimeZone;
            }
            set
            {
                RegisterPOSAPIDTO.TimeZone = value;
            }
        }
        public int CounterMstID
        {
            get
            {
                return (RegisterPOSAPIDTO != null) ? RegisterPOSAPIDTO.CounterMstID : new int();
            }
            set
            {
                RegisterPOSAPIDTO.CounterMstID = value;
            }
        }

        public string DeviceToken
        {
            get
            {
                return RegisterPOSAPIDTO.DeviceToken;
            }
            set
            {
                RegisterPOSAPIDTO.DeviceToken = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (RegisterPOSAPIDTO != null) ? RegisterPOSAPIDTO.CreatedBy : new int();
            }
            set
            {
                RegisterPOSAPIDTO.CreatedBy = value;
            }
        }
        public int Status
        {
            get
            {
                return (RegisterPOSAPIDTO != null) ? RegisterPOSAPIDTO.Status : new int();
            }
            set
            {
                RegisterPOSAPIDTO.Status = value;
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
                return (RegisterPOSAPIDTO != null) ? RegisterPOSAPIDTO.GeneralUnitsID : new int();
            }
            set
            {
                RegisterPOSAPIDTO.GeneralUnitsID = value;
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
